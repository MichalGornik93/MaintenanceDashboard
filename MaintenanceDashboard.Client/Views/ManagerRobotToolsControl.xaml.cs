using System.Windows;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class ManagerRobotToolsControl : UserControl
    {
        public ManagerRobotToolsControl()
        {
            InitializeComponent();
        }

        private void btnOpenPerformedRobotToolsActivitiesList_Checked(object sender, RoutedEventArgs e)
        {
            if (GridPrincipal != null)
            {
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new HistorySpendedRobotToolsControl());
            }
        }

        private void btnOpenManualPreventionRobotTool_Checked(object sender, RoutedEventArgs e)
        {
            if (GridPrincipal != null)
            {
                GridPrincipal.Children.Clear();
                GridPrincipal.Children.Add(new SpendRobotToolsControl());
            }
        }
    }
}
