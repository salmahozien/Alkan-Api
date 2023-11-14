using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class AddHomeLimits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "homeLimits",
                columns: table => new
                {
                    HomeLimitsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    From = table.Column<int>(type: "int", nullable: false),
                    To = table.Column<int>(type: "int", nullable: false),
                    NetPremium = table.Column<int>(type: "int", nullable: false),
                    TotalInstallment = table.Column<int>(type: "int", nullable: false),
                    HomeCompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_homeLimits", x => x.HomeLimitsId);
                    table.ForeignKey(
                        name: "FK_homeLimits_HomeCompany_HomeCompanyId",
                        column: x => x.HomeCompanyId,
                        principalTable: "HomeCompany",
                        principalColumn: "HomeCompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_homeLimits_HomeCompanyId",
                table: "homeLimits",
                column: "HomeCompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "homeLimits");
        }
    }
}
