using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HangszerekApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hangszerek",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nev = table.Column<string>(type: "TEXT", nullable: false),
                    Tipus = table.Column<string>(type: "TEXT", nullable: false),
                    Gyarto = table.Column<string>(type: "TEXT", nullable: false),
                    Ar = table.Column<decimal>(type: "TEXT", nullable: false),
                    Keszlet = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hangszerek", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hangszerek");
        }
    }
}
