using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class AddCompanyHealthInsuranceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "compsnyHealthInsuranceTypes",
                columns: table => new
                {
                    CompanyHealthInsuranceTypesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    MedicalCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compsnyHealthInsuranceTypes", x => x.CompanyHealthInsuranceTypesId);
                    table.ForeignKey(
                        name: "FK_compsnyHealthInsuranceTypes_medicalCompanies_MedicalCompanyId",
                        column: x => x.MedicalCompanyId,
                        principalTable: "medicalCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_compsnyHealthInsuranceTypes_MedicalCompanyId",
                table: "compsnyHealthInsuranceTypes",
                column: "MedicalCompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "compsnyHealthInsuranceTypes");
        }
    }
}
