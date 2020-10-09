using MaintenanceDashboard.Data.Models;
using MaintenanceDashbord.Common.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceDashboard.Data.API
{
    public class PreventionContext
    {
        private readonly DataContext context;

        public PreventionContext()
        {
            context = new DataContext();
        }

        public DataContext DataContext
        {
            get { return context; }
        }

        public List<Paddle> GetReviewPaddles()
        {
            return context.Paddles
                .ToList()
                .Where(c => (DateTime.Now - DateTime.ParseExact(c.LastPrevention, "yyyy-MM-dd", CultureInfo.InvariantCulture)).TotalDays>60)
                .ToList();
        }


        public List<Thermostat> GetToWashThermostat()
        {
            return context.Thermostats
                        .ToList()
                        .Where(c => (DateTime.Now - DateTime.ParseExact(c.LastWashDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)).TotalDays > 30)
                        .ToList();
        }
    }
}
