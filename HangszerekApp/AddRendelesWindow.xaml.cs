using System.Linq;
using System.Windows;
using HangszerekApp.Models;

namespace HangszerekApp
{
    public partial class AddRendelesWindow : Window
    {
        public Rendeles NewRendeles { get; private set; } = null!;

        public AddRendelesWindow()
        {
            InitializeComponent();
            LoadUgyfelek();
        }

        private void LoadUgyfelek()
        {
            using (var context = new HangszerekContext())
            {
                UgyfelComboBox.ItemsSource = context.Ugyfelek
                    .Select(u => new { u.ID, u.Nev })
                    .ToList();
                UgyfelComboBox.DisplayMemberPath = "Nev";
                UgyfelComboBox.SelectedValuePath = "ID";
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (UgyfelComboBox.SelectedValue is not int ugyfelID ||
                !decimal.TryParse(OsszegTextBox.Text, out var osszeg) ||
                DatumPicker.SelectedDate is null)
            {
                MessageBox.Show("Hibás adatbevitel! Kérlek ellenőrizd az értékeket.");
                return;
            }

            NewRendeles = new Rendeles
            {
                UgyfelID = ugyfelID,
                Datum = DatumPicker.SelectedDate.Value,
                Osszeg = osszeg
            };

            DialogResult = true;
            Close();
        }
    }
}
