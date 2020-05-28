using System;

namespace MaintenanceDashboard.Data.Domain
{
    public sealed class WorkshopContext : IDisposable //IDisposable- Provides a mechanism for releasing unmanaged resources
    {
        private readonly DataContext context;
        private bool disposed;

        public WorkshopContext()
        {
            context = new DataContext();
        }

        public DataContext DataContext
        {
            get { return context; }
        }

        public void AddNewEmployee(Employee employee)
        {
            Check.Require(employee.FirstName);
            Check.Require(employee.LastName);

            context.Employees.Add(employee);
            context.SaveChanges();

        }

        public void AddNewRegisterTool(RegisterTool registerTool)
        {
            Check.Require(registerTool.ToolName);
            //Check.Require(registerTool.);

            context.RegisterTools.Add(registerTool);
            context.SaveChanges();
        }

        static class Check
        {
            public static void Require(string value)
            {
                if (value == null)
                    throw new ArgumentNullException();
                else if (value.Trim().Length == 0)
                    throw new ArgumentException();
            }
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
