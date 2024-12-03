namespace HangszerekApp.Models
{
    public class Hangszer
    {
        public int ID { get; set; }        // Az egyedi azonosító
        public string Nev { get; set; } = string.Empty;    // A hangszer neve
        public string Tipus { get; set; } = string.Empty;  // Pl. Gitár, Zongora, Dob stb.
        public string Gyarto { get; set; } = string.Empty; // Gyártó neve
        public decimal Ar { get; set; }    // Ár (Ft)
        public int Keszlet { get; set; }   // Elérhető mennyiség
    }
}
