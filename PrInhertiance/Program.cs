using PrInhertiance.Contexts;
using PrInhertiance.Models;

namespace PrInhertiance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using MyCompanyDbContext dbContext = new MyCompanyDbContext();
            FullTimeEmployee fullTime = new FullTimeEmployee()
            {
                Name = "Ahmed",
                Age = 30,
                Address = "Cairo",
                Salary = 5000,
                StartDate = DateTime.Now,
            };
            PartTimeEmployee partTime = new PartTimeEmployee()
            {
                Name = "Mohamed",
                Age = 25,
                Address = "Giza",
                HourlyRate = 50,
                CountOfHours = 100,
            };
            //dbContext.Employees.Add(fullTime);
            //dbContext.Add(partTime);
            //dbContext.SaveChanges();
            //var fTem = (from Ft in dbContext.FullTimeEmployees select Ft).FirstOrDefault();
            //if (fTem != null)
            //{
            //    Console.WriteLine($"FullTime Employee: {fTem.Name}, Salary: {fTem.Salary}");
            //}
            //var pTem = (from Pt in dbContext.PartTimeEmployees select Pt).FirstOrDefault();
            //if (pTem != null)
            //{
            //    Console.WriteLine($"PartTime Employee: {pTem.Name}, HourlyRate: {pTem.HourlyRate}");
            //}
            #region Table-per-Hierarchy (TPH)
            //Default strategy in EF Core , All classes in an inheritance hierarchy are mapped to a
            //single table and a discriminator column is used to distinguish between different types.
            //var employees = from e in dbContext.Employees select e;
            //foreach (var emp in employees)
            //{
            //    if (emp is FullTimeEmployee fte)
            //    {
            //        Console.WriteLine($"FullTime Employee: {fte.Name}, Salary: {fte.Salary}");
            //    }
            //    else if (emp is PartTimeEmployee pte)
            //    {
            //        Console.WriteLine($"PartTime Employee: {pte.Name}, HourlyRate: {pte.HourlyRate}");
            //    }
            //}
            #endregion
            #region  Inheritance Mapping [TPT]
            //var employees = (from e in dbContext.Employees select e ).ToList();
            //if(employees is not null)
            //{
            //    foreach (var emp in employees.OfType<Employee>())
            //    {
            //        Console.WriteLine($"{emp.Name}: {emp.Age}");
            //    }
            //}
            #endregion
            #region Local 
            //var result = dbContext.Employees.Local.Any(E => E.Age != null);
            // No Database Interaction [No Request]
            //Console.WriteLine(result);
            //var result = dbContext.Employees.Any(E => E.Age != null);
            // Database Interaction [Request] 
            #endregion


        }
    }
}
