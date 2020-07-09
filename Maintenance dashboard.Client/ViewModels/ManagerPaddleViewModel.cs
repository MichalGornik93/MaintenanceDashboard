using MaintenanceDashboard.Data.Api;
using MaintenanceDashboard.Library;
using System.Windows.Input;

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

        public ICommand ContextInitializationCommand
        {
            get
            {
                return new ActionCommand(p => ContextInitialization());
            }
        }

        public void ContextInitialization()
        {
            _EmployeeViewModel.GetEmployeeList();
        }
        
    }
}
