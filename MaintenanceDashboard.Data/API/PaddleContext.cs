using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceDashboard.Data.Domain
{
    public class PaddleContext:IDisposable
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

        public void AddNewPaddle(Paddle paddle)
        {
            CheckString.Require(paddle.PaddleNumber);
            CheckString.Require(paddle.Model);

            context.Paddles.Add(paddle);
            context.SaveChanges();
        }


        //public void UpdateRegisterTool(RegisterTool registerTool)
        //{
        //    var entity = context.RegisterTools.Find(registerTool.Id);

        //    if (entity == null)
        //    {
        //        throw new NotImplementedException("Handle appropriately for your API design. ");
        //    }

        //    context.Entry(entity).CurrentValues.SetValues(registerTool);

        //    context.SaveChanges();
        //}

        public ICollection<Paddle> GetPaddleList()
        {
            return context.Paddles.OrderBy(p => p.Id).ToArray();
        }

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
    }
}
