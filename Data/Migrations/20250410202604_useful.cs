﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2.Data.Migrations
{
    /// <inheritdoc />
    public partial class useful : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "Usefulwork",
                table: "EmployeeWorkLogs",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usefulwork",
                table: "EmployeeWorkLogs");
        }
    }
}
