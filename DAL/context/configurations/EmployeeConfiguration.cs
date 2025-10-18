
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.context.configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Entities.Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
           builder.HasKey(E=>E.Id);
           builder.Property(E=>E.Name).IsRequired().HasMaxLength(100);
           builder.Property(E=>E.Age).IsRequired(false);
           builder.Property(E=>E.Address).IsRequired(false).HasMaxLength(500);
           builder.Property(E=>E.Salary).IsRequired();
           builder.Property(e=>e.Gender).HasConversion(x=>x.ToString(),s =>Enum.Parse<Gender>(s));
           builder.Property(e=>e.EmployeeType).HasConversion(x=>x.ToString(),s =>Enum.Parse<EmployeeType>(s));
           
            builder.HasOne(e=>e.Department)
              .WithMany(s=>s.Employees)
              .HasForeignKey(e=>e.DepId);
        }
    }
}
