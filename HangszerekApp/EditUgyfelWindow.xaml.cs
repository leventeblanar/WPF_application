using System.Windows;
using System.Windows.Controls;
using HangszerekApp.Models;

namespace HangszerekApp
{
    public partial class EditUgyfelWindow : Window
    {
        private readonly Ugyfel _existingUgyfel;

        public EditUgyfelWindow(Ugyfel ugyfel)
        {
            InitializeComponent();
            _existingUgyfel = ugyfel;

            NevInput.Text = ugyfel.Nev;
            NevInput.Foreground = System.Windows.Media.Brushes.Black;

            EmailInput.Text = ugyfel.Email;
            EmailInput.Foreground = System.Windows.Media.Brushes.Black;

            TelefonszamInput.Text = ugyfel.Telefonszam;
            TelefonszamInput.Foreground = System.Windows.Media.Brushes.Black;

            CimInput.Text = ugyfel.Cim;
            CimInput.Foreground = System.Windows.Media.Brushes.Black;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NevInput.Text) || string.IsNullOrWhiteSpace(EmailInput.Text) ||
                string.IsNullOrWhiteSpace(TelefonszamInput.Text) || string.IsNullOrWhiteSpace(CimInput.Text))
            {
                MessageBox.Show("Kérlek töltsd ki az összes mezőt!");
                return;
            }

            _existingUgyfel.Nev = NevInput.Text;
            _existingUgyfel.Email = EmailInput.Text;
            _existingUgyfel.Telefonszam = TelefonszamInput.Text;
            _existingUgyfel.Cim = CimInput.Text;

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
