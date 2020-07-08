using MaintenanceDashboard.Data.Domain;
using System.Collections.Generic;

namespace MaintenanceDashboard.Data.Api
{
    public interface IPaddleContext
    {
        void CreatePaddle(Paddle paddle);
        ICollection<Paddle> GetPaddleList();
    }
}