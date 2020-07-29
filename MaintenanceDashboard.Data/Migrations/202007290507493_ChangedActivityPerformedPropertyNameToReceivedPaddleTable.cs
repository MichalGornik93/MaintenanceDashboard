namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedActivityPerformedPropertyNameToReceivedPaddleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceivedPaddles", "ActivityPerformed", c => c.String(nullable: false));
            DropColumn("dbo.ReceivedPaddles", "PreventiveAction");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReceivedPaddles", "PreventiveAction", c => c.String(nullable: false));
            DropColumn("dbo.ReceivedPaddles", "ActivityPerformed");
        }
    }
}
