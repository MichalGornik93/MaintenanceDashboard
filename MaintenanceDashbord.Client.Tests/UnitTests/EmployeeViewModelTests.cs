using MaintenanceDashboard.Client.ViewModels;
using MaintenanceDashboard.Data.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MaintenanceDashbord.Client.Tests.UnitTests
{
    [TestClass]
    public class EmployeeViewModelTests
    {
        [TestMethod]
        public void AddCommand_CannotExecuteWhenFirstNameIsNotValid()
        {
            var viewModel = new MaintenanceDashboardViewModel
            {
                SelectedEmployee = new Employee
                {
                    FirstName=null,
                    LastName= "TestName",
                    UidCode= "TestUid"
                }
            };

            Assert.IsFalse(viewModel.AddEmployeeCommand.CanExecute(null));
        }

        [TestMethod]
        public void AddCommand_CannotExecuteWhenLastNameIsNotValid()
        {
            var viewModel = new MaintenanceDashboardViewModel
            {
                SelectedEmployee = new Employee
                {
                    FirstName = "TestName",
                    LastName = null,
                    UidCode = "TestUid"
                }
            };

            Assert.IsFalse(viewModel.AddEmployeeCommand.CanExecute(null));
        }

        [TestMethod]
        public void GetEmployeeListCommand_PopulatesEmployeePropertyWithExpectedCollectionFromDataStore()
        {
            using (var context = new MaintenanceDashboardContext())
            {
                context.AddNewEmployee(new Employee { FirstName = "TestFirstName1", LastName = "TestLastName1", UidCode = "TestCode1" });
                context.AddNewEmployee(new Employee { FirstName = "TestFirstName2", LastName = "TestLastName2", UidCode = "TestCode2" });
                context.AddNewEmployee(new Employee { FirstName = "TestFirstName3", LastName = "TestLastName3", UidCode = "TestCode3" });

                var viewModel = new MaintenanceDashboardViewModel(context);

                viewModel.GetEmployeeListCommand.Execute(null);

                Assert.IsTrue(viewModel.Employees.Count == 3);
            }
        }

        [TestMethod]
        public void GetEmployeeListCommand_SelectedEmployeeIsSetToNullWhenExecuted()
        {
            var viewModel = new MaintenanceDashboardViewModel();

            viewModel.SelectedEmployee = new Employee
            {
               FirstName="TestFirstName",
               LastName= "TestLastName",
               UidCode="TestCode"
            };

            viewModel.GetEmployeeListCommand.Execute(null);

            Assert.IsNull(viewModel.SelectedEmployee);
        }

        [TestMethod]
        public void SaveCommand_SelectedEmployeeFirstNameIsUpdatedInDataStore()
        {
            using (var context = new MaintenanceDashboardContext())
            {
                // Arrange
                context.AddNewEmployee(new Employee { FirstName = "TestFirstName1", LastName = "TestLastName1", UidCode = "TestCode1" });

                var viewModel = new MaintenanceDashboardViewModel(context);

                viewModel.GetEmployeeListCommand.Execute(null);
                viewModel.SelectedEmployee = viewModel.Employees.First();

                // Act
                viewModel.SelectedEmployee.FirstName = "newValue";
                viewModel.SaveEmployeeCommand.Execute(null);

                // Assert
                var employee = context.DataContext.Employees.Single();

                context.DataContext.Entry(employee).Reload();

                Assert.AreEqual(viewModel.SelectedEmployee.FirstName, employee.FirstName);
            }
        }

        [TestMethod]
        public void DeleteCommand_SelectedEmployeeIsDeletedFromDataStore()
        {
            using (var context = new MaintenanceDashboardContext())
            {
                // Arrange
                context.AddNewEmployee(new Employee { FirstName = "TestFirstName1", LastName = "TestLastName1", UidCode = "TestCode1" });

                var viewModel = new MaintenanceDashboardViewModel(context);

                viewModel.GetEmployeeListCommand.Execute(null);
                viewModel.SelectedEmployee = viewModel.Employees.First();

                // Act
                viewModel.DeleteEmployeeCommand.Execute(null);

                // Assert
                Assert.IsFalse(context.DataContext.Employees.Any());
            }
        }
    }
}
