using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class XlsUploadUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScenarioId",
                table: "XlsUploads",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UploadDate",
                table: "XlsUploads",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_XlsUploads_Scenarios_ScenarioId",
                table: "XlsUploads");

            migrationBuilder.DropIndex(
                name: "IX_XlsUploads_ScenarioId",
                table: "XlsUploads");

            migrationBuilder.DropColumn(
                name: "ScenarioId",
                table: "XlsUploads");

            migrationBuilder.DropColumn(
                name: "UploadDate",
                table: "XlsUploads");
        }
    }
}
