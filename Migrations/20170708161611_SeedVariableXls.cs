﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class SeedVariableXls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[VariableXls] ([Code], [DataBgCol], [DataBgRow], [DataEndCol], [DataEndRow], [SheetName], [YearBgCol], [YearBgRow], [YearEndCol], [YearEndRow],[VariableId]) VALUES ('', '2', '193', '11', '203', 'Global Results', '3', '192', '11', '192', (SELECT ID FROM Variables WHERE Name = 'Final Energy Consumption : By fuel'))");
            migrationBuilder.Sql("INSERT INTO [dbo].[VariableXls] ([Code], [DataBgCol], [DataBgRow], [DataEndCol], [DataEndRow], [SheetName], [YearBgCol], [YearBgRow], [YearEndCol], [YearEndRow],[VariableId]) VALUES ('', '2', '126', '11', '146', 'Global Results', '3', '125', '11', '125', (SELECT ID FROM Variables WHERE Name = 'Primary Energy: Imports/Exports'))");
            migrationBuilder.Sql("INSERT INTO [dbo].[VariableXls] ([Code], [DataBgCol], [DataBgRow], [DataEndCol], [DataEndRow], [SheetName], [YearBgCol], [YearBgRow], [YearEndCol], [YearEndRow],[VariableId]) VALUES ('', '2', '218', '11', '218', 'Global Results', '3', '209', '11', '209', (SELECT ID FROM Variables WHERE Name = 'Final Energy Consumption : By sector'))");
            migrationBuilder.Sql("INSERT INTO [dbo].[VariableXls] ([Code], [DataBgCol], [DataBgRow], [DataEndCol], [DataEndRow], [SheetName], [YearBgCol], [YearBgRow], [YearEndCol], [YearEndRow],[VariableId]) VALUES ('', '2', '7', '11', '24', 'Global Results', '3', '6', '11', '6', (SELECT ID FROM Variables WHERE Name = 'Generation'))");
            migrationBuilder.Sql("INSERT INTO [dbo].[VariableXls] ([Code], [DataBgCol], [DataBgRow], [DataEndCol], [DataEndRow], [SheetName], [YearBgCol], [YearBgRow], [YearEndCol], [YearEndRow],[VariableId]) VALUES ('', '2', '31', '11', '31', 'Global Results', '3', '29', '11', '29', (SELECT ID FROM Variables WHERE Name = 'CO2 intensity'))");
            migrationBuilder.Sql("INSERT INTO [dbo].[VariableXls] ([Code], [DataBgCol], [DataBgRow], [DataEndCol], [DataEndRow], [SheetName], [YearBgCol], [YearBgRow], [YearEndCol], [YearEndRow],[VariableId]) VALUES ('', '2', '37', '11', '46', 'Global Results', '3', '36', '11', '36', (SELECT ID FROM Variables WHERE Name = 'Consumption by sector'))");
            migrationBuilder.Sql("INSERT INTO [dbo].[VariableXls] ([Code], [DataBgCol], [DataBgRow], [DataEndCol], [DataEndRow], [SheetName], [YearBgCol], [YearBgRow], [YearEndCol], [YearEndRow],[VariableId]) VALUES ('', '2', '53', '11', '70', 'Global Results', '3', '52', '11', '52', (SELECT ID FROM Variables WHERE Name = 'Capacity'))");
            migrationBuilder.Sql("INSERT INTO [dbo].[VariableXls] ([Code], [DataBgCol], [DataBgRow], [DataEndCol], [DataEndRow], [SheetName], [YearBgCol], [YearBgRow], [YearEndCol], [YearEndRow],[VariableId]) VALUES ('', '3', '77', '11', '94', 'Global Results', '3', '76', '11', '76', (SELECT ID FROM Variables WHERE Name = 'Annualised investment costs'))");
            migrationBuilder.Sql("INSERT INTO [dbo].[VariableXls] ([Code], [DataBgCol], [DataBgRow], [DataEndCol], [DataEndRow], [SheetName], [YearBgCol], [YearBgRow], [YearEndCol], [YearEndRow],[VariableId]) VALUES ('', '2', '225', '11', '245', 'Global Results', '3', '224', '11', '224', (SELECT ID FROM Variables WHERE Name = 'CO2 emissions by sector'))");
            migrationBuilder.Sql("INSERT INTO [dbo].[VariableXls] ([Code], [DataBgCol], [DataBgRow], [DataEndCol], [DataEndRow], [SheetName], [YearBgCol], [YearBgRow], [YearEndCol], [YearEndRow],[VariableId]) VALUES ('', '2', '264', '11', '284', 'Global Results', '3', '263', '11', '263', (SELECT ID FROM Variables WHERE Name = 'Non-CO2 emissions by sector'))");
            migrationBuilder.Sql("INSERT INTO [dbo].[VariableXls] ([Code], [DataBgCol], [DataBgRow], [DataEndCol], [DataEndRow], [SheetName], [YearBgCol], [YearBgRow], [YearEndCol], [YearEndRow],[VariableId]) VALUES ('', '2', '292', '11', '292', 'Global Results', '3', '291', '11', '291', (SELECT ID FROM Variables WHERE Name = 'CO2 emissions by region'))");
            migrationBuilder.Sql("INSERT INTO [dbo].[VariableXls] ([Code], [DataBgCol], [DataBgRow], [DataEndCol], [DataEndRow], [SheetName], [YearBgCol], [YearBgRow], [YearEndCol], [YearEndRow],[VariableId]) VALUES ('', '2', '359', '11', '369', 'Global Results', '3', '358', '11', '358', (SELECT ID FROM Variables WHERE Name = 'Carbon price'))");
            migrationBuilder.Sql("INSERT INTO [dbo].[VariableXls] ([Code], [DataBgCol], [DataBgRow], [DataEndCol], [DataEndRow], [SheetName], [YearBgCol], [YearBgRow], [YearEndCol], [YearEndRow],[VariableId]) VALUES ('', '2', '721', '11', '736', 'Global Results', '3', '720', '11', '720', (SELECT ID FROM Variables WHERE Name = 'System costs'))");
            migrationBuilder.Sql("INSERT INTO [dbo].[VariableXls] ([Code], [DataBgCol], [DataBgRow], [DataEndCol], [DataEndRow], [SheetName], [YearBgCol], [YearBgRow], [YearEndCol], [YearEndRow],[VariableId]) VALUES ('', '2', '557', '11', '622', 'Global Results', '3', '556', '11', '556', (SELECT ID FROM Variables WHERE Name = 'Fuel consumption by technology' AND VariableGroupId = (SELECT ID FROM VariableGroups WHERE Name = 'Transport')))");
            migrationBuilder.Sql("INSERT INTO [dbo].[VariableXls] ([Code], [DataBgCol], [DataBgRow], [DataEndCol], [DataEndRow], [SheetName], [YearBgCol], [YearBgRow], [YearEndCol], [YearEndRow],[VariableId]) VALUES ('', '2', '786', '11', '792', 'Global Results', '3', '785', '11', '785', (SELECT ID FROM Variables WHERE Name = 'Fuel consumption by technology' AND VariableGroupId = (SELECT ID FROM VariableGroups WHERE Name = 'Industry')))");
            migrationBuilder.Sql("INSERT INTO [dbo].[VariableXls] ([Code], [DataBgCol], [DataBgRow], [DataEndCol], [DataEndRow], [SheetName], [YearBgCol], [YearBgRow], [YearEndCol], [YearEndRow],[VariableId]) VALUES ('', '2', '879', '11', '879', 'Global Results', '3', '860', '11', '860', (SELECT ID FROM Variables WHERE Name = 'Fuel consumption by technology' AND VariableGroupId = (SELECT ID FROM VariableGroups WHERE Name = 'Residential')))");
            migrationBuilder.Sql("INSERT INTO [dbo].[VariableXls] ([Code], [DataBgCol], [DataBgRow], [DataEndCol], [DataEndRow], [SheetName], [YearBgCol], [YearBgRow], [YearEndCol], [YearEndRow],[VariableId]) VALUES ('', '2', '870', '11', '877', 'Global Results', '3', '860', '11', '860', (SELECT ID FROM Variables WHERE Name = 'Fuel consumption by technology' AND VariableGroupId = (SELECT ID FROM VariableGroups WHERE Name = 'Commercial')))");
            migrationBuilder.Sql("INSERT INTO [dbo].[VariableXls] ([Code], [DataBgCol], [DataBgRow], [DataEndCol], [DataEndRow], [SheetName], [YearBgCol], [YearBgRow], [YearEndCol], [YearEndRow],[VariableId]) VALUES ('', '2', '861', '11', '868', 'Global Results', '3', '860', '11', '860', (SELECT ID FROM Variables WHERE Name = 'Fuel consumption by technology' AND VariableGroupId = (SELECT ID FROM VariableGroups WHERE Name = 'Agriculture')))");            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
