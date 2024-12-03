using System.Linq;
using System.Windows;
using HangszerekApp.Models;

namespace HangszerekApp
{
    public partial class RendelesekWindow : Window
    {
        public RendelesekWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (var context = new HangszerekContext())
            {
                RendelesekGrid.ItemsSource = context.Rendelesek
                    .Select(r => new
                    {
                        r.ID,
                        r.UgyfelID,
                        UgyfelNev = r.Ugyfel.Nev, // Ügyfél név a relációból
                        r.Datum,
                        r.Osszeg
                    }).ToList();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddRendelesWindow();
            if (addWindow.ShowDialog() == true)
            {
                using (var context = new HangszerekContext())
                {
                    context.Rendelesek.Add(addWindow.NewRendeles);
                    context.SaveChanges();
                }
                LoadData();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (RendelesekGrid.SelectedItem is not null)
            {
                var selectedRendeles = (dynamic)RendelesekGrid.SelectedItem;
                using (var context = new HangszerekContext())
                {
                    var rendeles = context.Rendelesek.Find(selectedRendeles.ID);
                    if (rendeles != null)
                    {
                        var editWindow = new EditRendelesWindow(rendeles);
                        if (editWindow.ShowDialog() == true)
                        {
                            context.SaveChanges();
                            LoadData();
                        }
                    }
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (RendelesekGrid.SelectedItem is not null)
            {
                var selectedRendeles = (dynamic)RendelesekGrid.SelectedItem;

                // Megerősítés
                var confirmResult = MessageBox.Show(
                    $"Biztosan törölni szeretnéd a rendelést ID: {selectedRendeles.ID}?",
                    "Megerősítés",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (confirmResult == MessageBoxResult.Yes)
                {
                    using (var context = new HangszerekContext())
                    {
                        var rendeles = context.Rendelesek.Find(selectedRendeles.ID);
                        if (rendeles != null)
                        {
                            context.Rendelesek.Remove(rendeles);
                            context.SaveChanges();

                            // Sikeres törlés visszajelzés
                            MessageBox.Show("A rendelés sikeresen törölve lett!", "Törlés sikeres", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            // Hibakezelés
                            MessageBox.Show("Nem található a rendelés az adatbázisban.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }

                    // Adatok frissítése
                    LoadData();
                }
            }
            else
            {
                // Figyelmeztetés, ha nincs kiválasztva rendelés
                MessageBox.Show("Kérlek válassz ki egy rendelést a törléshez!", "Nincs kiválasztva rendelés", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
