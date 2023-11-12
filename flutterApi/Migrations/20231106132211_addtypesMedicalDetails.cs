using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class addtypesMedicalDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "typesMedicalDetails",
                columns: table => new
                {
                    CompanyHealthInsuranceTypesId = table.Column<int>(type: "int", nullable: false),
                    PlaceOfTreatmentDetailsId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_typesMedicalDetails", x => new { x.CompanyHealthInsuranceTypesId, x.PlaceOfTreatmentDetailsId });
                    table.ForeignKey(
                        name: "FK_typesMedicalDetails_compsnyHealthInsuranceTypes_CompanyHealthInsuranceTypesId",
                        column: x => x.CompanyHealthInsuranceTypesId,
                        principalTable: "compsnyHealthInsuranceTypes",
                        principalColumn: "CompanyHealthInsuranceTypesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_typesMedicalDetails_PlaceOfTreatmentDetails_PlaceOfTreatmentDetailsId",
                        column: x => x.PlaceOfTreatmentDetailsId,
                        principalTable: "PlaceOfTreatmentDetails",
                        principalColumn: "PlaceOfTreatmentDetailsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_typesMedicalDetails_PlaceOfTreatmentDetailsId",
                table: "typesMedicalDetails",
                column: "PlaceOfTreatmentDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "typesMedicalDetails");
        }
    }
}
