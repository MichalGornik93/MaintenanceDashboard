namespace Maintenance_dashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredParameter : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Uid", c => c.String(nullable: false));
            AlterColumn("dbo.RegisterTools", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.RegisterTools", "Uid", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RegisterTools", "Uid", c => c.String());
            AlterColumn("dbo.RegisterTools", "Name", c => c.String());
            AlterColumn("dbo.Employees", "Uid", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
        }
    }
}
