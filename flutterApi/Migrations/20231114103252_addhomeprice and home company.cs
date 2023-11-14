using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class addhomepriceandhomecompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeCompany",
                columns: table => new
                {
                    HomeCompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeCompany", x => x.HomeCompanyId);
                });

            migrationBuilder.CreateTable(
                name: "homePrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HomeCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_homePrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_homePrices_HomeCompany_HomeCompanyId",
                        column: x => x.HomeCompanyId,
                        principalTable: "HomeCompany",
                        principalColumn: "HomeCompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_homePrices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_homePrices_HomeCompanyId",
                table: "homePrices",
                column: "HomeCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_homePrices_UserId",
                table: "homePrices",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "homePrices");

            migrationBuilder.DropTable(
                name: "HomeCompany");
        }
    }
}
