using System.Windows;
using HangszerekApp.Models;

namespace HangszerekApp
{
    public partial class AddSzallitoWindow : Window
    {
        public Szallito NewSzallito { get; private set; } = null!;

        public AddSzallitoWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NewSzallito = new Szallito
            {
                Nev = NevInput.Text,
                Kapcsolattarto = KapcsolattartoInput.Text,
                Email = EmailInput.Text,
                Telefon = TelefonInput.Text
            };
            DialogResult = true;
            Close();
        }
    }
}
