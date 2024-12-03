using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HangszerekApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rendelések_Ugyfelek_UgyfelID",
                table: "Rendelések");

            migrationBuilder.DropForeignKey(
                name: "FK_RendelésTételek_Hangszerek_HangszerID",
                table: "RendelésTételek");

            migrationBuilder.DropForeignKey(
                name: "FK_RendelésTételek_Rendelések_RendelesID",
                table: "RendelésTételek");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Szállítók",
                table: "Szállítók");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RendelésTételek",
                table: "RendelésTételek");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rendelések",
                table: "Rendelések");

            migrationBuilder.RenameTable(
                name: "Szállítók",
                newName: "Szallitok");

            migrationBuilder.RenameTable(
                name: "RendelésTételek",
                newName: "RendelesTetel");

            migrationBuilder.RenameTable(
                name: "Rendelések",
                newName: "Rendelesek");

            migrationBuilder.RenameIndex(
                name: "IX_RendelésTételek_RendelesID",
                table: "RendelesTetel",
                newName: "IX_RendelesTetel_RendelesID");

            migrationBuilder.RenameIndex(
                name: "IX_RendelésTételek_HangszerID",
                table: "RendelesTetel",
                newName: "IX_RendelesTetel_HangszerID");

            migrationBuilder.RenameIndex(
                name: "IX_Rendelések_UgyfelID",
                table: "Rendelesek",
                newName: "IX_Rendelesek_UgyfelID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Szallitok",
                table: "Szallitok",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RendelesTetel",
                table: "RendelesTetel",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rendelesek",
                table: "Rendelesek",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rendelesek_Ugyfelek_UgyfelID",
                table: "Rendelesek",
                column: "UgyfelID",
                principalTable: "Ugyfelek",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RendelesTetel_Hangszerek_HangszerID",
                table: "RendelesTetel",
                column: "HangszerID",
                principalTable: "Hangszerek",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RendelesTetel_Rendelesek_RendelesID",
                table: "RendelesTetel",
                column: "RendelesID",
                principalTable: "Rendelesek",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rendelesek_Ugyfelek_UgyfelID",
                table: "Rendelesek");

            migrationBuilder.DropForeignKey(
                name: "FK_RendelesTetel_Hangszerek_HangszerID",
                table: "RendelesTetel");

            migrationBuilder.DropForeignKey(
                name: "FK_RendelesTetel_Rendelesek_RendelesID",
                table: "RendelesTetel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Szallitok",
                table: "Szallitok");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RendelesTetel",
                table: "RendelesTetel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rendelesek",
                table: "Rendelesek");

            migrationBuilder.RenameTable(
                name: "Szallitok",
                newName: "Szállítók");

            migrationBuilder.RenameTable(
                name: "RendelesTetel",
                newName: "RendelésTételek");

            migrationBuilder.RenameTable(
                name: "Rendelesek",
                newName: "Rendelések");

            migrationBuilder.RenameIndex(
                name: "IX_RendelesTetel_RendelesID",
                table: "RendelésTételek",
                newName: "IX_RendelésTételek_RendelesID");

            migrationBuilder.RenameIndex(
                name: "IX_RendelesTetel_HangszerID",
                table: "RendelésTételek",
                newName: "IX_RendelésTételek_HangszerID");

            migrationBuilder.RenameIndex(
                name: "IX_Rendelesek_UgyfelID",
                table: "Rendelések",
                newName: "IX_Rendelések_UgyfelID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Szállítók",
                table: "Szállítók",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RendelésTételek",
                table: "RendelésTételek",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rendelések",
                table: "Rendelések",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rendelések_Ugyfelek_UgyfelID",
                table: "Rendelések",
                column: "UgyfelID",
                principalTable: "Ugyfelek",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RendelésTételek_Hangszerek_HangszerID",
                table: "RendelésTételek",
                column: "HangszerID",
                principalTable: "Hangszerek",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RendelésTételek_Rendelések_RendelesID",
                table: "RendelésTételek",
                column: "RendelesID",
                principalTable: "Rendelések",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
