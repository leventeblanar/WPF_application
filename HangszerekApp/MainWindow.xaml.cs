using System.Windows;

namespace HangszerekApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenHangszerek(object sender, RoutedEventArgs e)
        {
            var window = new HangszerekWindow();
            window.Show();
        }

        private void OpenUgyfelek(object sender, RoutedEventArgs e)
        {
            var window = new UgyfelekWindow();
            window.Show();
        }

        private void OpenRendelesek(object sender, RoutedEventArgs e)
        {
            var rendelesekWindow = new RendelesekWindow();
            rendelesekWindow.Show();
        }

        private void OpenRendelesTetel(object sender, RoutedEventArgs e)
        {
            var rendelesTetelWindow = new RendelesTetelWindow();
            rendelesTetelWindow.Show();
        }

        private void OpenSzallitok(object sender, RoutedEventArgs e)
        {
            var szallitokWindow = new SzallitokWindow();
            szallitokWindow.Show();
        }
    }
}

