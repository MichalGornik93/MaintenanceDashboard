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

        public void AcceptancePaddle(ReceivedPaddle receivedPaddle)
        {
            CheckValue.RequireString(receivedPaddle.AddedDate);
            CheckValue.RequireString(receivedPaddle.ActivityPerformed);
            CheckValue.RequireString(receivedPaddle.PlannedRepairDate);
            CheckValue.RequireString(receivedPaddle.IsOrders);
            CheckValue.RequireForeignKey(receivedPaddle.EmployeeId);
            CheckValue.RequireForeignKey(receivedPaddle.PaddleId);

            context.ReceivedPaddles.Add(receivedPaddle);
            context.SaveChanges();
        }

        public void SpendPaddle(ReceivedPaddle receivedPaddle)
        {
            //context.
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
