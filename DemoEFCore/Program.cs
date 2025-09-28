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
            //bool flag =  CompanyDbContextSeed.DataSeeding(companyDb);
            //   if(flag)
            //       Console.WriteLine("Data Seeded Successfully");
            //   else
            //       Console.WriteLine("Data Seeding Failed");

            #endregion
            #region Navigation Property - Related Data 
            //var emp01 = companyDb.Employees.FirstOrDefault(e => e.EmpId == 25);
            //if (emp01 != null)
            //{
            //    Console.WriteLine($"Employee Name : {emp01.EmpName}");
            //    Console.WriteLine($"Employee Salary : {emp01.Salary}");
            //    Console.WriteLine($"Employee Age : {emp01.EmployeeDepartment.DeptName}"); // Realted Data 
            //}
            //else
            //{
            //    Console.WriteLine("Employee Not Found");
            //}
            #endregion
            #region Eager Loading 
            //var emp01 = companyDb.Employees.Include(E=>E.EmployeeDepartment).FirstOrDefault(e => e.EmpId == 25);
            //if (emp01 != null)
            //{
            //    Console.WriteLine($"Employee Name : {emp01.EmpName}");
            //    Console.WriteLine($"Employee Department : {emp01.EmployeeDepartment.DeptName}"); 
            //}
            ////// if Navigation Property is Mandatory [Not Null] ==> Inner Join 
            ///// if Navigation Property is Optional [Null] ==> Left Join 
            //else
            //{
            //    Console.WriteLine("Employee Not Found");
            //}
            //var empwithManagerDepartment = companyDb.Employees.Include(E => E.ManageDepartment).FirstOrDefault(e => e.EmpId == 25);
            //if (empwithManagerDepartment != null)
            //{
            //    Console.WriteLine($"Employee Name : {empwithManagerDepartment.EmpName}");
            //    Console.WriteLine($"Employee Department : {empwithManagerDepartment.ManageDepartment?.DeptName ?? "No Department"}");
            //}

            //var empwithDepartment = companyDb.Employees.Include(E => E.EmployeeDepartment).ThenInclude(D=>D.Manager).FirstOrDefault(e => e.EmpId == 25);
            //if (empwithDepartment is not null)
            //{
            //    Console.WriteLine($"Employee Name : {empwithDepartment.EmpName}");
            //    Console.WriteLine($"Employee Department : {empwithDepartment.EmployeeDepartment?.DeptName}");
            //    Console.WriteLine(empwithDepartment.EmployeeDepartment?.Manager?.EmpId);
            //    Console.WriteLine(empwithDepartment.EmployeeDepartment?.Manager?.EmpName);
            //}
            // eager Loading => One request => All Data
            #endregion
            #region  Loading Related Data - Explicit Loading
            // Manual Loading of Related Data

            #region Ex01
            //var emp01WithDepartment = companyDb.Employees.FirstOrDefault(e => e.EmpId == 25);
            //if (emp01WithDepartment is not null)
            //{
            //    Console.WriteLine(emp01WithDepartment.EmpName);
            //    Console.WriteLine(emp01WithDepartment.EmployeeDepartmentId);
            //    // Load Related Data  explicitly
            //    // Navigational Property is One  => Reference 
            //    // Navigational Property is Many => Collection 
            //    companyDb.Entry(emp01WithDepartment).Reference(E => E.EmployeeDepartment).Load();
            //    Console.WriteLine(emp01WithDepartment.EmployeeDepartment?.DeptName);

            //} 
            #endregion
            #region Ex01
            //var Department01 = companyDb.Departments.FirstOrDefault(d=>d.DeptId == 10);
            //if(Department01 != null)
            //{
            //    Console.WriteLine(Department01.DeptName);//
            //    companyDb.Entry(Department01).Collection(D => D.Employees).Query().Where(E=>E.Age>25).Load();
            //    foreach(var emp in Department01.Employees) 
            //    {
            //        Console.WriteLine($"Employee Name : {emp.EmpName}");
            //    }
            //} 
            #endregion

            #endregion

        }
    }
}
