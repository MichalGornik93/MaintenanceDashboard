using MaintenanceDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

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
                .Where(c => (DateTime.Now - c.LastPreventionDate).TotalDays > 60);
        }


        public IEnumerable<Thermostat> GetToWashThermostat()
        {
            return context.Thermostats
                .ToList()
                .Where(d => d.CurrentLocation == "Warsztat" && d.CurrentStatus != "Awaria")
                .Where(c => (DateTime.Now - c.LastWashDate).TotalDays > 30);
        }
    }
}

