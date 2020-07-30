using MaintenanceDashboard.Data.Domain;
using System.Collections.Generic;

namespace MaintenanceDashboard.Data.Api
{
    public interface IReceivedPaddleContext
    {
        int CheckForeignKey(string numer);
        bool CheckReceivedPaddleExist(string number);
        void AcceptancePaddle(ReceivedPaddle receivedPaddle);
        ICollection<ReceivedPaddle> GetReceivedPaddleList();
    }
}