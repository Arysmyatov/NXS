using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class SeedWorldAggreegationXlsDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AgrigationXlsDescriptions] ([VariableId], " +
                                                                                "[RegionAgrigationTypeId]," +
                                                                                "[AttributeCol], " +
                                                                                "[CommodityCol], " +
                                                                                "[CommoditySetCol], " +
                                                                                "[ProcessSetCol], " +
                                                                                "[RowBg], " +
                                                                                "[RowEnd], " +
                                                                                "[SheetName], " +
                                                                                "[SubVariableCol], " +
                                                                                "[UserConstraintCol], " +
                                                                                "[YearColBg], " +
                                                                                "[YearColEnd], " +
                                                                                "[YearRowBg]) VALUES " +
                                                                                "((SELECT ID FROM Variables WHERE Name = 'Consumption by sector'), " +
                                                                                "(SELECT ID FROM RegionAgrigationTypes WHERE Name = 'World'), " +
                                                                                "'0', '0', '0', '13', '37', '46', 'Global Results', '2', '0', '3', '11', '36')");
            // GDP - By Region
            migrationBuilder.Sql("INSERT INTO [dbo].[AgrigationXlsDescriptions] ([VariableId], " +
                                                                                "[RegionAgrigationTypeId]," +
                                                                                "[AttributeCol], " +
                                                                                "[CommodityCol], " +
                                                                                "[CommoditySetCol], " +
                                                                                "[ProcessSetCol], " +
                                                                                "[RowBg], " +
                                                                                "[RowEnd], " +
                                                                                "[SheetName], " +
                                                                                "[SubVariableCol], " +
                                                                                "[UserConstraintCol], " +
                                                                                "[YearColBg], " +
                                                                                "[YearColEnd], " +
                                                                                "[YearRowBg]) VALUES " +
                                                                                "((SELECT ID FROM Variables WHERE Name = 'GDP'), " +
                                                                                "(SELECT ID FROM RegionAgrigationTypes WHERE Name = 'By Region'), " +
                                                                                "'0', '0', '0', '0', '3', '14', 'Global Results', '2', '0', '3', '17', '2')");        
        
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
