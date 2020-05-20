using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaintenanceDashbord.Library;
using System;

namespace MaintenanceDashbord.Tests.UnitTests
{
    [TestClass]
    public class ActionCommandTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ContructorThrowsExceptionIfActionParameterIsNull()
        {
            var command = new ActionCommand(null);
        }

        [TestMethod]
        public void ExecuteInvokeAction()
        {
            var invoked = false;

            Action<Object> action = obj => invoked = true;

            var command = new ActionCommand(action);

            command.Execute();

            Assert.IsTrue(invoked);
          }

        [TestMethod]
        public void ExecuteOverloadInvokesActionWithParameter()
        {

        }

        [TestMethod]
        public void CanExecuteIsTrueByDefault()
        {

        }

        [TestMethod]
        public void CanExecuteOverloadExecutesTruePredicate()
        {

        }

        [TestMethod]
        public void CanExecuteOverloadExecutesFalsePredicate()
        {

        }

    }
}
