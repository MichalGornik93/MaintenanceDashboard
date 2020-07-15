using MaintenanceDashboard.Data.Api;
using MaintenanceDashboard.Data.Domain;
using MaintenanceDashboard.Library;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class ReceivedPaddleViewModel:ViewModel
    {
        private readonly IReceivedPaddleContext context;

        public ICollection<ReceivedPaddle> ReceivedPaddles { get; private set; }

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

        public ReceivedPaddleViewModel(IReceivedPaddleContext context)
        {
            this.context = context;

            ReceivedPaddles = new ObservableCollection<ReceivedPaddle>();

            _EmployeeViewModel = new EmployeeViewModel(new EmployeeContext());
            _PaddleViewModel = new PaddleViewModel(new PaddleContext());
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
            ReceivedPaddles.Add(receivedPaddle);

            //TODO: Implements clean textbox
        }

        public void GetReceivedPaddleList()
        {
            ReceivedPaddles.Clear();

            foreach (var item in context.GetReceivedPaddleList())
                ReceivedPaddles.Add(item);
                
        }

        private void SaveReceivedPaddle()
        {

        }

        private void DeleteReceivedPaddle()
        {

        }

    }
}
