using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NXS.Migrations
{
    public partial class SubVariableDataUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentRegionId",
                table: "SubVariableData",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableData_ParentRegionId",
                table: "SubVariableData",
                column: "ParentRegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubVariableData_ParentRegions_ParentRegionId",
                table: "SubVariableData",
                column: "ParentRegionId",
                principalTable: "ParentRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubVariableData_ParentRegions_ParentRegionId",
                table: "SubVariableData");

            migrationBuilder.DropIndex(
                name: "IX_SubVariableData_ParentRegionId",
                table: "SubVariableData");

            migrationBuilder.DropColumn(
                name: "ParentRegionId",
                table: "SubVariableData");
        }
    }
}
