using Microsoft.EntityFrameworkCore.Migrations;

namespace eTeatar.Data.Migrations
{
    public partial class KupacID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Kupac",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Kupac");
        }
    }
}
