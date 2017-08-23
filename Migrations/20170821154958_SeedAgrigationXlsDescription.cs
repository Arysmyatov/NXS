using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class SeedAgrigationXlsDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Variable: Primary Energy: Production
            migrationBuilder.Sql("INSERT INTO AgrigationXlsDescriptions (VariableId, RegionAgrigationTypeId, SheetName, RowBg, RowEnd, YearRowBg, YearColBg, YearColEnd, SubVariableCol, CommoditySetCol) " + 
                                 "VALUES ((SELECT ID FROM Variables WHERE Name = 'Primary Energy: Production'), " + 
                                        "(SELECT ID FROM RegionAgrigationTypes WHERE Name = 'By Region'), " +
                                 "'By region', 184, 194, 183, 3, 11, 2, 13)");     

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
                                                                                "(SELECT ID FROM RegionAgrigationTypes WHERE Name = 'By Region'), " +
                                                                                "'0', '0', '0', '13', '37', '46', 'By region', '2', '0', '3', '11', '36')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
