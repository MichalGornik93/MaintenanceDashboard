using System;

namespace MaintenanceDashboard.Data.Domain
{
    public sealed class WorkshopContext : IDisposable
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
            // tu zwalniamy wszystkie zasoby
            Dispose(true);
            GC.SuppressFinalize(this); //Destruktor
        }

        private void Dispose(bool disposing)
        {
            if (disposed || !disposing)
                return;

            if (context != null)
                context.Dispose();

            disposed = true;
        }
        #endregion
    }
}
