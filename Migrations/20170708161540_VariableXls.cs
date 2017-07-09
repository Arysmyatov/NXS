using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NXS.Migrations
{
    public partial class VariableXls : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VariableXls",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 50, nullable: false),
                    DataBgCol = table.Column<int>(nullable: false),
                    DataBgRow = table.Column<int>(nullable: false),
                    DataEndCol = table.Column<int>(nullable: false),
                    DataEndRow = table.Column<int>(nullable: false),
                    SheetName = table.Column<string>(nullable: true),
                    VariableId = table.Column<int>(nullable: false),
                    YearBgCol = table.Column<int>(nullable: false),
                    YearBgRow = table.Column<int>(nullable: false),
                    YearEndCol = table.Column<int>(nullable: false),
                    YearEndRow = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariableXls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VariableXls_Variables_VariableId",
                        column: x => x.VariableId,
                        principalTable: "Variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VariableXls_VariableId",
                table: "VariableXls",
                column: "VariableId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VariableXls");
        }
    }
}
