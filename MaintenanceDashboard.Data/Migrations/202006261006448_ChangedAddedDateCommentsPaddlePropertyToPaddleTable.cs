namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAddedDateCommentsPaddlePropertyToPaddleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paddles", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Paddles", "CommentsPaddle", c => c.String());
            DropColumn("dbo.Paddles", "AddedTime");
            DropColumn("dbo.Paddles", "Comments");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Paddles", "Comments", c => c.String());
            AddColumn("dbo.Paddles", "AddedTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Paddles", "CommentsPaddle");
            DropColumn("dbo.Paddles", "AddedDate");
        }
    }
}
