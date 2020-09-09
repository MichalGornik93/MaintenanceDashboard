﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MaintenanceDashboard.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework;

namespace MaintenanceDashboard.Tests.UnitTests
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
        public void IsObservalbeObject()
        {
            Assert.IsTrue(typeof(ViewModel).BaseType == typeof(ObservableObject));
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void IDataErrorInfo_ErrorProperty_IsNotSUpported()
        {
            var viewModel = new TestViewModel();
            var value = viewModel.Error;
        }


        [TestMethod]
        public void IndexerPropertyValidatesPropertyNameWithValidValue()
        {
            var viewModel = new TestViewModel
            {
                RequiredProperty = "Some Value"
            };

            Assert.IsNull(viewModel["RequiredProperty"]);
        }

    }

    class TestViewModel : ViewModel
    {
        [Required]
        public string RequiredProperty { get; set; }
        [Required]
        public object SomeOtherProperty { get; set; }
    }
}
