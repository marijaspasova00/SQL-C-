using SQLProcedureConvert.DataAccess.Interaces;
using SQLProcedureConvert.Domain.Models;
using SQLProcedureConvert.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SQLProcedureConvert.DataAccess.Implementations;

namespace SQLProcedureConvert.Services.Implemenations
{
    public class ChangeApplicationStatusService : IChangeApplicationStatusService
    {
        private readonly IChangeApplicationStatusRepository _caStatusRepository;
        //private readonly IApplicationRepository _applicationRepository;
        public ChangeApplicationStatusService(IChangeApplicationStatusRepository _caStatusRepository1)
        {
            _caStatusRepository1 = _caStatusRepository;
        }
        public async Task<int> CreateAsync(ChangeApplicationStatus caStatusDb)
        {
            await _caStatusRepository.CreateAsync(caStatusDb);
            return caStatusDb.ID;
        }

        public async Task<List<ChangeApplicationStatus>> GetAllAsync()
        {
            List<ChangeApplicationStatus> changeApplicationStatuses = await _caStatusRepository.GetAllAsync();

            if (changeApplicationStatuses == null)
            {
                throw new Exception("Statuses are null");
            }

            return changeApplicationStatuses.ToList();
        }
    }
}
