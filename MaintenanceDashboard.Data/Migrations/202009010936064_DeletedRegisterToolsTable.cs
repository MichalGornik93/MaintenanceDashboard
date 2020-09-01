namespace MaintenanceDashboard.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedRegisterToolsTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.RegisterTools");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RegisterTools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ToolName = c.String(),
                        UidCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
