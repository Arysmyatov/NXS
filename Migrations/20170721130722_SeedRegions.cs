using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class SeedRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO ParentRegions (Name) VALUES ('ETM')");
            migrationBuilder.Sql("INSERT INTO ParentRegions (Name) VALUES ('TMXR')");

            // Regions for ETM
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('BNL', (SELECT ID FROM ParentRegions WHERE Name = 'ETM'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('DEU', (SELECT ID FROM ParentRegions WHERE Name = 'ETM'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('EEN', (SELECT ID FROM ParentRegions WHERE Name = 'ETM'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('EES', (SELECT ID FROM ParentRegions WHERE Name = 'ETM'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('FRA', (SELECT ID FROM ParentRegions WHERE Name = 'ETM'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('IAM', (SELECT ID FROM ParentRegions WHERE Name = 'ETM'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('IBE', (SELECT ID FROM ParentRegions WHERE Name = 'ETM'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('SDF', (SELECT ID FROM ParentRegions WHERE Name = 'ETM'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('UKI', (SELECT ID FROM ParentRegions WHERE Name = 'ETM'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('SWZ', (SELECT ID FROM ParentRegions WHERE Name = 'ETM'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('NOI', (SELECT ID FROM ParentRegions WHERE Name = 'ETM'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('World', (SELECT ID FROM ParentRegions WHERE Name = 'ETM'))");

            // Regions for TMXR
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('CTR', (SELECT ID FROM ParentRegions WHERE Name = 'TMXR'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('NES', (SELECT ID FROM ParentRegions WHERE Name = 'TMXR'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('NOE', (SELECT ID FROM ParentRegions WHERE Name = 'TMXR'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('OCC', (SELECT ID FROM ParentRegions WHERE Name = 'TMXR'))");
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('SSE', (SELECT ID FROM ParentRegions WHERE Name = 'TMXR'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM ParentRegions WHERE Name IN ('EU')");

            migrationBuilder.Sql("DELETE FROM Regions WHERE Name IN ('BNL', 'DEU', 'EEN', 'EES', 'FRA', 'IAM', 'IBE', 'SDF', 'UKI', 'SWZ', 'NOI', 'World')");
        }
    }
}
