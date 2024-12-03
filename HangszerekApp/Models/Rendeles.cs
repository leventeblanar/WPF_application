using System;

namespace HangszerekApp.Models
{
    public class Rendeles
    {
        public int ID { get; set; }
        public int UgyfelID { get; set; }
        public DateTime Datum { get; set; } = DateTime.Now; // Alapértelmezett érték
        public decimal Osszeg { get; set; }

        // Kapcsolat az ügyféllel
        public Ugyfel Ugyfel { get; set; } = null!; // Non-nullable típus biztosítása
    }
}