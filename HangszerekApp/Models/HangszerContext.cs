using Microsoft.EntityFrameworkCore;
using HangszerekApp.Models;

namespace HangszerekApp
{
    public class HangszerekContext : DbContext
    {
        public DbSet<Hangszer> Hangszerek { get; set; } = null!;
        public DbSet<Ugyfel> Ugyfelek { get; set; } = null!;
        public DbSet<Rendeles> Rendelesek { get; set; } = null!;
        public DbSet<RendelesTetel> RendelesTetel { get; set; } = null!;
        public DbSet<Szallito> Szallitok { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=hangszerek.db");
        }
    }
}

