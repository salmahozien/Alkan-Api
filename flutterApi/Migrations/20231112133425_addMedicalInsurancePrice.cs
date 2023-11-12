﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class addMedicalInsurancePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "medicalInsurancePrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Premium = table.Column<float>(type: "real", nullable: false),
                    CompanyHealthInsuranceTypesId = table.Column<int>(type: "int", nullable: false),
                    AgeLimitsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medicalInsurancePrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_medicalInsurancePrices_ageLimits_AgeLimitsId",
                        column: x => x.AgeLimitsId,
                        principalTable: "ageLimits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_medicalInsurancePrices_compsnyHealthInsuranceTypes_CompanyHealthInsuranceTypesId",
                        column: x => x.CompanyHealthInsuranceTypesId,
                        principalTable: "compsnyHealthInsuranceTypes",
                        principalColumn: "CompanyHealthInsuranceTypesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_medicalInsurancePrices_AgeLimitsId",
                table: "medicalInsurancePrices",
                column: "AgeLimitsId");

            migrationBuilder.CreateIndex(
                name: "IX_medicalInsurancePrices_CompanyHealthInsuranceTypesId",
                table: "medicalInsurancePrices",
                column: "CompanyHealthInsuranceTypesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "medicalInsurancePrices");
        }
    }
}
