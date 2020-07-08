using MaintenanceDashboard.Data.Api;
using MaintenanceDashboard.Data.Domain;
using MaintenanceDashboard.Library;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class ManagerPaddleViewModel:ViewModel
    {
        private EmployeeViewModel _EmployeeViewModel;
        public EmployeeViewModel EmployeeViewModel
        {
            get { return _EmployeeViewModel; }
        }

        private PaddleViewModel _PaddleViewModel;
        public PaddleViewModel PaddleViewModel
        {
            get { return _PaddleViewModel; }
        }



        public ManagerPaddleViewModel()
        {
            _EmployeeViewModel = new EmployeeViewModel(new EmployeeContext());
            _PaddleViewModel = new PaddleViewModel(new PaddleContext());
        }
        
    }
}
