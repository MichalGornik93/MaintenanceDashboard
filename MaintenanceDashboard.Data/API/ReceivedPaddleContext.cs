using MaintenanceDashboard.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaintenanceDashboard.Data.Api
{

    public class ReceivedPaddleContext : IDisposable, IReceivedPaddleContext
    {
        private readonly DataContext context;
        private bool disposed;

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
            //CheckValue.RequireString(receivedPaddle.PaddleNumber);

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
                t.LastPrevention = DateTime.Now.ToString("MM/dd/yyyy");

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

        #region IDisposable Members
        public void Dispose()
        {
            //Free all object here            
            Dispose(true);

            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            //Check to see if Dispose has already been called.
            if (disposed || !disposing)
                return;

            if (context != null)
                context.Dispose(); //Free any unmenaged object here

            disposed = true; // Note disposing has been done.
        }
        #endregion
    }
}
