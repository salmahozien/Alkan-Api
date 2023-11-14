using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class AddCompanyIdToHomeCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HomeCompanyId",
                table: "homePrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HomeCompnayId",
                table: "homePrices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_homePrices_HomeCompanyId",
                table: "homePrices",
                column: "HomeCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_homePrices_HomeCompany_HomeCompanyId",
                table: "homePrices",
                column: "HomeCompanyId",
                principalTable: "HomeCompany",
                principalColumn: "HomeCompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_homePrices_HomeCompany_HomeCompanyId",
                table: "homePrices");

            migrationBuilder.DropIndex(
                name: "IX_homePrices_HomeCompanyId",
                table: "homePrices");

            migrationBuilder.DropColumn(
                name: "HomeCompanyId",
                table: "homePrices");

            migrationBuilder.DropColumn(
                name: "HomeCompnayId",
                table: "homePrices");
        }
    }
}
