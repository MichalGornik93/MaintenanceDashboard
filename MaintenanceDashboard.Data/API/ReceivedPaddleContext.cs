using MaintenanceDashboard.Data.Models;
using MaintenanceDashbord.Common.Properties;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaintenanceDashboard.Data.API
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

        public void Receive(ReceivedPaddle receivedPaddle)
        {
            Validator.RequireString(receivedPaddle.ReceivingEmployee);
            Validator.RequireDateTime(receivedPaddle.ReceivedDate);
            Validator.RequireString(receivedPaddle.ActivityPerformed);
            Validator.RequireDateTime(receivedPaddle.PlannedRepairDate);
            
            context.ReceivedPaddles.Add(receivedPaddle);
            context.SaveChanges();
        }

        public void Spend(SpendedPaddle spendedPaddle)
        {
            Validator.RequireDateTime(spendedPaddle.ReceivedDate);
            Validator.RequireString(spendedPaddle.ActivityPerformed);
            Validator.RequireDateTime(spendedPaddle.RepairDate);
            Validator.RequireString(spendedPaddle.DescriptionIntervention);
            Validator.RequireString(spendedPaddle.ReceivingEmployee);
            Validator.RequireString(spendedPaddle.SpendingEmployee);

            context.SpendedPaddles.Add(spendedPaddle);
            context.SaveChanges();
        }

        public void Remove(ReceivedPaddle receivedPaddle)
        {
            context.ReceivedPaddles.Remove(receivedPaddle);
            context.SaveChanges();
        }

        public void SetLastPreventionDate(ReceivedPaddle receivedPaddle)
        {
            if (receivedPaddle.ActivityPerformed == "Prewencja")
            {
                var t =
                    (from c in context.Paddles
                     where c.Id == receivedPaddle.PaddleId
                     select c).First();
                t.LastPreventionDate = DateTime.Now.ToString(Resources.DateTimePattern);

                context.SaveChanges();
            }
        }

        public int GetId(string number)
        {
            return context.Paddles
                .FirstOrDefault(c => c.BarcodeNumber == number)
                .Id;
        }

        public bool IsExistInDb(string number)
        {
            var result = context.Paddles
                .FirstOrDefault(c => c.BarcodeNumber == number);

            if (result == null)
                return true;

            return false;
        }

        public bool IsAccepted(string number)
        {
            var result = context.ReceivedPaddles
                .FirstOrDefault(c => c.Paddle.BarcodeNumber == number);

            if (result != null)
                return true;

            return false;
        }
        
        public ICollection<ReceivedPaddle> GetAll()
        {
            return context.ReceivedPaddles
                .OrderBy(p => p.Id)
                .ToArray();
        }

    }
}
