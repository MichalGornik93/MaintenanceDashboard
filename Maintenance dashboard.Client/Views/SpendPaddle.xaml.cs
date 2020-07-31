using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.Api;
using System.Windows.Controls;
using System.Windows;

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

        private void btnSpendPaddle_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            gridInfoAddToDataBase.Visibility = Visibility.Visible;
            gridPrincipal.Visibility = Visibility.Collapsed;
        }
    }
}
