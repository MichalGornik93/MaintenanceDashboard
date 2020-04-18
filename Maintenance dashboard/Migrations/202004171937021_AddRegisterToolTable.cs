namespace Maintenance_dashboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegisterToolTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegisterTools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Uid = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RegisterTools");
        }
    }
}
