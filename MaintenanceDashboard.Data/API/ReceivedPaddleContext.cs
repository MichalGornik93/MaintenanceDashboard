using MaintenanceDashboard.Data.Domain;
using MaintenanceDashboard.Data.Interfaces;
using MaintenanceDashbord.Common.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaintenanceDashboard.Data.Api
{
    public class ReceivedPaddleContext : IReceivedPaddleContext
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
            CheckValue.RequireString(receivedPaddle.AddedDate);
            CheckValue.RequireString(receivedPaddle.ActivityPerformed);
            CheckValue.RequireString(receivedPaddle.PlannedRepairDate);
            CheckValue.RequireString(receivedPaddle.IsOrders);
            CheckValue.RequireString(receivedPaddle.ReceivingEmployee);
            
            context.ReceivedPaddles.Add(receivedPaddle);
            context.SaveChanges();
        }

        public Employee CheckEmployee(Employee employee)
        {
            return context.Employees.FirstOrDefault(c => c.Id == employee.Id);
        }

        public void CreateSpendedPaddle(SpendedPaddle spendedPaddle)
        {
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

        public bool CheckReceivedPaddleExist(string number)
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
