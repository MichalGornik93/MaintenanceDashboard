namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedThermostatTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Thermostats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false),
                        Model = c.String(nullable: false),
                        AddedDate = c.String(nullable: false),
                        Comments = c.String(),
                        LastPrevention = c.String(),
                        IsInWorkshop = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Thermostats");
        }
    }
}
