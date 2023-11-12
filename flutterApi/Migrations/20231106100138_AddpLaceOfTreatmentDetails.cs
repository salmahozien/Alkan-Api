using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class AddpLaceOfTreatmentDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PlaceOfTreatmentDetails",
                columns: table => new
                {
                    PlaceOfTreatmentDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlaceOfTreatmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceOfTreatmentDetails", x => x.PlaceOfTreatmentDetailsId);
                    table.ForeignKey(
                        name: "FK_PlaceOfTreatmentDetails_placeOfTreatments_PlaceOfTreatmentId",
                        column: x => x.PlaceOfTreatmentId,
                        principalTable: "placeOfTreatments",
                        principalColumn: "PlaceOfTreatmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlaceOfTreatmentDetails_PlaceOfTreatmentId",
                table: "PlaceOfTreatmentDetails",
                column: "PlaceOfTreatmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlaceOfTreatmentDetails");
        }
    }
}
