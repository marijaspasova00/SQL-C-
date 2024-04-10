using Microsoft.EntityFrameworkCore;
using SQLProcedureConvert.DataAccess.Interaces;
using SQLProcedureConvert.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLProcedureConvert.DataAccess.Implementations
{
    public class ContactRepository : IContactRepository
    {
        private readonly ProjectDBContext _dbContext;
        public ContactRepository(ProjectDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateAsync(Contact entity)
        {
            await _dbContext.Contacts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.ID;
        }

        public async Task DeleteAsync(int id)
        {
            Contact contactDb = await GetByIdAsync(id);

            if (contactDb != null)
            {
                _dbContext.Contacts.Remove(contactDb);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine("Contact does not exist!");
            }
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await _dbContext.Contacts.ToListAsync();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _dbContext.Contacts.FirstOrDefaultAsync(c => c.ID == id);
        }

        public async Task<Contact> UpdateAsync(Contact entity)
        {
            _dbContext.Contacts.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

    }
}

