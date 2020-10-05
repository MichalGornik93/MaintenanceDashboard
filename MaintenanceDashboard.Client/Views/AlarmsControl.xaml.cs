using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class AlarmsControl : UserControl
    {
        public AlarmsControl()
        {
            InitializeComponent();
            this.DataContext = new AlarmsViewModel(new AlarmsContext());
        }
    }
}
