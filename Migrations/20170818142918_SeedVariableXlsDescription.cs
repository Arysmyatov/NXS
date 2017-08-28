using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class SeedVariableXlsDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Variable: Primary Energy: Production
            migrationBuilder.Sql("INSERT INTO VariableXlsDescriptions (VariableId, SheetName, RowBg, RowEnd, RegionCol, ProcessSetCol, CommodityCol, YearColBg, YearColEnd) " + 
                                 "VALUES ((SELECT ID FROM Variables WHERE Name = 'Consumption by sector'), 'C_A01c', 5, 81, 2, 3, 0, 4, 12)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
