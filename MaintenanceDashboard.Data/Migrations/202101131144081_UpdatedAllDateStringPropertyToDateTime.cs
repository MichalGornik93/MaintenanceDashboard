namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAllDateStringPropertyToDateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Paddles", "AddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Paddles", "LastPreventionDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ReceivedPaddles", "ReceivedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ReceivedPaddles", "PlannedRepairDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SpendedPaddles", "ReceivedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SpendedPaddles", "RepairDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ReceivedThermostats", "ReceivedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.ReceivedThermostats", "PlannedRepairDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Thermostats", "AddedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Thermostats", "LastPreventionDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Thermostats", "LastWashDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SpendedThermostats", "ReceivedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.SpendedThermostats", "RepairDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SpendedThermostats", "RepairDate", c => c.String(nullable: false));
            AlterColumn("dbo.SpendedThermostats", "ReceivedDate", c => c.String(nullable: false));
            AlterColumn("dbo.Thermostats", "LastWashDate", c => c.String());
            AlterColumn("dbo.Thermostats", "LastPreventionDate", c => c.String());
            AlterColumn("dbo.Thermostats", "AddedDate", c => c.String(nullable: false));
            AlterColumn("dbo.ReceivedThermostats", "PlannedRepairDate", c => c.String());
            AlterColumn("dbo.ReceivedThermostats", "ReceivedDate", c => c.String(nullable: false));
            AlterColumn("dbo.SpendedPaddles", "RepairDate", c => c.String(nullable: false));
            AlterColumn("dbo.SpendedPaddles", "ReceivedDate", c => c.String(nullable: false));
            AlterColumn("dbo.ReceivedPaddles", "PlannedRepairDate", c => c.String(nullable: false));
            AlterColumn("dbo.ReceivedPaddles", "ReceivedDate", c => c.String(nullable: false));
            AlterColumn("dbo.Paddles", "LastPreventionDate", c => c.String());
            AlterColumn("dbo.Paddles", "AddedDate", c => c.String(nullable: false));
        }
    }
}
