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

            InitializeComponent();
            _managerPaddleViewModel = new ManagerPaddleViewModel();
            _managerPaddleViewModel.EmployeeViewModel.GetEmployeeList();
            this.DataContext = _managerPaddleViewModel;
        }
    }
}
