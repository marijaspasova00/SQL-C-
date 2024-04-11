using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SQLProcedureConvert.DataAccess;
using SQLProcedureConvert.DataAccess.Implementations;
using SQLProcedureConvert.DataAccess.Interaces;
using SQLProcedureConvert.Domain.Models;
using SQLProcedureConvert.Services.Implemenations;
using SQLProcedureConvert.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SQLProcedureConvert.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ProjectDBContext>(options => options.UseSqlServer(@"Data Source=DESKTOP-5PRDE8C\SQLEXPRESS;database=sqlProcedure; Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
  }
        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddTransient<IContactRepository, ContactRepository>();
            services.AddTransient<IApplicationRepository, ApplicationRepository>();
            services.AddTransient<IChangeApplicationStatusRepository, ChangeApplicationStatusRepository>();
        }
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IApplicationService, ApplicationService>();
            services.AddTransient<IChangeApplicationStatusService, ChangeApplicationStatusService>();
        }
    }
}
