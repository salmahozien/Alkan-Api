using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class addPersonalImages2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "personalImagesUrls",
                columns: table => new
                {
                    personalImagesUrlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCard = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalDrivingLicense = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CarLicense = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personalImagesUrls", x => x.personalImagesUrlId);
                    table.ForeignKey(
                        name: "FK_personalImagesUrls_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_personalImagesUrls_UserId",
                table: "personalImagesUrls",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "personalImagesUrls");
        }
    }
}
