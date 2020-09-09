using MaintenanceDashboard.Data.Domain;
using MaintenanceDashbord.Common.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaintenanceDashboard.Data.Api
{
    public class ReceivedPaddleContext 
    {
        private readonly DataContext context;
     
        public ReceivedPaddleContext()
        {
            context = new DataContext();
        }

        public DataContext DataContext
        {
            get { return context; }
        }

        public void CreateReceivedPaddle(ReceivedPaddle receivedPaddle)
        {
            CheckValue.RequireString(receivedPaddle.ReceivingEmployee);
            CheckValue.RequireDateTime(receivedPaddle.AddedDate);
            CheckValue.RequireString(receivedPaddle.ActivityPerformed);
            CheckValue.RequireDateTime(receivedPaddle.PlannedRepairDate);
            CheckValue.RequireString(receivedPaddle.IsOrders);
            
            context.ReceivedPaddles.Add(receivedPaddle);
            context.SaveChanges();
        }

        public Employee CheckEmployee(Employee employee)
        {
            return context.Employees.FirstOrDefault(c => c.Id == employee.Id);
        }

        public void CreateSpendedPaddle(SpendedPaddle spendedPaddle)
        {
            CheckValue.RequireDateTime(spendedPaddle.AddedDate);
            CheckValue.RequireString(spendedPaddle.ActivityPerformed);
            CheckValue.RequireDateTime(spendedPaddle.RepairDate);
            CheckValue.RequireString(spendedPaddle.IsOrders);
            CheckValue.RequireString(spendedPaddle.DescriptionIntervention);
            CheckValue.RequireString(spendedPaddle.ReceivingEmployee);
            CheckValue.RequireString(spendedPaddle.SpendingEmployee);

            context.SpendedPaddles.Add(spendedPaddle);
            context.SaveChanges();
        }

        public void DeleteReceivedPaddle(ReceivedPaddle receivedPaddle)
        {
            context.ReceivedPaddles.Remove(receivedPaddle);
            context.SaveChanges();
        }

        public void UpdateLastPreventionDate(ReceivedPaddle receivedPaddle)
        {
            if (receivedPaddle.ActivityPerformed == "Prewencja")
            {
                var t =
                    (from c in context.Paddles
                     where c.Id == receivedPaddle.PaddleId
                     select c).First();
                t.LastPrevention = DateTime.Now.ToString(Resources.DateTimePattern);

                context.SaveChanges();
            }
        }

        public int CheckForeignKey(string numer)
        {
            return context.Paddles.FirstOrDefault(c => c.Number == numer).Id;
        }

        public bool CheckIfReceivedPaddleExist(string number)
        {
            var result = context.Paddles.FirstOrDefault(c => c.Number == number);

            if (result == null)
                return true;

            return false;
        }

        public bool CheckIfIsAccepted(string number)
        {
            var result = context.ReceivedPaddles.FirstOrDefault(c => c.Paddle.Number == number);

            if (result != null)
                return true;

            return false;
        }
        
        public ICollection<ReceivedPaddle> GetReceivedPaddleList()
        {
            return context.ReceivedPaddles.OrderBy(p => p.Id).ToArray();
        }

    }
}
