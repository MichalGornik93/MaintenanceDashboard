namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPaddleForeignKeyToReceivedPaddleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceivedPaddles", "NumberId", c => c.Int(nullable: false));
            CreateIndex("dbo.ReceivedPaddles", "NumberId");
            AddForeignKey("dbo.ReceivedPaddles", "NumberId", "dbo.Paddles", "Id", cascadeDelete: true);
            DropColumn("dbo.ReceivedPaddles", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReceivedPaddles", "Number", c => c.String(nullable: false));
            DropForeignKey("dbo.ReceivedPaddles", "NumberId", "dbo.Paddles");
            DropIndex("dbo.ReceivedPaddles", new[] { "NumberId" });
            DropColumn("dbo.ReceivedPaddles", "NumberId");
        }
    }
}
