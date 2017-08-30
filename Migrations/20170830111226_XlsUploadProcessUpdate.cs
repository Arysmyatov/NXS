using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NXS.Migrations
{
    public partial class XlsUploadProcessUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsProcessed",
                table: "XlsUploads",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProcessDate",
                table: "XlsUploads",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsProcessed",
                table: "XlsUploads");

            migrationBuilder.DropColumn(
                name: "ProcessDate",
                table: "XlsUploads");
        }
    }
}
