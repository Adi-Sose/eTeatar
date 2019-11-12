using Microsoft.EntityFrameworkCore.Migrations;

namespace eTeatar.Data.Migrations
{
    public partial class TipKorisnikaRekurzivno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IduciTipKorisnikaId",
                table: "TipKorisnika",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TipKorisnika_IduciTipKorisnikaId",
                table: "TipKorisnika",
                column: "IduciTipKorisnikaId");

            migrationBuilder.AddForeignKey(
                name: "FK_TipKorisnika_TipKorisnika_IduciTipKorisnikaId",
                table: "TipKorisnika",
                column: "IduciTipKorisnikaId",
                principalTable: "TipKorisnika",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TipKorisnika_TipKorisnika_IduciTipKorisnikaId",
                table: "TipKorisnika");

            migrationBuilder.DropIndex(
                name: "IX_TipKorisnika_IduciTipKorisnikaId",
                table: "TipKorisnika");

            migrationBuilder.DropColumn(
                name: "IduciTipKorisnikaId",
                table: "TipKorisnika");
        }
    }
}
