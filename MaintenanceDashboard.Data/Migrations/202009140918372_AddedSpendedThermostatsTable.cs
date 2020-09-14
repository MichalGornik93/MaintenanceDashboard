namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSpendedThermostatsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpendedThermostats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThermostatId = c.Int(nullable: false),
                        AddedDate = c.String(nullable: false),
                        ActivityPerformed = c.String(nullable: false),
                        RepairDate = c.String(nullable: false),
                        Comments = c.String(),
                        IsOrders = c.String(nullable: false),
                        DescriptionIntervention = c.String(nullable: false),
                        ReceivingEmployee = c.String(nullable: false),
                        SpendingEmployee = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Thermostats", t => t.ThermostatId, cascadeDelete: true)
                .Index(t => t.ThermostatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpendedThermostats", "ThermostatId", "dbo.Thermostats");
            DropIndex("dbo.SpendedThermostats", new[] { "ThermostatId" });
            DropTable("dbo.SpendedThermostats");
        }
    }
}
