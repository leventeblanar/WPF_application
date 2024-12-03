namespace HangszerekApp.Models
{
    public class Ugyfel
    {
        public int ID { get; set; }
        public string Nev { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefonszam { get; set; } = string.Empty;
        public string Cim { get; set; } = string.Empty;
    }
}
