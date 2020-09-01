using MaintenanceDashboard.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaintenanceDashboard.Data.Api
{
    public class EmployeeContext : IEmployeeContext
    {
        private readonly DataContext context;

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
    }
}
