using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaintenanceDashbord.Library;
using System.ComponentModel;

namespace MaintenanceDashbord.Tests.UnitTests
{
    [TestClass]
    public class ViewModelTests
    {
        [TestMethod]
        public void IAbstractBaseClass()
        {
            Type t = typeof(ViewModel);

            Assert.IsTrue(t.IsAbstract);
        }

        [TestMethod]
        public void IsIDataErrorInfo()
        {
            Assert.IsTrue(typeof(IDataErrorInfo).IsAssignableFrom(typeof(ViewModel)));
        }
    }
}
