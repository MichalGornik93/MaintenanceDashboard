namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPaddleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paddles", "Model", c => c.String(nullable: false));
            AddColumn("dbo.Paddles", "Version", c => c.String(nullable: false));
            AddColumn("dbo.Paddles", "Operation", c => c.String(nullable: false));
            AlterColumn("dbo.Paddles", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Paddles", "Name", c => c.String());
            DropColumn("dbo.Paddles", "Operation");
            DropColumn("dbo.Paddles", "Version");
            DropColumn("dbo.Paddles", "Model");
        }
    }
}
