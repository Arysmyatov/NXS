using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class SeedVariables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Top
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('GDP', (SELECT ID FROM VariableGroups WHERE Name = 'Top'))");
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('Population', (SELECT ID FROM VariableGroups WHERE Name = 'Top'))");

            // Primary Energy
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('Primary Energy: Production', (SELECT ID FROM VariableGroups WHERE Name = 'Primary Energy'))");
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('Primary Energy: Imports/Exports', (SELECT ID FROM VariableGroups WHERE Name = 'Primary Energy'))");
            // Final Energy Consumption
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('Final Energy Consumption : By fuel', (SELECT ID FROM VariableGroups WHERE Name = 'Final Energy Consumption'))");
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('Final Energy Consumption : By sector', (SELECT ID FROM VariableGroups WHERE Name = 'Final Energy Consumption'))");
            // Electricity
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('Generation', (SELECT ID FROM VariableGroups WHERE Name = 'Electricity '))");
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('CO2 intensity', (SELECT ID FROM VariableGroups WHERE Name = 'Electricity '))");
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('Consumption by sector', (SELECT ID FROM VariableGroups WHERE Name = 'Electricity '))");
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('Capacity', (SELECT ID FROM VariableGroups WHERE Name = 'Electricity '))");
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('Annualised investment costs', (SELECT ID FROM VariableGroups WHERE Name = 'Electricity '))");
            // Emissiones
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('CO2 emissions by sector', (SELECT ID FROM VariableGroups WHERE Name = 'Emissiones'))");
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('Non-CO2 emissions by sector', (SELECT ID FROM VariableGroups WHERE Name = 'Emissiones'))");
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('CO2 emissions by region', (SELECT ID FROM VariableGroups WHERE Name = 'Emissiones'))");
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('GHG emissions by region', (SELECT ID FROM VariableGroups WHERE Name = 'Emissiones'))");
            // Transport 
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('Fuel consumption by technology', (SELECT ID FROM VariableGroups WHERE Name = 'Transport'))");
            // Industry
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('Fuel consumption by technology', (SELECT ID FROM VariableGroups WHERE Name = 'Industry'))");
            // Residential 
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('Fuel consumption by technology', (SELECT ID FROM VariableGroups WHERE Name = 'Residential'))");
            // Commercial 
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('Fuel consumption by technology', (SELECT ID FROM VariableGroups WHERE Name = 'Commercial'))");
            // Agriculture
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('Fuel consumption by technology', (SELECT ID FROM VariableGroups WHERE Name = 'Agriculture'))");
            // Bottom
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('Carbon price', (SELECT ID FROM VariableGroups WHERE Name = 'Bottom'))");
            migrationBuilder.Sql("INSERT INTO Variables (Name, VariableGroupId) VALUES ('System costs', (SELECT ID FROM VariableGroups WHERE Name = 'Bottom'))");
                    

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
