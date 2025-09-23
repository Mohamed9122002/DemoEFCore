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
        public DbSet<Employee>? Employees { get; set; }
        // DbSet<T> : Represents Collection of Entity T in Database
        public DbSet<Department>? Departments { get; set; }
        //public DbSet<Project> Projects { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
