using MaintenanceDashboard.Data.Domain;
using System.Collections.Generic;

namespace MaintenanceDashboard.Data.Interfaces
{
    public interface IReceivedPaddleContext
    {
        bool CheckIfReceivedPaddleExist(string number);
        void CreateReceivedPaddle(ReceivedPaddle receivedPaddle);
        void CreateSpendedPaddle(SpendedPaddle spendedPaddle);
        void DeleteReceivedPaddle(ReceivedPaddle receivedPaddle);
        ICollection<ReceivedPaddle> GetReceivedPaddleList();
        Employee CheckEmployee(Employee employee);
        void UpdateLastPreventionDate(ReceivedPaddle receivedPaddle);
        bool CheckIfIsAccepted(string number);
        int CheckForeignKey(string numer);
    }
}