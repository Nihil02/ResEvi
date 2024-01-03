using System.Threading.Tasks;
using ResEvi.Contracts;
using ResEvi.Data.Entities;
using System;
using ResEvi.Exceptions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ResEvi.Data.DAO
{
    internal sealed class ContactDAO : IDAO<Contact>
    {
        private readonly AppDbContext _context;
        public ContactDAO(AppDbContext context)
        {
            _context = context;
        }

        public async void Delete(long id)
        {
            if (id < 0)
            {
                throw new Exception("Invalid ID: " + id);
            }
            var contact = await _context.Contacts.FindAsync(id) ?? throw new EntityNotFoundException("Contact not found");
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

        }

        public async Task<Contact> Get(long id)
        {
            return await _context.Contacts.FindAsync(id) ?? throw new EntityNotFoundException("Contact not found");
        }

        public async Task<List<Contact>> Get()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return contacts;
        }

        public async Task<Contact> Save(Contact entity)
        {
            var newEntity = _context.Contacts.Add(entity);
            await _context.SaveChangesAsync();
            return newEntity.Entity;
        }

        public async Task<Contact> Update(Contact entity)
        {
            if (entity.Id < 0)
            {
                throw new Exception("Invalid ID in contactt: " + entity.ToString());
            }
            var contact = await _context.Contacts.FindAsync(entity.Id) ?? throw new EntityNotFoundException("Contact not found");
            _context.Entry(contact).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();
            return contact;
        }
    }
}