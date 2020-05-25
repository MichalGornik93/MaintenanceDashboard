using MaintenanceDashboard.Data.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MaintenanceDashboard.Data.Tests.UnitTests
{
    [TestClass]
    public class WorkshopContextTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNewEmployee_ThrowsException_WhenFirstNameIsNull()
        {
            using (var wc = new WorkshopContext())
            {
                var employee = new Employee
                {
                    FirstName = null,
                    LastName = "TestLastName",
                    UidCode = "TestUidCode"
                };
                wc.AddNewEmployee(employee);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNewEmployee_ThrowsException_WhenFirstNameIsEmpty()
        {
            using (var wc = new WorkshopContext())
            {
                var employee = new Employee
                {
                    FirstName = "",
                    LastName = "TestLastName",
                    UidCode = "TestUidCode"
                };
                wc.AddNewEmployee(employee);
            }
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNewEmployee_ThrowsException_WhenLastNameIsNull()
        {
            using (var wc = new WorkshopContext())
            {
                var employee = new Employee
                {
                    FirstName = "TestLastName",
                    LastName = null,
                    UidCode = "TestUidCode"
                };
                wc.AddNewEmployee(employee);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNewEmployee_ThrowsException_WhenLastNameIsEmpty()
        {
            using (var wc = new WorkshopContext())
            {
                var employee = new Employee
                {
                    FirstName = "TestLastName",
                    LastName = "",
                    UidCode = "TestUidCode"
                };
                wc.AddNewEmployee(employee);
            }
        }
    }
}
