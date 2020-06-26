namespace MaintenanceDashboard.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ChangedPaddleNumberModelAndAddedTimePropertyToPaddleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paddles", "PaddleNumber", c => c.String(nullable: false));
            AddColumn("dbo.Paddles", "Model", c => c.String(nullable: false));
            AddColumn("dbo.Paddles", "AddedTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Paddles", "Comments", c => c.String());
            DropColumn("dbo.Paddles", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Paddles", "Name", c => c.String());
            DropColumn("dbo.Paddles", "Comments");
            DropColumn("dbo.Paddles", "AddedTime");
            DropColumn("dbo.Paddles", "Model");
            DropColumn("dbo.Paddles", "PaddleNumber");
        }
    }
}
