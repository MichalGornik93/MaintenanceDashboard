namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDatePropertyToSpendedRobotToolsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpendedRobotTools", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpendedRobotTools", "Date");
        }
    }
}
