using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEFCore.Migrations
{
    /// <inheritdoc />
    public partial class workreationShipBetweenEmployeeDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeDepartmentId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeDepartmentId",
                table: "Employees",
                column: "EmployeeDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_EmployeeDepartmentId",
                table: "Employees",
                column: "EmployeeDepartmentId",
                principalSchema: "Sales",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_EmployeeDepartmentId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_EmployeeDepartmentId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeDepartmentId",
                table: "Employees");
        }
    }
}
