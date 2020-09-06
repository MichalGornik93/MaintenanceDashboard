using MaintenanceDashboard.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaintenanceDashboard.Data.API
{
    public class SpendedPaddleContext : ISpendedPaddleContext
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
            return context.SpendedPaddles.Where(c =>c.Paddle.Number == paddleNumber).OrderByDescending(p=>p.RepairDate).ToArray();
        }

        public ICollection<SpendedPaddle> GetSpendedPaddleList()
        {
            return context.SpendedPaddles.OrderByDescending(p => p.RepairDate).ToArray();
        }

    }
}
