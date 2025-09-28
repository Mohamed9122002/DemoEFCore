

using DataBaseFirst.Contexts;

namespace DataBaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Install EF Core packages
            //2.Scaffold the models and DbContext

            //Scaffold-DbContext -Connection "Server=.; Database = Northwind; Trusted_Connection = true; TrustServerCertificate = true" -Provider
            ///Scaffold-DbContext -Connection "Server=.; Database = Northwind; Trusted_Connection = true; TrustServerCertificate = true"  Microsoft.EntityFrameworkCore.SqlServer -Context "MyNorthWindDbContext" -ContextDir "Contexts" -OutputDir "Models"  -Tables "Customers",Employees",Orders","Products", "Sales Totals by Amount"
            using MyNorthwindDbContext
                myNorthWindDbContext = new MyNorthwindDbContext();
            var customers = myNorthWindDbContext.Customers.ToList();
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.CustomerId} {customer.CompanyName} {customer.ContactName}");
            }

        }
    }
}
