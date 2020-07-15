using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.Api;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{

    public partial class AcceptancePaddle : UserControl
    {
        private ManagerPaddleViewModel _managerPaddleViewModel;
        public AcceptancePaddle()
        {
            _managerPaddleViewModel = new ManagerPaddleViewModel(new ReceivedPaddleContext());
            this.DataContext = _managerPaddleViewModel;
            _managerPaddleViewModel.GetReceivedPaddleList();
            _managerPaddleViewModel.EmployeeViewModel.GetEmployeeList();
            InitializeComponent();
        }
    }
}
