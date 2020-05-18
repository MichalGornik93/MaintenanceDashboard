using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using MaintenanceDashboard.Data.Domain;

namespace MaintenanceDashboard.Data.Tests.FunctionalTests
{
    [TestClass]
    public class DatabaseScenerioTests
    {
        [TestMethod]
        public void CanCreateDataBase()
        {
            using (var db = new WorkshopDbContext())
            {
                db.Database.Create();
            }
        }
    }
}
