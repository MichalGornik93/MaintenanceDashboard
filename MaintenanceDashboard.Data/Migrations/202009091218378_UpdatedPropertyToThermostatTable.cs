namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedPropertyToThermostatTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Thermostats", "BarcodeNumber", c => c.String(nullable: false));
            AddColumn("dbo.Thermostats", "SerialNumber", c => c.String(nullable: false));
            DropColumn("dbo.Thermostats", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Thermostats", "Number", c => c.String(nullable: false));
            DropColumn("dbo.Thermostats", "SerialNumber");
            DropColumn("dbo.Thermostats", "BarcodeNumber");
        }
    }
}
