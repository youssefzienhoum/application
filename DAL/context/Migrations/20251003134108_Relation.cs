using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Context.Migrations
{
    /// <inheritdoc />
    public partial class Relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepId",
                table: "Employees",
                column: "DepId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Departments_DepId",
                table: "Employees",
                column: "DepId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Departments_DepId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_DepId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DepId",
                table: "Employees");
        }
    }
}
