namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPropertyNameToReceivedPaddleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceivedPaddles", "Number", c => c.String(nullable: false));
            DropColumn("dbo.ReceivedPaddles", "PaddleNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReceivedPaddles", "PaddleNumber", c => c.String(nullable: false));
            DropColumn("dbo.ReceivedPaddles", "Number");
        }
    }
}
