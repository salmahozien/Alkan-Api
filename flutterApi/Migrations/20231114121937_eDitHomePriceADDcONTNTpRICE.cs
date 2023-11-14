using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class eDitHomePriceADDcONTNTpRICE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "homePrices");

            migrationBuilder.AddColumn<double>(
                name: "PriceOfBuildings",
                table: "homePrices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PriceOfTheContentOfBuilding",
                table: "homePrices",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceOfBuildings",
                table: "homePrices");

            migrationBuilder.DropColumn(
                name: "PriceOfTheContentOfBuilding",
                table: "homePrices");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "homePrices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
