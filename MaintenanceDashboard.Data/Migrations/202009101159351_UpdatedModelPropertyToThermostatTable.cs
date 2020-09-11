namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedModelPropertyToThermostatTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Thermostats", "Model", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Thermostats", "Model", c => c.String(nullable: false));
        }
    }
}
