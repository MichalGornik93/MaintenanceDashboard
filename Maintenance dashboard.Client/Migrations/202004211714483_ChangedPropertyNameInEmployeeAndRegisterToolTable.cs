namespace MaintenanceDashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedPropertyNameInEmployeeAndRegisterToolTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "UidCode", c => c.String(nullable: false));
            AddColumn("dbo.RegisterTools", "ToolName", c => c.String(nullable: false));
            AddColumn("dbo.RegisterTools", "UidCode", c => c.String(nullable: false));
            DropColumn("dbo.Employees", "Name");
            DropColumn("dbo.Employees", "Surname");
            DropColumn("dbo.Employees", "Uid");
            DropColumn("dbo.RegisterTools", "Name");
            DropColumn("dbo.RegisterTools", "Uid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RegisterTools", "Uid", c => c.String(nullable: false));
            AddColumn("dbo.RegisterTools", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "Uid", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "Surname", c => c.String(nullable: false));
            AddColumn("dbo.Employees", "Name", c => c.String(nullable: false));
            DropColumn("dbo.RegisterTools", "UidCode");
            DropColumn("dbo.RegisterTools", "ToolName");
            DropColumn("dbo.Employees", "UidCode");
            DropColumn("dbo.Employees", "LastName");
            DropColumn("dbo.Employees", "FirstName");
        }
    }
}
