using System.Linq;
using System.Windows;
using HangszerekApp.Models;

namespace HangszerekApp
{
    public partial class SzallitokWindow : Window
    {
        public SzallitokWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (var context = new HangszerekContext())
            {
                SzallitokGrid.ItemsSource = context.Szallitok.ToList();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new AddSzallitoWindow();
            if (addWindow.ShowDialog() == true)
            {
                using (var context = new HangszerekContext())
                {
                    context.Szallitok.Add(addWindow.NewSzallito);
                    context.SaveChanges();
                }
                MessageBox.Show("Új szállító sikeresen hozzáadva!", "Hozzáadás");
                LoadData();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (SzallitokGrid.SelectedItem is Szallito selectedSzallito)
            {
                var editWindow = new EditSzallitoWindow(selectedSzallito);
                if (editWindow.ShowDialog() == true)
                {
                    using (var context = new HangszerekContext())
                    {
                        context.Szallitok.Update(selectedSzallito);
                        context.SaveChanges();
                    }
                    MessageBox.Show("Szállító sikeresen módosítva!", "Módosítás");
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Kérlek válassz ki egy szállítót a módosításhoz!", "Figyelmeztetés");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SzallitokGrid.SelectedItem is Szallito selectedSzallito)
            {
                var result = MessageBox.Show("Biztosan törölni szeretnéd ezt a szállítót?", "Megerősítés", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    using (var context = new HangszerekContext())
                    {
                        context.Szallitok.Remove(selectedSzallito);
                        context.SaveChanges();
                    }
                    MessageBox.Show("Szállító sikeresen törölve!", "Törlés");
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Kérlek válassz ki egy szállítót a törléshez!", "Figyelmeztetés");
            }
        }
    }
}
