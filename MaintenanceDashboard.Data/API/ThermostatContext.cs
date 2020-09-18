using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintenanceDashboard.Data.API;
using MaintenanceDashboard.Data.Models;

namespace MaintenanceDashboard.Data.API
{
    public class ThermostatContext
    {
        private readonly DataContext context;

        public ThermostatContext()
        {
            context = new DataContext();
        }

        public DataContext DataContext
        {
            get { return context; }
        }

        public void CreateThermostat(Thermostat thermostat)
        {
            CheckValue.RequireString(thermostat.BarcodeNumber);
            CheckValue.RequireString(thermostat.SerialNumber);
            CheckValue.RequireString(thermostat.Model);
            CheckValue.RequireDateTime(thermostat.AddedDate);
            CheckValue.RequireDateTime(thermostat.LastPrevention);
            CheckValue.RequireDateTime(thermostat.LastWashDate);

            context.Thermostats.Add(thermostat);
            context.SaveChanges();
        }

        public void UpdateThermostat(Thermostat thermostat)
        {
            var entity = context.Thermostats.Find(thermostat.Id);

            if (entity == null)
            {
                throw new NotImplementedException("Handle appropriately for your API design.");
            }

            context.Entry(entity).CurrentValues.SetValues(thermostat);
            context.SaveChanges();
        }

        public bool CheckIfThermostatExist(string number)
        {
            var result = context.Thermostats.FirstOrDefault(c => c.BarcodeNumber == number);

            if (result != null)
                return true;

            return false;
        }

        public ICollection<Thermostat> GetThermostatList()
        {
            return context.Thermostats.OrderBy(p => p.Id).ToArray();
        }
    }
}