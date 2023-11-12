using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class edithealth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_placeOfTreatments_compsnyHealthInsuranceTypes_CompanyHealthInsuranceTypesId",
                table: "placeOfTreatments");

            migrationBuilder.DropIndex(
                name: "IX_placeOfTreatments_CompanyHealthInsuranceTypesId",
                table: "placeOfTreatments");

            migrationBuilder.DropColumn(
                name: "CompanyHealthInsuranceTypesId",
                table: "placeOfTreatments");

            migrationBuilder.AddColumn<string>(
                name: "RegWay",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegWay",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "CompanyHealthInsuranceTypesId",
                table: "placeOfTreatments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_placeOfTreatments_CompanyHealthInsuranceTypesId",
                table: "placeOfTreatments",
                column: "CompanyHealthInsuranceTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_placeOfTreatments_compsnyHealthInsuranceTypes_CompanyHealthInsuranceTypesId",
                table: "placeOfTreatments",
                column: "CompanyHealthInsuranceTypesId",
                principalTable: "compsnyHealthInsuranceTypes",
                principalColumn: "CompanyHealthInsuranceTypesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
