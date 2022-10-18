using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_DataAccess.Migrations
{
    public partial class elev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AlternateKey_c.kullanicimail",
                table: "Kullanicis");

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciMail",
                table: "Kullanicis",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "KullaniciMail",
                table: "Kullanicis",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddUniqueConstraint(
                name: "AlternateKey_c.kullanicimail",
                table: "Kullanicis",
                column: "KullaniciMail");
        }
    }
}
