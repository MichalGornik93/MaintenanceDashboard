using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaintenanceDashboard.Data.Api;
using MaintenanceDashboard.Data.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MaintenanceDashboard.Data.Tests
{
    [TestClass]
    public class EmployeeContextTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNewEmployee_ThrowsException_WhenFirstNameIsEmpty()
        {
            var wc = new EmployeeContext();

            var employee = new Employee
            {
                FirstName = "",
                LastName = "TestLastName"
            };
            wc.CreateEmployee(employee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNewEmployee_ThrowsException_WhenFirstNameIsNull()
        {
            var wc = new EmployeeContext();

            var employee = new Employee
            {
                FirstName = null,
                LastName = "TestFirstName"
            };
            wc.CreateEmployee(employee);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNewEmployee_ThrowsException_WhenLastNameIsNull()
        {
            var wc = new EmployeeContext();

            var employee = new Employee
            {
                FirstName = "TestLastName",
                LastName = null
            };
            wc.CreateEmployee(employee);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNewEmployee_ThrowsException_WhenLastNameIsEmpty()
        {
            var wc = new EmployeeContext();

            var employee = new Employee
            {
                FirstName = "TestLastName",
                LastName = ""
            };
            wc.CreateEmployee(employee);
        }
    }
}
