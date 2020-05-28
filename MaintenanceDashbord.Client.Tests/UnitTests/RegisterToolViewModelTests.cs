﻿using MaintenanceDashbord.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaintenanceDashboard.Client.ViewModels;

namespace MaintenanceDashbord.Client.Tests.UnitTests
{
    [TestClass]
    public class RegisterToolViewModelTests
    {
        [TestMethod]
        public void IsViewModel()
        {
            Assert.IsTrue(typeof(RegisterToolViewlModel).BaseType == typeof(ViewModel));
        }

        [TestMethod]
        public void ValidationErrorWhenRegisterToolIsNotGreaterThanOrEqualTo2Characters()
        {
            var viewModel = new RegisterToolViewlModel
            {
                Tool = "B"
            };

            Assert.IsNotNull(viewModel["Tool"]);
        }

        [TestMethod]
        public void NoValidationErrorWhenRegisterToolMeetsAllRequirements()
        {
            var viewModel = new RegisterToolViewlModel
            {
                Tool = "David Anderson"
            };

            Assert.IsNull(viewModel["Tool"]);
        }

        [TestMethod]
        public void ValidationErrorWhenRegisterToolIsNotProvided()
        {
            var viewModel = new RegisterToolViewlModel
            {
                Tool = null
            };

            Assert.IsNotNull(viewModel["Tool"]);
        }

        [TestMethod]
        public void AddRegisterToolCommandCannotExecuteWhenToolNameIsNotValid()
        {
            var viewModel = new RegisterToolViewlModel
            {
                ToolName=null,
                UidCode ="TestUid"
            };

            Assert.IsFalse(viewModel.AddRegisterToolCommand.CanExecute(null));
        }


        //[TestMethod]
        //public void AddRegisterToolCommandAddsToolNameToRegisterToolsCollectionWhenExecutedSuccessfully()
        //{
        //    var viewModel = new RegisterToolViewlModel
        //    {
        //        ToolName="TestName",
        //        UidCode ="TestCode"
        //    };

        //    viewModel.AddRegisterToolCommand.Execute();

        //    Assert.IsTrue(viewModel.RegisterTools.Count == 1);
        //}

    }
}
