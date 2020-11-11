using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MaintenanceDashboard.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MaintenanceDashboard.Data.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MaintenanceDashboard.Data.DataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
