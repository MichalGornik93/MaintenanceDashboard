using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class PreventionControl : UserControl
    {
        public PreventionControl()
        {
            InitializeComponent();
            this.DataContext = new PreventionViewModel(new PreventionContext());
        }
    }
}
