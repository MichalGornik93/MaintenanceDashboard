namespace MaintenanceDashbord.Tests.UnitTests
{
    using System;
    using Maintenance_dashboard;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    class WorkshopDbContextTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNewEmployee_ThrowsException_WhenFirstNameIsNull()
        {
            using(var db = new WorkshopDbContext())
            {
                
            }
        }
    }
}
