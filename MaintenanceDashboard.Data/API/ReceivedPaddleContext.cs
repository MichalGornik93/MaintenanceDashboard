using MaintenanceDashboard.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaintenanceDashboard.Data.Api
{

    public class ReceivedPaddleContext : IDisposable
    {
        //TODO: Implement BaseContext
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
            //TODO: Implementation Data Validation

            context.ReceivedPaddles.Add(receivedPaddle);
            context.SaveChanges();
        }

        public void UpdateReceivedPaddle(ReceivedPaddle receivedPaddle)
        {
            var entity = context.ReceivedPaddles.Find(receivedPaddle.Id);

            if (entity == null)
            {
                throw new NotImplementedException("Handle appropriately for your API design. ");
            }

            context.Entry(entity).CurrentValues.SetValues(receivedPaddle);

            context.SaveChanges();
        }

        public void DeleteReceivedPaddle(ReceivedPaddle receivedPaddle)
        {
            context.ReceivedPaddles.Remove(receivedPaddle);
            context.SaveChanges();
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
