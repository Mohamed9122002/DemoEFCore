using Comman;
using DemoEFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore.DbContexts
{
    internal class CompanyDbContext : DbContext
    {
        public CompanyDbContext() : base()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server= .;Database=CompanyDb;Trusted_Connection = true; TrustServerCertificate = true ");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(E => E.EmpId);
            //modelBuilder.Entity<Employee>().Property("Name")// Will Throw Exception When You Add Migration if "Name" is Not Property in Employee Class
            modelBuilder.Entity<Employee>().Property<string>("Name"); // Will Define Name As Shadow Property [Exist only Database]
            modelBuilder.Entity<Employee>()
                //.Property(nameof(Employee.EmpName))
                .Property(E => E.EmpName)
                .HasColumnName("EmployeeName")
                .HasColumnType("varchar") // Varchar(1)
                .HasMaxLength(50) // Varchar(50)
                .IsRequired(false); // Allow Null 

            modelBuilder.Entity<Department>(D =>
            {
                D.ToTable("Departments" ,"Sales");
                D.HasKey(Dpt => Dpt.DeptId);
                D.Property(Dpt => Dpt.DeptId)
                .UseIdentityColumn(10, 10);
                //D.Property(Dpt => Dpt.DeptId)
                //.ValueGeneratedNever(); // Not Identity Column
                //D.Property(Dpt => Dpt.DeptId)
                //.HasDefaultValueSql("NewGuid()"); 
                D.Property(Dpt => Dpt.DeptName)
                .HasColumnName("DepartmentName")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired()
                .HasDefaultValue("HR");
                D.Property(D => D.DateOfCreation)
                .HasAnnotation("DataType", "Date")
                //.IsRequired(false)
                //.HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));// Default value = new DateOnly Now
               .HasDefaultValueSql("GetDate()"); // Default value = new DateTime Now
                D.Ignore(D => D.Serial);

            });


        }
        public DbSet<Employee>? Employees { get;  set; }
        //// DbSet<T> : Represents Collection of Entity T in Database
        //public DbSet<Department>? Departments { get; set; }
        ////public DbSet<Project> Projects { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Department> Departments { get; set; }
    }
}
