namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropPlannedRepairDateProperty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ReceivedPaddles", "PlannedRepairDate");
            DropColumn("dbo.ReceivedThermostats", "PlannedRepairDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReceivedThermostats", "PlannedRepairDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ReceivedPaddles", "PlannedRepairDate", c => c.DateTime(nullable: false));
        }
    }
}
