using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_DataAccess.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kullanicis_KullaniciRols_kullaniciRolRoleID",
                table: "Kullanicis");

            migrationBuilder.AlterColumn<int>(
                name: "kullaniciRolRoleID",
                table: "Kullanicis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanicis_KullaniciRols_kullaniciRolRoleID",
                table: "Kullanicis",
                column: "kullaniciRolRoleID",
                principalTable: "KullaniciRols",
                principalColumn: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kullanicis_KullaniciRols_kullaniciRolRoleID",
                table: "Kullanicis");

            migrationBuilder.AlterColumn<int>(
                name: "kullaniciRolRoleID",
                table: "Kullanicis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanicis_KullaniciRols_kullaniciRolRoleID",
                table: "Kullanicis",
                column: "kullaniciRolRoleID",
                principalTable: "KullaniciRols",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
