using MaintenanceDashboard.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace MaintenanceDashboard.Data.API
{
    public class SpendedPaddleContext 
    {
        private readonly DataContext context;

        public SpendedPaddleContext()
        {
            context = new DataContext();
        }

        public DataContext DataContext
        {
            get { return context; }
        }

        public ICollection<SpendedPaddle> GetFiltredList(string number)
        {
            return context.SpendedPaddles
                .Where(c =>c.Paddle.BarcodeNumber == number)
                .OrderByDescending(p=>p.RepairDate)
                .ToArray();
        }

        public ICollection<SpendedPaddle> GetAll()
        {
            return context.SpendedPaddles
                .OrderByDescending(p => p.RepairDate)
                .ToArray();
        }

    }
}
