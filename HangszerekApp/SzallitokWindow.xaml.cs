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
    }
}
