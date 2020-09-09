namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedUidPropertyToEmployeeTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "UidCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "UidCode", c => c.String());
        }
    }
}
