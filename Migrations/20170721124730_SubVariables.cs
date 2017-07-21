using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NXS.Migrations
{
    public partial class SubVariables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubVariableId",
                table: "Data",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SubVariables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubVariables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "XlsUploads",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(maxLength: 255, nullable: false),
                    KeyParameterId = table.Column<int>(nullable: false),
                    KeyParameterLevelId = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: true),
                    ScenarioId = table.Column<int>(nullable: false),
                    UploadDate = table.Column<DateTime>(nullable: false)
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_XlsUploads_Scenarios_ScenarioId",
                        column: x => x.ScenarioId,
                        principalTable: "Scenarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Data_KeyParameterLevelId",
                table: "Data",
                column: "KeyParameterLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Data_SubVariableId",
                table: "Data",
                column: "SubVariableId");

            migrationBuilder.CreateIndex(
                name: "IX_XlsUploads_KeyParameterLevelId",
                table: "XlsUploads",
                column: "KeyParameterLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_XlsUploads_RegionId",
                table: "XlsUploads",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_XlsUploads_ScenarioId",
                table: "XlsUploads",
                column: "ScenarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Data_KeyParameterLevels_KeyParameterLevelId",
                table: "Data",
                column: "KeyParameterLevelId",
                principalTable: "KeyParameterLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Data_SubVariables_SubVariableId",
                table: "Data",
                column: "SubVariableId",
                principalTable: "SubVariables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Data_KeyParameterLevels_KeyParameterLevelId",
                table: "Data");

            migrationBuilder.DropForeignKey(
                name: "FK_Data_SubVariables_SubVariableId",
                table: "Data");

            migrationBuilder.DropTable(
                name: "SubVariables");

            migrationBuilder.DropTable(
                name: "XlsUploads");

            migrationBuilder.DropIndex(
                name: "IX_Data_KeyParameterLevelId",
                table: "Data");

            migrationBuilder.DropIndex(
                name: "IX_Data_SubVariableId",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "SubVariableId",
                table: "Data");
        }
    }
}
