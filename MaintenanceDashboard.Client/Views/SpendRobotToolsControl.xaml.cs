using MaintenanceDashboard.Client.ViewModels;
using System.Windows.Controls;
using MaintenanceDashboard.Data.API;

namespace MaintenanceDashboard.Client.Views
{
    public partial class SpendRobotToolsControl : UserControl
    {
        public SpendRobotToolsControl()
        {
            InitializeComponent();
            this.DataContext = new RobotToolsViewModel(new RobotToolsContext());
        }
    }
}
