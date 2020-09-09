using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Common;
using MaintenanceDashboard.Data.Api;
using MaintenanceDashboard.Data.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceDashboard.Client.Tests
{
    [TestClass]
    public class EmployeeViewModelTests
    {
        [TestMethod]
        public void IsViewModel()
        {
            Assert.IsTrue(typeof(EmployeeViewModel).BaseType == typeof(ViewModel));
        }

        [TestMethod]
        public void CreateCommand_CannotExecuteWhenFirstNameIsNotValid()
        {
            var viewModel = new EmployeeViewModel()
            {
                SelectedEmployee = new Employee
                {
                    FirstName = null,
                    LastName = "TestName"
                }
            };

            Assert.IsFalse(viewModel.CreateEmployeeCommand.CanExecute(null));
        }

        [TestMethod]
        public void CreateCommand_CannotExecuteWhenLastNameIsNotValid()
        {
            var viewModel = new EmployeeViewModel
            {
                SelectedEmployee = new Employee
                {
                    FirstName = "TestName",
                    LastName = null
                }
            };

            Assert.IsFalse(viewModel.CreateEmployeeCommand.CanExecute(null));
        }
    }
}
