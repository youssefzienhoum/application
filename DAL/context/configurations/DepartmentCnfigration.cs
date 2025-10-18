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
    internal class DepartmentCnfigration : IEntityTypeConfiguration<Entities.Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Code).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.CreatedOn).IsRequired();
            builder.Property(e => e.CreatedBy).IsRequired();
            builder.Property(e => e.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.Property(e => e.LastModifiedBy).IsRequired();
            builder.Property(e => e.LastModifiedOn).IsRequired();

           
        }
    }
}
