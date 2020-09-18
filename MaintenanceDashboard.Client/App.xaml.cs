using MaintenanceDashboard.Client;
using MaintenanceDashboard.Data.Models;
using System;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Runtime.Remoting.Contexts;
using System.Windows;

namespace MaintenanceDashboard
{

    public partial class App : Application
    {
        public App()
        {
            Dispatcher.UnhandledException += OnDispatcherUnhandledException;
        }

        void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            var errorMessage = string.Format("An exception occurred: {0}", e.Exception.Message);
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //Write log containing our exception information
            File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory + "\\log.txt", e.Exception.StackTrace);
            e.Handled = true;
        }
    }
}
