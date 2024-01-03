using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResEvi.Contracts;
using ResEvi.Data.Entities;
using ResEvi.Exceptions;

namespace ResEvi.Data.DAO
{
    internal sealed class ProjectDAO : IDAO<Project>
    {
        private readonly AppDbContext _context;
        public ProjectDAO(AppDbContext context)
        {
            _context = context;
        }

        public async void Delete(long id)
        {
            if (id < 0)
            {
                throw new Exception("Invalid ID: " + id);
            }
            var project = await _context.Projects.FindAsync(id) ?? throw new EntityNotFoundException("Project not found");
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();

        }

        public async Task<Project> Get(long id)
        {
            return await _context.Projects.FindAsync(id) ?? throw new EntityNotFoundException("Project not found");
        }

        public async Task<List<Project>> Get()
        {
            var projects = await _context.Projects.ToListAsync();
            return projects;
        }

        public async Task<Project> Save(Project entity)
        {
            var newEntity = _context.Projects.Add(entity);
            await _context.SaveChangesAsync();
            return newEntity.Entity;
        }

        public async Task<Project> Update(Project entity)
        {
            if (entity.Id < 0)
            {
                throw new Exception("Invalid ID in project: " + entity.ToString());
            }
            var project = await _context.Projects.FindAsync(entity.Id) ?? throw new EntityNotFoundException("Project not found");
            _context.Entry(project).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return project;
        }
    }
}