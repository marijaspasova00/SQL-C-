using SQLProcedureConvert.DataAccess.Interaces;
using SQLProcedureConvert.Models.Models;
using SQLProcedureConvert.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SQLProcedureConvert.Services.Implemenations
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<int> CreateAsync(Contact contact)
        {
            Contact contactDb = await GetByIdAsync(contact.ID);
            await _contactRepository.CreateAsync(contactDb);
            return contactDb.ID;
        }

        public async Task DeleteAsync(int id)
        {
            await _contactRepository.DeleteAsync(id);
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            List<Contact> contacts = await _contactRepository.GetAllAsync();

            if (contacts == null)
            {
                throw new Exception("Contacts are null");
            }

            return contacts.ToList();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            Contact contact = await GetByIdAsync(id);
            if (contact == null)
            {
                throw new Exception("Contact is null");
            }

            return contact;
        }

        public async Task<Contact> UpdateAsync(Contact contact, int id)
        {
            Contact contactDb = await _contactRepository.GetByIdAsync(id);


            if (contactDb == null)
            {
                throw new Exception("Contact is null!");
            }
            contactDb.Name = contact.Name;

            await _contactRepository.UpdateAsync(contactDb);
            var updatedContact = await _contactRepository.GetByIdAsync(id);
            return updatedContact;
        }
    }
}
