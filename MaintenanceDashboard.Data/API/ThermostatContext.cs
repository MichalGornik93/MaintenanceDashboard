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

        public void Create(Thermostat thermostat)
        {
            Validator.RequireString(thermostat.BarcodeNumber);
            Validator.RequireString(thermostat.SerialNumber);
            Validator.RequireString(thermostat.Model);
            Validator.RequireDateTime(thermostat.AddedDate);
            Validator.RequireDateTime(thermostat.LastPrevention);
            Validator.RequireDateTime(thermostat.LastWashDate);

            context.Thermostats.Add(thermostat);
            context.SaveChanges();
        }

        public void Update(Thermostat thermostat)
        {
            var entity = context.Thermostats
                .Find(thermostat.Id);

            if (entity == null)
            {
                throw new NotImplementedException("Handle appropriately for your API design.");
            }

            context.Entry(entity).CurrentValues.SetValues(thermostat);
            context.SaveChanges();
        }

        public bool IsExistInDb(string number)
        {
            var result = context.Thermostats
                .FirstOrDefault(c => c.BarcodeNumber == number);

            if (result != null)
                return true;

            return false;
        }

        public string GetFirstFreeBarcodeNumber()
        {
            return String.Format("Ter" + BarcodeNumber.ParseBarcodeNumberToInt(FindLastBarcodeNumber()));

        }

        public ICollection<Thermostat> GetAll()
        {
            return context.Thermostats
                .OrderBy(p => p.Id)
                .ToArray();
        }

        public string FindLastBarcodeNumber()
        {
            return context.Thermostats
                .OrderByDescending(p => p.Id)
                .Select(r => r.BarcodeNumber)
                .First().ToString();
        }

    }
}