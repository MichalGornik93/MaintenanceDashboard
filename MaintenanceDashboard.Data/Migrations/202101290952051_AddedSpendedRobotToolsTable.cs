namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSpendedRobotToolsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpendedRobotTools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Name = c.String(),
                        IsDoubler = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SpendedRobotTools");
        }
    }
}
