using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResEvi.Contracts;
using ResEvi.Data.Entities;
using ResEvi.Exceptions;

namespace ResEvi.Data.DAO
{
    internal sealed class RecordDAO : IDAO<Record>
    {
        private readonly AppDbContext _context;
        public RecordDAO(AppDbContext context)
        {
            _context = context;
        }

        public async void Delete(long id)
        {
            if (id < 0)
            {
                throw new Exception("Invalid ID: " + id);
            }
            var record = await _context.Records.FindAsync(id) ?? throw new EntityNotFoundException("Record not found");
            _context.Records.Remove(record);
            await _context.SaveChangesAsync();

        }

        public async Task<Record> Get(long id)
        {
            return await _context.Records.FindAsync(id) ?? throw new EntityNotFoundException("Record not found");
        }

        public async Task<List<Record>> Get()
        {
            var records = await _context.Records.ToListAsync();
            return records;
        }

        public async Task<Record> Save(Record entity)
        {
            var newEntity = _context.Records.Add(entity);
            await _context.SaveChangesAsync();
            return newEntity.Entity;
        }

        public async Task<Record> Update(Record entity)
        {
            if (entity.Id < 0)
            {
                throw new Exception("Invalid ID in record: " + entity.ToString());
            }
            var record = await _context.Records.FindAsync(entity.Id) ?? throw new EntityNotFoundException("Record not found");
            _context.Entry(record).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return record;
        }
    }
}