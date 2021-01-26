using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class HistorySpendedThermostatControl : UserControl
    {
        public HistorySpendedThermostatControl()
        {
            this.DataContext = new SpendedThermostatViewModel(new SpendedThermostatContext());
            InitializeComponent();
        }
    }
}
