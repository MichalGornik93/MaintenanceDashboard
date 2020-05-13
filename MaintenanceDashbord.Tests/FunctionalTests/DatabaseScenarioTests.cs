using Microsoft.VisualStudio.TestTools.UnitTesting;
using Maintenance_dashboard;

namespace Maintenance_dashbord.Tests
{
    [TestClass]
    class DatabaseScenarioTests
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
