using MaintenanceDashboard.Data.Domain;
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

        //TODO: UpdateLastWashDate

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
