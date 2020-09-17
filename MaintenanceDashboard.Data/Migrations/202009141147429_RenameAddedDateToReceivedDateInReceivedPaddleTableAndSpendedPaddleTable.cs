namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameAddedDateToReceivedDateInReceivedPaddleTableAndSpendedPaddleTable : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.ReceivedPaddles", "AddedDate", "ReceivedDate");
            RenameColumn("dbo.SpendedPaddles", "AddedDate", "ReceivedDate");
            
        }
        
        public override void Down()
        {
            RenameColumn("dbo.ReceivedPaddles", "ReceivedDate", "AddedDate");
            RenameColumn("dbo.SpendedPaddles", "ReceivedDate", "AddedDate");
        }
    }
}
