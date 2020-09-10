using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.API;
using System.Windows.Controls;
using System.Windows;

namespace MaintenanceDashboard.Client.Views
{

    public partial class AcceptancePaddleControl : UserControl
    {
        private ReceivedPaddleViewModel _receivedPaddleViewModel;
        public AcceptancePaddleControl()
        {
            _receivedPaddleViewModel = new ReceivedPaddleViewModel(new ReceivedPaddleContext());
            this.DataContext = _receivedPaddleViewModel;
           InitializeComponent();
        }

        private void employeeComboBox_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _receivedPaddleViewModel.EmployeeViewModel.GetEmployeeList();
        }
    }
}
