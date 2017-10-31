using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NXS.Migrations
{
    public partial class VariableDailyDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO SubVariables (Name) VALUES ('WD-OFF')");
            migrationBuilder.Sql("INSERT INTO SubVariables (Name) VALUES ('WD-MID')");
            migrationBuilder.Sql("INSERT INTO SubVariables (Name) VALUES ('WD-ON')");
            migrationBuilder.Sql("INSERT INTO SubVariables (Name) VALUES ('WE-OFF')");
            migrationBuilder.Sql("INSERT INTO SubVariables (Name) VALUES ('WE-MID')");
            migrationBuilder.Sql("INSERT INTO SubVariables (Name) VALUES ('WE-ON')");
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM VariableGroups WHERE Name IN ('WD-OFF'," +
                                                                           "'WD-MID'," +
                                                                           "'WD-ON'," +
                                                                           "'WE-OFF'," +
                                                                           "'WE-MID'," +
                                                                           "'WE-ON')");            
        }
    }
}