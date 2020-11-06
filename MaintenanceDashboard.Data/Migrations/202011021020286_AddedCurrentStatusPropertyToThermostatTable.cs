namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCurrentStatusPropertyToThermostatTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Thermostats", "CurrentStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Thermostats", "CurrentStatus");
        }
    }
}
