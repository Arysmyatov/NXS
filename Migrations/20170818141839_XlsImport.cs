using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NXS.Migrations
{
    public partial class XlsImport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Commodities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commodities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommoditySet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommoditySet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VariableData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariableData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserConstraint",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConstraint", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VariableXlsDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeCol = table.Column<int>(nullable: false, defaultValue: 0),
                    CommodityCol = table.Column<int>(nullable: false, defaultValue: 0),
                    CommoditySetCol = table.Column<int>(nullable: false, defaultValue: 0),
                    ProcessSetCol = table.Column<int>(nullable: false, defaultValue: 0),
                    RegionCol = table.Column<int>(nullable: false, defaultValue: 0),
                    RowBg = table.Column<int>(nullable: false, defaultValue: 0),
                    RowEnd = table.Column<int>(nullable: false, defaultValue: 0),
                    SheetName = table.Column<string>(nullable: true),
                    UserConstraintCol = table.Column<int>(nullable: false, defaultValue: 0),
                    VariableId = table.Column<int>(nullable: false),
                    YearColBg = table.Column<int>(nullable: false),
                    YearColEnd = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VariableXlsDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VariableXlsDescriptions_Variables_VariableId",
                        column: x => x.VariableId,
                        principalTable: "Variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VariableXlsDescriptions_VariableId",
                table: "VariableXlsDescriptions",
                column: "VariableId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "Commodities");

            migrationBuilder.DropTable(
                name: "CommoditySet");

            migrationBuilder.DropTable(
                name: "VariableData");

            migrationBuilder.DropTable(
                name: "UserConstraint");

            migrationBuilder.DropTable(
                name: "VariableXlsDescriptions");
        }
    }
}
