using MaintenanceDashboard.Data.Models;
using MaintenanceDashbord.Common.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceDashboard.Data.API
{
    public class ReceivedThermostatContext
    {
        private readonly DataContext context;

        public ReceivedThermostatContext()
        {
            context = new DataContext();
        }

        public DataContext DataContext
        {
            get { return context; }
        }

        public void CreateReceivedThermostat(ReceivedThermostat receivedThermostat)
        {
            //TODO: Data validation


            context.ReceivedThermostats.Add(receivedThermostat);
            context.SaveChanges();
        }

        public void CreateSpendedThermostat(SpendedThermostat spendedThermostat)
        {
            //TODO: Data validation


            context.SpendedThermostats.Add(spendedThermostat);
            context.SaveChanges();
        }

        public void DeleteReceivedThermostat(ReceivedThermostat receivedThermostat)
        {
            context.ReceivedThermostats.Remove(receivedThermostat);
            context.SaveChanges();
        }

        public void UpdateLastPreventionDate(ReceivedThermostat receivedThermostat)
        {
            if (receivedThermostat.ActivityPerformed == "Prewencja")
            {
                var t =
                    (from c in context.Thermostats
                     where c.Id == receivedThermostat.ThermostatId
                     select c).First();
                t.LastPrevention = DateTime.Now.ToString(Resources.DateTimePattern);

                context.SaveChanges();
            }
        }

        public void UpdateLastWashDate(ReceivedThermostat receivedThermostat)
        {
            if (receivedThermostat.ActivityPerformed == "Plukanie termostatu")
            {
                var t =
                    (from c in context.Thermostats
                     where c.Id == receivedThermostat.ThermostatId
                     select c).First();
                t.LastWashDate = DateTime.Now.ToString(Resources.DateTimePattern);

                context.SaveChanges();
            }
        }

        public void UpdateCurrentLocation(ReceivedThermostat receivedThermostat, string currentLocation)
        {
            var t =
                   (from c in context.Thermostats
                    where c.Id == receivedThermostat.ThermostatId
                    select c).First();
            t.CurrentLocation=currentLocation;

            context.SaveChanges();
        }


        public int CheckForeignKey(string number)
        {
            return context.Thermostats.FirstOrDefault(c => c.BarcodeNumber == number).Id;
        }

        public bool CheckIfReceivedThermostatExist(string number)
        {
            var result = context.Thermostats.FirstOrDefault(c => c.BarcodeNumber == number);

            if (result == null)
                return true;

            return false;
        }

        public string CheckLastLocation(string number)
        {
            return context.Thermostats.FirstOrDefault(c => c.BarcodeNumber == number).CurrentLocation;
        }

        public bool CheckIfIsAccepted(string number)
        {
            var result = context.ReceivedThermostats.FirstOrDefault(c => c.Thermostat.BarcodeNumber == number);

            if (result != null)
                return true;

            return false;
        }

        public ICollection<ReceivedThermostat> GetReceivedThermostatsList()
        {
            return context.ReceivedThermostats.OrderBy(p => p.Id).ToArray();
        }
    }
}
