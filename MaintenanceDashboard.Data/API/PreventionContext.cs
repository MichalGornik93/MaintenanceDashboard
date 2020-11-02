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

        public IEnumerable<Paddle> GetReviewPaddles()
        {
            return context.Paddles
                .ToList()
                .Where(c =>
                {
                    
                    try
                    {
                        return (DateTime.Now - DateTime.ParseExact(c.LastPreventionDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)).TotalDays > 60;
                    }
                    catch
                    {
                        throw new ArgumentException("Bład rzutowania string na typ Date Time dbo.Paddle, LastPrevention");
                    }
                });


        }


        public IEnumerable<Thermostat> GetToWashThermostat()
        {
            return context.Thermostats
                .Where(d => d.CurrentLocation == "Warsztat" )
                .ToList()
                .Where(c =>
                {
                    
                    try
                    {
                        return (DateTime.Now - DateTime.ParseExact(c.LastWashDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)).TotalDays > 30;
                    }
                    catch
                    {
                        throw new ArgumentException("Bład rzutowania string na typ Date Time dbo.Thermostat, LastWashDate");
                    }
                });
        }
    }
}

