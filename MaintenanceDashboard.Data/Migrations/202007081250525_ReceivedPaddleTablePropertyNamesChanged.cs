namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReceivedPaddleTablePropertyNamesChanged : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReceivedPaddles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Employee = c.String(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        PreventiveAction = c.String(nullable: false),
                        PlannedRepairTime = c.DateTime(nullable: false),
                        Comments = c.String(),
                        IsOrders = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.GetedPaddles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.GetedPaddles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Employee = c.String(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        PreventiveAction = c.String(nullable: false),
                        PlannedRepairTime = c.String(nullable: false),
                        CommentsGetedPaddle = c.String(),
                        IsOrders = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.ReceivedPaddles");
        }
    }
}
