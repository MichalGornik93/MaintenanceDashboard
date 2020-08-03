namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPaddleIdAsForeignKeyToSpendedPaddleTableAndReceivedPaddleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceivedPaddles", "PaddleId", c => c.Int(nullable: false));
            AddColumn("dbo.SpendedPaddles", "PaddleId", c => c.Int(nullable: false));
            CreateIndex("dbo.ReceivedPaddles", "PaddleId");
            CreateIndex("dbo.SpendedPaddles", "PaddleId");
            AddForeignKey("dbo.ReceivedPaddles", "PaddleId", "dbo.Paddles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SpendedPaddles", "PaddleId", "dbo.Paddles", "Id", cascadeDelete: true);
            DropColumn("dbo.ReceivedPaddles", "PaddleNumber");
            DropColumn("dbo.SpendedPaddles", "PaddleNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SpendedPaddles", "PaddleNumber", c => c.String(nullable: false));
            AddColumn("dbo.ReceivedPaddles", "PaddleNumber", c => c.String(nullable: false));
            DropForeignKey("dbo.SpendedPaddles", "PaddleId", "dbo.Paddles");
            DropForeignKey("dbo.ReceivedPaddles", "PaddleId", "dbo.Paddles");
            DropIndex("dbo.SpendedPaddles", new[] { "PaddleId" });
            DropIndex("dbo.ReceivedPaddles", new[] { "PaddleId" });
            DropColumn("dbo.SpendedPaddles", "PaddleId");
            DropColumn("dbo.ReceivedPaddles", "PaddleId");
        }
    }
}
