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

        public ActionCommand CreateReceivedPaddleCommand
        {
            get
            {
                return new ActionCommand(p => CreateReceivedPaddle());
            }
            //TODO: Implementation data validation
        }

        private void CreateReceivedPaddle()
        {
            var receivedPaddle = new ReceivedPaddle
            {
                Employee = EmployeeViewModel.SelectedEmployee.LastName,
                DateAdded = "Test",
                PreventiveAction = "Test",
                PlannedRepairTime = "Test",
                Comments = "Test",
                IsOrders = "Test"

            };

            context.CreateReceivedPaddle(receivedPaddle);

            //TODO: Implements clean textbox
        }

        private void GetReceivedPaddleList()
        {

        }

        private void SaveReceivedPaddle()
        {

        }

        private void DeleteReceivedPaddle()
        {

        }

    }
}
