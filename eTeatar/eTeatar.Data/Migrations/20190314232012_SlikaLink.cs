using Microsoft.EntityFrameworkCore.Migrations;

namespace eTeatar.Data.Migrations
{
    public partial class SlikaLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SlikaLink",
                table: "Predstava",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlikaLink",
                table: "Obavijest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlikaLink",
                table: "Glumac",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SlikaLink",
                table: "Predstava");

            migrationBuilder.DropColumn(
                name: "SlikaLink",
                table: "Obavijest");

            migrationBuilder.DropColumn(
                name: "SlikaLink",
                table: "Glumac");
        }
    }
}
