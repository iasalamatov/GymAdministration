namespace GymAdministration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstRun : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        DateOfValidityStart = c.DateTime(nullable: false),
                        DateOfValidityFinish = c.DateTime(nullable: false),
                        Coach_id = c.Int(),
                        Manager_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Coaches", t => t.Coach_id)
                .ForeignKey("dbo.Managers", t => t.Manager_id)
                .Index(t => t.Coach_id)
                .Index(t => t.Manager_id);
            
            CreateTable(
                "dbo.Coaches",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Managers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "Manager_id", "dbo.Managers");
            DropForeignKey("dbo.Clients", "Coach_id", "dbo.Coaches");
            DropIndex("dbo.Clients", new[] { "Manager_id" });
            DropIndex("dbo.Clients", new[] { "Coach_id" });
            DropTable("dbo.Managers");
            DropTable("dbo.Coaches");
            DropTable("dbo.Clients");
        }
    }
}
