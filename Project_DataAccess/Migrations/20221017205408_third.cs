using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_DataAccess.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Etkinliks_Sehirs_SehirID",
                table: "Etkinliks");

            migrationBuilder.DropIndex(
                name: "IX_Etkinliks_SehirID",
                table: "Etkinliks");

            migrationBuilder.DropColumn(
                name: "SehirID",
                table: "Etkinliks");

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

            migrationBuilder.CreateTable(
                name: "EtkinlikSehir",
                columns: table => new
                {
                    EtkinlikID = table.Column<int>(type: "int", nullable: false),
                    SehirID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtkinlikSehir", x => new { x.EtkinlikID, x.SehirID });
                    table.ForeignKey(
                        name: "FK_EtkinlikSehir_Etkinliks_EtkinlikID",
                        column: x => x.EtkinlikID,
                        principalTable: "Etkinliks",
                        principalColumn: "EtkinlikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtkinlikSehir_Sehirs_SehirID",
                        column: x => x.SehirID,
                        principalTable: "Sehirs",
                        principalColumn: "SehirID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EtkinlikSehir_SehirID",
                table: "EtkinlikSehir",
                column: "SehirID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EtkinlikSehir");

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

            migrationBuilder.AddColumn<int>(
                name: "SehirID",
                table: "Etkinliks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Etkinliks_SehirID",
                table: "Etkinliks",
                column: "SehirID");

            migrationBuilder.AddForeignKey(
                name: "FK_Etkinliks_Sehirs_SehirID",
                table: "Etkinliks",
                column: "SehirID",
                principalTable: "Sehirs",
                principalColumn: "SehirID");
        }
    }
}
