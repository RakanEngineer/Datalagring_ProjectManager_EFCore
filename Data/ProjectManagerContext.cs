using Datalagring_ProjectManager_EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalagring_ProjectManager_EFCore.Data
{
    class ProjectManagerContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        //public ILoggerFactory Factory { get; }
        //public ProjectManagerContext(ILoggerFactory factory)
        //{
        //    Factory = factory;
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLoggerFactory(Factory);

            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=ProjectManager;Integrated Security=true; Encrypt=True;Trust Server Certificate=True");

        }
    }
}
