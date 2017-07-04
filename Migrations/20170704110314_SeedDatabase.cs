using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO ParentRegions (Name) VALUES ('EU')");
            
            // Regions
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('BNL', (SELECT ID FROM ParentRegions WHERE Name = 'EU'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('DEU', (SELECT ID FROM ParentRegions WHERE Name = 'EU'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('EEN', (SELECT ID FROM ParentRegions WHERE Name = 'EU'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('EES', (SELECT ID FROM ParentRegions WHERE Name = 'EU'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('FRA', (SELECT ID FROM ParentRegions WHERE Name = 'EU'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('IAM', (SELECT ID FROM ParentRegions WHERE Name = 'EU'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('IBE', (SELECT ID FROM ParentRegions WHERE Name = 'EU'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('SDF', (SELECT ID FROM ParentRegions WHERE Name = 'EU'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('UKI', (SELECT ID FROM ParentRegions WHERE Name = 'EU'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('SWZ', (SELECT ID FROM ParentRegions WHERE Name = 'EU'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('NOI', (SELECT ID FROM ParentRegions WHERE Name = 'EU'))");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM ParentRegions WHERE Name IN ('EU', 'Make2', 'Make3')");

            migrationBuilder.Sql("DELETE FROM Regions WHERE Name IN ('BNL', 'DEU', 'EEN', 'EES', 'FRA', 'IAM', 'IBE', 'SDF', 'UKI', 'SWZ', 'NOI')");
        }
    }
}