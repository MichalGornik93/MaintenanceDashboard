namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedUidPropertyToEmployeeTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "UidCode", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "UidCode", c => c.String(nullable: false));
        }
    }
}
