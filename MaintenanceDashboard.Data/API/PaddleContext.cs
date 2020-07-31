using MaintenanceDashboard.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaintenanceDashboard.Data.Api
{
    public class PaddleContext : IDisposable, IPaddleContext
    {
        private readonly DataContext context;
        private bool disposed;

        public PaddleContext()
        {
            context = new DataContext();
        }

        public DataContext DataContext
        {
            get { return context; }
        }

        public void CreatePaddle(Paddle paddle)
        {
            CheckValue.RequireString(paddle.Number);
            CheckValue.RequireString(paddle.Model);

            context.Paddles.Add(paddle);
            context.SaveChanges();
        }


        public void UpdatePaddle(Paddle paddle)
        {
            var entity = context.Paddles.Find(paddle.Id);

            if (entity == null)
            {
                throw new NotImplementedException("Handle appropriately for your API design. ");
            }

            context.Entry(entity).CurrentValues.SetValues(paddle);

            context.SaveChanges();
        }

        public void DeletePaddle(Paddle paddle)
        {
            context.Paddles.Remove(paddle);
            context.SaveChanges();
        }


        public bool CheckPaddleExist(string number)
        {
            var result = context.Paddles.FirstOrDefault(c => c.Number == number);
            
            if (result !=null) 
                return true;
            
            return false; 
        }

     
        public ICollection<Paddle> GetPaddleList()
        {
            return context.Paddles.OrderBy(p => p.Id).ToArray();
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
