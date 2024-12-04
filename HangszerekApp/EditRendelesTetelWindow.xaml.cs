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

            try
            {
                LoadDropdownData();

                // Populating fields with existing data
                RendelesDropdown.SelectedValue = rendelesTetel.RendelesID;
                HangszerDropdown.SelectedValue = rendelesTetel.HangszerID;
                MennyisegInput.Text = rendelesTetel.Mennyiseg.ToString();
                EgysegarInput.Text = rendelesTetel.Egysegar.ToString();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Hiba történt az adatok betöltése során: {ex.Message}");
            }
        }

        private void LoadDropdownData()
        {
            using (var context = new HangszerekContext())
            {
                // Load Rendelések
                var rendelesek = context.Rendelesek
                    .Select(r => new
                    {
                        r.ID,
                        DisplayText = $"{r.Ugyfel.Nev} - #{r.ID} - {r.Datum:yyyy.MM.dd}"
                    })
                    .AsEnumerable() // EF Core translation workaround
                    .ToList();

                if (!rendelesek.Any())
                {
                    MessageBox.Show("Nincsenek elérhető rendelések az adatbázisban.");
                    RendelesDropdown.IsEnabled = false;
                }

                RendelesDropdown.ItemsSource = rendelesek;
                RendelesDropdown.DisplayMemberPath = "DisplayText";
                RendelesDropdown.SelectedValuePath = "ID";

                // Load Hangszerek
                var hangszerek = context.Hangszerek
                    .Select(h => new
                    {
                        h.ID,
                        DisplayText = $"{h.Nev} - #{h.ID}"
                    })
                    .AsEnumerable() // EF Core translation workaround
                    .OrderBy(h => h.DisplayText)
                    .ToList();

                if (!hangszerek.Any())
                {
                    MessageBox.Show("Nincsenek elérhető hangszerek az adatbázisban.");
                    HangszerDropdown.IsEnabled = false;
                }

                HangszerDropdown.ItemsSource = hangszerek;
                HangszerDropdown.DisplayMemberPath = "DisplayText";
                HangszerDropdown.SelectedValuePath = "ID";
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
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

                // Update fields
                _existingRendelesTetel.RendelesID = (int)RendelesDropdown.SelectedValue;
                _existingRendelesTetel.HangszerID = (int)HangszerDropdown.SelectedValue;
                _existingRendelesTetel.Mennyiseg = mennyiseg;
                _existingRendelesTetel.Egysegar = egysegar;

                DialogResult = true;
                Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Hiba történt a mentés során: {ex.Message}");
            }
        }
    }
}
