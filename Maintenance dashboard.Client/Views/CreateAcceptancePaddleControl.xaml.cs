using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.Api;
using System.Windows.Controls;

namespace MaintenanceDashboard.Client.Views
{

    public partial class CreateAcceptancePaddle : UserControl
    {
        private ReceivedPaddleViewModel _managerPaddleViewModel;
        public CreateAcceptancePaddle()
        {
            _managerPaddleViewModel = new ReceivedPaddleViewModel(new ReceivedPaddleContext());
            this.DataContext = _managerPaddleViewModel;
            _managerPaddleViewModel.GetReceivedPaddleList();
            _managerPaddleViewModel.EmployeeViewModel.GetEmployeeList();
            _managerPaddleViewModel.PaddleViewModel.GetPaddleList();
            InitializeComponent();
        }
    }
}
