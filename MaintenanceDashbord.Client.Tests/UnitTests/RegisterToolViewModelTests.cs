using MaintenanceDashboard.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaintenanceDashboard.Data.Domain;
using MaintenanceDashboard.Client.ViewModels;
using System.Linq;

namespace MaintenanceDashboard.Client.Tests.UnitTests
{
    [TestClass]
    public class RegisterToolViewModelTests
    {
        [TestMethod]
        public void IsViewModel()
        {
            Assert.IsTrue(typeof(MaintenanceDashboardViewModel).BaseType == typeof(ViewModel));
        }

        [TestMethod]
        public void AddCommand_CannotExecuteWhenToolNameIsNotValid()
        {
            var viewModel = new MaintenanceDashboardViewModel
            {
                SelectedRegisterTool = new RegisterTool
                {
                    ToolName = null,
                    UidCode = "TestCode"
                }
            };

            Assert.IsFalse(viewModel.AddRegisterToolCommand.CanExecute(null));
        }


        [TestMethod]
        public void GetRegisterToolListCommand_PopulatesRegisterToolsPropertyWithExpectedCollectionFromDataStore()
        {
            using (var context = new MaintenanceDashboardContext())
            {
                context.AddNewRegisterTool(new RegisterTool { ToolName = "TestName1", UidCode="TestCode1"});
                context.AddNewRegisterTool(new RegisterTool { ToolName = "TestName2", UidCode = "TestCode2" });
                context.AddNewRegisterTool(new RegisterTool { ToolName = "TestName3", UidCode = "TestCode3" });

                var viewModel = new MaintenanceDashboardViewModel(context);

                viewModel.GetRegisterToolListCommand.Execute(null);

                Assert.IsTrue(viewModel.RegisterTools.Count == 3);

            }
        }

        [TestMethod]
        public void GetRegisterToolListCommand_SelectedRegisterToolIsSetToNullWhenExecuted()
        {
            var viewModel = new MaintenanceDashboardViewModel();

            viewModel.SelectedRegisterTool = new RegisterTool
            {
                ToolName = "TestName",
                UidCode = "TestCode"
            };

            viewModel.GetRegisterToolListCommand.Execute(null);

            Assert.IsNull(viewModel.SelectedRegisterTool);
        }

        [TestMethod]
        public void SaveCommand_SelectedRegisterToolsToolNameIsUpdatedInDataStore()
        {
            using (var context = new MaintenanceDashboardContext())
            {
                // Arrange
                context.AddNewRegisterTool(new RegisterTool { ToolName = "TestName1", UidCode = "TestCode1" });

                var viewModel = new MaintenanceDashboardViewModel(context);

                viewModel.GetRegisterToolListCommand.Execute(null);
                viewModel.SelectedRegisterTool = viewModel.RegisterTools.First();

                // Act
                viewModel.SelectedRegisterTool.ToolName = "newValue";
                viewModel.SaveRegisterToolCommand.Execute(null);

                // Assert
                var registerTool = context.DataContext.RegisterTools.Single();

                context.DataContext.Entry(registerTool).Reload();

                Assert.AreEqual(viewModel.SelectedRegisterTool.ToolName, registerTool.ToolName);
            }
        }

        [TestMethod]
        public void DeleteCommand_SelectedRegisterToolIsDeletedFromDataStore()
        {
            using (var context = new MaintenanceDashboardContext())
            {
                // Arrange
                context.AddNewRegisterTool(new RegisterTool { ToolName = "TestName1", UidCode = "TestCode1" });

                var viewModel = new MaintenanceDashboardViewModel(context);

                viewModel.GetRegisterToolListCommand.Execute(null);
                viewModel.SelectedRegisterTool = viewModel.RegisterTools.First();

                // Act
                viewModel.DeleteRegisterToolCommand.Execute(null);

                // Assert
                Assert.IsFalse(context.DataContext.RegisterTools.Any());
            }
        }
    }
}
