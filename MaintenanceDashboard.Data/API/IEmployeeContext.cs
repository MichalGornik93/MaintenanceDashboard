using System.Collections.Generic;

namespace MaintenanceDashboard.Data.Domain
{
    public interface IEmployeeContext
    {
        void CreateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        ICollection<Employee> GetEmployeeList();
        void UpdateEmployee(Employee employee);
    }
}