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

        public void Receive(ReceivedThermostat receivedThermostat)
        {
            Validator.RequireString(receivedThermostat.ReceivingEmployee);
            Validator.RequireDateTime(receivedThermostat.ReceivedDate);
            Validator.RequireString(receivedThermostat.ActivityPerformed);
            Validator.RequireDateTime(receivedThermostat.PlannedRepairDate);

            context.ReceivedThermostats.Add(receivedThermostat);
            context.SaveChanges();
        }

        public void Spend(SpendedThermostat spendedThermostat)
        {
            Validator.RequireString(spendedThermostat.ReceivingEmployee);
            Validator.RequireString(spendedThermostat.DescriptionIntervention);
            Validator.RequireString(spendedThermostat.SpendingEmployee);
            Validator.RequireString(spendedThermostat.ActivityPerformed);
            Validator.RequireDateTime(spendedThermostat.ReceivedDate);
            Validator.RequireDateTime(spendedThermostat.RepairDate);

            context.SpendedThermostats.Add(spendedThermostat);
            context.SaveChanges();
        }

        public void Remove(ReceivedThermostat receivedThermostat)
        {
            context.ReceivedThermostats.Remove(receivedThermostat);
            context.SaveChanges();
        }

        public void SetLastPreventionDate(ReceivedThermostat receivedThermostat)
        {
            if (receivedThermostat.ActivityPerformed == "Prewencja")
            {
                var t =
                    (from c in context.Thermostats
                     where c.Id == receivedThermostat.ThermostatId
                     select c).First();
                t.LastPreventionDate = DateTime.Now.ToString(Resources.DateTimePattern);

                context.SaveChanges();
            }
        }

        public void SetLastWashDate(ReceivedThermostat receivedThermostat)
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

        public void SetCurrentLocation(ReceivedThermostat receivedThermostat, string currentLocation)
        {
            var t =
                   (from c in context.Thermostats
                    where c.Id == receivedThermostat.ThermostatId
                    select c).First();
            t.CurrentLocation=currentLocation;

            context.SaveChanges();
        }


        public int GetId(string number)
        {
            return context.Thermostats
                .FirstOrDefault(c => c.BarcodeNumber == number)
                .Id;
        }

        public bool IsExistInDb(string number)
        {
            var result = context.Thermostats
                .FirstOrDefault(c => c.BarcodeNumber == number);

            if (result == null)
                return true;

            return false;
        }

        public bool IsAccepted(string number)
        {
            var result = context.ReceivedThermostats
                .FirstOrDefault(c => c.Thermostat.BarcodeNumber == number);

            if (result != null)
                return true;

            return false;
        }

        public ICollection<ReceivedThermostat> GetAll()
        {
            return context.ReceivedThermostats
                .OrderBy(p => p.Id)
                .ToArray();
        }
    }
}
