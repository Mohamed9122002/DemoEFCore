using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore.Models
{
    // Model : POCO Class [Plain Old CLR Object] - Domian Entity 

    #region By Convention 
    //internal class Employee
    //{
    //    // Public Numeric Property Named As [Id , EmployeeId]
    //    public int Id { get; set; } // Pk with Identity Constraint [1,1]
    //    public string? Name { get; set; }
    //    // Nullable Reference Type 
    //    //string? is Mapped to nvarchar(MAX) allow Null  
    //    public decimal Salary { get; set; }
    //    // value Type  Not Allow Null 
    //    // decimal is Mapped to decimal(18,2) Not Allow Null
    //    public int Age { get; set; }
    //    // value Type  int is mapped to int Not Allow Null
    //} 
    #endregion
    #region Data Annotation 
    //[Table("Employees")]
    //internal class Employee
    //{
    //    // Public Numeric Property Named As [Id , EmployeeId]
    //    [Key]
    //    public int EmpId { get; set; } // Pk with Identity Constraint [1,1]
    //    [Required]
    //    [Column("EmployeeName",TypeName = "varchar")]
    //    //[MaxLength(5,ErrorMessage = "Name of Employee Must Be Less Than 51 Char")]
    //    //[MinLength(3,ErrorMessage ="Name of Employee Must Be More Than 3 Char")]
    //    [StringLength(50,MinimumLength =3)]
    //    // Backend Validation Will Not Be Mapped to Database

    //    public string EmpName { get; set; }
    //    //string? is Mapped to varchar(1) Not allow Null
    //    [Column("EmployeeSalary",TypeName ="decimal(10,2)")]
    //    public decimal Salary { get; set; }
    //    // value Type  Not Allow Null 
    //    // decimal is Mapped to decimal(18,2) Not Allow Null
    //    [Range(21,60)] // Will Not Be Mapped to Database 
    //    [AllowedValues(25,28,30,35,40)] // Custom Attribute 
    //    public int Age { get; set; }
    //    // value Type  int is mapped to int Not Allow Null
    //}
    #endregion
    [Table("Employees")]
    internal class Employee
    {
        // Public Numeric Property Named As [Id , EmployeeId]

        public int EmpId { get; set; } // Pk with Identity Constraint [1,1]
        [Required]
        [Column("EmployeeName", TypeName = "varchar")]
        //[MaxLength(5,ErrorMessage = "Name of Employee Must Be Less Than 51 Char")]
        //[MinLength(3,ErrorMessage ="Name of Employee Must Be More Than 3 Char")]
        //[StringLength(50, MinimumLength = 3)]
        // Backend Validation Will Not Be Mapped to Database

        public string EmpName { get; set; }
        //string? is Mapped to varchar(1) Not allow Null
        [Column("EmployeeSalary", TypeName = "decimal(10,2)")]
        public decimal Salary { get; set; }
        // value Type  Not Allow Null 
        // decimal is Mapped to decimal(18,2) Not Allow Null
        [Range(21, 60)] // Will Not Be Mapped to Database 
        [AllowedValues(25, 28, 30, 35, 40)] // Custom Attribute 
        public int Age { get; set; }
        // value Type  int is mapped to int Not Allow Null
        [Required]
        public string Email { get; set; }
        [Phone]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        // Navigation Property [one]
        public Department? ManageDepartment  { get; set; }
        //oneToOne [Mandatory-Mandatory]
        public Address EmpAddress { get; set; }


    }
}
