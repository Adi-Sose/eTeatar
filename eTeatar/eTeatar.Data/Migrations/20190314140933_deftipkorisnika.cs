using Microsoft.EntityFrameworkCore.Migrations;

namespace eTeatar.Data.Migrations
{
    public partial class deftipkorisnika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsOsnovni",
                table: "TipKorisnika",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOsnovni",
                table: "TipKorisnika");
        }
    }
}
