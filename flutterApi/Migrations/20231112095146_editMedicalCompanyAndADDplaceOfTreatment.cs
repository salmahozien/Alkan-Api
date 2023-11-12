using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class editMedicalCompanyAndADDplaceOfTreatment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "medicalCompanies",
                newName: "MedicalCompanyId");

            migrationBuilder.AddColumn<int>(
                name: "MedicalCompanyId",
                table: "placeOfTreatments",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_placeOfTreatments_MedicalCompanyId",
                table: "placeOfTreatments",
                column: "MedicalCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_placeOfTreatments_medicalCompanies_MedicalCompanyId",
                table: "placeOfTreatments",
                column: "MedicalCompanyId",
                principalTable: "medicalCompanies",
                principalColumn: "MedicalCompanyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_placeOfTreatments_medicalCompanies_MedicalCompanyId",
                table: "placeOfTreatments");

            migrationBuilder.DropIndex(
                name: "IX_placeOfTreatments_MedicalCompanyId",
                table: "placeOfTreatments");

            migrationBuilder.DropColumn(
                name: "MedicalCompanyId",
                table: "placeOfTreatments");

            migrationBuilder.RenameColumn(
                name: "MedicalCompanyId",
                table: "medicalCompanies",
                newName: "Id");
        }
    }
}
