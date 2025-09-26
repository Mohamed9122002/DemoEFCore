using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore.Models
{
    internal class Department
    {
        public int DeptId { get; set; }

        public string DeptName { get; set; }

        public DateOnly DateOfCreation { get; set; }

        public int Serial { get; set; }
        // Fk Must Be Named As [ManagerId , ManagerEmpId,EmployeeId ,EmployeeEmpId]
        /// <summary>
        ///  if You did't represent Fk in Model 
        ///  EF Create column to table with name [ManagerEmpId] 
        ///  in one to one Relationship  fk is required if you defined both navigation properties 
        /// </summary>
        //public int ManagerId { get; set; } // FK
        // Data Annotation
        //Use[ForeignKey] Attribute if needed(when FK name does not match the related entity's PK)

        //[ForeignKey(nameof(Manager))]
        public int DeptManagerId { get; set; } // FK
        // Use Fluent API to configure Relationship 
        /// <summary>
        ///  Use Fluent APIs When FK property name does not match PK , Need custom FK constraints

        /// </summary>

        // Navigation Property (one)

        // Ef Core : Department Must has one Employee To Manage it [total Participt]
        public Employee Manager { get; set; } = null!; 
    }
}
