using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfDataAccess.Migrations
{
    public partial class prvamigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorijas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kreirano = table.Column<DateTime>(nullable: false),
                    Modifikovano = table.Column<DateTime>(nullable: true),
                    Obrisano = table.Column<bool>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorijas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ulogas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kreirano = table.Column<DateTime>(nullable: false),
                    Modifikovano = table.Column<DateTime>(nullable: true),
                    Obrisano = table.Column<bool>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ulogas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kreirano = table.Column<DateTime>(nullable: false),
                    Modifikovano = table.Column<DateTime>(nullable: true),
                    Obrisano = table.Column<bool>(nullable: false),
                    Naslov = table.Column<string>(nullable: true),
                    Tekst = table.Column<string>(nullable: true),
                    Id_Kategorija = table.Column<int>(nullable: true),
                    KategorijaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vests_Kategorijas_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorijas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Korisniks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kreirano = table.Column<DateTime>(nullable: false),
                    Modifikovano = table.Column<DateTime>(nullable: true),
                    Obrisano = table.Column<bool>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Lozinka = table.Column<string>(nullable: true),
                    Id_Uloga = table.Column<int>(nullable: true),
                    UlogaId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisniks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisniks_Ulogas_UlogaId",
                        column: x => x.UlogaId,
                        principalTable: "Ulogas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Slikas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kreirano = table.Column<DateTime>(nullable: false),
                    Modifikovano = table.Column<DateTime>(nullable: true),
                    Obrisano = table.Column<bool>(nullable: false),
                    Alt = table.Column<string>(nullable: true),
                    Putanja = table.Column<string>(nullable: true),
                    Id_Vest = table.Column<int>(nullable: true),
                    VestId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slikas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slikas_Vests_VestId",
                        column: x => x.VestId,
                        principalTable: "Vests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Komentars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kreirano = table.Column<DateTime>(nullable: false),
                    Modifikovano = table.Column<DateTime>(nullable: true),
                    Obrisano = table.Column<bool>(nullable: false),
                    Komentar_Tekst = table.Column<string>(nullable: true),
                    Id_Vest = table.Column<int>(nullable: false),
                    Id_Korisnik = table.Column<int>(nullable: false),
                    VestId = table.Column<int>(nullable: true),
                    KorisnikId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komentars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Komentars_Korisniks_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisniks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Komentars_Vests_VestId",
                        column: x => x.VestId,
                        principalTable: "Vests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Komentars_KorisnikId",
                table: "Komentars",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Komentars_VestId",
                table: "Komentars",
                column: "VestId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisniks_UlogaId",
                table: "Korisniks",
                column: "UlogaId");

            migrationBuilder.CreateIndex(
                name: "IX_Slikas_VestId",
                table: "Slikas",
                column: "VestId");

            migrationBuilder.CreateIndex(
                name: "IX_Vests_KategorijaId",
                table: "Vests",
                column: "KategorijaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Komentars");

            migrationBuilder.DropTable(
                name: "Slikas");

            migrationBuilder.DropTable(
                name: "Korisniks");

            migrationBuilder.DropTable(
                name: "Vests");

            migrationBuilder.DropTable(
                name: "Ulogas");

            migrationBuilder.DropTable(
                name: "Kategorijas");
        }
    }
}
