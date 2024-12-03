using System.Linq;
using System.Windows;
using HangszerekApp.Models;

namespace HangszerekApp
{
    public partial class EditRendelesWindow : Window
    {
        private readonly Rendeles _existingRendeles;

        public EditRendelesWindow(Rendeles rendeles)
        {
            InitializeComponent();
            _existingRendeles = rendeles;

            LoadUgyfelek();

            // Populate fields with existing values
            UgyfelComboBox.SelectedValue = rendeles.UgyfelID;
            DatumPicker.SelectedDate = rendeles.Datum;
            OsszegTextBox.Text = rendeles.Osszeg.ToString();
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

            _existingRendeles.UgyfelID = ugyfelID;
            _existingRendeles.Datum = DatumPicker.SelectedDate.Value;
            _existingRendeles.Osszeg = osszeg;

            DialogResult = true;
            Close();
        }
    }
}
