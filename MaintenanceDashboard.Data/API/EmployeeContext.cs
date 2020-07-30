using MaintenanceDashboard.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaintenanceDashboard.Data.Api
{
    public class EmployeeContext : IDisposable, IEmployeeContext
    {
        private readonly DataContext context;

        private bool disposed;

        public EmployeeContext()
        {
            context = new DataContext();
        }

        public DataContext DataContext
        {
            get { return context; }
        }

        public void CreateEmployee(Employee employee)
        {
            CheckValue.RequireString(employee.FirstName);
            CheckValue.RequireString(employee.LastName);

            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            var entity = context.Employees.Find(employee.Id);

            if (entity == null)
            {
                throw new NotImplementedException("Handle appropriately for your API design. ");
            }

            context.Entry(entity).CurrentValues.SetValues(employee);

            context.SaveChanges();
        }

        public void DeleteEmployee(Employee employee)
        {
            context.Employees.Remove(employee);
            context.SaveChanges();
        }

        public ICollection<Employee> GetEmployeeList()
        {
            return context.Employees.OrderBy(p => p.Id).ToArray();
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
