using SQLProcedureConvert.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLProcedureConvert.DataAccess.Interaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(int id);
        Task<int> CreateAsync(Contact contact);
        Task<Contact> UpdateAsync(Contact contact);
        Task DeleteAsync(int id);
    }
}
