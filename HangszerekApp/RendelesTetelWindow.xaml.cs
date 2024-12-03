using System.Linq;
using System.Windows;
using HangszerekApp.Models;

namespace HangszerekApp
{
    public partial class RendelesTetelWindow : Window
    {
        public RendelesTetelWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (var context = new HangszerekContext())
            {
                RendelesTetelGrid.ItemsSource = context.RendelesTetel
                    .Select(rt => new
                    {
                        rt.ID,
                        rt.RendelesID,
                        RendelesDatum = rt.Rendeles.Datum, // Kapcsolódó rendelés dátuma
                        rt.HangszerID,
                        HangszerNev = rt.Hangszer.Nev, // Kapcsolódó hangszer neve
                        rt.Mennyiseg,
                        rt.Egysegar
                    }).ToList();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddRendelesTetelWindow();
            if (addWindow.ShowDialog() == true)
            {
                using (var context = new HangszerekContext())
                {
                    context.RendelesTetel.Add(addWindow.NewRendelesTetel);
                    context.SaveChanges();
                }
                MessageBox.Show("Új rendelési tétel sikeresen hozzáadva!", "Hozzáadás sikeres", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadData();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (RendelesTetelGrid.SelectedItem is not null)
            {
                var selectedTetel = (dynamic)RendelesTetelGrid.SelectedItem;
                using (var context = new HangszerekContext())
                {
                    var tetel = context.RendelesTetel.Find(selectedTetel.ID);
                    if (tetel != null)
                    {
                        var editWindow = new EditRendelesTetelWindow(tetel);
                        if (editWindow.ShowDialog() == true)
                        {
                            context.SaveChanges();
                            MessageBox.Show("A rendelési tétel sikeresen módosítva!", "Módosítás sikeres", MessageBoxButton.OK, MessageBoxImage.Information);
                            LoadData();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Kérlek válassz ki egy rendelési tételt a módosításhoz!", "Nincs kiválasztva tétel", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (RendelesTetelGrid.SelectedItem is not null)
            {
                var selectedTetel = (dynamic)RendelesTetelGrid.SelectedItem;

                var confirmResult = MessageBox.Show(
                    $"Biztosan törölni szeretnéd a rendelési tételt ID: {selectedTetel.ID}?",
                    "Megerősítés",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (confirmResult == MessageBoxResult.Yes)
                {
                    using (var context = new HangszerekContext())
                    {
                        var tetel = context.RendelesTetel.Find(selectedTetel.ID);
                        if (tetel != null)
                        {
                            context.RendelesTetel.Remove(tetel);
                            context.SaveChanges();
                            MessageBox.Show("A rendelési tétel sikeresen törölve lett!", "Törlés sikeres", MessageBoxButton.OK, MessageBoxImage.Information);
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Nem található a rendelési tétel az adatbázisban.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Kérlek válassz ki egy rendelési tételt a törléshez!", "Nincs kiválasztva tétel", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
