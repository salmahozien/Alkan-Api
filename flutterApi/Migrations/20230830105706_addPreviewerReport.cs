using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class addPreviewerReport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "previewerReports",
                columns: table => new
                {
                    PreviewerReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Report = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Video = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_previewerReports", x => x.PreviewerReportId);
                    table.ForeignKey(
                        name: "FK_previewerReports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PreviewerReportImages",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviewerReportId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreviewerReportImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreviewerReportImages_previewerReports_PreviewerReportId",
                        column: x => x.PreviewerReportId,
                        principalTable: "previewerReports",
                        principalColumn: "PreviewerReportId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreviewerReportImages_PreviewerReportId",
                table: "PreviewerReportImages",
                column: "PreviewerReportId");

            migrationBuilder.CreateIndex(
                name: "IX_previewerReports_UserId",
                table: "previewerReports",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreviewerReportImages");

            migrationBuilder.DropTable(
                name: "previewerReports");
        }
    }
}
