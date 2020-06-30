using System.Collections.Generic;

namespace MaintenanceDashboard.Data.Domain
{
    public interface IPaddleContext
    {
        void CreatePaddle(Paddle paddle);
        ICollection<Paddle> GetPaddleList();
    }
}