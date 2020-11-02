namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedIsOrderProperty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ReceivedPaddles", "IsOrders");
            DropColumn("dbo.SpendedPaddles", "IsOrders");
            DropColumn("dbo.ReceivedThermostats", "IsOrders");
            DropColumn("dbo.SpendedThermostats", "IsOrders");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SpendedThermostats", "IsOrders", c => c.String(nullable: false));
            AddColumn("dbo.ReceivedThermostats", "IsOrders", c => c.String(nullable: false));
            AddColumn("dbo.SpendedPaddles", "IsOrders", c => c.String(nullable: false));
            AddColumn("dbo.ReceivedPaddles", "IsOrders", c => c.String(nullable: false));
        }
    }
}
