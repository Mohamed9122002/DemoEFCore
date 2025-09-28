
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
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

            {
                builder.ToTable("Departments", "Sales");
                builder.HasKey(Dpt => Dpt.DeptId);
                builder.Property(Dpt => Dpt.DeptId)
                .UseIdentityColumn(10, 10);
                //D.Property(Dpt => Dpt.DeptId)
                //.ValueGeneratedNever(); // Not Identity Column
                //D.Property(Dpt => Dpt.DeptId)
                //.HasDefaultValueSql("NewGuid()"); 
                builder.Property(Dpt => Dpt.DeptName)
                .HasColumnName("DepartmentName")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired()
                .HasDefaultValue("HR");
                builder.Property(D => D.DateOfCreation)
                .HasAnnotation("DataType", "Date")
               //.IsRequired(false)
               //.HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));// Default value = new DateOnly Now
               .HasDefaultValueSql("GetDate()"); // Default value = new DateTime Now
                builder.Ignore(D => D.Serial);
                builder.Property(D=>D.DeptManagerId).IsRequired(false);


            }
        }
    }
}
