using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class HistorySpendedRobotToolsControl : UserControl
    {
        public HistorySpendedRobotToolsControl()
        {
            this.DataContext = new RobotToolsViewModel(new RobotToolsContext());
            InitializeComponent();
        }
    }
}
