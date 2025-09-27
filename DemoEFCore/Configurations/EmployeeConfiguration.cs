using DemoEFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(E => E.EmpId);
            //modelBuilder.Entity<Employee>().Property("Name")// Will Throw Exception When You Add Migration if "Name" is Not Property in Employee Class
            builder.Property<string>("Name"); // Will Define Name As Shadow Property [Exist only Database]
            builder
                //.Property(nameof(Employee.EmpName))
                .Property(E => E.EmpName)
                .HasColumnName("EmployeeName")
                .HasColumnType("varchar") // Varchar(1)
                .HasMaxLength(50) // Varchar(50)
                .IsRequired(false); // Allow Null 

            builder.OwnsOne(E => E.EmpAddress, Address => Address.WithOwner());
        }
    }
}
