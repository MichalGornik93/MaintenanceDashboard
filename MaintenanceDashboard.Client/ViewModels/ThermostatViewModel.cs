using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MaintenanceDashboard.Common;
using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Models;
using MaintenanceDashbord.Common.Properties;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class ThermostatViewModel : ViewModel
    {
        private readonly ThermostatContext context;
        public ICollection<Thermostat> Thermostats { get; private set; }
        public string SerialNumber { get; set; }
        public string BarcodeNumber { get; set; }
        public string Comments { get; set; }
        public string AddedDate { get; set; } = DateTime.Now.ToString(Resources.DateTimePattern);
        public string Model { get; set; } = Resources.ThermostatModelPattern;

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

        private Thermostat _selectedThermostat;
        public Thermostat SelectedThermostat
        {
            get { return _selectedThermostat; }
            set
            {
                _selectedThermostat = value;
                NotifyPropertyChanged();
            }
        }

        public ThermostatViewModel(ThermostatContext context)
        {
            this.context = context;
            Thermostats = new ObservableCollection<Thermostat>();
            GetThermostatList();
        }

        public ActionCommand CreateThermostatCommand
        {
            get
            {
                return new ActionCommand(p => CreateThermostat(),
                    p => IsValidThermostat());
            }
        }

        public ActionCommand SaveThermostatCommand
        {
            get
            {
                return new ActionCommand(p => SaveThermostat());
            }
        }

        public void CreateThermostat()
        {
            var thermostat = new Thermostat
            {
                BarcodeNumber = BarcodeNumber,
                SerialNumber = SerialNumber,
                Model = Model,
                AddedDate = AddedDate,
                LastPrevention = DateTime.Now.ToString(Resources.DateTimePattern),
                LastWashDate = DateTime.Now.ToString(Resources.DateTimePattern),
                Comments = Comments
            };

            context.CreateThermostat(thermostat);
            ConnectedSuccessfully = true;
        }

        public void GetThermostatList()
        {
            Thermostats.Clear();
            SelectedThermostat = null;

            foreach (var item in context.GetThermostatList())
                Thermostats.Add(item);
        }

        private void SaveThermostat()
        {
            if (SelectedThermostat != null)
                context.UpdateThermostat(SelectedThermostat);
        }

        public bool IsValidThermostat()
        {
            if (OnValidate(BarcodeNumber) == null
                && !String.IsNullOrWhiteSpace(SerialNumber))
                return true;
            return false;
        }

        protected override string OnValidate(string propertyName)
        {
            if (String.IsNullOrEmpty(BarcodeNumber))
                return "Pole musi być wypełnione";
            else if (!Regex.IsMatch(BarcodeNumber, Resources.ThermostatBarcodePattern))
                return "Niepoprawna składnia ciągu {Ter...}";
            else if (context.CheckIfThermostatExist(BarcodeNumber))
                return "Termostat istnieje już w bazie danych";
            return base.OnValidate(propertyName);
        }
    }
}
