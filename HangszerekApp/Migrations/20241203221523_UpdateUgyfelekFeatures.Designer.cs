﻿// <auto-generated />
using System;
using HangszerekApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HangszerekApp.Migrations
{
    [DbContext(typeof(HangszerekContext))]
    [Migration("20241203221523_UpdateUgyfelekFeatures")]
    partial class UpdateUgyfelekFeatures
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("HangszerekApp.Models.Hangszer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Ar")
                        .HasColumnType("TEXT");

                    b.Property<string>("Gyarto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Keszlet")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nev")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Tipus")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Hangszerek");
                });

            modelBuilder.Entity("HangszerekApp.Models.Rendeles", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Osszeg")
                        .HasColumnType("TEXT");

                    b.Property<int>("UgyfelID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("UgyfelID");

                    b.ToTable("Rendelesek");
                });

            modelBuilder.Entity("HangszerekApp.Models.RendelesTetel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Egysegar")
                        .HasColumnType("TEXT");

                    b.Property<int>("HangszerID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Mennyiseg")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RendelesID")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("HangszerID");

                    b.HasIndex("RendelesID");

                    b.ToTable("RendelesTetel");
                });

            modelBuilder.Entity("HangszerekApp.Models.Szallito", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Kapcsolattarto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nev")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Szallitok");
                });

            modelBuilder.Entity("HangszerekApp.Models.Ugyfel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cim")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nev")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefonszam")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("Ugyfelek");
                });

            modelBuilder.Entity("HangszerekApp.Models.Rendeles", b =>
                {
                    b.HasOne("HangszerekApp.Models.Ugyfel", "Ugyfel")
                        .WithMany()
                        .HasForeignKey("UgyfelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ugyfel");
                });

            modelBuilder.Entity("HangszerekApp.Models.RendelesTetel", b =>
                {
                    b.HasOne("HangszerekApp.Models.Hangszer", "Hangszer")
                        .WithMany()
                        .HasForeignKey("HangszerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HangszerekApp.Models.Rendeles", "Rendeles")
                        .WithMany()
                        .HasForeignKey("RendelesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hangszer");

                    b.Navigation("Rendeles");
                });
#pragma warning restore 612, 618
        }
    }
}
