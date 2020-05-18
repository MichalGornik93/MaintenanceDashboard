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
            using (var wc = new WorkshopContext())
            {
                Employee entity = wc.AddNewEmployee("TestName", "TestLastName", "TestString");

                bool exist = wc.DataContext.Employees.Any(e => e.Id == entity.Id);

                Assert.IsTrue(exist);
            }

        }

    }
}
