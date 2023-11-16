using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class EditPersonalAccidentLimit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NetPremium",
                table: "PersonalAccidentLimit",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalInstallment",
                table: "PersonalAccidentLimit",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NetPremium",
                table: "PersonalAccidentLimit");

            migrationBuilder.DropColumn(
                name: "TotalInstallment",
                table: "PersonalAccidentLimit");
        }
    }
}
