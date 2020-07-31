namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLastPreventionPropertyToPaddleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paddles", "LastPrevention", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Paddles", "LastPrevention");
        }
    }
}
