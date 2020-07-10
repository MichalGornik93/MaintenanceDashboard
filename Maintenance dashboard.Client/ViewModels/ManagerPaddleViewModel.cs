using MaintenanceDashboard.Data.Api;
using MaintenanceDashboard.Data.Domain;
using MaintenanceDashboard.Library;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class ManagerPaddleViewModel:ViewModel
    {
        private readonly IReceivedPaddleContext context;

        public ICollection<ReceivedPaddle> ReceivedPaddles;

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

        public ManagerPaddleViewModel(IReceivedPaddleContext context)
        {
            _EmployeeViewModel = new EmployeeViewModel(new EmployeeContext());
            _PaddleViewModel = new PaddleViewModel(new PaddleContext());
            this.context = context;
            ReceivedPaddles = new ObservableCollection<ReceivedPaddle>();
        }


        //public ICommand ContextInitializationCommand
        //{
        //    get
        //    {
        //        return new ActionCommand(p => ContextInitialization());
        //    }
        //}

        //public void ContextInitialization()
        //{
        //    _EmployeeViewModel.GetEmployeeList();
        //}
        
    }
}
