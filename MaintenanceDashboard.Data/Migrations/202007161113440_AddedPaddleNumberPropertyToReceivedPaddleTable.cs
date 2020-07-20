namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPaddleNumberPropertyToReceivedPaddleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceivedPaddles", "PaddleNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReceivedPaddles", "PaddleNumber");
        }
    }
}
