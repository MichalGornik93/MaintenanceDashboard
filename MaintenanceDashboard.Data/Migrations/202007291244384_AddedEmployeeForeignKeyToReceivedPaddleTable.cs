namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmployeeForeignKeyToReceivedPaddleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceivedPaddles", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.ReceivedPaddles", "EmployeeId");
            AddForeignKey("dbo.ReceivedPaddles", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            DropColumn("dbo.ReceivedPaddles", "Employee");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReceivedPaddles", "Employee", c => c.String(nullable: false));
            DropForeignKey("dbo.ReceivedPaddles", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.ReceivedPaddles", new[] { "EmployeeId" });
            DropColumn("dbo.ReceivedPaddles", "EmployeeId");
        }
    }
}
