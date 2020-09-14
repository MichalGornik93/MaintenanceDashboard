using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintenanceDashboard.Common;
using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Domain;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class ReceivedThermostatViewModel : ViewModel
    {
        private readonly ReceivedThermostatContext context;

        public ICollection<SpendedPaddle> SpendedPaddles { get; private set; }
        public string BarcodeThermostatNumber { get; set; }
        public string DescriptionIntervention { get; set; }

        private EmployeeViewModel _EmployeeViewModel;
        public EmployeeViewModel EmployeeViewModel
        {
            get { return _EmployeeViewModel; }
        }

        private ThermostatViewModel _ThermostatViewModel;
        public ThermostatViewModel ThermostatViewModel
        {
            get { return _ThermostatViewModel; }
            set { _ThermostatViewModel = value; }
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

    }
}
