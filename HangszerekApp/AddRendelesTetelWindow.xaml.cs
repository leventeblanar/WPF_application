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
            using (var context = new HangszerekContext())
            {
                // Rendelések betöltése
                var rendelesek = context.Rendelesek
                    .Select(r => new
                    {
                        r.ID,
                        DisplayText = $"{r.Ugyfel.Nev} - #{r.ID} - {r.Datum:yyyy.MM.dd}" // Ügyfél neve + ID + Dátum
                    }).ToList();

                RendelesDropdown.ItemsSource = rendelesek;
                RendelesDropdown.DisplayMemberPath = "DisplayText";
                RendelesDropdown.SelectedValuePath = "ID";

                // Hangszerek betöltése
                var hangszerek = context.Hangszerek
                    .Select(h => new
                    {
                        h.ID,
                        DisplayText = $"{h.Nev} - #{h.ID}" // Hangszer neve + ID
                    }).OrderBy(h => h.DisplayText).ToList();

                HangszerDropdown.ItemsSource = hangszerek;
                HangszerDropdown.DisplayMemberPath = "DisplayText";
                HangszerDropdown.SelectedValuePath = "ID";
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
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
    }
}
