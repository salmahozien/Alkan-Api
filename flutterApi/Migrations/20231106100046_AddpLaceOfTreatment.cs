using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class AddpLaceOfTreatment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "placeOfTreatments",
                columns: table => new
                {
                    PlaceOfTreatmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyHealthInsuranceTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_placeOfTreatments", x => x.PlaceOfTreatmentId);
                    table.ForeignKey(
                        name: "FK_placeOfTreatments_compsnyHealthInsuranceTypes_CompanyHealthInsuranceTypesId",
                        column: x => x.CompanyHealthInsuranceTypesId,
                        principalTable: "compsnyHealthInsuranceTypes",
                        principalColumn: "CompanyHealthInsuranceTypesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_placeOfTreatments_CompanyHealthInsuranceTypesId",
                table: "placeOfTreatments",
                column: "CompanyHealthInsuranceTypesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "placeOfTreatments");
        }
    }
}
