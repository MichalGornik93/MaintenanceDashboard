using MaintenanceDashboard.Client;
using MaintenanceDashboard.Client.ViewModels;
using System.Windows;

namespace MaintenanceDashboard
{

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new MainWindow
            {
                DataContext = new RegisterToolViewModel()
            };

            window.ShowDialog();
        }
    }
}
