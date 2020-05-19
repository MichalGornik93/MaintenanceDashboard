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

        public Employee AddNewEmployee(string firstName, string lastName, string uidCode)
        {
            if (firstName == null)
                throw new ArgumentNullException("firstName", "firstName must be non-null");

            if (String.IsNullOrEmpty(firstName))
                throw new ArgumentException("firstName must not be an empty string", "firstName");

            if (lastName == null)
                throw new ArgumentNullException("lastName", "lastName must be non-null");

            if (String.IsNullOrEmpty(lastName))
                throw new ArgumentException("lastName must not be an empty string", "lastName");

            var employee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                UidCode = uidCode
            };

            context.Employees.Add(employee);
            context.SaveChanges();

            return employee;
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
