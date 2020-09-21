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

        public ActionCommand GetFiltredListCommand
        {
            get
            {
                return new ActionCommand(p => GetFiltredList());
            }
        }

        public ActionCommand GetAllCommand
        {
            get
            {
                return new ActionCommand(p => GetAll());
            }
        }

        public void GetFiltredList()
        {
            SpendedThermostats.Clear();

            foreach (var item in context.GetFiltredList(BarcodeNumber))
                SpendedThermostats.Add(item);
        }

        public void GetAll()
        {
            SpendedThermostats.Clear();

            foreach (var item in context.GetAll())
                SpendedThermostats.Add(item);
        }
    }
}
