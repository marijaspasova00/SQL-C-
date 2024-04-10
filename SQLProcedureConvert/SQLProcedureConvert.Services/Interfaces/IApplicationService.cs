using SQLProcedureConvert.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLProcedureConvert.Services.Interfaces
{
    public interface IApplicationService
    {
        Task<List<Application>> GetAllAsync();
        Task<Application> GetByIdAsync(int id);
        Task<int> CreateAsync(Application application);
        Task<Application> UpdateAsync(Application application, int id);
        Task DeleteAsync(int id);
    }
}
