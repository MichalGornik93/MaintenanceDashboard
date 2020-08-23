using MaintenanceDashboard.Data.Api;
using MaintenanceDashboard.Data.Domain;
using MaintenanceDashboard.Library;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using MaintenanceDashboard.Common;
using MaintenanceDashboard.Data.Interfaces;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class ReceivedPaddleViewModel : ViewModel
    {
        private const string _paddleBarcodePattern = "Pal[0-9]{1,3}$";

        private readonly IReceivedPaddleContext context;

        public ICollection<ReceivedPaddle> ReceivedPaddles { get; }

        public string PaddleNumber { get; set; }
        public string DescriptionIntervention { get; set; }

        public EmployeeViewModel EmployeeViewModel { get; set; }
        
        public PaddleViewModel PaddleViewModel { get; set; }

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

        private DateTime _addedData = DateTime.Now;
        
        public DateTime AddedDate
        {
            get => _addedData;
            set => _addedData = value;
        }

        private string _repairData = DateTime.Now.ToString("dd/MM/yyyy");
        public string RepairDate
        {
            get => _repairData; 
            set => _repairData = value; 
        }

        private DateTime _plannedRepairDate = DateTime.Now.AddDays(2);
        public DateTime PlannedRepairDate
        {
            get => _plannedRepairDate; 
            set => _plannedRepairDate = value; 
        }
        public string Comments { get; set; }

        public string IsOrder { get; set; }

        public string ActivityPerformed { get; set; }


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

            EmployeeViewModel = new EmployeeViewModel(new EmployeeContext());
            PaddleViewModel = new PaddleViewModel(new PaddleContext());
        }

        public ActionCommand AcceptancePaddleCommand
        {
            get
            {
                return new ActionCommand(
                    p => AcceptancePaddle(),
                    p => IsValidReceivedPaddle());
            }
        }

        public ActionCommand SpendPaddleCommand
        {
            get
            {
                return new ActionCommand(
                    p => SpendPaddle(),
                    p => IsValidSpendedPaddle());
            }
        }

        private bool IsValidReceivedPaddle()
            => OnValidate(PaddleNumber) == null && EmployeeViewModel.SelectedEmployee != null && IsOrder != null && ActivityPerformed != null;

        private bool IsValidSpendedPaddle()
            => SelectedReceivedPaddle != null && !String.IsNullOrWhiteSpace(DescriptionIntervention) && EmployeeViewModel.SelectedEmployee != null;

        protected override string OnValidate(string propertyName)
        {
            if (String.IsNullOrEmpty(PaddleNumber))
                return Text.EMPTY_FIELD;
            if (!Regex.IsMatch(PaddleNumber, _paddleBarcodePattern))
                return Text.INVALID_PAL;
            if (context.CheckReceivedPaddleExist(PaddleNumber))
                return Text.PAL_DOES_NOT_EXIST;
            if (context.CheckIfIsAccepted(PaddleNumber))
                return Text.PAL_RECIVED;
            
            return base.OnValidate(propertyName);
        }

        private void AcceptancePaddle()
        {
            var receivedPaddle = new ReceivedPaddle
            {
                ReceivingEmployee = $"{EmployeeViewModel.SelectedEmployee.FirstName} {EmployeeViewModel.SelectedEmployee.LastName}",
                PaddleId = context.CheckForeignKey(PaddleNumber),
                AddedDate = AddedDate.ToString("dd/MM/yyyy"),
                ActivityPerformed = ActivityPerformed,
                PlannedRepairDate = PlannedRepairDate.ToString("dd/MM/yyyy"),
                Comments = Comments,
                IsOrders = IsOrder
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
