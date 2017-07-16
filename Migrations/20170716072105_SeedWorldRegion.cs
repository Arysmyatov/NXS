using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class SeedWorldRegion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Regions (Name, ParentRegionId) VALUES ('World', (SELECT ID FROM ParentRegions WHERE Name = 'EU'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
