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
    public class ThermostatViewModel : ViewModel, IRegisterCompontent
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
            BarcodeNumber = context.GetFirstFreeBarcodeNumber();
            GetAll();
        }

        public ActionCommand CreateCommand
        {
            get
            {
                return new ActionCommand(p => Create(),
                    p => IsValidThermostat());
            }
        }

        public ActionCommand UpdateCommand
        {
            get
            {
                return new ActionCommand(p => Update());
            }
        }

        public void Create()
        {
            var thermostat = new Thermostat
            {
                BarcodeNumber = BarcodeNumber,
                SerialNumber = SerialNumber,
                Model = Model,
                AddedDate = AddedDate,
                LastPreventionDate = DateTime.Now.ToString(Resources.DateTimePattern),
                LastWashDate = DateTime.Now.ToString(Resources.DateTimePattern),
                Comments = Comments
            };

            context.Create(thermostat);
            ConnectedSuccessfully = true;
        }

        public void Update()
        {
            if (SelectedThermostat != null)
                context.Update(SelectedThermostat);
        }

        public void GetAll()
        {
            Thermostats.Clear();
            SelectedThermostat = null;

            foreach (var item in context.GetAll())
                Thermostats.Add(item);
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
            else if (context.IsExistInDb(BarcodeNumber))
                return "Termostat istnieje już w bazie danych";
            return base.OnValidate(propertyName);
        }
    }
}
