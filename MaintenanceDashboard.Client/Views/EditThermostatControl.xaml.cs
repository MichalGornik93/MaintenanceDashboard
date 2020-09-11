using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class EditThermostatControl : UserControl
    {
        public EditThermostatControl()
        {
            InitializeComponent();
            var _thermostatViewModel = new ThermostatViewModel(new ThermostatContext());
            this.DataContext = _thermostatViewModel;
            _thermostatViewModel.GetThermostatList();
        }
    }
}
