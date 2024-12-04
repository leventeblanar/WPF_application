using System.Windows;
using HangszerekApp.Models;

namespace HangszerekApp
{
    public partial class EditSzallitoWindow : Window
    {
        private readonly Szallito _existingSzallito;

        public EditSzallitoWindow(Szallito szallito)
        {
            InitializeComponent();
            _existingSzallito = szallito;

            NevInput.Text = szallito.Nev;
            KapcsolattartoInput.Text = szallito.Kapcsolattarto;
            EmailInput.Text = szallito.Email;
            TelefonInput.Text = szallito.Telefon;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _existingSzallito.Nev = NevInput.Text;
            _existingSzallito.Kapcsolattarto = KapcsolattartoInput.Text;
            _existingSzallito.Email = EmailInput.Text;
            _existingSzallito.Telefon = TelefonInput.Text;

            DialogResult = true;
            Close();
        }
    }
}
