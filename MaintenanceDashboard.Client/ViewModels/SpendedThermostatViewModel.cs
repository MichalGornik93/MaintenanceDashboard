using MaintenanceDashboard.Client.Interfaces;
using MaintenanceDashboard.Common;
using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceDashboard.Client.ViewModels
{
    public class SpendedThermostatViewModel : ViewModel, ISpendedComponent
    {
        private readonly SpendedThermostatContext context;
        public ICollection<SpendedThermostat> SpendedThermostats { get; set; }
        public string BarcodeNumber { get; set; }

        public SpendedThermostatViewModel(SpendedThermostatContext context)
        {
            this.context = context;
            SpendedThermostats = new ObservableCollection<SpendedThermostat>();
        }

        public ActionCommand GetFiltredSpendedThermostatListCommand
        {
            get
            {
                return new ActionCommand(p => GetFiltredSpendedList());
            }
        }

        public ActionCommand GetSpendedThermostatListCommand
        {
            get
            {
                return new ActionCommand(p => GetSpendedList());
            }
        }

        public void GetFiltredSpendedList()
        {
            SpendedThermostats.Clear();

            foreach (var item in context.GetFiltredSpendedThermostatList(BarcodeNumber))
                SpendedThermostats.Add(item);
        }

        public void GetSpendedList()
        {
            SpendedThermostats.Clear();

            foreach (var item in context.GetSpendedThermostatList())
                SpendedThermostats.Add(item);
        }
    }
}
