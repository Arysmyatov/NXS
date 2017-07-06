using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NXS.Migrations
{
    public partial class Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KeyParameterId = table.Column<int>(nullable: false),
                    KeyParameterLevelId = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: false),
                    ScenarioId = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    VariableId = table.Column<int>(nullable: false),
                    Year = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Data_KeyParameters_KeyParameterId",
                        column: x => x.KeyParameterId,
                        principalTable: "KeyParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Data_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Data_Scenarios_ScenarioId",
                        column: x => x.ScenarioId,
                        principalTable: "Scenarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Data_Variables_VariableId",
                        column: x => x.VariableId,
                        principalTable: "Variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Data_KeyParameterId",
                table: "Data",
                column: "KeyParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_Data_RegionId",
                table: "Data",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Data_ScenarioId",
                table: "Data",
                column: "ScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Data_VariableId",
                table: "Data",
                column: "VariableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Data");
        }
    }
}
