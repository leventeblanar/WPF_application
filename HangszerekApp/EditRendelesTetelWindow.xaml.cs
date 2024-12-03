using System.Linq;
using System.Windows;
using HangszerekApp.Models;

namespace HangszerekApp
{
    public partial class EditRendelesTetelWindow : Window
    {
        private readonly RendelesTetel _existingRendelesTetel;

        public EditRendelesTetelWindow(RendelesTetel rendelesTetel)
        {
            InitializeComponent();
            _existingRendelesTetel = rendelesTetel;

            LoadDropdownData();

            // Populating fields with existing data
            RendelesDropdown.SelectedValue = rendelesTetel.RendelesID;
            HangszerDropdown.SelectedValue = rendelesTetel.HangszerID;
            MennyisegInput.Text = rendelesTetel.Mennyiseg.ToString();
            EgysegarInput.Text = rendelesTetel.Egysegar.ToString();
        }

        private void LoadDropdownData()
        {
            using (var context = new HangszerekContext())
            {
                var rendelesek = context.Rendelesek
                    .Select(r => new
                    {
                        r.ID,
                        DisplayText = $"{r.Ugyfel.Nev} - #{r.ID} - {r.Datum:yyyy.MM.dd}"
                    }).ToList();

                RendelesDropdown.ItemsSource = rendelesek;
                RendelesDropdown.DisplayMemberPath = "DisplayText";
                RendelesDropdown.SelectedValuePath = "ID";

                var hangszerek = context.Hangszerek
                    .Select(h => new
                    {
                        h.ID,
                        DisplayText = $"{h.Nev} - #{h.ID}"
                    }).OrderBy(h => h.DisplayText).ToList();

                HangszerDropdown.ItemsSource = hangszerek;
                HangszerDropdown.DisplayMemberPath = "DisplayText";
                HangszerDropdown.SelectedValuePath = "ID";
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (RendelesDropdown.SelectedValue is null || HangszerDropdown.SelectedValue is null)
            {
                MessageBox.Show("Kérlek válassz egy rendelést és egy hangszert!");
                return;
            }

            if (!int.TryParse(MennyisegInput.Text, out var mennyiseg) || !decimal.TryParse(EgysegarInput.Text, out var egysegar))
            {
                MessageBox.Show("Hibás adatbevitel! Kérlek ellenőrizd az értékeket.");
                return;
            }

            _existingRendelesTetel.RendelesID = (int)RendelesDropdown.SelectedValue;
            _existingRendelesTetel.HangszerID = (int)HangszerDropdown.SelectedValue;
            _existingRendelesTetel.Mennyiseg = mennyiseg;
            _existingRendelesTetel.Egysegar = egysegar;

            DialogResult = true;
            Close();
        }
    }
}
