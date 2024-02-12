using Microsoft.EntityFrameworkCore;
using ResEvi.Contracts;
using ResEvi.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResEvi.Data.DAO
{
    internal abstract class AbstractDAO<T> : IDAO<T> where T : class, IEntity
    {
        private readonly AppDbContext _context;

        protected AbstractDAO(AppDbContext context)
        {
            _context = context;
        }

        protected string GetName()
        {
            return typeof(T).Name;
        }

        public async Task Delete(long id)
        {
            if (id < 0)
            {
                throw new Exception("Invalid ID: " + id);
            }

            var entity = await _context.Set<T>().FindAsync(id) ?? throw new EntityNotFoundException(GetName() + " not found");
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Get(long id)
        {
            return await _context.Set<T>().FindAsync(id) ?? throw new EntityNotFoundException(GetName() + " not found");
        }

        public async Task<List<T>> Get()
        {
            var entities = await _context.Set<T>().ToListAsync();
            return entities;
        }

        public async Task<T> Save(T entity)
        {
            var newEntity = _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return newEntity.Entity;
        }

        public async Task<T> Update(T entity)
        {
            if (entity.Id < 0)
            {
                throw new Exception("Invalid ID in " + GetName() +": " + entity.ToString());
            }

            var foundEntity = await _context.Set<T>().FindAsync(entity.Id) ?? throw new EntityNotFoundException(GetName() + " not found");
            _context.Entry(foundEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return foundEntity;
        }
    }
}
