using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NXS.Migrations
{
    public partial class KeyParameters_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "KeyParameterLevelId",
                table: "KeyParameters",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KeyParameterLevels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyParameterLevels", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeyParameters_KeyParameterLevelId",
                table: "KeyParameters",
                column: "KeyParameterLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_KeyParameters_KeyParameterLevels_KeyParameterLevelId",
                table: "KeyParameters",
                column: "KeyParameterLevelId",
                principalTable: "KeyParameterLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeyParameters_KeyParameterLevels_KeyParameterLevelId",
                table: "KeyParameters");

            migrationBuilder.DropTable(
                name: "KeyParameterLevels");

            migrationBuilder.DropIndex(
                name: "IX_KeyParameters_KeyParameterLevelId",
                table: "KeyParameters");

            migrationBuilder.DropColumn(
                name: "KeyParameterLevelId",
                table: "KeyParameters");
        }
    }
}
