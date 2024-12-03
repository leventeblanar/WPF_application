using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HangszerekApp.Migrations
{
    /// <inheritdoc />
    public partial class AddRemainingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Szállítók",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nev = table.Column<string>(type: "TEXT", nullable: false),
                    Kapcsolattarto = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Telefon = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szállítók", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ugyfelek",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nev = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Telefonszam = table.Column<string>(type: "TEXT", nullable: false),
                    Cim = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ugyfelek", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rendelések",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UgyfelID = table.Column<int>(type: "INTEGER", nullable: false),
                    Datum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Osszeg = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rendelések", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rendelések_Ugyfelek_UgyfelID",
                        column: x => x.UgyfelID,
                        principalTable: "Ugyfelek",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RendelésTételek",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RendelesID = table.Column<int>(type: "INTEGER", nullable: false),
                    HangszerID = table.Column<int>(type: "INTEGER", nullable: false),
                    Mennyiseg = table.Column<int>(type: "INTEGER", nullable: false),
                    Egysegar = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RendelésTételek", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RendelésTételek_Hangszerek_HangszerID",
                        column: x => x.HangszerID,
                        principalTable: "Hangszerek",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RendelésTételek_Rendelések_RendelesID",
                        column: x => x.RendelesID,
                        principalTable: "Rendelések",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rendelések_UgyfelID",
                table: "Rendelések",
                column: "UgyfelID");

            migrationBuilder.CreateIndex(
                name: "IX_RendelésTételek_HangszerID",
                table: "RendelésTételek",
                column: "HangszerID");

            migrationBuilder.CreateIndex(
                name: "IX_RendelésTételek_RendelesID",
                table: "RendelésTételek",
                column: "RendelesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RendelésTételek");

            migrationBuilder.DropTable(
                name: "Szállítók");

            migrationBuilder.DropTable(
                name: "Rendelések");

            migrationBuilder.DropTable(
                name: "Ugyfelek");
        }
    }
}
