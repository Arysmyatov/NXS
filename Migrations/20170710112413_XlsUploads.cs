using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NXS.Migrations
{
    public partial class XlsUploads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "XlsUploads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(maxLength: 255, nullable: false),
                    KeyParameterLevelId = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XlsUploads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XlsUploads_KeyParameterLevels_KeyParameterLevelId",
                        column: x => x.KeyParameterLevelId,
                        principalTable: "KeyParameterLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_XlsUploads_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_XlsUploads_KeyParameterLevelId",
                table: "XlsUploads",
                column: "KeyParameterLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_XlsUploads_RegionId",
                table: "XlsUploads",
                column: "RegionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "XlsUploads");
        }
    }
}
