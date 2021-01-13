using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using MaintenanceDashboard.Client.Interfaces;
using MaintenanceDashboard.Common;
using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Models;
using MaintenanceDashboard.Common.Properties;

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
        public DateTime RepairDate { get; set; } = DateTime.Now;
        public string ActivityPerformed { get; set; }
        public string LastLocation { get; set; }

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

            EmployeeViewModel.GetAll();
            GetAll();

        }

        public ActionCommand ReceiveCommand
        {
            get
            {
                return new ActionCommand(p => Receive(),
                    p => IsValidReceivedThermostat());
            }
        }

        public ActionCommand SpendCommand
        {
            get
            {
                return new ActionCommand(p => Spend(),
                    p => IsValidSpendedThermostat());
            }
        }


        public void Receive()
        {
            var receivedThermostat = new ReceivedThermostat
            {
                ReceivingEmployee = String.Format("{0} {1}", EmployeeViewModel.SelectedEmployee.FirstName, EmployeeViewModel.SelectedEmployee.LastName),
                ThermostatId = context.GetId(BarcodeNumber),
                ReceivedDate = ReceivedDate,
                ActivityPerformed = ActivityPerformed,
                DescriptionIntervention = DescriptionIntervention,
                LastLocation = LastLocation
            };

            if (!context.IsAccepted(BarcodeNumber))
            {
                context.Receive(receivedThermostat);
                
            }
            else
            {
                context.UpdateOnReceive(receivedThermostat);
            }

            if (receivedThermostat.ActivityPerformed == "Awaria")
            {
                context.SetCurrentStatus(receivedThermostat, "Awaria");
            }
            else
                context.SetCurrentStatus(receivedThermostat, "W czasie: " + receivedThermostat.ActivityPerformed.ToString());

            context.SetCurrentLocation(receivedThermostat, "Warsztat");
            
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
                DescriptionIntervention = SelectedReceivedThermostat.DescriptionIntervention,
                LastLocation = SelectedReceivedThermostat.LastLocation,
                ReceivingEmployee = SelectedReceivedThermostat.ReceivingEmployee,
                SpendingEmployee = String.Format("{0} {1}", EmployeeViewModel.SelectedEmployee.FirstName, EmployeeViewModel.SelectedEmployee.LastName)
            };

            context.SetLastPreventionDate(SelectedReceivedThermostat);
            context.SetLastWashDate(SelectedReceivedThermostat);
            context.SetCurrentLocation(SelectedReceivedThermostat, CurrentLocation);
            context.SetCurrentStatus(SelectedReceivedThermostat, "Sprawny");

            if (CurrentLocation != "Warsztat") //If the release on the machine it seems
            {
                context.Spend(spendedThermostat);

                if (SelectedReceivedThermostat != null)
                {
                    context.Remove(SelectedReceivedThermostat);
                    ReceivedThermostats.Remove(SelectedReceivedThermostat);
                    SelectedReceivedThermostat = null;
                }
            }
            else  //If the relese for the workshop take back
            {
                var receivedThermostat = new ReceivedThermostat
                {
                    ThermostatId = SelectedReceivedThermostat.ThermostatId,
                    ReceivedDate = SelectedReceivedThermostat.ReceivedDate,
                    ActivityPerformed = "Do wydania",
                    DescriptionIntervention = null,
                    LastLocation = SelectedReceivedThermostat.LastLocation,
                    ReceivingEmployee = SelectedReceivedThermostat.ReceivingEmployee
                };

                context.UpdateOnSpend(receivedThermostat);
                context.Spend(spendedThermostat);
            }

            ConnectedSuccessfully = true;
        }

        public void GetAll()
        {
            ReceivedThermostats.Clear();

            foreach (var item in context.GetAll())
                ReceivedThermostats.Add(item);
        }

        private bool IsValidReceivedThermostat()
        {
            if (OnValidate(BarcodeNumber) == null
                && EmployeeViewModel.SelectedEmployee != null
                && ReceivedDate != null
                && ActivityPerformed != null
                && !String.IsNullOrWhiteSpace(LastLocation))
                return true;
            return false;
        }


        private bool IsValidSpendedThermostat()
        {
            if (SelectedReceivedThermostat != null
                && !String.IsNullOrWhiteSpace(SelectedReceivedThermostat.DescriptionIntervention)
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
            else if (context.IsExistInDb(BarcodeNumber))
                return "Termostat nie istnieje w bazie danych";
            //else if (context.IsAccepted(BarcodeNumber))
            //    return "Termostat jest już przyjęty";
            return base.OnValidate(propertyName);
        }


    }
}
