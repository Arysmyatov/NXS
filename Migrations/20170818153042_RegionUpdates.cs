using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class RegionUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_XlsUploads_Regions_RegionId",
                table: "XlsUploads");

            migrationBuilder.DropIndex(
                name: "IX_XlsUploads_RegionId",
                table: "XlsUploads");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "XlsUploads");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "XlsUploads",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_XlsUploads_RegionId",
                table: "XlsUploads",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_XlsUploads_Regions_RegionId",
                table: "XlsUploads",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
