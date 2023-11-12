using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class EditPlaceOfTreatmentMedicalCompanyId3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_placeOfTreatments_medicalCompanies_MedicalCompanyId",
                table: "placeOfTreatments");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalCompanyId",
                table: "placeOfTreatments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "MedicalCompanyId",
                table: "placeOfTreatments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_placeOfTreatments_medicalCompanies_MedicalCompanyId",
                table: "placeOfTreatments",
                column: "MedicalCompanyId",
                principalTable: "medicalCompanies",
                principalColumn: "MedicalCompanyId");
        }
    }
}
