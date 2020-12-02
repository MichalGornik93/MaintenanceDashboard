namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDecriptionInterventionProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceivedPaddles", "DescriptionIntervention", c => c.String());
            AddColumn("dbo.ReceivedThermostats", "DescriptionIntervention", c => c.String());
            DropColumn("dbo.ReceivedPaddles", "Comments");
            DropColumn("dbo.SpendedPaddles", "Comments");
            DropColumn("dbo.ReceivedThermostats", "Comments");
            DropColumn("dbo.SpendedThermostats", "Comments");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SpendedThermostats", "Comments", c => c.String());
            AddColumn("dbo.ReceivedThermostats", "Comments", c => c.String());
            AddColumn("dbo.SpendedPaddles", "Comments", c => c.String());
            AddColumn("dbo.ReceivedPaddles", "Comments", c => c.String());
            DropColumn("dbo.ReceivedThermostats", "DescriptionIntervention");
            DropColumn("dbo.ReceivedPaddles", "DescriptionIntervention");
        }
    }
}
