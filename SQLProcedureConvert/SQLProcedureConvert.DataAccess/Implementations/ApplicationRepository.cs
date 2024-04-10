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
        public class ApplicationRepository : IApplicationRepository
        {
            private readonly ProjectDBContext _dbContext;
            public ApplicationRepository(ProjectDBContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<int> CreateAsync(Application entity)
            {
                await _dbContext.Application.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity.ID;
            }
            public async Task DeleteAsync(int id)
            {
                Application appDb = await GetByIdAsync(id);

                if (appDb != null)
                {
                    _dbContext.Application.Remove(appDb);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    Console.WriteLine("Application does not exist!");
                }
            }
            public async Task<List<Application>> GetAllAsync()
            {
                return await _dbContext.Application.ToListAsync();
            }

            public async Task<Application> GetByIdAsync(int id)
            {
                return await _dbContext.Application.FirstOrDefaultAsync(c => c.ID == id);
            }

            public async Task<Application> UpdateAsync(Application entity)
            {
                _dbContext.Application.Update(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }

        }
}
