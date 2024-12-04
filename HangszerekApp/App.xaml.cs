using System;
using System.IO;
using System.Windows;

namespace HangszerekApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                var exception = args.ExceptionObject as Exception;
                File.WriteAllText("error_log.txt", exception?.ToString() ?? "Ismeretlen hiba történt.");
            };

            base.OnStartup(e);
        }
    }
}
