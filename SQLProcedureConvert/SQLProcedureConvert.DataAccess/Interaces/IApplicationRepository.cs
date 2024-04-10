using SQLProcedureConvert.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLProcedureConvert.DataAccess.Interaces
{
    public interface IApplicationRepository
    {
        Task<List<Application>> GetAllAsync();
        Task<Application> GetByIdAsync(int id);
        Task<int> CreateAsync(Application application);
        Task<Application> UpdateAsync(Application application);
        Task DeleteAsync(int id);
    }
}
