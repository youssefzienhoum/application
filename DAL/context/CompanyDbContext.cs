using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.context
{
    public class CompanyDbContext(DbContextOptions<CompanyDbContext> options):DbContext(options)
    {
        public DbSet<Entities.Department> Departments { get; set; }
        public DbSet<Entities.Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CompanyDbContext).Assembly);

        }

        }
}
