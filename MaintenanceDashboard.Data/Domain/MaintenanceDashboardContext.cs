using System;
using System.Collections.Generic;
using System.Linq;

namespace MaintenanceDashboard.Data.Domain
{
    public sealed class MaintenanceDashboardContext : IDisposable //IDisposable- Provides a mechanism for releasing unmanaged resources
    {
        private readonly DataContext context;
        private bool disposed;

        public MaintenanceDashboardContext()
        {
            context = new DataContext();
        }

        public DataContext DataContext
        {
            get { return context; }
        }

        #region EmployeeContext

        public void AddNewEmployee(Employee employee)
        {
            Check.Require(employee.FirstName);
            Check.Require(employee.LastName);

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

        public ICollection<Employee> GetEmployeeList()
        {
            return context.Employees.OrderBy(p => p.Id).ToArray();
        }

        #endregion

        #region RegisterToolContext
        public void AddNewRegisterTool(RegisterTool registerTool)
        {
            Check.Require(registerTool.ToolName);

            context.RegisterTools.Add(registerTool);
            context.SaveChanges();
        }


        public void UpdateRegisterTool(RegisterTool registerTool)
        {
            var entity = context.RegisterTools.Find(registerTool.Id);

            if (entity == null)
            {
                throw new NotImplementedException("Handle appropriately for your API design. ");
            }

            context.Entry(entity).CurrentValues.SetValues(registerTool);

            context.SaveChanges();
        }

        public ICollection<RegisterTool> GetRegisterToolList()
        {
            return context.RegisterTools.OrderBy(p => p.Id).ToArray();
        }

        #endregion

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
