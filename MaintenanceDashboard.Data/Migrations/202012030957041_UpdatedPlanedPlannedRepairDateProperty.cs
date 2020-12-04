namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPlanedPlannedRepairDateProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ReceivedThermostats", "PlannedRepairDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReceivedThermostats", "PlannedRepairDate", c => c.String(nullable: false));
        }
    }
}
