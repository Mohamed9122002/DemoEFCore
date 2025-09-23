using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore.Models
{
    // Model : POCO Class [Plain Old CLR Object] - Domian Entity 

    internal class Employee
    {
        // Public Numeric Property Named As [Id , EmployeeId]
        public int Id { get; set; } // Pk with Identity Constraint [1,1]
        public string? Name { get; set; }
        // Nullable Reference Type 
        //string? is Mapped to nvarchar(MAX) allow Null  
        public decimal Salary { get; set; }
        // value Type  Not Allow Null 
        // decimal is Mapped to decimal(18,2) Not Allow Null
        public int Age { get; set; }
        // value Type  int is mapped to int Not Allow Null
    }
}
