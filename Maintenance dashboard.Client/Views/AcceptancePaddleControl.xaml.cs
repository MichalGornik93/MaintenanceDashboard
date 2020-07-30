using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.Api;
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

        private void btnGetPaddle_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            gridInfoAddToDataBase.Visibility = Visibility.Visible;
            gridPrincipal.Visibility = Visibility.Collapsed;
        }

        private void employeeComboBox_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _receivedPaddleViewModel.EmployeeViewModel.GetEmployeeList();
        }
    }
}
