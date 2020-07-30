namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSpendedPaddleTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpendedPaddles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaddleId = c.Int(nullable: false),
                        AddedDate = c.String(nullable: false),
                        ActivityPerformed = c.String(nullable: false),
                        RepairDate = c.String(nullable: false),
                        Comments = c.String(),
                        IsOrders = c.String(nullable: false),
                        DescriptionIntervention = c.String(nullable: false),
                        ReceivingEmployee_Id = c.Int(),
                        SpendingEmployee_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paddles", t => t.PaddleId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.ReceivingEmployee_Id)
                .ForeignKey("dbo.Employees", t => t.SpendingEmployee_Id)
                .Index(t => t.PaddleId)
                .Index(t => t.ReceivingEmployee_Id)
                .Index(t => t.SpendingEmployee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpendedPaddles", "SpendingEmployee_Id", "dbo.Employees");
            DropForeignKey("dbo.SpendedPaddles", "ReceivingEmployee_Id", "dbo.Employees");
            DropForeignKey("dbo.SpendedPaddles", "PaddleId", "dbo.Paddles");
            DropIndex("dbo.SpendedPaddles", new[] { "SpendingEmployee_Id" });
            DropIndex("dbo.SpendedPaddles", new[] { "ReceivingEmployee_Id" });
            DropIndex("dbo.SpendedPaddles", new[] { "PaddleId" });
            DropTable("dbo.SpendedPaddles");
        }
    }
}
