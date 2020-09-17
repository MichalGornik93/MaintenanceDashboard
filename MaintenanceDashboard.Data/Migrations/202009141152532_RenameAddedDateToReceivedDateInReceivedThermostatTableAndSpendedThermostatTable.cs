namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class RenameAddedDateToReceivedDateInReceivedThermostatTableAndSpendedThermostatTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.ReceivedThermostats", "AddedDate", "ReceivedDate");
            RenameColumn("dbo.SpendedThermostats", "AddedDate", "ReceivedDate");
        }

        public override void Down()
        {
            RenameColumn("dbo.ReceivedThermostats", "ReceivedDate", "AddedDate");
            RenameColumn("dbo.SpendedThermostats", "ReceivedDate", "AddedDate");
        }
    }
}
