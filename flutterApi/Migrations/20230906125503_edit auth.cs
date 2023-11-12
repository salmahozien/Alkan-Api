using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class editauth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "insuranceRequests",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_insuranceRequests_UserId",
                table: "insuranceRequests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_insuranceRequests_Users_UserId",
                table: "insuranceRequests",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_insuranceRequests_Users_UserId",
                table: "insuranceRequests");

            migrationBuilder.DropIndex(
                name: "IX_insuranceRequests_UserId",
                table: "insuranceRequests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "insuranceRequests");
        }
    }
}
