namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameIsWorkshopToCurrentLocationInThermostatTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Thermostats", "CurrentLocation", c => c.Int(nullable: false));
            DropColumn("dbo.Thermostats", "IsInWorkshop");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Thermostats", "IsInWorkshop", c => c.Boolean(nullable: false));
            DropColumn("dbo.Thermostats", "CurrentLocation");
        }
    }
}
