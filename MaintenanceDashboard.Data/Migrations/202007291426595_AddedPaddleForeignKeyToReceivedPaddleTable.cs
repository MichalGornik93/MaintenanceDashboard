namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPaddleForeignKeyToReceivedPaddleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceivedPaddles", "PaddleId", c => c.Int(nullable: false));
            CreateIndex("dbo.ReceivedPaddles", "PaddleId");
            AddForeignKey("dbo.ReceivedPaddles", "PaddleId", "dbo.Paddles", "Id", cascadeDelete: true);
            DropColumn("dbo.ReceivedPaddles", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReceivedPaddles", "Number", c => c.String(nullable: false));
            DropForeignKey("dbo.ReceivedPaddles", "PaddleId", "dbo.Paddles");
            DropIndex("dbo.ReceivedPaddles", new[] { "PaddleId" });
            DropColumn("dbo.ReceivedPaddles", "PaddleId");
        }
    }
}
