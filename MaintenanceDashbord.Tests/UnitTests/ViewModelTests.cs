using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaintenanceDashbord.Library;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))] 
        public void  IDataErrorInfo_ErrorProperty_IsNotSUpported()
        {
            var viewModel = new TestViewModel();
            var value = viewModel.Error;
        }

        [TestMethod]
        public void IndexerPropertyValidatesPropertyNameWithInvalidValue()
        {
            var viewModel = new TestViewModel();
            Assert.IsNotNull(viewModel["RequiredProperty"]);
        }

        [TestMethod]
        public void IndexerPropertyValidatesPropertyNameWithValidValue()
        {
            var viewModel = new TestViewModel
                            {
                                RequiredProperty= "Some Value"
                            };

            Assert.IsNull(viewModel["RequiredProperty"]);
        }
    }

    class TestViewModel:ViewModel
    {
        [Required]
        public string RequiredProperty
        { get; set; }

    }
}
