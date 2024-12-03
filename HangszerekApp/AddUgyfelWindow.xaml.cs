using System.Windows;
using System.Windows.Controls;
using HangszerekApp.Models;

namespace HangszerekApp
{
    public partial class AddUgyfelWindow : Window
    {
        public Ugyfel NewUgyfel { get; private set; } = null!;

        public AddUgyfelWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (NevInput.Text == "Név" || EmailInput.Text == "Email" || TelefonszamInput.Text == "Telefonszám" || CimInput.Text == "Cím" ||
                string.IsNullOrWhiteSpace(NevInput.Text) || string.IsNullOrWhiteSpace(EmailInput.Text) || string.IsNullOrWhiteSpace(TelefonszamInput.Text) || string.IsNullOrWhiteSpace(CimInput.Text))
            {
                MessageBox.Show("Kérlek töltsd ki az összes mezőt!");
                return;
            }

            NewUgyfel = new Ugyfel
            {
                Nev = NevInput.Text,
                Email = EmailInput.Text,
                Telefonszam = TelefonszamInput.Text,
                Cim = CimInput.Text
            };

            DialogResult = true;
            Close();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Foreground == System.Windows.Media.Brushes.Gray)
            {
                textBox.Text = "";
                textBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
            {
                switch (textBox.Name)
                {
                    case "NevInput":
                        textBox.Text = "Név";
                        break;
                    case "EmailInput":
                        textBox.Text = "Email";
                        break;
                    case "TelefonszamInput":
                        textBox.Text = "Telefonszám";
                        break;
                    case "CimInput":
                        textBox.Text = "Cím";
                        break;
                }
                textBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }
    }
}
