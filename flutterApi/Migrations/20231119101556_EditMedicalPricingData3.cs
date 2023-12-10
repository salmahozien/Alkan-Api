using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class EditMedicalPricingData3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyHealthInsuranceTypesId",
                table: "medicalPricingsData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MedicalCompanyId",
                table: "medicalPricingsData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_medicalPricingsData_CompanyHealthInsuranceTypesId",
                table: "medicalPricingsData",
                column: "CompanyHealthInsuranceTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_medicalPricingsData_MedicalCompanyId",
                table: "medicalPricingsData",
                column: "MedicalCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_medicalPricingsData_compsnyHealthInsuranceTypes_CompanyHealthInsuranceTypesId",
                table: "medicalPricingsData",
                column: "CompanyHealthInsuranceTypesId",
                principalTable: "compsnyHealthInsuranceTypes",
                principalColumn: "CompanyHealthInsuranceTypesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_medicalPricingsData_medicalCompanies_MedicalCompanyId",
                table: "medicalPricingsData",
                column: "MedicalCompanyId",
                principalTable: "medicalCompanies",
                principalColumn: "MedicalCompanyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medicalPricingsData_compsnyHealthInsuranceTypes_CompanyHealthInsuranceTypesId",
                table: "medicalPricingsData");

            migrationBuilder.DropForeignKey(
                name: "FK_medicalPricingsData_medicalCompanies_MedicalCompanyId",
                table: "medicalPricingsData");

            migrationBuilder.DropIndex(
                name: "IX_medicalPricingsData_CompanyHealthInsuranceTypesId",
                table: "medicalPricingsData");

            migrationBuilder.DropIndex(
                name: "IX_medicalPricingsData_MedicalCompanyId",
                table: "medicalPricingsData");

            migrationBuilder.DropColumn(
                name: "CompanyHealthInsuranceTypesId",
                table: "medicalPricingsData");

            migrationBuilder.DropColumn(
                name: "MedicalCompanyId",
                table: "medicalPricingsData");
        }
    }
}
