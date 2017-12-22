using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Hotel.Data.Migrations
{
    public partial class HotelData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<float>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    Vrsta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipUsluge",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipUsluge", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UslugeHotela",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cijena = table.Column<float>(nullable: false),
                    DatumPocetka = table.Column<DateTime>(nullable: false),
                    DatumZavrsetka = table.Column<DateTime>(nullable: false),
                    Naziv = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UslugeHotela", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VrstaSmjestaja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaSmjestaja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DrzavaId = table.Column<int>(nullable: false),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_DrzavaId",
                        column: x => x.DrzavaId,
                        principalTable: "Drzava",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Smjestaj",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojKreveta = table.Column<int>(nullable: false),
                    BrojSmjestaja = table.Column<int>(nullable: false),
                    Kvadratura = table.Column<int>(nullable: false),
                    Sprat = table.Column<int>(nullable: false),
                    VrstaSmjestajaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smjestaj", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Smjestaj_VrstaSmjestaja_VrstaSmjestajaId",
                        column: x => x.VrstaSmjestajaId,
                        principalTable: "VrstaSmjestaja",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojPasosa = table.Column<string>(nullable: true),
                    DatumRodenja = table.Column<DateTime>(nullable: false),
                    Drzavljanstvo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    GradId = table.Column<int>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Spol = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gost_Grad_GradId",
                        column: x => x.GradId,
                        principalTable: "Grad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenik",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aktivan = table.Column<bool>(nullable: false),
                    BracniStatus = table.Column<string>(nullable: true),
                    BrojUgovora = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    DatumZaposljenja = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    GradId = table.Column<int>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    JMBG = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Spol = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true),
                    isAdministrator = table.Column<bool>(nullable: false),
                    isCistacica = table.Column<bool>(nullable: false),
                    isKuhar = table.Column<bool>(nullable: false),
                    isRecepcioner = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zaposlenik_Grad_GradId",
                        column: x => x.GradId,
                        principalTable: "Grad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pogodnost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Opis = table.Column<string>(nullable: true),
                    SmjestajId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pogodnost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pogodnost_Smjestaj_SmjestajId",
                        column: x => x.SmjestajId,
                        principalTable: "Smjestaj",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckIN",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BrojDjece = table.Column<int>(nullable: false),
                    BrojOdraslih = table.Column<int>(nullable: false),
                    DatumDolaska = table.Column<DateTime>(nullable: false),
                    DatumOdlaska = table.Column<DateTime>(nullable: false),
                    Depozit = table.Column<float>(nullable: false),
                    GostId = table.Column<int>(nullable: false),
                    Napomena = table.Column<string>(nullable: true),
                    TipUslugeId = table.Column<int>(nullable: false),
                    ZaposlenikId = table.Column<int>(nullable: false),
                    ZaposlenikId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckIN", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckIN_Gost_GostId",
                        column: x => x.GostId,
                        principalTable: "Gost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckIN_TipUsluge_TipUslugeId",
                        column: x => x.TipUslugeId,
                        principalTable: "TipUsluge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckIN_Zaposlenik_ZaposlenikId",
                        column: x => x.ZaposlenikId,
                        principalTable: "Zaposlenik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckIN_Zaposlenik_ZaposlenikId1",
                        column: x => x.ZaposlenikId1,
                        principalTable: "Zaposlenik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumKreiranja = table.Column<DateTime>(nullable: false),
                    Hitnost = table.Column<string>(nullable: true),
                    Opis = table.Column<string>(nullable: true),
                    ZaposlenikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Narudzba_Zaposlenik_ZaposlenikId",
                        column: x => x.ZaposlenikId,
                        principalTable: "Zaposlenik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZahtjevZaCiscenjem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DatumZahtjeva = table.Column<DateTime>(nullable: false),
                    Opis = table.Column<string>(nullable: true),
                    Prioritet = table.Column<string>(nullable: true),
                    SmjestajId = table.Column<int>(nullable: false),
                    ZaposlenikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZahtjevZaCiscenjem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZahtjevZaCiscenjem_Smjestaj_SmjestajId",
                        column: x => x.SmjestajId,
                        principalTable: "Smjestaj",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZahtjevZaCiscenjem_Zaposlenik_ZaposlenikId",
                        column: x => x.ZaposlenikId,
                        principalTable: "Zaposlenik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PogodnostiSmjestaja",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Napomena = table.Column<string>(nullable: true),
                    PogodnostId = table.Column<int>(nullable: false),
                    SmjestajId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PogodnostiSmjestaja", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PogodnostiSmjestaja_Pogodnost_PogodnostId",
                        column: x => x.PogodnostId,
                        principalTable: "Pogodnost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PogodnostiSmjestaja_Smjestaj_SmjestajId",
                        column: x => x.SmjestajId,
                        principalTable: "Smjestaj",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckINId = table.Column<int>(nullable: false),
                    GostId = table.Column<int>(nullable: false),
                    GostId1 = table.Column<int>(nullable: true),
                    Sadrzaj = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Feedback_CheckIN_CheckINId",
                        column: x => x.CheckINId,
                        principalTable: "CheckIN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Feedback_Gost_GostId",
                        column: x => x.GostId,
                        principalTable: "Gost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Feedback_Gost_GostId1",
                        column: x => x.GostId1,
                        principalTable: "Gost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckINId = table.Column<int>(nullable: false),
                    DatumIzdavanja = table.Column<DateTime>(nullable: false),
                    GostId = table.Column<int>(nullable: false),
                    GostId1 = table.Column<int>(nullable: true),
                    Suma = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Racun_CheckIN_CheckINId",
                        column: x => x.CheckINId,
                        principalTable: "CheckIN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Racun_Gost_GostId",
                        column: x => x.GostId,
                        principalTable: "Gost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Racun_Gost_GostId1",
                        column: x => x.GostId1,
                        principalTable: "Gost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RezervisanaUsluga",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckINId = table.Column<int>(nullable: false),
                    Datumrezervacije = table.Column<DateTime>(nullable: false),
                    UslugeHotelaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervisanaUsluga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RezervisanaUsluga_CheckIN_CheckINId",
                        column: x => x.CheckINId,
                        principalTable: "CheckIN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezervisanaUsluga_UslugeHotela_UslugeHotelaId",
                        column: x => x.UslugeHotelaId,
                        principalTable: "UslugeHotela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RezervisanSmjestaj",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckINId = table.Column<int>(nullable: false),
                    GostId = table.Column<int>(nullable: false),
                    GostId1 = table.Column<int>(nullable: true),
                    SmjestajId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RezervisanSmjestaj", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RezervisanSmjestaj_CheckIN_CheckINId",
                        column: x => x.CheckINId,
                        principalTable: "CheckIN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RezervisanSmjestaj_Gost_GostId",
                        column: x => x.GostId,
                        principalTable: "Gost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RezervisanSmjestaj_Gost_GostId1",
                        column: x => x.GostId1,
                        principalTable: "Gost",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RezervisanSmjestaj_Smjestaj_SmjestajId",
                        column: x => x.SmjestajId,
                        principalTable: "Smjestaj",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uplata",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckINId = table.Column<int>(nullable: false),
                    DatumUplate = table.Column<DateTime>(nullable: false),
                    Iznos = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uplata_CheckIN_CheckINId",
                        column: x => x.CheckINId,
                        principalTable: "CheckIN",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stavke",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Kolicina = table.Column<int>(nullable: false),
                    NarudzbaId = table.Column<int>(nullable: false),
                    ProizvodId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stavke", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stavke_Narudzba_NarudzbaId",
                        column: x => x.NarudzbaId,
                        principalTable: "Narudzba",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stavke_Proizvod_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckIN_GostId",
                table: "CheckIN",
                column: "GostId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckIN_TipUslugeId",
                table: "CheckIN",
                column: "TipUslugeId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckIN_ZaposlenikId",
                table: "CheckIN",
                column: "ZaposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckIN_ZaposlenikId1",
                table: "CheckIN",
                column: "ZaposlenikId1");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_CheckINId",
                table: "Feedback",
                column: "CheckINId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_GostId",
                table: "Feedback",
                column: "GostId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_GostId1",
                table: "Feedback",
                column: "GostId1");

            migrationBuilder.CreateIndex(
                name: "IX_Gost_GradId",
                table: "Gost",
                column: "GradId");

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaId",
                table: "Grad",
                column: "DrzavaId");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_ZaposlenikId",
                table: "Narudzba",
                column: "ZaposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Pogodnost_SmjestajId",
                table: "Pogodnost",
                column: "SmjestajId");

            migrationBuilder.CreateIndex(
                name: "IX_PogodnostiSmjestaja_PogodnostId",
                table: "PogodnostiSmjestaja",
                column: "PogodnostId");

            migrationBuilder.CreateIndex(
                name: "IX_PogodnostiSmjestaja_SmjestajId",
                table: "PogodnostiSmjestaja",
                column: "SmjestajId");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_CheckINId",
                table: "Racun",
                column: "CheckINId");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_GostId",
                table: "Racun",
                column: "GostId");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_GostId1",
                table: "Racun",
                column: "GostId1");

            migrationBuilder.CreateIndex(
                name: "IX_RezervisanaUsluga_CheckINId",
                table: "RezervisanaUsluga",
                column: "CheckINId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervisanaUsluga_UslugeHotelaId",
                table: "RezervisanaUsluga",
                column: "UslugeHotelaId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervisanSmjestaj_CheckINId",
                table: "RezervisanSmjestaj",
                column: "CheckINId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervisanSmjestaj_GostId",
                table: "RezervisanSmjestaj",
                column: "GostId");

            migrationBuilder.CreateIndex(
                name: "IX_RezervisanSmjestaj_GostId1",
                table: "RezervisanSmjestaj",
                column: "GostId1");

            migrationBuilder.CreateIndex(
                name: "IX_RezervisanSmjestaj_SmjestajId",
                table: "RezervisanSmjestaj",
                column: "SmjestajId");

            migrationBuilder.CreateIndex(
                name: "IX_Smjestaj_VrstaSmjestajaId",
                table: "Smjestaj",
                column: "VrstaSmjestajaId");

            migrationBuilder.CreateIndex(
                name: "IX_Stavke_NarudzbaId",
                table: "Stavke",
                column: "NarudzbaId");

            migrationBuilder.CreateIndex(
                name: "IX_Stavke_ProizvodId",
                table: "Stavke",
                column: "ProizvodId");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_CheckINId",
                table: "Uplata",
                column: "CheckINId");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtjevZaCiscenjem_SmjestajId",
                table: "ZahtjevZaCiscenjem",
                column: "SmjestajId");

            migrationBuilder.CreateIndex(
                name: "IX_ZahtjevZaCiscenjem_ZaposlenikId",
                table: "ZahtjevZaCiscenjem",
                column: "ZaposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenik_GradId",
                table: "Zaposlenik",
                column: "GradId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "PogodnostiSmjestaja");

            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropTable(
                name: "RezervisanaUsluga");

            migrationBuilder.DropTable(
                name: "RezervisanSmjestaj");

            migrationBuilder.DropTable(
                name: "Stavke");

            migrationBuilder.DropTable(
                name: "Uplata");

            migrationBuilder.DropTable(
                name: "ZahtjevZaCiscenjem");

            migrationBuilder.DropTable(
                name: "Pogodnost");

            migrationBuilder.DropTable(
                name: "UslugeHotela");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "CheckIN");

            migrationBuilder.DropTable(
                name: "Smjestaj");

            migrationBuilder.DropTable(
                name: "Gost");

            migrationBuilder.DropTable(
                name: "TipUsluge");

            migrationBuilder.DropTable(
                name: "Zaposlenik");

            migrationBuilder.DropTable(
                name: "VrstaSmjestaja");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "Drzava");
        }
    }
}
