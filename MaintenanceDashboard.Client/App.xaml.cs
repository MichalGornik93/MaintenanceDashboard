using MaintenanceDashboard.Client;
using MaintenanceDashboard.Client.Views;
using MaterialDesignThemes.Wpf;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MaintenanceDashboard
{

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow window = new MainWindow();
            window.Show();
        }


        public App()
        {
            Dispatcher.UnhandledException += OnDispatcherUnhandledException;
        }

        void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            var errorMessage = string.Format("Wystąpił wyjątek: {0}", e.Exception.Message);
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //Write log containing our exception information
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\log.txt", e.Exception.StackTrace);
            e.Handled = true;
        }
        
    }
}
