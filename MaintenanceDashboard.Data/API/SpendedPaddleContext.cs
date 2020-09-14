using MaintenanceDashboard.Data.Domain;
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

        public ICollection<SpendedPaddle> GetFiltredSpendedPaddleList(string paddleNumber)
        {
            return context.SpendedPaddles.Where(c =>c.Paddle.BarcodeNumber == paddleNumber).OrderByDescending(p=>p.RepairDate).ToArray();
        }

        public ICollection<SpendedPaddle> GetSpendedPaddleList()
        {
            return context.SpendedPaddles.OrderByDescending(p => p.RepairDate).ToArray();
        }

    }
}
