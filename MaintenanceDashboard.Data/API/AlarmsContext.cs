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
    public class AlarmsContext
    {
        private readonly DataContext context;

        public AlarmsContext()
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
    }
}
