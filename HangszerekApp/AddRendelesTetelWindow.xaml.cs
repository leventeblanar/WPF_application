using System.Linq;
using System.Windows;
using HangszerekApp.Models;

namespace HangszerekApp
{
    public partial class AddRendelesTetelWindow : Window
    {
        public RendelesTetel NewRendelesTetel { get; private set; } = null!;

        public AddRendelesTetelWindow()
        {
            InitializeComponent();
            LoadDropdownData();
        }

        private void LoadDropdownData()
        {
            try
            {
                using (var context = new HangszerekContext())
                {
                    // Rendelések betöltése
                    var rendelesek = context.Rendelesek
                        .Select(r => new
                        {
                            r.ID,
                            r.Datum,
                            UgyfelNev = r.Ugyfel.Nev
                        })
                        .AsEnumerable() // Átváltás LINQ-to-Objects-re
                        .Select(r => new
                        {
                            r.ID,
                            DisplayText = $"{r.UgyfelNev} - #{r.ID} - {r.Datum:yyyy.MM.dd}" // Ügyfél neve + ID + Dátum
                        })
                        .ToList();

                    if (!rendelesek.Any())
                    {
                        MessageBox.Show("Nincsenek elérhető rendelések az adatbázisban!");
                        RendelesDropdown.IsEnabled = false;
                        return;
                    }

                    RendelesDropdown.ItemsSource = rendelesek;
                    RendelesDropdown.DisplayMemberPath = "DisplayText";
                    RendelesDropdown.SelectedValuePath = "ID";

                    // Hangszerek betöltése
                    var hangszerek = context.Hangszerek
                        .Select(h => new
                        {
                            h.ID,
                            h.Nev
                        })
                        .AsEnumerable() // Átváltás LINQ-to-Objects-re
                        .Select(h => new
                        {
                            h.ID,
                            DisplayText = $"{h.Nev} - #{h.ID}" // Hangszer neve + ID
                        })
                        .OrderBy(h => h.DisplayText)
                        .ToList();

                    if (!hangszerek.Any())
                    {
                        MessageBox.Show("Nincsenek elérhető hangszerek az adatbázisban!");
                        HangszerDropdown.IsEnabled = false;
                        return;
                    }

                    HangszerDropdown.ItemsSource = hangszerek;
                    HangszerDropdown.DisplayMemberPath = "DisplayText";
                    HangszerDropdown.SelectedValuePath = "ID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a dropdown adatok betöltése közben: {ex.Message}");
            }
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (RendelesDropdown.SelectedValue == null || HangszerDropdown.SelectedValue == null)
                {
                    MessageBox.Show("Kérlek válassz egy rendelést és egy hangszert!");
                    return;
                }

                if (!int.TryParse(MennyisegInput.Text, out var mennyiseg) || !decimal.TryParse(EgysegarInput.Text, out var egysegar))
                {
                    MessageBox.Show("Hibás adatbevitel! Kérlek ellenőrizd az értékeket.");
                    return;
                }

                NewRendelesTetel = new RendelesTetel
                {
                    RendelesID = (int)RendelesDropdown.SelectedValue,
                    HangszerID = (int)HangszerDropdown.SelectedValue,
                    Mennyiseg = mennyiseg,
                    Egysegar = egysegar
                };

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a rendelési tétel hozzáadása során: {ex.Message}");
            }
        }

    }
}
