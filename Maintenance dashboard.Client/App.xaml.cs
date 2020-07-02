using MaintenanceDashboard.Client;
using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.Domain;
using System.Windows;
using Unity;

namespace MaintenanceDashboard
{

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var container = new UnityContainer();

            container.RegisterType<IRegisterToolContext, RegisterToolContext>();
            container.RegisterType<IEmployeeContext, EmployeeContext>();
            container.RegisterType<IPaddleContext, PaddleContext>();
            container.RegisterType<BaseViewModel>();

            var window = new MainWindow
            {
                DataContext = container.Resolve<BaseViewModel>()
            };

            window.ShowDialog();
        }
    }
}
