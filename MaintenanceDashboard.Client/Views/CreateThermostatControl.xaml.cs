using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class CreateThermostatControl : UserControl
    {
        public CreateThermostatControl()
        {
            InitializeComponent();
            this.DataContext = new ThermostatViewModel(new ThermostatContext());
        }
    }
}
