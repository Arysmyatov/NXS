using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class SeedXlsRegionTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO XlsRegionTypes (Name) VALUES ('General region')");
            migrationBuilder.Sql("INSERT INTO XlsRegionTypes (Name) VALUES ('World region')");

            migrationBuilder.Sql("UPDATE [dbo].[VariableXls] SET XlsRegionTypeId = (SELECT ID FROM XlsRegionTypes WHERE Name = 'General region')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
