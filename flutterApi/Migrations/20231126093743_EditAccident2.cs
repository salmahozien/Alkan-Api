using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class EditAccident2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accidents_policies_PolicyId",
                table: "Accidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Accidents_Users_UserId",
                table: "Accidents");

            migrationBuilder.DropColumn(
                name: "AccidentLocation",
                table: "Accidents");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "Accidents");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Accidents",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<int>(
                name: "PolicyId",
                table: "Accidents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Accidents",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Accidents",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Accidents_policies_PolicyId",
                table: "Accidents",
                column: "PolicyId",
                principalTable: "policies",
                principalColumn: "PolicyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accidents_Users_UserId",
                table: "Accidents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accidents_policies_PolicyId",
                table: "Accidents");

            migrationBuilder.DropForeignKey(
                name: "FK_Accidents_Users_UserId",
                table: "Accidents");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Accidents");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Accidents");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Accidents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PolicyId",
                table: "Accidents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AccidentLocation",
                table: "Accidents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Accidents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Accidents_policies_PolicyId",
                table: "Accidents",
                column: "PolicyId",
                principalTable: "policies",
                principalColumn: "PolicyId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Accidents_Users_UserId",
                table: "Accidents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
