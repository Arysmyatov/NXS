using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class SeedKeyParameters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // KeyParameterGroups
            migrationBuilder.Sql("INSERT INTO KeyParameterGroups (Name) VALUES ('Bottom')");
            migrationBuilder.Sql("INSERT INTO KeyParameterGroups (Name) VALUES ('Fossil fuel prices')");

            // KeyParameters
            migrationBuilder.Sql("INSERT INTO KeyParameters (Name, KeyParameterGroupId) VALUES ('Discount rates', (SELECT ID FROM KeyParameterGroups WHERE Name = 'Bottom'))");
            migrationBuilder.Sql("INSERT INTO KeyParameters (Name, KeyParameterGroupId) VALUES ('GDP', (SELECT ID FROM KeyParameterGroups WHERE Name = 'Bottom'))");
            migrationBuilder.Sql("INSERT INTO KeyParameters (Name, KeyParameterGroupId) VALUES ('Population', (SELECT ID FROM KeyParameterGroups WHERE Name = 'Bottom'))");

            migrationBuilder.Sql("INSERT INTO KeyParameters (Name, KeyParameterGroupId) VALUES ('Oil', (SELECT ID FROM KeyParameterGroups WHERE Name = 'Fossil fuel prices'))");
            migrationBuilder.Sql("INSERT INTO KeyParameters (Name, KeyParameterGroupId) VALUES ('Gas', (SELECT ID FROM KeyParameterGroups WHERE Name = 'Fossil fuel prices'))");
            migrationBuilder.Sql("INSERT INTO KeyParameters (Name, KeyParameterGroupId) VALUES ('Coal', (SELECT ID FROM KeyParameterGroups WHERE Name = 'Fossil fuel prices'))");

            // KeyParametersLevel
            migrationBuilder.Sql("INSERT INTO KeyParameterLevels (Name) VALUES ('Low')");
            migrationBuilder.Sql("INSERT INTO KeyParameterLevels (Name) VALUES ('Medium')");
            migrationBuilder.Sql("INSERT INTO KeyParameterLevels (Name) VALUES ('High')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // KeyParameterGroups
            migrationBuilder.Sql("DELETE FROM KeyParameterGroups WHERE Name IN ('Bottom'," +
                                                                               "'Fossil fuel prices',");
            // KeyParameters
            migrationBuilder.Sql("DELETE FROM KeyParameters WHERE Name IN ('Discount rates'," +
                                                                          "'Population'," +
                                                                          "'Oil'," +
                                                                          "'Gas'," +
                                                                          "'Coal'," +
                                                                          "'GDP',");            
            // KeyParameterLevels
            migrationBuilder.Sql("DELETE FROM KeyParameterGroups WHERE Name IN ('Low'," +
                                                                               "'Medium'," +
                                                                               "'High',");                                                                          
        }
    }
}
