using MaintenanceDashboard.Client;
using MaintenanceDashboard.Client.Infrastructure;
using System.Windows;

namespace MaintenanceDashboard
{
    public partial class App : Application
    {
        private SmartWorkshopPlc smartWorkshopPlc;
        private RobotToolsPlc robotToolsPlc;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow window = new MainWindow();
            window.Show();
            smartWorkshopPlc = new SmartWorkshopPlc();
            robotToolsPlc = new RobotToolsPlc();
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
