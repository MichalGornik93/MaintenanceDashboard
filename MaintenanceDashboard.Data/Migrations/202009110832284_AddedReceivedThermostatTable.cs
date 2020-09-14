namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReceivedThermostatTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReceivedThermostats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReceivingEmployee = c.String(nullable: false),
                        ThermostatId = c.Int(nullable: false),
                        AddedDate = c.String(nullable: false),
                        ActivityPerformed = c.String(nullable: false),
                        PlannedRepairDate = c.String(nullable: false),
                        Comments = c.String(),
                        IsOrders = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Thermostats", t => t.ThermostatId, cascadeDelete: true)
                .Index(t => t.ThermostatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceivedThermostats", "ThermostatId", "dbo.Thermostats");
            DropIndex("dbo.ReceivedThermostats", new[] { "ThermostatId" });
            DropTable("dbo.ReceivedThermostats");
        }
    }
}
