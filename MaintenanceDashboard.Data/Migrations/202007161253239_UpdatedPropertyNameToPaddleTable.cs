namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPropertyNameToPaddleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paddles", "Number", c => c.String(nullable: false));
            AddColumn("dbo.Paddles", "Comments", c => c.String());
            DropColumn("dbo.Paddles", "PaddleNumber");
            DropColumn("dbo.Paddles", "CommentsPaddle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Paddles", "CommentsPaddle", c => c.String());
            AddColumn("dbo.Paddles", "PaddleNumber", c => c.String(nullable: false));
            DropColumn("dbo.Paddles", "Comments");
            DropColumn("dbo.Paddles", "Number");
        }
    }
}
