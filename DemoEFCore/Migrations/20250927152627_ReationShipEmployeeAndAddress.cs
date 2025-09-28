using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEFCore.Migrations
{
    /// <inheritdoc />
    public partial class ReationShipEmployeeAndAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmpAddress_City",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpAddress_Country",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpAddress_Street",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpAddress_City",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmpAddress_Country",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmpAddress_Street",
                table: "Employees");
        }
    }
}
