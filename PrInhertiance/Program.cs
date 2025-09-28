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
            //dbContext.Add(fullTime);
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
        }
    }
}
