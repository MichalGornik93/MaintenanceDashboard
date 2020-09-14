namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLastWashDatePropertyToThermostatTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Thermostats", "LastWashDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Thermostats", "LastWashDate");
        }
    }
}
