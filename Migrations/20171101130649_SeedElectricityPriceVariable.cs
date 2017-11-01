using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NXS.Migrations
{
    public partial class SeedElectricityPriceVariable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('Electricity price', (SELECT ID FROM VariableGroups WHERE Name = 'Bottom'))");
            migrationBuilder.Sql("INSERT INTO SubVariables (Name) VALUES ('Electricity price')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM SubVariables WHERE Name IN ('Electricity price')");            
            migrationBuilder.Sql("DELETE FROM Variables WHERE Name IN ('Electricity price')");
        }
    }
}
