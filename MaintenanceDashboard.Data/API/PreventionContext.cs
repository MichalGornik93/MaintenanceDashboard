using MaintenanceDashboard.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MaintenanceDashboard.Common.Properties;

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
                .Where(c => (DateTime.Now - c.LastPreventionDate).TotalDays > Settings.Default.PaddleInspectionInterval);
        }


        public IEnumerable<Thermostat> GetToWashThermostat()
        {
            return context.Thermostats
                .ToList()
                .Where(d => d.CurrentLocation == "Warsztat" && d.CurrentStatus != "Awaria")
                .Where(c => (DateTime.Now - c.LastWashDate).TotalDays > Settings.Default.ThermostatWashInterval);
        }
        public IEnumerable<SpendedRobotTool> GetReviewRobotTools()
        {
            return context.SpendedRobotTools
                .ToList()
                .Where(d => (DateTime.Now - d.Date).TotalDays > Settings.Default.RobotToolInspectionInterval)
                .GroupBy(c => c.Number)
                .Select(x => x.FirstOrDefault());
        }
    }
}

