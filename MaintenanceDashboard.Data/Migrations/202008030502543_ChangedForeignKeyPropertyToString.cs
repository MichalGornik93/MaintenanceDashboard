namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedForeignKeyPropertyToString : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReceivedPaddles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.SpendedPaddles", "PaddleId", "dbo.Paddles");
            DropForeignKey("dbo.ReceivedPaddles", "PaddleId", "dbo.Paddles");
            DropForeignKey("dbo.SpendedPaddles", "ReceivingEmployee_Id", "dbo.Employees");
            DropForeignKey("dbo.SpendedPaddles", "SpendingEmployee_Id", "dbo.Employees");
            DropIndex("dbo.ReceivedPaddles", new[] { "EmployeeId" });
            DropIndex("dbo.ReceivedPaddles", new[] { "PaddleId" });
            DropIndex("dbo.SpendedPaddles", new[] { "PaddleId" });
            DropIndex("dbo.SpendedPaddles", new[] { "ReceivingEmployee_Id" });
            DropIndex("dbo.SpendedPaddles", new[] { "SpendingEmployee_Id" });
            AddColumn("dbo.ReceivedPaddles", "ReceivingEmployee", c => c.String(nullable: false));
            AddColumn("dbo.ReceivedPaddles", "PaddleNumber", c => c.String(nullable: false));
            AddColumn("dbo.SpendedPaddles", "PaddleNumber", c => c.String(nullable: false));
            AddColumn("dbo.SpendedPaddles", "ReceivingEmployee", c => c.String(nullable: false));
            AddColumn("dbo.SpendedPaddles", "SpendingEmployee", c => c.String(nullable: false));
            DropColumn("dbo.ReceivedPaddles", "EmployeeId");
            DropColumn("dbo.ReceivedPaddles", "PaddleId");
            DropColumn("dbo.SpendedPaddles", "PaddleId");
            DropColumn("dbo.SpendedPaddles", "ReceivingEmployee_Id");
            DropColumn("dbo.SpendedPaddles", "SpendingEmployee_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SpendedPaddles", "SpendingEmployee_Id", c => c.Int());
            AddColumn("dbo.SpendedPaddles", "ReceivingEmployee_Id", c => c.Int());
            AddColumn("dbo.SpendedPaddles", "PaddleId", c => c.Int(nullable: false));
            AddColumn("dbo.ReceivedPaddles", "PaddleId", c => c.Int(nullable: false));
            AddColumn("dbo.ReceivedPaddles", "EmployeeId", c => c.Int(nullable: false));
            DropColumn("dbo.SpendedPaddles", "SpendingEmployee");
            DropColumn("dbo.SpendedPaddles", "ReceivingEmployee");
            DropColumn("dbo.SpendedPaddles", "PaddleNumber");
            DropColumn("dbo.ReceivedPaddles", "PaddleNumber");
            DropColumn("dbo.ReceivedPaddles", "ReceivingEmployee");
            CreateIndex("dbo.SpendedPaddles", "SpendingEmployee_Id");
            CreateIndex("dbo.SpendedPaddles", "ReceivingEmployee_Id");
            CreateIndex("dbo.SpendedPaddles", "PaddleId");
            CreateIndex("dbo.ReceivedPaddles", "PaddleId");
            CreateIndex("dbo.ReceivedPaddles", "EmployeeId");
            AddForeignKey("dbo.SpendedPaddles", "SpendingEmployee_Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.SpendedPaddles", "ReceivingEmployee_Id", "dbo.Employees", "Id");
            AddForeignKey("dbo.ReceivedPaddles", "PaddleId", "dbo.Paddles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SpendedPaddles", "PaddleId", "dbo.Paddles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ReceivedPaddles", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
