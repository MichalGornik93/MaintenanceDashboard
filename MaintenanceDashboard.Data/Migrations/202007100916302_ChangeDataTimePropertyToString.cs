namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataTimePropertyToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ReceivedPaddles", "DateAdded", c => c.String(nullable: false));
            AlterColumn("dbo.ReceivedPaddles", "PlannedRepairTime", c => c.String(nullable: false));
            AlterColumn("dbo.Paddles", "AddedDate", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Paddles", "AddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ReceivedPaddles", "PlannedRepairTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ReceivedPaddles", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
