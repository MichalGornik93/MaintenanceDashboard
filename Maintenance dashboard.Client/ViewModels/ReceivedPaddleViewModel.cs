using MaintenanceDashboard.Data.Api;
using MaintenanceDashboard.Data.Domain;
using MaintenanceDashboard.Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

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

        private string _addedData = DateTime.Now.ToString("MM/dd/yyyy");
        public string AddedDate
        {
            get { return _addedData; }
            set { _addedData = value; }
        }

        private DateTime _repairDate=DateTime.Now.AddDays(2);

        public DateTime RepairDate
        {
            get { return _repairDate; }
            set { _repairDate = value; }
        }
        public string Comments { get; set; }

        private string _isOrder;

        public string IsOrder
        {
            get { return _isOrder; }
            set { _isOrder = value; }
        }
        public string PaddleNumber { get; set; }



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

        private void CreateReceivedPaddle() //TODO: Implemented arguments
        {
            var receivedPaddle = new ReceivedPaddle
            {
                Employee = EmployeeViewModel.SelectedEmployee.LastName,
                PaddleNumber = PaddleNumber,
                DateAdded = AddedDate,
                PreventiveAction = "Test",
                PlannedRepairTime = RepairDate.ToString("MM/dd/yyyy"),
                Comments = Comments,
                IsOrders = IsOrder.ToString()
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
