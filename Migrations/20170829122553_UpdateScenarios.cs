using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class UpdateScenarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_XlsUploads_Scenarios_ScenarioId",
                table: "XlsUploads");

            migrationBuilder.DropIndex(
                name: "IX_XlsUploads_ScenarioId",
                table: "XlsUploads");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_XlsUploads_ScenarioId",
                table: "XlsUploads",
                column: "ScenarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_XlsUploads_Scenarios_ScenarioId",
                table: "XlsUploads",
                column: "ScenarioId",
                principalTable: "Scenarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
