﻿// <auto-generated />
using HangszerekApp;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HangszerekApp.Migrations
{
    [DbContext(typeof(HangszerekContext))]
    [Migration("20241203111301_InitialCreate")]
    partial class InitialCreate
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
#pragma warning restore 612, 618
        }
    }
}