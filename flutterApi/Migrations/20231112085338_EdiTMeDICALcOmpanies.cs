using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace flutterApi.Migrations
{
    public partial class EdiTMeDICALcOmpanies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_CompanyInfo_CompanyInfoId",
                table: "Insurances");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyInfoId",
                table: "Insurances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_CompanyInfo_CompanyInfoId",
                table: "Insurances",
                column: "CompanyInfoId",
                principalTable: "CompanyInfo",
                principalColumn: "CompanyInfoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_CompanyInfo_CompanyInfoId",
                table: "Insurances");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyInfoId",
                table: "Insurances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_CompanyInfo_CompanyInfoId",
                table: "Insurances",
                column: "CompanyInfoId",
                principalTable: "CompanyInfo",
                principalColumn: "CompanyInfoId");
        }
    }
}
