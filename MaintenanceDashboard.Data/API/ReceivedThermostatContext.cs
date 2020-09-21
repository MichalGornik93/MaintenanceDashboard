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
            CheckValue.RequireString(receivedThermostat.ReceivingEmployee);
            CheckValue.RequireDateTime(receivedThermostat.ReceivedDate);
            CheckValue.RequireString(receivedThermostat.ActivityPerformed);
            CheckValue.RequireDateTime(receivedThermostat.PlannedRepairDate);
            CheckValue.RequireString(receivedThermostat.IsOrders);

            context.ReceivedThermostats.Add(receivedThermostat);
            context.SaveChanges();
        }

        public void Spend(SpendedThermostat spendedThermostat)
        {
            CheckValue.RequireString(spendedThermostat.ReceivingEmployee);
            CheckValue.RequireString(spendedThermostat.DescriptionIntervention);
            CheckValue.RequireString(spendedThermostat.SpendingEmployee);
            CheckValue.RequireString(spendedThermostat.ActivityPerformed);
            CheckValue.RequireDateTime(spendedThermostat.ReceivedDate);
            CheckValue.RequireDateTime(spendedThermostat.RepairDate);

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
                t.LastPrevention = DateTime.Now.ToString(Resources.DateTimePattern);

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
            return context.Thermostats.FirstOrDefault(c => c.BarcodeNumber == number).Id;
        }

        public bool IsExistInDb(string number)
        {
            var result = context.Thermostats.FirstOrDefault(c => c.BarcodeNumber == number);

            if (result == null)
                return true;

            return false;
        }

        public string FindLastLocation(string number)
        {
            return context.Thermostats
                .FirstOrDefault(c => c.BarcodeNumber == number)
                .CurrentLocation;
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
