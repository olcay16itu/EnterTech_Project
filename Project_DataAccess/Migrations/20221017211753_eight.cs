using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_DataAccess.Migrations
{
    public partial class eight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoris",
                columns: table => new
                {
                    KategoriID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAd = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoris", x => x.KategoriID);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciRols",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciRols", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Sehirs",
                columns: table => new
                {
                    SehirID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SehirAdı = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sehirs", x => x.SehirID);
                });

            migrationBuilder.CreateTable(
                name: "Etkinliks",
                columns: table => new
                {
                    EtkinlikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EtkinlikAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EtkinlikYeri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EtkinlikKisiLimiti = table.Column<int>(type: "int", nullable: false),
                    EtkinlikTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTicket = table.Column<bool>(type: "bit", nullable: false),
                    KategoriID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etkinliks", x => x.EtkinlikID);
                    table.ForeignKey(
                        name: "FK_Etkinliks_Kategoris_KategoriID",
                        column: x => x.KategoriID,
                        principalTable: "Kategoris",
                        principalColumn: "KategoriID");
                });

            migrationBuilder.CreateTable(
                name: "Kullanicis",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciRegisterID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciMail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KullaniciSifre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciYas = table.Column<int>(type: "int", nullable: false),
                    kullaniciRolRoleID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicis", x => x.KullaniciID);
                    table.UniqueConstraint("AlternateKey_c.kullanicimail", x => x.KullaniciMail);
                    table.ForeignKey(
                        name: "FK_Kullanicis_KullaniciRols_kullaniciRolRoleID",
                        column: x => x.kullaniciRolRoleID,
                        principalTable: "KullaniciRols",
                        principalColumn: "RoleID");
                });

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

            migrationBuilder.CreateTable(
                name: "EtkinlikKullanici",
                columns: table => new
                {
                    EtkinlikID = table.Column<int>(type: "int", nullable: false),
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EtkinlikKullanici", x => new { x.EtkinlikID, x.KullaniciID });
                    table.ForeignKey(
                        name: "FK_EtkinlikKullanici_Etkinliks_EtkinlikID",
                        column: x => x.EtkinlikID,
                        principalTable: "Etkinliks",
                        principalColumn: "EtkinlikID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EtkinlikKullanici_Kullanicis_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicis",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EtkinlikKullanici_KullaniciID",
                table: "EtkinlikKullanici",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Etkinliks_KategoriID",
                table: "Etkinliks",
                column: "KategoriID");

            migrationBuilder.CreateIndex(
                name: "IX_EtkinlikSehir_SehirID",
                table: "EtkinlikSehir",
                column: "SehirID");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicis_kullaniciRolRoleID",
                table: "Kullanicis",
                column: "kullaniciRolRoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EtkinlikKullanici");

            migrationBuilder.DropTable(
                name: "EtkinlikSehir");

            migrationBuilder.DropTable(
                name: "Kullanicis");

            migrationBuilder.DropTable(
                name: "Etkinliks");

            migrationBuilder.DropTable(
                name: "Sehirs");

            migrationBuilder.DropTable(
                name: "KullaniciRols");

            migrationBuilder.DropTable(
                name: "Kategoris");
        }
    }
}
