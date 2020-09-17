namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedLocationPropertyToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ReceivedThermostats", "LastLocation", c => c.String());
            AlterColumn("dbo.Thermostats", "CurrentLocation", c => c.String());
            AlterColumn("dbo.SpendedThermostats", "LastLocation", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SpendedThermostats", "LastLocation", c => c.Int(nullable: false));
            AlterColumn("dbo.Thermostats", "CurrentLocation", c => c.Int(nullable: false));
            AlterColumn("dbo.ReceivedThermostats", "LastLocation", c => c.Int(nullable: false));
        }
    }
}
