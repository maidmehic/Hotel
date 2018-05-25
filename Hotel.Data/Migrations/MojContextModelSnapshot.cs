﻿// <auto-generated />
using Hotel.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Hotel.Data.Migrations
{
    [DbContext(typeof(MojContext))]
    partial class MojContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hotel.Data.Models.CheckIN", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrojDjece");

                    b.Property<int>("BrojOdraslih");

                    b.Property<DateTime>("DatumDolaska");

                    b.Property<DateTime>("DatumOdlaska");

                    b.Property<int>("GostId");

                    b.Property<string>("Napomena");

                    b.Property<int>("TipUslugeId");

                    b.Property<int>("ZaposlenikId");

                    b.HasKey("Id");

                    b.HasIndex("GostId");

                    b.HasIndex("TipUslugeId");

                    b.HasIndex("ZaposlenikId");

                    b.ToTable("CheckIN");
                });

            modelBuilder.Entity("Hotel.Data.Models.Dostava", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<int>("RezervisanSmjestajId");

                    b.Property<bool>("Zavrsena");

                    b.HasKey("Id");

                    b.HasIndex("RezervisanSmjestajId");

                    b.ToTable("Dostava");
                });

            modelBuilder.Entity("Hotel.Data.Models.DostavaStavke", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DostavaId");

                    b.Property<int>("Kolicina");

                    b.Property<int>("ProizvodId");

                    b.HasKey("Id");

                    b.HasIndex("DostavaId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("DostavaStavke");
                });

            modelBuilder.Entity("Hotel.Data.Models.Drzava", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("Drzava");
                });

            modelBuilder.Entity("Hotel.Data.Models.Feedback", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CheckINId");

                    b.Property<int>("GostId");

                    b.Property<string>("Sadrzaj");

                    b.HasKey("Id");

                    b.HasIndex("CheckINId");

                    b.HasIndex("GostId");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("Hotel.Data.Models.Gost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BrojPasosa");

                    b.Property<DateTime>("DatumRodenja");

                    b.Property<string>("Drzavljanstvo");

                    b.Property<string>("Email");

                    b.Property<int>("GradId");

                    b.Property<string>("Ime");

                    b.Property<string>("Prezime");

                    b.Property<string>("Spol");

                    b.Property<string>("Telefon");

                    b.HasKey("Id");

                    b.HasIndex("GradId");

                    b.ToTable("Gost");
                });

            modelBuilder.Entity("Hotel.Data.Models.Grad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DrzavaId");

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.HasIndex("DrzavaId");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("Hotel.Data.Models.Narudzba", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumKreiranja");

                    b.Property<string>("Hitnost");

                    b.Property<string>("Opis");

                    b.Property<bool>("Otkazana");

                    b.Property<int>("ZaposlenikId");

                    b.Property<bool>("Zavrsena");

                    b.HasKey("Id");

                    b.HasIndex("ZaposlenikId");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("Hotel.Data.Models.Pogodnost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Opis");

                    b.HasKey("Id");

                    b.ToTable("Pogodnost");
                });

            modelBuilder.Entity("Hotel.Data.Models.PogodnostiSmjestaja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Napomena");

                    b.Property<int>("PogodnostId");

                    b.Property<int>("SmjestajId");

                    b.HasKey("Id");

                    b.HasIndex("PogodnostId");

                    b.HasIndex("SmjestajId");

                    b.ToTable("PogodnostiSmjestaja");
                });

            modelBuilder.Entity("Hotel.Data.Models.Proizvodi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Cijena");

                    b.Property<float>("Kolicina");

                    b.Property<string>("MjernaJedinica");

                    b.Property<string>("Naziv");

                    b.Property<string>("Vrsta");

                    b.HasKey("Id");

                    b.ToTable("Proizvod");
                });

            modelBuilder.Entity("Hotel.Data.Models.Racun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CheckINId");

                    b.Property<DateTime>("DatumIzdavanja");

                    b.Property<int>("GostId");

                    b.Property<double>("Suma");

                    b.HasKey("Id");

                    b.HasIndex("CheckINId");

                    b.HasIndex("GostId");

                    b.ToTable("Racun");
                });

            modelBuilder.Entity("Hotel.Data.Models.RezervisanaUsluga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CheckINId");

                    b.Property<int>("UslugeHotelaId");

                    b.HasKey("Id");

                    b.HasIndex("CheckINId");

                    b.HasIndex("UslugeHotelaId");

                    b.ToTable("RezervisanaUsluga");
                });

            modelBuilder.Entity("Hotel.Data.Models.RezervisanSmjestaj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CheckINId");

                    b.Property<int>("GostId");

                    b.Property<int>("SmjestajId");

                    b.HasKey("Id");

                    b.HasIndex("CheckINId");

                    b.HasIndex("GostId");

                    b.HasIndex("SmjestajId");

                    b.ToTable("RezervisanSmjestaj");
                });

            modelBuilder.Entity("Hotel.Data.Models.Smjestaj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrojKreveta");

                    b.Property<int>("BrojSmjestaja");

                    b.Property<double>("Cijena");

                    b.Property<int>("Kvadratura");

                    b.Property<int>("Sprat");

                    b.Property<int>("VrstaSmjestajaId");

                    b.Property<bool>("Zauzeto");

                    b.HasKey("Id");

                    b.HasIndex("VrstaSmjestajaId");

                    b.ToTable("Smjestaj");
                });

            modelBuilder.Entity("Hotel.Data.Models.Stavke", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Kolicina");

                    b.Property<int>("NarudzbaId");

                    b.Property<int>("ProizvodId");

                    b.HasKey("Id");

                    b.HasIndex("NarudzbaId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("Stavke");
                });

            modelBuilder.Entity("Hotel.Data.Models.TipUsluge", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Cijena");

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("TipUsluge");
                });

            modelBuilder.Entity("Hotel.Data.Models.UslugeHotela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Cijena");

                    b.Property<DateTime>("DatumPocetka");

                    b.Property<DateTime>("DatumZavrsetka");

                    b.Property<string>("Naziv");

                    b.Property<string>("Opis");

                    b.HasKey("Id");

                    b.ToTable("UslugeHotela");
                });

            modelBuilder.Entity("Hotel.Data.Models.VrstaSmjestaja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Naziv");

                    b.HasKey("Id");

                    b.ToTable("VrstaSmjestaja");
                });

            modelBuilder.Entity("Hotel.Data.Models.ZahtjevZaCiscenjem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DatumZahtjeva");

                    b.Property<bool>("Obavljen");

                    b.Property<string>("Opis");

                    b.Property<string>("Prioritet");

                    b.Property<int>("SmjestajId");

                    b.Property<int?>("ZaposlenikId");

                    b.HasKey("Id");

                    b.HasIndex("SmjestajId");

                    b.HasIndex("ZaposlenikId");

                    b.ToTable("ZahtjevZaCiscenjem");
                });

            modelBuilder.Entity("Hotel.Data.Models.Zaposlenik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Aktivan");

                    b.Property<string>("BracniStatus");

                    b.Property<string>("BrojUgovora");

                    b.Property<DateTime>("DatumRodjenja");

                    b.Property<DateTime>("DatumZaposljenja");

                    b.Property<string>("Email");

                    b.Property<int>("GradId");

                    b.Property<string>("Ime");

                    b.Property<string>("JMBG");

                    b.Property<string>("Prezime");

                    b.Property<string>("Spol");

                    b.Property<string>("Telefon");

                    b.Property<bool>("isAdministrator");

                    b.Property<bool>("isCistacica");

                    b.Property<bool>("isKuhar");

                    b.Property<bool>("isRecepcioner");

                    b.Property<string>("password");

                    b.Property<string>("username");

                    b.HasKey("Id");

                    b.HasIndex("GradId");

                    b.ToTable("Zaposlenik");
                });

            modelBuilder.Entity("Hotel.Data.Models.CheckIN", b =>
                {
                    b.HasOne("Hotel.Data.Models.Gost", "Gost")
                        .WithMany()
                        .HasForeignKey("GostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hotel.Data.Models.TipUsluge", "TipUsluge")
                        .WithMany()
                        .HasForeignKey("TipUslugeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hotel.Data.Models.Zaposlenik", "Zaposlenik")
                        .WithMany()
                        .HasForeignKey("ZaposlenikId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Hotel.Data.Models.Dostava", b =>
                {
                    b.HasOne("Hotel.Data.Models.RezervisanSmjestaj", "RezervisanSmjestaj")
                        .WithMany()
                        .HasForeignKey("RezervisanSmjestajId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hotel.Data.Models.DostavaStavke", b =>
                {
                    b.HasOne("Hotel.Data.Models.Dostava", "Dostava")
                        .WithMany()
                        .HasForeignKey("DostavaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hotel.Data.Models.Proizvodi", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hotel.Data.Models.Feedback", b =>
                {
                    b.HasOne("Hotel.Data.Models.CheckIN", "CheckIN")
                        .WithMany()
                        .HasForeignKey("CheckINId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hotel.Data.Models.Gost", "Gost")
                        .WithMany()
                        .HasForeignKey("GostId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Hotel.Data.Models.Gost", b =>
                {
                    b.HasOne("Hotel.Data.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hotel.Data.Models.Grad", b =>
                {
                    b.HasOne("Hotel.Data.Models.Drzava", "Drzava")
                        .WithMany()
                        .HasForeignKey("DrzavaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hotel.Data.Models.Narudzba", b =>
                {
                    b.HasOne("Hotel.Data.Models.Zaposlenik", "Zaposlenik")
                        .WithMany()
                        .HasForeignKey("ZaposlenikId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hotel.Data.Models.PogodnostiSmjestaja", b =>
                {
                    b.HasOne("Hotel.Data.Models.Pogodnost", "Pogodnost")
                        .WithMany()
                        .HasForeignKey("PogodnostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hotel.Data.Models.Smjestaj", "Smjestaj")
                        .WithMany()
                        .HasForeignKey("SmjestajId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hotel.Data.Models.Racun", b =>
                {
                    b.HasOne("Hotel.Data.Models.CheckIN", "CheckIN")
                        .WithMany()
                        .HasForeignKey("CheckINId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hotel.Data.Models.Gost", "Gost")
                        .WithMany()
                        .HasForeignKey("GostId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Hotel.Data.Models.RezervisanaUsluga", b =>
                {
                    b.HasOne("Hotel.Data.Models.CheckIN", "CheckIN")
                        .WithMany()
                        .HasForeignKey("CheckINId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hotel.Data.Models.UslugeHotela", "UslugeHotela")
                        .WithMany()
                        .HasForeignKey("UslugeHotelaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hotel.Data.Models.RezervisanSmjestaj", b =>
                {
                    b.HasOne("Hotel.Data.Models.CheckIN", "CheckIN")
                        .WithMany()
                        .HasForeignKey("CheckINId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hotel.Data.Models.Gost", "Gost")
                        .WithMany()
                        .HasForeignKey("GostId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Hotel.Data.Models.Smjestaj", "Smjestaj")
                        .WithMany()
                        .HasForeignKey("SmjestajId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hotel.Data.Models.Smjestaj", b =>
                {
                    b.HasOne("Hotel.Data.Models.VrstaSmjestaja", "VrstaSmjestaja")
                        .WithMany()
                        .HasForeignKey("VrstaSmjestajaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hotel.Data.Models.Stavke", b =>
                {
                    b.HasOne("Hotel.Data.Models.Narudzba", "Narudzba")
                        .WithMany()
                        .HasForeignKey("NarudzbaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hotel.Data.Models.Proizvodi", "Proizvodi")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Hotel.Data.Models.ZahtjevZaCiscenjem", b =>
                {
                    b.HasOne("Hotel.Data.Models.Smjestaj", "Smjestaj")
                        .WithMany()
                        .HasForeignKey("SmjestajId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Hotel.Data.Models.Zaposlenik", "Zaposlenik")
                        .WithMany()
                        .HasForeignKey("ZaposlenikId");
                });

            modelBuilder.Entity("Hotel.Data.Models.Zaposlenik", b =>
                {
                    b.HasOne("Hotel.Data.Models.Grad", "Grad")
                        .WithMany()
                        .HasForeignKey("GradId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
