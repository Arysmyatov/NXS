using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class SeedVariableXls_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO VariableXls (Code, SheetName, DifForYerasX, DifForYerasY, DifForDataX, DifForDataY, VariableId) VALUES ('C_A02b', " +
                                                                                                                                                     "'Global results'," + 
                                                                                                                                                     "2," +
                                                                                                                                                     "3," +
                                                                                                                                                     "1," + 
                                                                                                                                                     "4," + 
                                                                                                                                                    "(SELECT ID FROM Variables WHERE Name = 'Final Energy Consumption : By fuel'))");
            migrationBuilder.Sql("INSERT INTO VariableXls (Code, SheetName, DifForYerasX, DifForYerasY, DifForDataX, DifForDataY, VariableId) VALUES ('C_A02c', " +
                                                                                                                                                     "'Global results'," + 
                                                                                                                                                     "2," +
                                                                                                                                                     "3," +
                                                                                                                                                     "1," + 
                                                                                                                                                     "4," + 
                                                                                                                                                    "(SELECT ID FROM Variables WHERE Name = 'Final Energy Consumption : By sector'))");       
            migrationBuilder.Sql("INSERT INTO VariableXls (Code, SheetName, DifForYerasX, DifForYerasY, DifForDataX, DifForDataY, VariableId) VALUES ('C_A01a', " +
                                                                                                                                                     "'Global results'," + 
                                                                                                                                                     "2," +
                                                                                                                                                     "3," +
                                                                                                                                                     "1," + 
                                                                                                                                                     "4," + 
                                                                                                                                                    "(SELECT ID FROM Variables WHERE Name = 'Generation'))");       
            migrationBuilder.Sql("INSERT INTO VariableXls (Code, SheetName, DifForYerasX, DifForYerasY, DifForDataX, DifForDataY, VariableId) VALUES ('C_A01b', " +
                                                                                                                                                     "'Global results'," + 
                                                                                                                                                     "2," +
                                                                                                                                                     "3," +
                                                                                                                                                     "1," + 
                                                                                                                                                     "4," + 
                                                                                                                                                    "(SELECT ID FROM Variables WHERE Name = 'Consumption by sector'))");       
            migrationBuilder.Sql("INSERT INTO VariableXls (Code, SheetName, DifForYerasX, DifForYerasY, DifForDataX, DifForDataY, VariableId) VALUES ('C_A01d', " +
                                                                                                                                                     "'Global results'," + 
                                                                                                                                                     "2," +
                                                                                                                                                     "3," +
                                                                                                                                                     "1," + 
                                                                                                                                                     "4," + 
                                                                                                                                                    "(SELECT ID FROM Variables WHERE Name = 'Capacity'))");
            migrationBuilder.Sql("INSERT INTO VariableXls (Code, SheetName, DifForYerasX, DifForYerasY, DifForDataX, DifForDataY, VariableId) VALUES ('C_A01e', " +
                                                                                                                                                     "'Global results'," + 
                                                                                                                                                     "2," +
                                                                                                                                                     "3," +
                                                                                                                                                     "1," + 
                                                                                                                                                     "4," + 
                                                                                                                                                    "(SELECT ID FROM Variables WHERE Name = 'Annualised investment costs'))");
            migrationBuilder.Sql("INSERT INTO VariableXls (Code, SheetName, DifForYerasX, DifForYerasY, DifForDataX, DifForDataY, VariableId) VALUES ('C_A03a', " +
                                                                                                                                                     "'Global results'," + 
                                                                                                                                                     "2," +
                                                                                                                                                     "3," +
                                                                                                                                                     "1," + 
                                                                                                                                                     "4," + 
                                                                                                                                                    "(SELECT ID FROM Variables WHERE Name = 'CO2 emissions by sector'))");       
            migrationBuilder.Sql("INSERT INTO VariableXls (Code, SheetName, DifForYerasX, DifForYerasY, DifForDataX, DifForDataY, VariableId) VALUES ('C_A03d', " +
                                                                                                                                                     "'Global results'," + 
                                                                                                                                                     "2," +
                                                                                                                                                     "3," +
                                                                                                                                                     "1," + 
                                                                                                                                                     "4," + 
                                                                                                                                                    "(SELECT ID FROM Variables WHERE Name = 'Non-CO2 emissions by sector'))");
            migrationBuilder.Sql("INSERT INTO VariableXls (Code, SheetName, DifForYerasX, DifForYerasY, DifForDataX, DifForDataY, VariableId) VALUES ('C_A03h', " +
                                                                                                                                                     "'Global results'," + 
                                                                                                                                                     "2," +
                                                                                                                                                     "3," +
                                                                                                                                                     "1," + 
                                                                                                                                                     "4," + 
                                                                                                                                                    "(SELECT ID FROM Variables WHERE Name = 'CO2 emissions by region'))");
            migrationBuilder.Sql("INSERT INTO VariableXls (Code, SheetName, DifForYerasX, DifForYerasY, DifForDataX, DifForDataY, VariableId) VALUES ('C_A03i', " +
                                                                                                                                                     "'Global results'," + 
                                                                                                                                                     "2," +
                                                                                                                                                     "3," +
                                                                                                                                                     "1," + 
                                                                                                                                                     "4," + 
                                                                                                                                                    "(SELECT ID FROM Variables WHERE Name = 'GHG emissions by region'))");       
            migrationBuilder.Sql("INSERT INTO VariableXls (Code, SheetName, DifForYerasX, DifForYerasY, DifForDataX, DifForDataY, VariableId) VALUES ('C_A06a', " +
                                                                                                                                                     "'Global results'," + 
                                                                                                                                                     "2," +
                                                                                                                                                     "3," +
                                                                                                                                                     "1," + 
                                                                                                                                                     "4," + 
                                                                                                                                                    "(SELECT ID FROM Variables WHERE Name = 'Carbon price'))");

            migrationBuilder.Sql("INSERT INTO VariableXls (Code, SheetName, DifForYerasX, DifForYerasY, DifForDataX, DifForDataY, VariableId) VALUES ('C_A09a', " +
                                                                                                                                                     "'Global results'," + 
                                                                                                                                                     "2," +
                                                                                                                                                     "3," +
                                                                                                                                                     "1," + 
                                                                                                                                                     "4," + 
                                                                                                                                                    "(SELECT ID FROM Variables WHERE Name = 'System costs'))");       
                                                                                                                                                    

            migrationBuilder.Sql("INSERT INTO VariableXls (Code, SheetName, DifForYerasX, DifForYerasY, DifForDataX, DifForDataY, VariableId) VALUES ('C_A08c', " +
                                                                                                                                                     "'Global results'," + 
                                                                                                                                                     "2," +
                                                                                                                                                     "3," +
                                                                                                                                                     "1," + 
                                                                                                                                                     "4," + 
                                                                                                                                                    "(SELECT ID FROM Variables WHERE Name = 'Fuel consumption by technology' AND VariableGroupId = (SELECT ID FROM VariableGroups WHERE Name = '______')))");       
            migrationBuilder.Sql("INSERT INTO VariableXls (Code, SheetName, DifForYerasX, DifForYerasY, DifForDataX, DifForDataY, VariableId) VALUES ('C_A10a', " +
                                                                                                                                                     "'Global results'," + 
                                                                                                                                                     "2," +
                                                                                                                                                     "3," +
                                                                                                                                                     "1," + 
                                                                                                                                                     "4," + 
                                                                                                                                                    "(SELECT ID FROM Variables WHERE Name = 'Fuel consumption by technology' AND VariableGroupId = (SELECT ID FROM VariableGroups WHERE Name = '______')))");       
            migrationBuilder.Sql("INSERT INTO VariableXls (Code, SheetName, DifForYerasX, DifForYerasY, DifForDataX, DifForDataY, VariableId) VALUES ('C_A10b', " +
                                                                                                                                                     "'Global results'," + 
                                                                                                                                                     "2," +
                                                                                                                                                     "3," +
                                                                                                                                                     "1," + 
                                                                                                                                                     "4," + 
                                                                                                                                                    "(SELECT ID FROM Variables WHERE Name = 'Fuel consumption by technology' AND VariableGroupId = (SELECT ID FROM VariableGroups WHERE Name = '______')))");       
            migrationBuilder.Sql("INSERT INTO VariableXls (Code, SheetName, DifForYerasX, DifForYerasY, DifForDataX, DifForDataY, VariableId) VALUES ('________', " +
                                                                                                                                                     "'Global results'," + 
                                                                                                                                                     "2," +
                                                                                                                                                     "3," +
                                                                                                                                                     "1," + 
                                                                                                                                                     "4," + 
                                                                                                                                                    "(SELECT ID FROM Variables WHERE Name = 'Fuel consumption by technology' AND VariableGroupId = (SELECT ID FROM VariableGroups WHERE Name = '______')))");       
            migrationBuilder.Sql("INSERT INTO VariableXls (Code, SheetName, DifForYerasX, DifForYerasY, DifForDataX, DifForDataY, VariableId) VALUES ('________', " +
                                                                                                                                                     "'Global results'," + 
                                                                                                                                                     "2," +
                                                                                                                                                     "3," +
                                                                                                                                                     "1," + 
                                                                                                                                                     "4," + 
                                                                                                                                                    "(SELECT ID FROM Variables WHERE Name = 'Fuel consumption by technology' AND VariableGroupId = (SELECT ID FROM VariableGroups WHERE Name = '______')))");       





                                                                                                                                                    
                                                                                                                                                    


                                                                                                                                                    
                                                                                                                                                    
                                                                                                                                                    
                                                                                                                                                    
                                                                                                                                                    
                                                                                                                                                    
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
