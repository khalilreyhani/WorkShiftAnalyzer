using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2.Data.Migrations
{
    /// <inheritdoc />
    public partial class addworkstartandfilename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "EmployeeWorkLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "WorkStart",
                table: "EmployeeWorkLogs",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileName",
                table: "EmployeeWorkLogs");

            migrationBuilder.DropColumn(
                name: "WorkStart",
                table: "EmployeeWorkLogs");
        }
    }
}
