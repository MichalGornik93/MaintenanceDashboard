namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSpendingEmployeePropertyToSpendedRobotToolsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpendedRobotTools", "SpendingEmployee", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpendedRobotTools", "SpendingEmployee");
        }
    }
}
