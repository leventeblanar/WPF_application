using System.Windows;
using HangszerekApp.Models;

namespace HangszerekApp
{
    public partial class AddHangszerWindow : Window
    {
        public Hangszer NewHangszer { get; private set; } = null!;

        public AddHangszerWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NevTextBox.Text) || 
                string.IsNullOrWhiteSpace(TipusTextBox.Text) || 
                string.IsNullOrWhiteSpace(GyartoTextBox.Text) || 
                !decimal.TryParse(ArTextBox.Text, out var ar) || 
                !int.TryParse(KeszletTextBox.Text, out var keszlet))
            {
                MessageBox.Show("Hibás adatbevitel! Kérlek ellenőrizd az értékeket.");
                return;
            }

            NewHangszer = new Hangszer
            {
                Nev = NevTextBox.Text,
                Tipus = TipusTextBox.Text,
                Gyarto = GyartoTextBox.Text,
                Ar = ar,
                Keszlet = keszlet
            };

            DialogResult = true;
            Close();
        }
    }
}
