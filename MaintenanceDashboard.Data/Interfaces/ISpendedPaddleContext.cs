using MaintenanceDashboard.Data.Domain;
using System.Collections.Generic;

namespace MaintenanceDashboard.Data.Interfaces
{
    public interface ISpendedPaddleContext
    {
        ICollection<SpendedPaddle> GetFiltredSpendedPaddleList(string paddleNumber);
        ICollection<SpendedPaddle> GetSpendedPaddleList();
    }
}