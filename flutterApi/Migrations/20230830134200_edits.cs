using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class edits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreviewerReportImages");

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "previewerReports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "reportImageDb",
                columns: table => new
                {
                    ReportImageDbId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportImageDbName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportImageDbPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reportImageDb", x => x.ReportImageDbId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "reportImageDb");

            migrationBuilder.DropColumn(
                name: "Images",
                table: "previewerReports");

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
        }
    }
}
