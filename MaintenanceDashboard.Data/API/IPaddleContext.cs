using MaintenanceDashboard.Data.Domain;
using System.Collections.Generic;

namespace MaintenanceDashboard.Data.Api
{
    public interface IPaddleContext
    {
        void CreatePaddle(Paddle paddle);
        void DeletePaddle(Paddle paddle);
        ICollection<Paddle> GetPaddleList();
        void UpdatePaddle(Paddle paddle);
    }
}