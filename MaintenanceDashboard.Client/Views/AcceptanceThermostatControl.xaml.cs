using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaintenanceDashboard.Client.Views
{
    public partial class AcceptanceThermostatControl : UserControl
    {
        private readonly ReceivedThermostatViewModel _receivedThermostatViewModel;
        public AcceptanceThermostatControl()
        {
            _receivedThermostatViewModel = new ReceivedThermostatViewModel(new ReceivedThermostatContext());
            this.DataContext = _receivedThermostatViewModel;
            InitializeComponent();
        }

        private void employeeComboBox_GotMouseCapture(object sender, MouseEventArgs e)
        {
            _receivedThermostatViewModel.EmployeeViewModel.GetEmployeeList();
        }
    }
}
