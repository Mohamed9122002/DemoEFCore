
using DemoEFCore.Configurations;
using DemoEFCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoEFCore.DbContexts
{
    internal class CompanyDbContext : DbContext
    {
        public CompanyDbContext() : base()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server= .;Database=CompanyDb;Trusted_Connection = true; TrustServerCertificate = true ").UseLazyLoadingProxies();



        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>()
            //    .HasKey(E => E.EmpId);
            ////modelBuilder.Entity<Employee>().Property("Name")// Will Throw Exception When You Add Migration if "Name" is Not Property in Employee Class
            //modelBuilder.Entity<Employee>().Property<string>("Name"); // Will Define Name As Shadow Property [Exist only Database]
            //modelBuilder.Entity<Employee>()
            //    //.Property(nameof(Employee.EmpName))
            //    .Property(E => E.EmpName)
            //    .HasColumnName("EmployeeName")
            //    .HasColumnType("varchar") // Varchar(1)
            //    .HasMaxLength(50) // Varchar(50)
            //    .IsRequired(false); // Allow Null 
            //modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            //modelBuilder.Entity<Department>(D =>
            //{
            //    D.ToTable("Departments", "Sales");
            //    D.HasKey(Dpt => Dpt.DeptId);
            //    D.Property(Dpt => Dpt.DeptId)
            //    .UseIdentityColumn(10, 10);
            //    //D.Property(Dpt => Dpt.DeptId)
            //    //.ValueGeneratedNever(); // Not Identity Column
            //    //D.Property(Dpt => Dpt.DeptId)
            //    //.HasDefaultValueSql("NewGuid()"); 
            //    D.Property(Dpt => Dpt.DeptName)
            //    .HasColumnName("DepartmentName")
            //    .HasColumnType("varchar")
            //    .HasMaxLength(20)
            //    .IsRequired()
            //    .HasDefaultValue("HR");
            //    D.Property(D => D.DateOfCreation)
            //    .HasAnnotation("DataType", "Date")
            //    //.IsRequired(false)
            //    //.HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));// Default value = new DateOnly Now
            //   .HasDefaultValueSql("GetDate()"); // Default value = new DateTime Now
            //    D.Ignore(D => D.Serial);

            //});
            //modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // Automaticallly Apply All Fluent APIs Configurations From executing Assembly 
            modelBuilder.Entity<Employee>()
                .HasOne(E => E.ManageDepartment)
                .WithOne(E => E.Manager)
                .HasForeignKey<Department>(D => D.DeptManagerId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired(true);
            //modelBuilder.Entity<Employee>()
            //    .HasOne<Department>()
            //    .WithOne();

            ////////////////////// 
            //modelBuilder.Entity<Employee>()
            //    .HasOne(E => E.EmployeeDepartment) // Each Employee Has One Department 
            //    .WithMany(D => D.Employees) // Each Department Has Many Employees
            //    .HasForeignKey(E => E.EmployeeDepartmentId) // Foreign Key in Employee Table
            //    .IsRequired() // Makes relationship required 
            //    .OnDelete(DeleteBehavior.NoAction);

            //// Many To Many Configuration 
            //modelBuilder.Entity<Student>()
            //    .HasMany(S => S.Courses)
            //    .WithMany(C => C.Students)
            //    .UsingEntity(RT => RT.ToTable("Hamda");
            //// Many to Many 
            //modelBuilder.Entity<StudentCourse>()
            //     .HasKey(sc=> new { sc.StudentId, sc.CourseId});

            modelBuilder.Entity<Student>()
                .HasMany(S => S.StudentCourses)
                .WithOne(SC => SC.Student)
                .HasForeignKey(SC => SC.StudentId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();

            modelBuilder.Entity<Course>()
                .HasMany(C => C.StudentCourses)
                .WithOne(SC => SC.Course)
                .HasForeignKey(SC => SC.CourseId);

        }
        public DbSet<Employee>? Employees { get;  set; }
        //// DbSet<T> : Represents Collection of Entity T in Database
        public DbSet<Department> Departments { get; set; }
        ////public DbSet<Project> Projects { get; set; }
        //public DbSet<Product> Products { get; set; }
        //public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
