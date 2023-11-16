using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class AddPersonalAccidentLimit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalAccidentLimit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<int>(type: "int", nullable: false),
                    PersonalAccidentCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalAccidentLimit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalAccidentLimit_PersonalAccidentCompanies_PersonalAccidentCompanyId",
                        column: x => x.PersonalAccidentCompanyId,
                        principalTable: "PersonalAccidentCompanies",
                        principalColumn: "PersonalAccidentCompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalAccidentLimit_PersonalAccidentCompanyId",
                table: "PersonalAccidentLimit",
                column: "PersonalAccidentCompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalAccidentLimit");
        }
    }
}
