using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class SeedRegionAgrigationTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Roles: add Admin role
            migrationBuilder.Sql("INSERT INTO RegionAgrigationTypes (Name) VALUES ('By Region')");
            migrationBuilder.Sql("INSERT INTO RegionAgrigationTypes (Name) VALUES ('World')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
