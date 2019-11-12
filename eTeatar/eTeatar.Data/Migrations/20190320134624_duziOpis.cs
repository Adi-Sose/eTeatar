using Microsoft.EntityFrameworkCore.Migrations;

namespace eTeatar.Data.Migrations
{
    public partial class duziOpis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Opis",
                table: "Predstava",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 512);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Opis",
                table: "Predstava",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
