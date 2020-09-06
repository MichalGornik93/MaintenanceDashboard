using MaintenanceDashboard.Data.Domain;
using System.Collections.Generic;

namespace MaintenanceDashboard.Data.API
{
    public interface ISpendedPaddleContext
    {
        ICollection<SpendedPaddle> GetFiltredSpendedPaddleList(string paddleNumber);
        ICollection<SpendedPaddle> GetSpendedPaddleList();
    }
}