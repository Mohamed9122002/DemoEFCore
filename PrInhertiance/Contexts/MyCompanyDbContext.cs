using Microsoft.EntityFrameworkCore;
using PrInhertiance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrInhertiance.Contexts
{
    public class MyCompanyDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= .;Database=MyCompany;Trusted_Connection = true; TrustServerCertificate = true ");
        }
        public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }
        public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }
    }
}
