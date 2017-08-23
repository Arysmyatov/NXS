using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class SeedAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Roles: add Admin role
            migrationBuilder.Sql("INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES (1, 'Admin', 'ADMIN')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
