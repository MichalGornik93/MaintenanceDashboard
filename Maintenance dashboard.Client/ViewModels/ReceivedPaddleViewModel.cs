using MaintenanceDashboard.Data.Api;
using MaintenanceDashboard.Data.Domain;
using MaintenanceDashboard.Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Linq;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class ReceivedPaddleViewModel : ViewModel
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

        private string _addedData = DateTime.Now.ToString("MM/dd/yyyy");
        public string AddedDate
        {
            get { return _addedData; }
            set { _addedData = value; }
        }

        private string _repairData = DateTime.Now.ToString("MM/dd/yyyy");
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

        public string Number { get; set; }

        public string DescriptionIntervention { get; set; }

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

        public ReceivedPaddleViewModel(IReceivedPaddleContext context)
        {
            this.context = context;

            ReceivedPaddles = new ObservableCollection<ReceivedPaddle>();

            _EmployeeViewModel = new EmployeeViewModel(new EmployeeContext());
            _PaddleViewModel = new PaddleViewModel(new PaddleContext());
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
                    p => SelectedReceivedPaddle != null &&
                    !String.IsNullOrWhiteSpace(DescriptionIntervention) &&
                     EmployeeViewModel.SelectedEmployee != null);
            }
        }

        private bool IsValidReceivedPaddle()
        {
            if (OnValidate(Number) == null && EmployeeViewModel.SelectedEmployee != null && PlannedRepairDate != null && IsOrder != null && ActivityPerformed != null)
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
                return "Paletka nie istnieje w bazie danych";
            else if(context.CheckIfIsAccepted(Number))
                return "Paletka jest już przyjęta";
            return base.OnValidate(propertyName);
        }

        private void AcceptancePaddle()
        {
            var receivedPaddle = new ReceivedPaddle
            {
                EmployeeId = EmployeeViewModel.SelectedEmployee.Id,
                PaddleId = context.CheckForeignKey(Number),
                AddedDate = AddedDate,
                ActivityPerformed = ActivityPerformed,
                PlannedRepairDate = PlannedRepairDate.ToString("MM/dd/yyyy"),
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
                AddedDate = SelectedReceivedPaddle.AddedDate,
                ActivityPerformed = SelectedReceivedPaddle.ActivityPerformed,
                RepairDate = RepairDate,
                Comments = SelectedReceivedPaddle.Comments,
                IsOrders = SelectedReceivedPaddle.IsOrders,
                DescriptionIntervention = DescriptionIntervention,
                ReceivingEmployee = SelectedReceivedPaddle.Employee,
                SpendingEmployee = context.CheckEmployee(EmployeeViewModel.SelectedEmployee)
            };
            context.CreateSpendedPaddle(spendedPaddle);

            ConnectedSuccessfully = true;

            context.UpdateLastPreventionDate(SelectedReceivedPaddle);

            if (SelectedReceivedPaddle != null)
            {
                context.DeleteReceivedPaddle(SelectedReceivedPaddle);
                ReceivedPaddles.Remove(SelectedReceivedPaddle);
                SelectedReceivedPaddle = null;
            }

            
        }

        public void GetReceivedPaddleList()
        {
            ReceivedPaddles.Clear();

            foreach (var item in context.GetReceivedPaddleList())
                ReceivedPaddles.Add(item);
        }
    }
}
