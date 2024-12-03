namespace HangszerekApp.Models
{
    public class RendelesTetel
    {
        public int ID { get; set; }
        public int RendelesID { get; set; }
        public int HangszerID { get; set; }
        public int Mennyiseg { get; set; }
        public decimal Egysegar { get; set; }

        // Kapcsolatok
        public Rendeles Rendeles { get; set; } = null!; // Non-nullable típus biztosítása
        public Hangszer Hangszer { get; set; } = null!; // Non-nullable típus biztosítása
    }
}
