using MaintenanceDashboard.Data.Domain;
using System.Collections.Generic;

namespace MaintenanceDashboard.Data.Interfaces
{
    public interface IEmployeeContext
    {
        void CreateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        ICollection<Employee> GetEmployeeList();
        void UpdateEmployee(Employee employee);
    }
}