namespace Maintenance_dashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSurnameColumnToEmploeeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Surname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Surname");
        }
    }
}
