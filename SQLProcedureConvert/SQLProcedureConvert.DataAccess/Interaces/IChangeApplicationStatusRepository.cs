using SQLProcedureConvert.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLProcedureConvert.DataAccess.Interaces
{
    public interface IChangeApplicationStatusRepository
    {
        Task<int> CreateAsync(ChangeApplicationStatus caStatus);
        Task<List<ChangeApplicationStatus>> GetAllAsync();
    }
}
