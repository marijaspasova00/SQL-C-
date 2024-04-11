using SQLProcedureConvert.DataAccess.Interaces;
using SQLProcedureConvert.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SQLProcedureConvert.Domain.Models;

namespace SQLProcedureConvert.Services.Implemenations
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<bool> CreateAsync(Contact contact)
        {
            
            await _contactRepository.CreateAsync(contact);
            return true;
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
            Contact contact = await _contactRepository.GetByIdAsync(id);
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
