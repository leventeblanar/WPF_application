using System.Linq;
using System.Windows;
using HangszerekApp.Models;

namespace HangszerekApp
{
    public partial class HangszerekWindow : Window
    {
        public HangszerekWindow()
        {
            InitializeComponent();
            LoadData();
        }

        // Adatok betöltése
        private void LoadData()
        {
            using (var context = new HangszerekContext())
            {
                HangszerekGrid.ItemsSource = context.Hangszerek.ToList();
            }
        }

        // Rendelések ablak megnyitása
        private void OpenRendelesek(object sender, RoutedEventArgs e)
        {
            var rendelesekWindow = new RendelesekWindow();
            rendelesekWindow.Show();
        }

        // Új hangszer hozzáadása
        private void AddHangszer_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddHangszerWindow();
            if (addWindow.ShowDialog() == true)
            {
                try
                {
                    using (var context = new HangszerekContext())
                    {
                        context.Hangszerek.Add(addWindow.NewHangszer);
                        context.SaveChanges();
                    }
                    LoadData(); // Frissítjük az adatokat
                    MessageBox.Show("Új hangszer hozzáadva!");
                }
                catch
                {
                    MessageBox.Show("Hiba történt a hangszer hozzáadása során.");
                }
            }
        }

        // Hangszer módosítása
        private void EditHangszer_Click(object sender, RoutedEventArgs e)
        {
            if (HangszerekGrid.SelectedItem is Hangszer selectedHangszer)
            {
                var editWindow = new EditHangszerWindow(selectedHangszer);
                if (editWindow.ShowDialog() == true)
                {
                    try
                    {
                        using (var context = new HangszerekContext())
                        {
                            context.Hangszerek.Update(selectedHangszer);
                            context.SaveChanges();
                        }
                        LoadData(); // Frissítjük az adatokat
                        MessageBox.Show("Hangszer sikeresen módosítva!");
                    }
                    catch
                    {
                        MessageBox.Show("Hiba történt a hangszer módosítása során.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Válassz ki egy hangszert a módosításhoz!");
            }
        }

        // Hangszer törlése
        private void DeleteHangszer_Click(object sender, RoutedEventArgs e)
        {
            if (HangszerekGrid.SelectedItem is Hangszer selectedHangszer)
            {
                var result = MessageBox.Show(
                    "Biztosan törölni szeretnéd ezt a hangszert?",
                    "Törlés megerősítése",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        using (var context = new HangszerekContext())
                        {
                            context.Hangszerek.Remove(selectedHangszer);
                            context.SaveChanges();
                        }
                        LoadData(); // Frissítjük az adatokat
                        MessageBox.Show("Hangszer sikeresen törölve!");
                    }
                    catch
                    {
                        MessageBox.Show("Hiba történt a hangszer törlése során.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Válassz ki egy hangszert a törléshez!");
            }
        }
    }
}
