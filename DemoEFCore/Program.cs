using DemoEFCore.Data;
using DemoEFCore.DbContexts;
using DemoEFCore.Models;
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
            //Employee employee01 = new Employee()
            //{
            //    EmpName = "John Doe",
            //    Salary = 15000,
            //    Age = 30,
            //    Email = "JohnDoe@gmail.com",
            //    PhoneNumber = "01123456789",
            //    Password = "P@ssw0rd"

            //};
            //Console.WriteLine(companyDb.Entry<Employee>(employee01).State); // Detached
            //companyDb.Add(employee01);
            //companyDb.SaveChanges();    
            #region Dynmaic Data Seeding 
         bool flag =  CompanyDbContextSeed.DataSeeding(companyDb);
            if(flag)
                Console.WriteLine("Data Seeded Successfully");
            else
                Console.WriteLine("Data Seeding Failed");

            #endregion

        }
    }
}
