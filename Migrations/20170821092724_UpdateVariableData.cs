using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NXS.Migrations
{
    public partial class UpdateVariableData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_VariableData",
                table: "VariableData");

            migrationBuilder.RenameTable(
                name: "VariableData",
                newName: "ProcessSet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProcessSet",
                table: "ProcessSet",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "VariableData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeId = table.Column<int>(nullable: true),
                    CommodityId = table.Column<int>(nullable: true),
                    CommoditySetId = table.Column<int>(nullable: true),
                    KeyParameterId = table.Column<int>(nullable: false),
                    KeyParameterLevelId = table.Column<int>(nullable: false),
                    ProcessSetId = table.Column<int>(nullable: true),
                    RegionId = table.Column<int>(nullable: true),
                    ScenarioId = table.Column<int>(nullable: false),
                    UserConstraintId = table.Column<int>(nullable: true),
                    Value = table.Column<decimal>(nullable: false),
                    VariableId = table.Column<int>(nullable: false),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariableData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VariableData_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VariableData_CommoditySet_CommoditySetId",
                        column: x => x.CommoditySetId,
                        principalTable: "CommoditySet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VariableData_KeyParameters_KeyParameterId",
                        column: x => x.KeyParameterId,
                        principalTable: "KeyParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VariableData_KeyParameterLevels_KeyParameterLevelId",
                        column: x => x.KeyParameterLevelId,
                        principalTable: "KeyParameterLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VariableData_ProcessSet_ProcessSetId",
                        column: x => x.ProcessSetId,
                        principalTable: "ProcessSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VariableData_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VariableData_Scenarios_ScenarioId",
                        column: x => x.ScenarioId,
                        principalTable: "Scenarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VariableData_UserConstraint_UserConstraintId",
                        column: x => x.UserConstraintId,
                        principalTable: "UserConstraint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VariableData_Variables_VariableId",
                        column: x => x.VariableId,
                        principalTable: "Variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VariableData_AttributeId",
                table: "VariableData",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_VariableData_CommoditySetId",
                table: "VariableData",
                column: "CommoditySetId");

            migrationBuilder.CreateIndex(
                name: "IX_VariableData_KeyParameterId",
                table: "VariableData",
                column: "KeyParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_VariableData_KeyParameterLevelId",
                table: "VariableData",
                column: "KeyParameterLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_VariableData_ProcessSetId",
                table: "VariableData",
                column: "ProcessSetId");

            migrationBuilder.CreateIndex(
                name: "IX_VariableData_RegionId",
                table: "VariableData",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_VariableData_ScenarioId",
                table: "VariableData",
                column: "ScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_VariableData_UserConstraintId",
                table: "VariableData",
                column: "UserConstraintId");

            migrationBuilder.CreateIndex(
                name: "IX_VariableData_VariableId",
                table: "VariableData",
                column: "VariableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VariableData");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProcessSet",
                table: "ProcessSet");

            migrationBuilder.RenameTable(
                name: "ProcessSet",
                newName: "VariableData");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VariableData",
                table: "VariableData",
                column: "Id");
        }
    }
}
