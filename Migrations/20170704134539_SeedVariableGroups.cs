using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class SeedVariableGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //VariableGroups
            migrationBuilder.Sql("INSERT INTO VariableGroups (Name) VALUES ('Top')");
            migrationBuilder.Sql("INSERT INTO VariableGroups (Name) VALUES ('Bottom')");
            migrationBuilder.Sql("INSERT INTO VariableGroups (Name) VALUES ('Primary Energy')");
            migrationBuilder.Sql("INSERT INTO VariableGroups (Name) VALUES ('Final Energy Consumption')");
            migrationBuilder.Sql("INSERT INTO VariableGroups (Name) VALUES ('Electricity')");
            migrationBuilder.Sql("INSERT INTO VariableGroups (Name) VALUES ('Emissiones')");
            migrationBuilder.Sql("INSERT INTO VariableGroups (Name) VALUES ('Transport')");
            migrationBuilder.Sql("INSERT INTO VariableGroups (Name) VALUES ('Industry')");
            migrationBuilder.Sql("INSERT INTO VariableGroups (Name) VALUES ('Residential')");
            migrationBuilder.Sql("INSERT INTO VariableGroups (Name) VALUES ('Commercial')");
            migrationBuilder.Sql("INSERT INTO VariableGroups (Name) VALUES ('Agriculture')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM VariableGroups WHERE Name IN ('Primary Energy'," +
                                                                           "'Top'," +
                                                                           "'Bottom'," +
                                                                           "'Final Energy Consumption'," +
                                                                           "'Electricity'," + 
                                                                           "'Emissiones'," + 
                                                                           "'Transport'," + 
                                                                           "'Industry'," +
                                                                           "'Residential'," +
                                                                           "'Commercial'," +
                                                                           "'Agriculture',)");
        }
    }
}
