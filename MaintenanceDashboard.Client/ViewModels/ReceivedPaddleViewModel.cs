using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Domain;
using MaintenanceDashboard.Common;
using MaintenanceDashbord.Common.Properties;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class ReceivedPaddleViewModel : ViewModel
    {
        private readonly ReceivedPaddleContext context;

        public ICollection<ReceivedPaddle> ReceivedPaddles { get; private set; }

        public string BarcodeNumber { get; set; }
        public string DescriptionIntervention { get; set; }
        public EmployeeViewModel EmployeeViewModel { get; }
        public PaddleViewModel PaddleViewModel { get; }

        private bool _connectedSuccessfully;
        public bool ConnectedSuccessfully
        {
            get { return _connectedSuccessfully; }
            set
            {
                _connectedSuccessfully = value;
                NotifyPropertyChanged();
            }
        }

        private DateTime _receivedDate = DateTime.Now;
        public DateTime ReceivedDate
        {
            get { return _receivedDate; }
            set { _receivedDate = value; }
        }

        private string _repairData = DateTime.Now.ToString(Resources.DateTimePattern);
        public string RepairDate
        {
            get { return _repairData; }
            set { _repairData = value; }
        }

        private DateTime _plannedRepairDate = DateTime.Now.AddDays(2);
        public DateTime PlannedRepairDate
        {
            get { return _plannedRepairDate; }
            set { _plannedRepairDate = value; }
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


        private ReceivedPaddle _selectedReceivedPaddle;
        public ReceivedPaddle SelectedReceivedPaddle
        {
            get { return _selectedReceivedPaddle; }
            set
            {
                _selectedReceivedPaddle = value;
                NotifyPropertyChanged();
            }
        }

        public ReceivedPaddleViewModel(ReceivedPaddleContext context)
        {
            this.context = context;

            ReceivedPaddles = new ObservableCollection<ReceivedPaddle>();

            EmployeeViewModel = new EmployeeViewModel(new EmployeeContext());
            PaddleViewModel = new PaddleViewModel(new PaddleContext());
        }

        public ActionCommand AcceptancePaddleCommand
        {
            get
            {
                return new ActionCommand(p => AcceptancePaddle(),
                    p => IsValidReceivedPaddle());
            }
        }

        public ActionCommand SpendPaddleCommand
        {
            get
            {
                return new ActionCommand(p => SpendPaddle(),
                    p => IsValidSpendedPaddle());
            }
        }

        private bool IsValidReceivedPaddle()
        {
            if (OnValidate(BarcodeNumber) == null 
                && EmployeeViewModel.SelectedEmployee != null 
                && PlannedRepairDate != null 
                && ReceivedDate != null 
                && IsOrder != null 
                && ActivityPerformed != null)
                return true;
            return false;
        }

        private bool IsValidSpendedPaddle()
        {
            if (SelectedReceivedPaddle != null 
                && !String.IsNullOrWhiteSpace(DescriptionIntervention) 
                && EmployeeViewModel.SelectedEmployee != null)
                return true;
            return false;

        }

        protected override string OnValidate(string propertyName)
        {
            if (String.IsNullOrEmpty(BarcodeNumber))
                return "Pole musi być wypełnione";
            else if (!Regex.IsMatch(BarcodeNumber, Resources.PaddleBarcodePattern))
                return "Niepoprawna składnia ciągu {Pal...}";
            else if (context.CheckIfReceivedPaddleExist(BarcodeNumber))
                return "Paletka nie istnieje w bazie danych";
            else if (context.CheckIfIsAccepted(BarcodeNumber))
                return "Paletka jest już przyjęta";
            return base.OnValidate(propertyName);
        }

        private void AcceptancePaddle()
        {
            var receivedPaddle = new ReceivedPaddle
            {
                ReceivingEmployee = String.Format("{0} {1}", EmployeeViewModel.SelectedEmployee.FirstName, EmployeeViewModel.SelectedEmployee.LastName),
                PaddleId = context.CheckForeignKey(BarcodeNumber),
                ReceivedDate = ReceivedDate.ToString(Resources.DateTimePattern),
                ActivityPerformed = ActivityPerformed,
                PlannedRepairDate = PlannedRepairDate.ToString(Resources.DateTimePattern),
                Comments = Comments,
                IsOrders = IsOrder.ToString()
            };
            context.CreateReceivedPaddle(receivedPaddle);
            ConnectedSuccessfully = true;
        }

        public void SpendPaddle()
        {
            var spendedPaddle = new SpendedPaddle
            {
                PaddleId = SelectedReceivedPaddle.PaddleId,
                ReceivedDate = SelectedReceivedPaddle.ReceivedDate,
                ActivityPerformed = SelectedReceivedPaddle.ActivityPerformed,
                RepairDate = RepairDate,
                Comments = SelectedReceivedPaddle.Comments,
                IsOrders = SelectedReceivedPaddle.IsOrders,
                DescriptionIntervention = DescriptionIntervention,
                ReceivingEmployee = SelectedReceivedPaddle.ReceivingEmployee,
                SpendingEmployee = String.Format("{0} {1}", EmployeeViewModel.SelectedEmployee.FirstName, EmployeeViewModel.SelectedEmployee.LastName)
            };
            context.CreateSpendedPaddle(spendedPaddle);
            context.UpdateLastPreventionDate(SelectedReceivedPaddle);

            if (SelectedReceivedPaddle != null)
            {
                context.DeleteReceivedPaddle(SelectedReceivedPaddle);
                ReceivedPaddles.Remove(SelectedReceivedPaddle);
                SelectedReceivedPaddle = null;
            }
            ConnectedSuccessfully = true;
        }

        public void GetReceivedPaddleList()
        {
            ReceivedPaddles.Clear();

            foreach (var item in context.GetReceivedPaddleList())
                ReceivedPaddles.Add(item);
        }
    }
}
