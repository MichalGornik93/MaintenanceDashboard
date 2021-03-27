using MaintenanceDashboard.Client.ViewModels;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class SettingsControl : UserControl
    {
        public SettingsControl()
        {
            this.DataContext = new SettingsViewModel();
            InitializeComponent();
        }
    }
}
