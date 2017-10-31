using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NXS.Migrations
{
    public partial class MidTermGenerationVariableSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('Mid Term Generation', (SELECT ID FROM VariableGroups WHERE Name = 'Bottom'))");
            migrationBuilder.Sql("INSERT INTO SubVariables (Name) VALUES ('Mid Term Generation')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Variables WHERE Name IN ('Mid Term Generation')");
            migrationBuilder.Sql("DELETE FROM SubVariables WHERE Name IN ('Mid Term Generation')");
        }
    }
}