using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NXS.Migrations
{
    public partial class KeyParameterGroups : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KeyParameterGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyParameterGroups", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeyParameters_KeyParameterGroupId",
                table: "KeyParameters",
                column: "KeyParameterGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_KeyParameters_KeyParameterGroups_KeyParameterGroupId",
                table: "KeyParameters",
                column: "KeyParameterGroupId",
                principalTable: "KeyParameterGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeyParameters_KeyParameterGroups_KeyParameterGroupId",
                table: "KeyParameters");

            migrationBuilder.DropTable(
                name: "KeyParameterGroups");

            migrationBuilder.DropIndex(
                name: "IX_KeyParameters_KeyParameterGroupId",
                table: "KeyParameters");
        }
    }
}
