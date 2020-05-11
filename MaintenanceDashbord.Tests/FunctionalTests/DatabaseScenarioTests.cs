using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maintenance_dashboard;

namespace MaintenanceDashbord.Tests
{
    [TestClass]
    public class DatabaseScenarioTests
    {
        [TestMethod]
        public void CanCreateDatabase()
        {
            using (var db = new WorkshopDbContext())
            {
                db.Database.Create();
            }
        }
    }
}
