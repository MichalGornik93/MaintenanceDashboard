using MaintenanceDashboard.Client;
using MaintenanceDashboard.Data.Domain;
using System;
using System.Data.Entity.Infrastructure;
using System.Runtime.Remoting.Contexts;
using System.Windows;

namespace MaintenanceDashboard
{

    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            using (DataContext context = new DataContext())
            {

                try
                {
                    context.Database.Connection.Open();
                    context.Database.Connection.Close();
                }
                catch (Exception a)
                {
                    MessageBox.Show("Brak połączenia z MS SQL Server","Alarm", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }

            base.OnStartup(e);

            var window = new MainWindow();
            window.Show();
        }
    }
}
