using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.Api;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{
    public partial class SpendPaddle : UserControl
    {
        private ReceivedPaddleViewModel _receivedPaddleViewModel;
        public SpendPaddle()
        {
            _receivedPaddleViewModel = new ReceivedPaddleViewModel(new ReceivedPaddleContext());
            this.DataContext = _receivedPaddleViewModel;
            _receivedPaddleViewModel.GetReceivedPaddleList();
            InitializeComponent();
        }

        private void employeeComboBox_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _receivedPaddleViewModel.EmployeeViewModel.GetEmployeeList();
        }
    }
}
