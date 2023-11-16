using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class addPersonalAccidentCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalAccidentCompanies",
                columns: table => new
                {
                    PersonalAccidentCompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalAccidentCompanies", x => x.PersonalAccidentCompanyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalAccidentCompanies");
        }
    }
}
