using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NXS.Migrations
{
    public partial class InitialCreate : Migration
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

            migrationBuilder.CreateTable(
                name: "ParentRegions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentRegions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Scenarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scenarios", x => x.Id);
                });

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
                name: "VariableGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariableGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeyParameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KeyParameterGroupId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeyParameters_KeyParameterGroups_KeyParameterGroupId",
                        column: x => x.KeyParameterGroupId,
                        principalTable: "KeyParameterGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    ParentRegionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Regions_ParentRegions_ParentRegionId",
                        column: x => x.ParentRegionId,
                        principalTable: "ParentRegions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Variables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    VariableGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Variables_VariableGroups_VariableGroupId",
                        column: x => x.VariableGroupId,
                        principalTable: "VariableGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    SubVariableId = table.Column<int>(nullable: false),
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
                        name: "FK_Data_KeyParameterLevels_KeyParameterLevelId",
                        column: x => x.KeyParameterLevelId,
                        principalTable: "KeyParameterLevels",
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
                        name: "FK_Data_SubVariables_SubVariableId",
                        column: x => x.SubVariableId,
                        principalTable: "SubVariables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Data_Variables_VariableId",
                        column: x => x.VariableId,
                        principalTable: "Variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_Data_KeyParameterId",
                table: "Data",
                column: "KeyParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_Data_KeyParameterLevelId",
                table: "Data",
                column: "KeyParameterLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Data_RegionId",
                table: "Data",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Data_ScenarioId",
                table: "Data",
                column: "ScenarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Data_SubVariableId",
                table: "Data",
                column: "SubVariableId");

            migrationBuilder.CreateIndex(
                name: "IX_Data_VariableId",
                table: "Data",
                column: "VariableId");

            migrationBuilder.CreateIndex(
                name: "IX_KeyParameters_KeyParameterGroupId",
                table: "KeyParameters",
                column: "KeyParameterGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_ParentRegionId",
                table: "Regions",
                column: "ParentRegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Variables_VariableGroupId",
                table: "Variables",
                column: "VariableGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_VariableXls_VariableId",
                table: "VariableXls",
                column: "VariableId",
                unique: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Data");

            migrationBuilder.DropTable(
                name: "VariableXls");

            migrationBuilder.DropTable(
                name: "XlsUploads");

            migrationBuilder.DropTable(
                name: "KeyParameters");

            migrationBuilder.DropTable(
                name: "SubVariables");

            migrationBuilder.DropTable(
                name: "Variables");

            migrationBuilder.DropTable(
                name: "KeyParameterLevels");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Scenarios");

            migrationBuilder.DropTable(
                name: "KeyParameterGroups");

            migrationBuilder.DropTable(
                name: "VariableGroups");

            migrationBuilder.DropTable(
                name: "ParentRegions");
        }
    }
}
