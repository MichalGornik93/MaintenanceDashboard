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
                wc.AddNewEmployee(null, "TestLastName", "TestUid");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNewEmployee_ThrowsException_WhenFirstNameIsEmpty()
        {
            using (var wc = new WorkshopContext())
            {
                wc.AddNewEmployee("", "TestLastName", "TestUid");
            }
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNewEmployee_ThrowsException_WhenLastNameIsNull()
        {
            using (var wc = new WorkshopContext())
            {
                wc.AddNewEmployee("TestFirstName", null, "TestUid");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNewEmployee_ThrowsException_WhenLastNameIsEmpty()
        {
            using (var wc = new WorkshopContext())
            {
                wc.AddNewEmployee("TestFirstName", "", "TestUid");
            }
        }
    }
}
