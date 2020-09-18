using MaintenanceDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceDashboard.Data.API
{
    public class SpendedThermostatContext
    {
        private readonly DataContext context;

        public SpendedThermostatContext()
        {
            context = new DataContext();
        }

        public DataContext DataContext
        {
            get { return context; }
        }

        public ICollection<SpendedThermostat> GetFiltredSpendedThermostatList(string barcodeNumber)
        {
            return context.SpendedThermostats.Where(c => c.Thermostat.BarcodeNumber == barcodeNumber).OrderByDescending(p => p.RepairDate).ToArray();
        }

        public ICollection<SpendedThermostat> GetSpendedThermostatList()
        {
            return context.SpendedThermostats.OrderByDescending(p => p.RepairDate).ToArray();
        }
    }
}
