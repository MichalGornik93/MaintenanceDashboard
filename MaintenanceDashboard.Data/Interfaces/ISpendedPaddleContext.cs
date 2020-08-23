using System.Collections.Generic;
using MaintenanceDashboard.Data.Domain;

namespace MaintenanceDashboard.Data.Interfaces
{
    public interface ISpendedPaddleContext
    {
        ICollection<SpendedPaddle> GetSpendedPaddleList();
    }
}