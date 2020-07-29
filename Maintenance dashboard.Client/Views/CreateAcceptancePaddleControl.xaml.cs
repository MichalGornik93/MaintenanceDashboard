using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.Api;
using System.Windows.Controls;
using System.Windows;

namespace MaintenanceDashboard.Client.Views
{

    public partial class CreateAcceptancePaddle : UserControl
    {
        private ReceivedPaddleViewModel _managerPaddleViewModel;
        public CreateAcceptancePaddle()
        {
            _managerPaddleViewModel = new ReceivedPaddleViewModel(new ReceivedPaddleContext());
            this.DataContext = _managerPaddleViewModel;
            _managerPaddleViewModel.EmployeeViewModel.GetEmployeeList();
            InitializeComponent();
        }

        private void btnGetPaddle_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            gridInfoAddToDataBase.Visibility = Visibility.Visible;
            gridPrincipal.Visibility = Visibility.Collapsed;
        }
    }
}
