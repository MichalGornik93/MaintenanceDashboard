using MaintenanceDashboard.Data.Domain;
using System.Collections.Generic;

namespace MaintenanceDashboard.Data.Api
{
    public interface IReceivedPaddleContext
    {
        int CheckForeignKey(string numer);
        bool CheckReceivedPaddleExist(string number);
        void CreateReceivedPaddle(ReceivedPaddle receivedPaddle);
        void DeleteReceivedPaddle(ReceivedPaddle receivedPaddle);
        ICollection<ReceivedPaddle> GetReceivedPaddleList();
        void UpdateReceivedPaddle(ReceivedPaddle receivedPaddle);
    }
}