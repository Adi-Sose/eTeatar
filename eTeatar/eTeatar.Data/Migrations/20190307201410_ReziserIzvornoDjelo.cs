using Microsoft.EntityFrameworkCore.Migrations;

namespace eTeatar.Data.Migrations
{
    public partial class ReziserIzvornoDjelo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Godina",
                table: "Predstava");

            migrationBuilder.AddColumn<string>(
                name: "NazivIzvornogDjela",
                table: "Predstava",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ReziserImePrezime",
                table: "Predstava",
                maxLength: 128,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NazivIzvornogDjela",
                table: "Predstava");

            migrationBuilder.DropColumn(
                name: "ReziserImePrezime",
                table: "Predstava");

            migrationBuilder.AddColumn<int>(
                name: "Godina",
                table: "Predstava",
                nullable: false,
                defaultValue: 0);
        }
    }
}
