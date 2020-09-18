using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MaintenanceDashboard.Client.Interfaces;
using MaintenanceDashboard.Common;
using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Models;
using MaintenanceDashbord.Common.Properties;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class ReceivedThermostatViewModel : ViewModel, IReceivedComponent
    {
        private readonly ReceivedThermostatContext context;
        public ICollection<ReceivedThermostat> ReceivedThermostats { get; private set; }
        public EmployeeViewModel EmployeeViewModel { get; }
        public ThermostatViewModel ThermostatViewModel { get; set; }
        public string CurrentLocation { get; set; }

        public string BarcodeNumber { get; set; }
        public string DescriptionIntervention { get; set; }
        public DateTime ReceivedDate { get; set; } = DateTime.Now;
        public string RepairDate { get; set; } = DateTime.Now.ToString(Resources.DateTimePattern);
        public DateTime PlannedRepairDate { get; set; } = DateTime.Now.AddDays(2);
        public string Comments { get; set; }
        public string IsOrder { get; set; }
        public string ActivityPerformed { get; set; }

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

        private ReceivedThermostat _selectedReceivedThermostat;
        public ReceivedThermostat SelectedReceivedThermostat
        {
            get { return _selectedReceivedThermostat; }
            set
            {
                _selectedReceivedThermostat = value;
                NotifyPropertyChanged();
            }
        }

        public ReceivedThermostatViewModel(ReceivedThermostatContext context)
        {
            this.context = context;

            ReceivedThermostats = new ObservableCollection<ReceivedThermostat>();
            EmployeeViewModel = new EmployeeViewModel(new EmployeeContext());
            ThermostatViewModel = new ThermostatViewModel(new ThermostatContext());
            EmployeeViewModel.GetEmployeeList();
            GetList();
        }

        public ActionCommand AcceptanceThermostatCommand
        {
            get
            {
                return new ActionCommand(p => Acceptance(),
                    p => IsValidReceivedThermostat());
            }
        }

        public ActionCommand SpendThermostatCommand
        {
            get
            {
                return new ActionCommand(p => Spend(),
                    p => IsValidSpendedThermostat());
            }
        }

        public void Acceptance()
        {
            var receivedThermostat = new ReceivedThermostat
            {
                ReceivingEmployee = String.Format("{0} {1}", EmployeeViewModel.SelectedEmployee.FirstName, EmployeeViewModel.SelectedEmployee.LastName),
                ThermostatId = context.CheckForeignKey(BarcodeNumber),
                ReceivedDate = ReceivedDate.ToString(Resources.DateTimePattern),
                ActivityPerformed = ActivityPerformed,
                PlannedRepairDate = PlannedRepairDate.ToString(Resources.DateTimePattern),
                Comments = Comments,
                IsOrders = IsOrder.ToString(),
                LastLocation = context.CheckLastLocation(BarcodeNumber)
            };

            context.UpdateCurrentLocation(receivedThermostat, "Warsztat");
            context.CreateReceivedThermostat(receivedThermostat);

            ConnectedSuccessfully = true;
        }

        public void Spend()
        {
            var spendedThermostat = new SpendedThermostat
            {
                ThermostatId = SelectedReceivedThermostat.ThermostatId,
                ReceivedDate = SelectedReceivedThermostat.ReceivedDate,
                ActivityPerformed = SelectedReceivedThermostat.ActivityPerformed,
                RepairDate = RepairDate,
                Comments = SelectedReceivedThermostat.Comments,
                IsOrders = SelectedReceivedThermostat.IsOrders,
                DescriptionIntervention = DescriptionIntervention,
                LastLocation = SelectedReceivedThermostat.LastLocation,
                ReceivingEmployee = SelectedReceivedThermostat.ReceivingEmployee,
                SpendingEmployee = String.Format("{0} {1}", EmployeeViewModel.SelectedEmployee.FirstName, EmployeeViewModel.SelectedEmployee.LastName)
            };
            context.CreateSpendedThermostat(spendedThermostat);

            context.UpdateLastPreventionDate(SelectedReceivedThermostat);
            context.UpdateLastWashDate(SelectedReceivedThermostat);
            context.UpdateCurrentLocation(SelectedReceivedThermostat, CurrentLocation);

            if (SelectedReceivedThermostat != null)
            {
                context.DeleteReceivedThermostat(SelectedReceivedThermostat);
                ReceivedThermostats.Remove(SelectedReceivedThermostat);
                SelectedReceivedThermostat = null;
            }
            ConnectedSuccessfully = true;
        }

        public void GetList()
        {
            ReceivedThermostats.Clear();

            foreach (var item in context.GetReceivedThermostatsList())
                ReceivedThermostats.Add(item);
        }

        private bool IsValidReceivedThermostat()
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

        private bool IsValidSpendedThermostat()
        {
            if (SelectedReceivedThermostat != null
                && !String.IsNullOrWhiteSpace(DescriptionIntervention)
                && EmployeeViewModel.SelectedEmployee != null
                && !String.IsNullOrWhiteSpace(CurrentLocation))
                return true;
            return false;

        }

        protected override string OnValidate(string propertyName)
        {
            if (String.IsNullOrEmpty(BarcodeNumber))
                return "Pole musi być wypełnione";
            else if (!Regex.IsMatch(BarcodeNumber, Resources.ThermostatBarcodePattern))
                return "Niepoprawna składnia ciągu {Ter...}";
            else if (context.CheckIfReceivedThermostatExist(BarcodeNumber))
                return "Termostat nie istnieje w bazie danych";
            else if (context.CheckIfIsAccepted(BarcodeNumber))
                return "Termostat jest już przyjęty";
            return base.OnValidate(propertyName);
        }


    }
}
