using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web2Project.Migrations
{
    public partial class Migracija1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Lozinka = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImeIPrezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRodjenja = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    TipKoorisnika = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Verifikovan = table.Column<bool>(type: "bit", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Novac = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Porudzbina",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProdavacId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KupacId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Informacija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    Cena = table.Column<double>(type: "float", nullable: false),
                    VremeDostave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KorisnikEmail = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KorisnikEmail1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porudzbina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Porudzbina_Korisnik_KorisnikEmail",
                        column: x => x.KorisnikEmail,
                        principalTable: "Korisnik",
                        principalColumn: "Email");
                    table.ForeignKey(
                        name: "FK_Porudzbina_Korisnik_KorisnikEmail1",
                        column: x => x.KorisnikEmail1,
                        principalTable: "Korisnik",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateTable(
                name: "Paket",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<double>(type: "float", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PorudzbinaId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paket_Porudzbina_PorudzbinaId",
                        column: x => x.PorudzbinaId,
                        principalTable: "Porudzbina",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paket_PorudzbinaId",
                table: "Paket",
                column: "PorudzbinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Porudzbina_KorisnikEmail",
                table: "Porudzbina",
                column: "KorisnikEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Porudzbina_KorisnikEmail1",
                table: "Porudzbina",
                column: "KorisnikEmail1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paket");

            migrationBuilder.DropTable(
                name: "Porudzbina");

            migrationBuilder.DropTable(
                name: "Korisnik");
        }
    }
}
