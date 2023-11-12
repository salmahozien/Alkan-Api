using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class EditpERSONALiMAGES : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PersonalImages",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalImages_UserId",
                table: "PersonalImages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalImages_Users_UserId",
                table: "PersonalImages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonalImages_Users_UserId",
                table: "PersonalImages");

            migrationBuilder.DropIndex(
                name: "IX_PersonalImages_UserId",
                table: "PersonalImages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PersonalImages");
        }
    }
}
