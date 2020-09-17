namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLastLocationPropertyToSpendThermostatTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpendedThermostats", "LastLocation", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpendedThermostats", "LastLocation");
        }
    }
}
