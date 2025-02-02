﻿// <auto-generated />
using System;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfDataAccess.Migrations
{
    [DbContext(typeof(ProjekatASPContext))]
    [Migration("20190607224304_Baza prepravka")]
    partial class Bazaprepravka
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjekatAsp.Domain.Kategorija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Kreirano");

                    b.Property<DateTime?>("Modifikovano");

                    b.Property<string>("Naziv");

                    b.Property<bool>("Obrisano");

                    b.HasKey("Id");

                    b.ToTable("Kategorijas");
                });

            modelBuilder.Entity("ProjekatAsp.Domain.Komentar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Komentar_Tekst");

                    b.Property<int>("KorisnikId");

                    b.Property<DateTime>("Kreirano");

                    b.Property<DateTime?>("Modifikovano");

                    b.Property<bool>("Obrisano");

                    b.Property<int>("VestId");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("VestId");

                    b.ToTable("Komentars");
                });

            modelBuilder.Entity("ProjekatAsp.Domain.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Ime");

                    b.Property<DateTime>("Kreirano");

                    b.Property<string>("Lozinka");

                    b.Property<DateTime?>("Modifikovano");

                    b.Property<bool>("Obrisano");

                    b.Property<string>("Prezime");

                    b.Property<int?>("UlogaId");

                    b.HasKey("Id");

                    b.HasIndex("UlogaId");

                    b.ToTable("Korisniks");
                });

            modelBuilder.Entity("ProjekatAsp.Domain.Slika", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Alt");

                    b.Property<DateTime>("Kreirano");

                    b.Property<DateTime?>("Modifikovano");

                    b.Property<bool>("Obrisano");

                    b.Property<string>("Putanja");

                    b.Property<int?>("VestId");

                    b.HasKey("Id");

                    b.HasIndex("VestId");

                    b.ToTable("Slikas");
                });

            modelBuilder.Entity("ProjekatAsp.Domain.Uloga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Kreirano");

                    b.Property<DateTime?>("Modifikovano");

                    b.Property<string>("Naziv");

                    b.Property<bool>("Obrisano");

                    b.HasKey("Id");

                    b.ToTable("Ulogas");
                });

            modelBuilder.Entity("ProjekatAsp.Domain.Vest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Id_Kategorija");

                    b.Property<int?>("KategorijaId");

                    b.Property<DateTime>("Kreirano");

                    b.Property<DateTime?>("Modifikovano");

                    b.Property<string>("Naslov");

                    b.Property<bool>("Obrisano");

                    b.Property<string>("Tekst");

                    b.HasKey("Id");

                    b.HasIndex("KategorijaId");

                    b.ToTable("Vests");
                });

            modelBuilder.Entity("ProjekatAsp.Domain.Komentar", b =>
                {
                    b.HasOne("ProjekatAsp.Domain.Korisnik", "Korisnik")
                        .WithMany("Komentars")
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjekatAsp.Domain.Vest", "Vest")
                        .WithMany("Komentars")
                        .HasForeignKey("VestId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjekatAsp.Domain.Korisnik", b =>
                {
                    b.HasOne("ProjekatAsp.Domain.Uloga", "Uloga")
                        .WithMany("Korisniks")
                        .HasForeignKey("UlogaId");
                });

            modelBuilder.Entity("ProjekatAsp.Domain.Slika", b =>
                {
                    b.HasOne("ProjekatAsp.Domain.Vest", "Vest")
                        .WithMany("Slikas")
                        .HasForeignKey("VestId");
                });

            modelBuilder.Entity("ProjekatAsp.Domain.Vest", b =>
                {
                    b.HasOne("ProjekatAsp.Domain.Kategorija", "Kategorija")
                        .WithMany("Vests")
                        .HasForeignKey("KategorijaId");
                });
#pragma warning restore 612, 618
        }
    }
}
