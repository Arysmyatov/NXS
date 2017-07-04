using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class Variables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variable_VariableGroups_VariableGroupId",
                table: "Variable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Variable",
                table: "Variable");

            migrationBuilder.RenameTable(
                name: "Variable",
                newName: "Variables");

            migrationBuilder.RenameIndex(
                name: "IX_Variable_VariableGroupId",
                table: "Variables",
                newName: "IX_Variables_VariableGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Variables",
                table: "Variables",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Variables_VariableGroups_VariableGroupId",
                table: "Variables",
                column: "VariableGroupId",
                principalTable: "VariableGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Variables_VariableGroups_VariableGroupId",
                table: "Variables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Variables",
                table: "Variables");

            migrationBuilder.RenameTable(
                name: "Variables",
                newName: "Variable");

            migrationBuilder.RenameIndex(
                name: "IX_Variables_VariableGroupId",
                table: "Variable",
                newName: "IX_Variable_VariableGroupId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Variable",
                table: "Variable",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Variable_VariableGroups_VariableGroupId",
                table: "Variable",
                column: "VariableGroupId",
                principalTable: "VariableGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
