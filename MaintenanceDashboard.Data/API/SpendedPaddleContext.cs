using MaintenanceDashboard.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using MaintenanceDashboard.Data.Interfaces;

namespace MaintenanceDashboard.Data.API
{
    public class SpendedPaddleContext : ISpendedPaddleContext
    {
        private readonly DataContext _context;

        public SpendedPaddleContext()
        {
            _context = new DataContext();
        }

        public ICollection<SpendedPaddle> GetSpendedPaddleList()
        {
            return _context.SpendedPaddles.OrderBy(p => p.Id).ToArray();
        }
    }
}
