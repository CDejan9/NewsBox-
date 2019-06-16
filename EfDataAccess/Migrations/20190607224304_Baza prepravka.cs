using Microsoft.EntityFrameworkCore.Migrations;

namespace EfDataAccess.Migrations
{
    public partial class Bazaprepravka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komentars_Korisniks_KorisnikId",
                table: "Komentars");

            migrationBuilder.DropForeignKey(
                name: "FK_Komentars_Vests_VestId",
                table: "Komentars");

            migrationBuilder.DropColumn(
                name: "Id_Vest",
                table: "Slikas");

            migrationBuilder.DropColumn(
                name: "Id_Uloga",
                table: "Korisniks");

            migrationBuilder.DropColumn(
                name: "Id_Korisnik",
                table: "Komentars");

            migrationBuilder.DropColumn(
                name: "Id_Vest",
                table: "Komentars");

            migrationBuilder.AlterColumn<int>(
                name: "VestId",
                table: "Komentars",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "KorisnikId",
                table: "Komentars",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Komentars_Korisniks_KorisnikId",
                table: "Komentars",
                column: "KorisnikId",
                principalTable: "Korisniks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Komentars_Vests_VestId",
                table: "Komentars",
                column: "VestId",
                principalTable: "Vests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Komentars_Korisniks_KorisnikId",
                table: "Komentars");

            migrationBuilder.DropForeignKey(
                name: "FK_Komentars_Vests_VestId",
                table: "Komentars");

            migrationBuilder.AddColumn<int>(
                name: "Id_Vest",
                table: "Slikas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id_Uloga",
                table: "Korisniks",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VestId",
                table: "Komentars",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "KorisnikId",
                table: "Komentars",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "Id_Korisnik",
                table: "Komentars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id_Vest",
                table: "Komentars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Komentars_Korisniks_KorisnikId",
                table: "Komentars",
                column: "KorisnikId",
                principalTable: "Korisniks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Komentars_Vests_VestId",
                table: "Komentars",
                column: "VestId",
                principalTable: "Vests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
