namespace GymAdministration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addVisit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Visits",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        StartTime = c.DateTime(nullable: false),
                        FinishTime = c.DateTime(nullable: false),
                        Client_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Clients", t => t.Client_id)
                .Index(t => t.Client_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visits", "Client_id", "dbo.Clients");
            DropIndex("dbo.Visits", new[] { "Client_id" });
            DropTable("dbo.Visits");
        }
    }
}
