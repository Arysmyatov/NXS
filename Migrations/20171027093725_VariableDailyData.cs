using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NXS.Migrations
{
    public partial class VariableDailyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "SubVariableDailyData");

            migrationBuilder.AddColumn<int>(
                name: "Month",
                table: "SubVariableDailyData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "SubVariableDailyData",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Month",
                table: "SubVariableDailyData");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "SubVariableDailyData");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "SubVariableDailyData",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
