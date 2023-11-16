using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class AddPersonalAccidentPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonalAccidentPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PersonalAccidentCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalAccidentPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalAccidentPrice_PersonalAccidentCompanies_PersonalAccidentCompanyId",
                        column: x => x.PersonalAccidentCompanyId,
                        principalTable: "PersonalAccidentCompanies",
                        principalColumn: "PersonalAccidentCompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalAccidentPrice_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalAccidentPrice_PersonalAccidentCompanyId",
                table: "PersonalAccidentPrice",
                column: "PersonalAccidentCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalAccidentPrice_UserId",
                table: "PersonalAccidentPrice",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalAccidentPrice");
        }
    }
}
