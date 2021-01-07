using MaintenanceDashboard.Client;
using MaintenanceDashboard.Common.PlcService;
using System;
using System.IO;
using System.Windows;

namespace MaintenanceDashboard
{
    public partial class App : Application
    {
        private eCmmsPlc eCmmsPlc;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow window = new MainWindow();
            window.Show();
            eCmmsPlc = new eCmmsPlc();
        }

        public App()
        {

            Dispatcher.UnhandledException += OnDispatcherUnhandledException;
        }

        void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            var errorMessage = string.Format("Wystąpił wyjątek: {0}", e.Exception.Message);
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            e.Handled = true;
        }




    }
}
