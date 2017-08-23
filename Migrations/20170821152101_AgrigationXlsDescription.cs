using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NXS.Migrations
{
    public partial class AgrigationXlsDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "AgrigationXlsDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeCol = table.Column<int>(nullable: false, defaultValue: 0),
                    CommodityCol = table.Column<int>(nullable: false, defaultValue: 0),
                    CommoditySetCol = table.Column<int>(nullable: false, defaultValue: 0),
                    ProcessSetCol = table.Column<int>(nullable: false, defaultValue: 0),
                    RegionAgrigationTypeId = table.Column<int>(nullable: false),
                    RowBg = table.Column<int>(nullable: false),
                    RowEnd = table.Column<int>(nullable: false),
                    SheetName = table.Column<string>(nullable: true),
                    SubVariableCol = table.Column<int>(nullable: false),
                    UserConstraintCol = table.Column<int>(nullable: false, defaultValue: 0),
                    VariableId = table.Column<int>(nullable: false),
                    YearColBg = table.Column<int>(nullable: false),
                    YearColEnd = table.Column<int>(nullable: false),
                    YearRowBg = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgrigationXlsDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgrigationXlsDescriptions_Variables_VariableId",
                        column: x => x.VariableId,
                        principalTable: "Variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegionAgrigationTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionAgrigationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubVariableData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeId = table.Column<int>(nullable: true, defaultValue: 0),
                    CommodityId = table.Column<int>(nullable: true, defaultValue: 0),
                    CommoditySetId = table.Column<int>(nullable: true, defaultValue: 0),
                    KeyParameterId = table.Column<int>(nullable: false),
                    KeyParameterLevelId = table.Column<int>(nullable: false),
                    ProcessSetId = table.Column<int>(nullable: true, defaultValue: 0),
                    RegionAgrigationTypeId = table.Column<int>(nullable: false),
                    RegionId = table.Column<int>(nullable: true),
                    ScenarioId = table.Column<int>(nullable: false),
                    SubVariableId = table.Column<int>(nullable: false),
                    UserConstraintId = table.Column<int>(nullable: true, defaultValue: 0),
                    Value = table.Column<decimal>(nullable: false),
                    VariableId = table.Column<int>(nullable: false),
                    Year = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubVariableData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubVariableData_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubVariableData_CommoditySet_CommoditySetId",
                        column: x => x.CommoditySetId,
                        principalTable: "CommoditySet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubVariableData_KeyParameters_KeyParameterId",
                        column: x => x.KeyParameterId,
                        principalTable: "KeyParameters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubVariableData_KeyParameterLevels_KeyParameterLevelId",
                        column: x => x.KeyParameterLevelId,
                        principalTable: "KeyParameterLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubVariableData_ProcessSet_ProcessSetId",
                        column: x => x.ProcessSetId,
                        principalTable: "ProcessSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubVariableData_RegionAgrigationTypes_RegionAgrigationTypeId",
                        column: x => x.RegionAgrigationTypeId,
                        principalTable: "RegionAgrigationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubVariableData_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubVariableData_Scenarios_ScenarioId",
                        column: x => x.ScenarioId,
                        principalTable: "Scenarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubVariableData_SubVariables_SubVariableId",
                        column: x => x.SubVariableId,
                        principalTable: "SubVariables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubVariableData_UserConstraint_UserConstraintId",
                        column: x => x.UserConstraintId,
                        principalTable: "UserConstraint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SubVariableData_Variables_VariableId",
                        column: x => x.VariableId,
                        principalTable: "Variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgrigationXlsDescriptions_VariableId",
                table: "AgrigationXlsDescriptions",
                column: "VariableId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableData_AttributeId",
                table: "SubVariableData",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableData_CommoditySetId",
                table: "SubVariableData",
                column: "CommoditySetId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableData_KeyParameterId",
                table: "SubVariableData",
                column: "KeyParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableData_KeyParameterLevelId",
                table: "SubVariableData",
                column: "KeyParameterLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableData_ProcessSetId",
                table: "SubVariableData",
                column: "ProcessSetId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableData_RegionAgrigationTypeId",
                table: "SubVariableData",
                column: "RegionAgrigationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableData_RegionId",
                table: "SubVariableData",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableData_ScenarioId",
                table: "SubVariableData",
                column: "ScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableData_SubVariableId",
                table: "SubVariableData",
                column: "SubVariableId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableData_UserConstraintId",
                table: "SubVariableData",
                column: "UserConstraintId");

            migrationBuilder.CreateIndex(
                name: "IX_SubVariableData_VariableId",
                table: "SubVariableData",
                column: "VariableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgrigationXlsDescriptions");

            migrationBuilder.DropTable(
                name: "SubVariableData");

            migrationBuilder.DropTable(
                name: "RegionAgrigationTypes");

            migrationBuilder.AddColumn<int>(
                name: "XlsRegionTypeId",
                table: "VariableXls",
                nullable: false,
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
    }
}
