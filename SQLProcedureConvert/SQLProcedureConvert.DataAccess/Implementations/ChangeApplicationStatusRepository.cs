using Microsoft.EntityFrameworkCore;
using SQLProcedureConvert.DataAccess.Interaces;
using SQLProcedureConvert.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLProcedureConvert.DataAccess.Implementations
{
    public class ChangeApplicationStatusRepository : IChangeApplicationStatusRepository
    {
        private readonly ProjectDBContext _dbContext;
        public ChangeApplicationStatusRepository(ProjectDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> CreateAsync(ChangeApplicationStatus entity)
        {
            await _dbContext.ChangeApplicationStatus.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.ID;
        }

        public async Task<List<ChangeApplicationStatus>> GetAllAsync()
        {
            return await _dbContext.ChangeApplicationStatus.ToListAsync();
        }
    }
}
