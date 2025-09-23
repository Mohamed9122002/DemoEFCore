using DemoEFCore.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Net.Security;

namespace DemoEFCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Database Connection [Unmanaged Resourse]
            using CompanyDbContext companyDb = new CompanyDbContext();
            //companyDb.Database.Migrate(); // Apply Pending Migration to Database

        }
    }
}
