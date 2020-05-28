using MaintenanceDashboard.Client;
using MaintenanceDashboard.Client.ViewModels;
using System.Windows;

namespace MaintenanceDashboard
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new MainWindow
            {
                DataContext = new RegisterToolViewlModel()
            };

            window.ShowDialog();
        }
    }
}
