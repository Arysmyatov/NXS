using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NXS.Migrations
{
    public partial class SubVariableDailyData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubVariableDailyData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeId = table.Column<int>(type: "int", nullable: true),
                    CommodityId = table.Column<int>(type: "int", nullable: true),
                    CommoditySetId = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KeyParameterId = table.Column<int>(type: "int", nullable: false),
                    KeyParameterLevelId = table.Column<int>(type: "int", nullable: false),
                    ParentRegionId = table.Column<int>(type: "int", nullable: true),
                    ProcessSetId = table.Column<int>(type: "int", nullable: true),
                    RegionAgrigationTypeId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: true),
                    ScenarioId = table.Column<int>(type: "int", nullable: false),
                    SubVariableId = table.Column<int>(type: "int", nullable: false),
                    UserConstraintId = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    VariableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubVariableDailyData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubVariableDailyData_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubVariableDailyData_CommoditySet_CommoditySetId",
                        column: x => x.CommoditySetId,
                        principalTable: "CommoditySet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubVariableDailyData_KeyParameters_KeyParameterId",
                        column: x => x.KeyParameterId,
                        principalTable: "KeyParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubVariableDailyData_KeyParameterLevels_KeyParameterLevelId",
                        column: x => x.KeyParameterLevelId,
                        principalTable: "KeyParameterLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubVariableDailyData_ParentRegions_ParentRegionId",
                        column: x => x.ParentRegionId,
                        principalTable: "ParentRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubVariableDailyData_ProcessSet_ProcessSetId",
                        column: x => x.ProcessSetId,
                        principalTable: "ProcessSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubVariableDailyData_RegionAgrigationTypes_RegionAgrigationTypeId",
                        column: x => x.RegionAgrigationTypeId,
                        principalTable: "RegionAgrigationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubVariableDailyData_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubVariableDailyData_Scenarios_ScenarioId",
                        column: x => x.ScenarioId,
                        principalTable: "Scenarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubVariableDailyData_SubVariables_SubVariableId",
                        column: x => x.SubVariableId,
                        principalTable: "SubVariables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubVariableDailyData_UserConstraint_UserConstraintId",
                        column: x => x.UserConstraintId,
                        principalTable: "UserConstraint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubVariableDailyData_Variables_VariableId",
                        column: x => x.VariableId,
                        principalTable: "Variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableDailyData_AttributeId",
                table: "SubVariableDailyData",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableDailyData_CommoditySetId",
                table: "SubVariableDailyData",
                column: "CommoditySetId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableDailyData_KeyParameterId",
                table: "SubVariableDailyData",
                column: "KeyParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableDailyData_KeyParameterLevelId",
                table: "SubVariableDailyData",
                column: "KeyParameterLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableDailyData_ParentRegionId",
                table: "SubVariableDailyData",
                column: "ParentRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableDailyData_ProcessSetId",
                table: "SubVariableDailyData",
                column: "ProcessSetId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableDailyData_RegionAgrigationTypeId",
                table: "SubVariableDailyData",
                column: "RegionAgrigationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableDailyData_RegionId",
                table: "SubVariableDailyData",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableDailyData_ScenarioId",
                table: "SubVariableDailyData",
                column: "ScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableDailyData_SubVariableId",
                table: "SubVariableDailyData",
                column: "SubVariableId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableDailyData_UserConstraintId",
                table: "SubVariableDailyData",
                column: "UserConstraintId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableDailyData_VariableId",
                table: "SubVariableDailyData",
                column: "VariableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubVariableDailyData");
        }
    }
}
