using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NXS.Migrations
{
    public partial class NxsUserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ParentRegions_ParentRegionId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ParentRegionId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ParentRegions_ParentRegionId",
                table: "AspNetUsers",
                column: "ParentRegionId",
                principalTable: "ParentRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ParentRegions_ParentRegionId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ParentRegionId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ParentRegions_ParentRegionId",
                table: "AspNetUsers",
                column: "ParentRegionId",
                principalTable: "ParentRegions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
