using System.Linq;
using System.Windows;
using HangszerekApp.Models;

namespace HangszerekApp
{
    public partial class UgyfelekWindow : Window
    {
        public UgyfelekWindow()
        {
            InitializeComponent();
            LoadData();
        }

        // Ügyfelek adatainak betöltése
        private void LoadData()
        {
            using (var context = new HangszerekContext())
            {
                UgyfelekGrid.ItemsSource = context.Ugyfelek.ToList();
            }
        }

        // Új ügyfél hozzáadása
        private void AddUgyfel_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddUgyfelWindow();
            if (addWindow.ShowDialog() == true)
            {
                using (var context = new HangszerekContext())
                {
                    context.Ugyfelek.Add(addWindow.NewUgyfel);
                    context.SaveChanges();
                }
                LoadData(); // Frissítjük az adatokat
                MessageBox.Show("Új ügyfél sikeresen hozzáadva!", "Siker", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Ügyfél módosítása
        private void EditUgyfel_Click(object sender, RoutedEventArgs e)
        {
            if (UgyfelekGrid.SelectedItem is Ugyfel selectedUgyfel)
            {
                var editWindow = new EditUgyfelWindow(selectedUgyfel);
                if (editWindow.ShowDialog() == true)
                {
                    using (var context = new HangszerekContext())
                    {
                        context.Ugyfelek.Update(selectedUgyfel);
                        context.SaveChanges();
                    }
                    LoadData(); // Frissítjük az adatokat
                    MessageBox.Show("Ügyfél adatai sikeresen módosítva!", "Siker", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Válassz ki egy ügyfelet a módosításhoz!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Ügyfél törlése
        private void DeleteUgyfel_Click(object sender, RoutedEventArgs e)
        {
            if (UgyfelekGrid.SelectedItem is Ugyfel selectedUgyfel)
            {
                var result = MessageBox.Show("Biztosan törölni szeretnéd ezt az ügyfelet?", "Megerősítés", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new HangszerekContext())
                    {
                        context.Ugyfelek.Remove(selectedUgyfel);
                        context.SaveChanges();
                    }
                    LoadData(); // Frissítjük az adatokat
                    MessageBox.Show("Ügyfél sikeresen törölve!", "Siker", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Válassz ki egy ügyfelet a törléshez!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
