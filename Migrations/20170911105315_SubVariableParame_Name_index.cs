using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NXS.Migrations
{
    public partial class SubVariableParame_Name_index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add SubVariable index
            migrationBuilder.CreateIndex(
                name: "SubVariableNameIndex",
                table: "SubVariables",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "SubVariableNameIndex",
                table: "SubVariables");
        }
    }
}
