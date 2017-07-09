using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class SeedVariableXls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO VariableXls (" + 
            "VariableId," + 
            "Code, " +
            "SheetName," +
            "YearBgRow," +
            "YearBgCol," +
            "YearEndRow," +
            "YearEndCol," +
            "DataBgRow," +
            "DataBgCol," +
            "DataEndRow," +
            "DataEndCol)" + " VALUES ((SELECT ID FROM Variables WHERE Name = 'Primary Energy: Imports/Exports')," +
            "'', " +
            "'Global Results', " +
            "125, " +
            "3, " +
            "125, " +
            "11, " +            
            "126, " +
            "2, " +
            "146, " +
            "11)");

            migrationBuilder.Sql("INSERT INTO VariableXls (" + 
            "VariableId," +  
            "Code, " +            
            "SheetName," +
            "YearBgRow," +
            "YearBgCol," +
            "YearEndRow," +
            "YearEndCol," +
            "DataBgRow," +
            "DataBgCol," +
            "DataEndRow," +
            "DataEndCol)" + " VALUES ((SELECT ID FROM Variables WHERE Name = 'Final Energy Consumption : By fuel')," +
            "'', " + 
            "'Global Results'," +
            "192, " +
            "3, " +
            "192, " +
            "11, " +            
            "193, " +
            "2, " +
            "203, " +
            "11)");



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
