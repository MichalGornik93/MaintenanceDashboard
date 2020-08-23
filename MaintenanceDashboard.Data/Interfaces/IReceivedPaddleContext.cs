using System.Collections.Generic;
using MaintenanceDashboard.Data.Domain;

namespace MaintenanceDashboard.Data.Interfaces
{
    public interface IReceivedPaddleContext
    {
        bool CheckReceivedPaddleExist(string number);
        
        void CreateReceivedPaddle(ReceivedPaddle receivedPaddle);
        
        void CreateSpendedPaddle(SpendedPaddle spendedPaddle);
        
        void DeleteReceivedPaddle(ReceivedPaddle receivedPaddle);
        
        ICollection<ReceivedPaddle> GetReceivedPaddleList();
        
        Employee CheckEmployee(Employee employee);
        
        void UpdateLastPreventionDate(ReceivedPaddle receivedPaddle);
        
        bool CheckIfIsAccepted(string number);
        
        int CheckForeignKey(string number);
    }
}