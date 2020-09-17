namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLastLocationPropertyToReceivedThermostatTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceivedThermostats", "LastLocation", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReceivedThermostats", "LastLocation");
        }
    }
}
