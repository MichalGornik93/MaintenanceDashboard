using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class HistorySpendedThermostat : UserControl
    {
        private readonly SpendedThermostatViewModel _spendedThermostatViewModel;
        public HistorySpendedThermostat()
        {
            _spendedThermostatViewModel = new SpendedThermostatViewModel(new SpendedThermostatContext());
            this.DataContext = _spendedThermostatViewModel;
            InitializeComponent();
        }
    }
}
