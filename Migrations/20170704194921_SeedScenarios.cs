using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class SeedScenarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Scenarios
            migrationBuilder.Sql("INSERT INTO Scenarios (Name) VALUES ('Low Carbon')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //remove scenarios 
            migrationBuilder.Sql("DELETE FROM Scenarios WHERE Name IN ('Low Carbon')");            
        }
    }
}
