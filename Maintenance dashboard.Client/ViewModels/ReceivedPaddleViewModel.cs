using MaintenanceDashboard.Data.Api;
using MaintenanceDashboard.Data.Domain;
using MaintenanceDashboard.Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class ReceivedPaddleViewModel:ViewModel
    {
        private const string _paddleBarcodePattern = "Pal[0-9]{1,3}$";

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

        private string _activityPerformed;

        public string ActivityPerformed
        {
            get { return _activityPerformed; }
            set { _activityPerformed = value; }
        }

        public string Number { get; set; }



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
                return new ActionCommand(p => CreateReceivedPaddle(EmployeeViewModel.SelectedEmployee, Number, AddedDate, ActivityPerformed, RepairDate, Comments, IsOrder),
                    p => IsValidReceivedPaddle());
            }
        }

        private bool IsValidReceivedPaddle()
        {
            if (OnValidate(Number) == null && EmployeeViewModel.SelectedEmployee != null && RepairDate != null && IsOrder != null && ActivityPerformed != null) 
                return true;
            return false;
        }

        protected override string OnValidate(string propertyName)
        {
            if (String.IsNullOrEmpty(Number))
                return "Pole musi być wypełnione";
            else if (!Regex.IsMatch(Number, _paddleBarcodePattern))
                return "Niepoprawna składnia ciągu {Pal...}";
            else if (context.CheckReceivedPaddleExist(Number))
                return "Nie istnieje w bazie danych";
            return base.OnValidate(propertyName);
        }


        private void CreateReceivedPaddle(Employee employee, string number, string addedDate, string activityPerformed, DateTime planedRepairDate, string comments, string isOrder) 
        {
            var receivedPaddle = new ReceivedPaddle
            {
                EmployeeId = employee.Id,
                NumberId = context.CheckForeignKey(number), 
                DateAdded = addedDate,
                ActivityPerformed = activityPerformed,
                PlannedRepairTime = planedRepairDate.ToString("MM/dd/yyyy"),
                Comments = comments,
                IsOrders = isOrder.ToString()
            };

            context.CreateReceivedPaddle(receivedPaddle);

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
