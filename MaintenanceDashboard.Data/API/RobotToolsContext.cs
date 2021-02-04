using MaintenanceDashboard.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MaintenanceDashboard.Data.API
{
    public class RobotToolsContext
    {
        private readonly DataContext context;
        public RobotToolsContext()
        {
            context = new DataContext();
        }

        public DataContext DataContext
        {
            get { return context; }
        }

        public void Create(SpendedRobotTool spendedRobotTool)
        {
            context.SpendedRobotTools.Add(spendedRobotTool);
            context.SaveChanges();
        }

        public ICollection<SpendedRobotTool> GetAll()
        {
            return context.SpendedRobotTools
                .OrderByDescending(p => p.Date)
                .ToArray();
        }
        public ICollection<SpendedRobotTool> GetFiltredList(int number)
        {
            return context.SpendedRobotTools
                .Where(c => c.Number == number)
                .OrderByDescending(p => p.Date)
                .ToArray();
        }
    }
}
