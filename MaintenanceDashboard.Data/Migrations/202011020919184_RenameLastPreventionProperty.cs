namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameLastPreventionProperty : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Paddles", "LastPrevention", "LastPreventionDate");
            RenameColumn("dbo.Thermostats", "LastPrevention", "LastPreventionDate");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Paddles", "LastPreventionDate", "LastPrevention");
            RenameColumn("dbo.Thermostats", "LastPreventionDate", "LastPrevention");
        }
    }
}
