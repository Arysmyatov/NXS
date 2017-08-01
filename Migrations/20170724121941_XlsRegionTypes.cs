using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NXS.Migrations
{
    public partial class XlsRegionTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "XlsRegionTypeId",
                table: "VariableXls",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "XlsRegionTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XlsRegionTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VariableXls_XlsRegionTypeId",
                table: "VariableXls",
                column: "XlsRegionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VariableXls_XlsRegionTypes_XlsRegionTypeId",
                table: "VariableXls",
                column: "XlsRegionTypeId",
                principalTable: "XlsRegionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VariableXls_XlsRegionTypes_XlsRegionTypeId",
                table: "VariableXls");

            migrationBuilder.DropTable(
                name: "XlsRegionTypes");

            migrationBuilder.DropIndex(
                name: "IX_VariableXls_XlsRegionTypeId",
                table: "VariableXls");

            migrationBuilder.DropColumn(
                name: "XlsRegionTypeId",
                table: "VariableXls");
        }
    }
}
