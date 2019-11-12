using Microsoft.EntityFrameworkCore.Migrations;

namespace eTeatar.Data.Migrations
{
    public partial class Izbacenaadresakupca : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "Kupac");

            migrationBuilder.DropColumn(
                name: "BrojAdrese",
                table: "Kupac");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "Kupac",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrojAdrese",
                table: "Kupac",
                nullable: false,
                defaultValue: 0);
        }
    }
}
