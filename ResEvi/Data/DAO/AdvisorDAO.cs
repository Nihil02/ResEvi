using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResEvi.Contracts;
using ResEvi.Data.Entities;
using ResEvi.Exceptions;

[assembly: InternalsVisibleTo("Tests")]

namespace ResEvi.Data.DAO 
{
    internal sealed class AdvisorDAO : IDAO<Advisor>
    {
        private readonly AppDbContext _context;
        public AdvisorDAO(AppDbContext context)
        {
            _context = context;
        }

        public async void Delete(long id)
        {
            if (id < 0)
            {
                throw new Exception("Invalid ID: " + id);
            }
            var advisor = await _context.Advisors.FindAsync(id) ?? throw new EntityNotFoundException("Advisor not found");
            _context.Advisors.Remove(advisor);
            await _context.SaveChangesAsync();

        }

        public async Task<Advisor> Get(long id)
        {
            return await _context.Advisors.FindAsync(id) ?? throw new EntityNotFoundException("Advisor not found");
        }

        public async Task<List<Advisor>> Get()
        {
            var advisors = await _context.Advisors.ToListAsync();
            return advisors;
        }

        public async Task<Advisor> Save(Advisor entity)
        {
            var newEntity = _context.Advisors.Add(entity);
            await _context.SaveChangesAsync();
            return newEntity.Entity;
        }

        public async Task<Advisor> Update(Advisor entity)
        {
            if (entity.Id < 0)
            {
                throw new Exception("Invalid ID in advisor: " + entity.ToString());
            }
            var advisor = await _context.Advisors.FindAsync(entity.Id) ?? throw new EntityNotFoundException("Advisor not found");
            _context.Entry(advisor).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return advisor;
        }
    }
}