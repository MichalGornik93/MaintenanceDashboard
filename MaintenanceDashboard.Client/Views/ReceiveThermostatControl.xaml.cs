using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaintenanceDashboard.Client.Views
{
    public partial class AcceptanceThermostatControl : UserControl
    {
        public AcceptanceThermostatControl()
        {
            this.DataContext = new ReceivedThermostatViewModel(new ReceivedThermostatContext());
            InitializeComponent();
        }
    }
}
