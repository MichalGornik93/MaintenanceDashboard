using MaintenanceDashboard.Data.Domain;
using System.Collections.Generic;

namespace MaintenanceDashboard.Data.Api
{
    public interface IReceivedPaddleContext
    {
        int CheckForeignKey(string numer);
        bool CheckReceivedPaddleExist(string number);
        void CreateReceivedPaddle(ReceivedPaddle receivedPaddle);
        void CreateSpendedPaddle(SpendedPaddle spendedPaddle);
        void DeleteReceivedPaddle(ReceivedPaddle receivedPaddle);
        ICollection<ReceivedPaddle> GetReceivedPaddleList();
        Employee CheckEmployee(Employee employee);
        void UpdateLastPreventionDate(ReceivedPaddle receivedPaddle);
        bool CheckIfIsAccepted(string number);
    }
}