using System.Windows;
using HangszerekApp.Models;

namespace HangszerekApp
{
    public partial class EditHangszerWindow : Window
    {
        public Hangszer UpdatedHangszer { get; private set; }

        public EditHangszerWindow(Hangszer hangszer)
        {
            InitializeComponent();

            UpdatedHangszer = hangszer;

            // Populate fields with existing values
            NevTextBox.Text = hangszer.Nev;
            TipusTextBox.Text = hangszer.Tipus;
            GyartoTextBox.Text = hangszer.Gyarto;
            ArTextBox.Text = hangszer.Ar.ToString();
            KeszletTextBox.Text = hangszer.Keszlet.ToString();
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

            UpdatedHangszer.Nev = NevTextBox.Text;
            UpdatedHangszer.Tipus = TipusTextBox.Text;
            UpdatedHangszer.Gyarto = GyartoTextBox.Text;
            UpdatedHangszer.Ar = ar;
            UpdatedHangszer.Keszlet = keszlet;

            DialogResult = true;
            Close();
        }
    }
}
