using System.Windows.Controls;
using MaintenanceDashboard.Client.ViewModels;

namespace MaintenanceDashboard.Client.Views
{
    public partial class ServiceControl : UserControl
    {
        public ServiceControl()
        {
            InitializeComponent();
            this.DataContext = new ServiceControlViewModel();
        }
    }
}
