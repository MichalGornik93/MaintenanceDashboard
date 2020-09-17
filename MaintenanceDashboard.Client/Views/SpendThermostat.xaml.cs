using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows.Controls;
using System.Windows.Input;

namespace MaintenanceDashboard.Client.Views
{
    public partial class SpendThermostatControl : UserControl
    {
        private readonly ReceivedThermostatViewModel _receivedThermostatViewModel;
        public SpendThermostatControl()
        {
            _receivedThermostatViewModel = new ReceivedThermostatViewModel(new ReceivedThermostatContext());
            this.DataContext = _receivedThermostatViewModel;
            _receivedThermostatViewModel.GetReceivedThermostatList();
            InitializeComponent();
        }

        private void employeeComboBox_GotMouseCapture(object sender, MouseEventArgs e)
        {
            _receivedThermostatViewModel.EmployeeViewModel.GetEmployeeList();
        }
    }
}
