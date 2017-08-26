using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NXS.Migrations
{
    public partial class AgreegationSubVariables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgreegationSubVariables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    VariableId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgreegationSubVariables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgreegationSubVariables_Variables_VariableId",
                        column: x => x.VariableId,
                        principalTable: "Variables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AgreegationSubVariableSubVariables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgreegationSubVariableId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgreegationSubVariableSubVariables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgreegationSubVariableSubVariables_AgreegationSubVariables_AgreegationSubVariableId",
                        column: x => x.AgreegationSubVariableId,
                        principalTable: "AgreegationSubVariables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgrigationXlsDescriptions_RegionAgrigationTypeId",
                table: "AgrigationXlsDescriptions",
                column: "RegionAgrigationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AgreegationSubVariables_VariableId",
                table: "AgreegationSubVariables",
                column: "VariableId");

            migrationBuilder.CreateIndex(
                name: "IX_AgreegationSubVariableSubVariables_AgreegationSubVariableId",
                table: "AgreegationSubVariableSubVariables",
                column: "AgreegationSubVariableId");

            migrationBuilder.AddForeignKey(
                name: "FK_AgrigationXlsDescriptions_RegionAgrigationTypes_RegionAgrigationTypeId",
                table: "AgrigationXlsDescriptions",
                column: "RegionAgrigationTypeId",
                principalTable: "RegionAgrigationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AgrigationXlsDescriptions_RegionAgrigationTypes_RegionAgrigationTypeId",
                table: "AgrigationXlsDescriptions");

            migrationBuilder.DropTable(
                name: "AgreegationSubVariableSubVariables");

            migrationBuilder.DropTable(
                name: "AgreegationSubVariables");

            migrationBuilder.DropIndex(
                name: "IX_AgrigationXlsDescriptions_RegionAgrigationTypeId",
                table: "AgrigationXlsDescriptions");
        }
    }
}
