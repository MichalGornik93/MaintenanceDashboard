using MaintenanceDashboard.Data.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MaintenanceDashboard.Data.Tests.FunctionalTests
{
    [TestClass]
    public class EmployeeScenerioTests
    {
        [TestMethod]
        public void AddNewEmployeeIsSuccessful()
        {
            using (var wc = new MaintenanceDashboardContext())
            {
                var employee = new Employee
                {
                    FirstName = "TestFirstName",
                    LastName = "TestLastName",
                    UidCode = "TestUidCode"
                };

                wc.AddNewEmployee(employee);

                bool exist = wc.DataContext.Employees.Any(e => e.Id == employee.Id);

                Assert.IsTrue(exist);
            }

        }

    }
}
