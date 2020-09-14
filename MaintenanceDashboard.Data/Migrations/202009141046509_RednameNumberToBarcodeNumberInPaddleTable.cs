namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RednameNumberToBarcodeNumberInPaddleTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Paddles", "Number", "BarcodeNumber");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Paddles", "BarcodeNumber", "Number");
        }
    }
}
