namespace GymAdministration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstRun1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "PhoneNumber", c => c.String());
            AddColumn("dbo.Clients", "IsHere", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "IsHere");
            DropColumn("dbo.Clients", "PhoneNumber");
        }
    }
}
