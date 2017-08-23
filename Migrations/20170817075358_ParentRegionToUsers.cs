using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class ParentRegionToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentRegionId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ParentRegionId",
                table: "AspNetUsers",
                column: "ParentRegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ParentRegions_ParentRegionId",
                table: "AspNetUsers",
                column: "ParentRegionId",
                principalTable: "ParentRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ParentRegions_ParentRegionId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ParentRegionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ParentRegionId",
                table: "AspNetUsers");
        }
    }
}
