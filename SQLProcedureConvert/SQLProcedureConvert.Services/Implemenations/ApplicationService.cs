using SQLProcedureConvert.DataAccess.Interaces;
using SQLProcedureConvert.Domain.Models;
using SQLProcedureConvert.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLProcedureConvert.Services.Implemenations
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IChangeApplicationStatusRepository _caStatusRepository;
        public ApplicationService(IApplicationRepository applicationRepository, IChangeApplicationStatusRepository caStatusRepository)
        {
            _applicationRepository = applicationRepository;
            _caStatusRepository = caStatusRepository;
        }
        public async Task<int> CreateAsync(Application application)
        {
            Application applicationDb = await GetByIdAsync(application.ID);
            await _applicationRepository.CreateAsync(applicationDb);
            return applicationDb.ID;
        }

        public async Task  DeleteAsync(int id)
        {
            await _applicationRepository.DeleteAsync(id);
        }

        public async Task<List<Application>> GetAllAsync()
        {
            List<Application> applications = await _applicationRepository.GetAllAsync();

            if (applications == null)
            {
                throw new Exception("Applications are null");
            }

            return applications.ToList();
        }

        public async Task<Application> GetByIdAsync(int id)
        {
            Application application = await GetByIdAsync(id);
            if (application == null)
            {
                throw new Exception("Contact is null");
            }

            return application;
        }

        public async Task<Application> UpdateAsync(Application application, int id)
        {
            Application applicationDb = await _applicationRepository.GetByIdAsync(id);
            ChangeApplicationStatus csDb = new ChangeApplicationStatus();

            if (applicationDb == null)
            {
                throw new Exception("Applications is null!");
            }
            csDb.ApplicationID = application.ID;
            csDb.ContactID = application.ContactID;
            csDb.StatusFrom = applicationDb.CurrentStatus;
            csDb.Date = DateTime.Now;
            applicationDb.CurrentStatus = application.CurrentStatus;
            csDb.NewStatus = application.CurrentStatus;

            await _applicationRepository.UpdateAsync(applicationDb);
            await _caStatusRepository.CreateAsync(csDb);
            var upadatedApplication = await _applicationRepository.GetByIdAsync(id);
            return upadatedApplication;
        }

    }
}
