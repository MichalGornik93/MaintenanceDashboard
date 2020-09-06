using MaintenanceDashboard.Data.Domain;
using System.Collections.Generic;

namespace MaintenanceDashboard.Data.Interfaces
{
    public interface IPaddleContext
    {
        bool CheckPaddleExist(string number);
        void CreatePaddle(Paddle paddle);
        void DeletePaddle(Paddle paddle);
        ICollection<Paddle> GetPaddleList();
        void UpdatePaddle(Paddle paddle);
    }
}