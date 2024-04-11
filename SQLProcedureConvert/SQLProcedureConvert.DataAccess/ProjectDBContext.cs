using Microsoft.EntityFrameworkCore;
using SQLProcedureConvert.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace SQLProcedureConvert.DataAccess
{
    public class ProjectDBContext : DbContext
    {
        public ProjectDBContext(DbContextOptions<ProjectDBContext> options) : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Application> Application { get; set; }
        public DbSet<ChangeApplicationStatus> ChangeApplicationStatus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Application>()
                   .HasOne(a => a.Contact);
            modelBuilder.Entity<ChangeApplicationStatus>()
                   .HasOne(s => s.Application)
                   .WithMany(a => a.ChangeApplicationStatus)
                   .HasForeignKey(s => s.ApplicationID);
        }
    }
}

