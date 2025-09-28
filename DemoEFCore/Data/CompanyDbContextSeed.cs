using DemoEFCore.DbContexts;
using DemoEFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DemoEFCore.Data
{
    internal static class CompanyDbContextSeed
    {
        public static bool DataSeeding(CompanyDbContext dbContext)
        {
            try
            {
                var departmentsData = File.ReadAllText("Files\\departments.json");
                var departmentsList = JsonSerializer.Deserialize<List<Department>>(departmentsData);
                if (departmentsList?.Count > 0)
                {
                    dbContext.Departments.AddRange(departmentsList);
                    dbContext.SaveChanges();
                }

                if (!dbContext.Employees.Any())
                {
                    var EmployeesData = File.ReadAllText("Files\\employees.json");
                    // Convert string to List<Employee>
                    var Employees = JsonSerializer.Deserialize<List<Employee>>(EmployeesData);
                    if (Employees?.Count > 0)
                    {
                        //foreach (var employee in Employees)
                        //{
                        //    dbContext.Employees.Add(employee);
                        //}
                        dbContext.Employees.AddRange(Employees);
                        dbContext.SaveChanges();
                    }
                }
                return true;
            }
            catch(Exception ec)
            {
                Console.WriteLine(ec);
                return false;
            }
        }
    }
}
