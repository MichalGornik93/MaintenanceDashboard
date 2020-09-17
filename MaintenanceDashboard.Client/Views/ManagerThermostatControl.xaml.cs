using System.Windows;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class ManagerThermostatControl : UserControl
    {
        public ManagerThermostatControl()
        {
            InitializeComponent();
        }

        private void btnOpenAcceptanceThermostat_Checked(object sender, RoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new AcceptanceThermostatControl());
        }

        private void btnOpenSpendThermostat_Checked(object sender, RoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new SpendThermostatControl());
        }

        private void btnOpenAddThermostat_Checked(object sender, RoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new CreateThermostatControl());
        }

        private void btnOpenEditThermostat_Checked(object sender, RoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new EditThermostatControl());
        }

        private void btnOpenPerformedThermostatActivitiesList_Checked(object sender, RoutedEventArgs e)
        {
            GridPrincipal.Children.Clear();
            GridPrincipal.Children.Add(new HistorySpendedThermostat());
        }
    }
}
