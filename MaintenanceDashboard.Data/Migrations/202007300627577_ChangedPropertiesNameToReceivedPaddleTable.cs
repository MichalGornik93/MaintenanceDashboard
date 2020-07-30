namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPropertiesNameToReceivedPaddleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceivedPaddles", "AddedDate", c => c.String(nullable: false));
            AddColumn("dbo.ReceivedPaddles", "PlannedRepairDate", c => c.String(nullable: false));
            DropColumn("dbo.ReceivedPaddles", "DateAdded");
            DropColumn("dbo.ReceivedPaddles", "PlannedRepairTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReceivedPaddles", "PlannedRepairTime", c => c.String(nullable: false));
            AddColumn("dbo.ReceivedPaddles", "DateAdded", c => c.String(nullable: false));
            DropColumn("dbo.ReceivedPaddles", "PlannedRepairDate");
            DropColumn("dbo.ReceivedPaddles", "AddedDate");
        }
    }
}
