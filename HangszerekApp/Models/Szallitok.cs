namespace HangszerekApp.Models
{
    public class Szallito
    {
        public int ID { get; set; }
        public string Nev { get; set; } = string.Empty;
        public string Kapcsolattarto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;
    }
}
