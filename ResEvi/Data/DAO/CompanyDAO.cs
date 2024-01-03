using System.Threading.Tasks;
using ResEvi.Contracts;
using ResEvi.Data.Entities;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ResEvi.Exceptions;

namespace ResEvi.Data.DAO 
{
    internal sealed class CompanyDAO : IDAO<Company>
    {
        private readonly AppDbContext _context;
        public CompanyDAO(AppDbContext context)
        {
            _context = context;
        }

        public async void Delete(long id)
        {
            if (id < 0)
            {
                throw new Exception("Invalid ID: " + id);
            }
            var company = await _context.Advisors.FindAsync(id) ?? throw new EntityNotFoundException("Company not found");
            _context.Advisors.Remove(company);
            await _context.SaveChangesAsync();

        }

        public async Task<Advisor> Get(long id)
        {
            return await _context.Advisors.FindAsync(id) ?? throw new EntityNotFoundException("Company not found");
        }

        public async Task<List<Company>> Get()
        {
            var companies = await _context.Companies.ToListAsync();
            return companies;
        }

        public async Task<Company> Save(Company entity)
        {
            var newEntity = _context.Companies.Add(entity);
            await _context.SaveChangesAsync();
            return newEntity.Entity;
        }

        public async Task<Company> Update(Company entity)
        {
            if (entity.Id < 0)
            {
                throw new Exception("Invalid ID in company: " + entity.ToString());
            }
            var company = await _context.Companies.FindAsync(entity.Id) ?? throw new EntityNotFoundException("Company not found");
            _context.Entry(company).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return company;
        }

        Task<Company> IDAO<Company>.Get(long id)
        {
            throw new NotImplementedException();
        }
    }
}