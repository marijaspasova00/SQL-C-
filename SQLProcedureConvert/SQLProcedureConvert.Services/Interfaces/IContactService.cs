using SQLProcedureConvert.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLProcedureConvert.Services.Interfaces
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(int id);
        Task<int> CreateAsync(Contact contact);
        Task<Contact> UpdateAsync(Contact contact, int id);
        Task DeleteAsync(int id);
    }
}
