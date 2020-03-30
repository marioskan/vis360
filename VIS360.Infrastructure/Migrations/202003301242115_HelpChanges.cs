namespace VIS360.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HelpChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HelpOffers", "UserID", c => c.Int(nullable: false));
            AddColumn("dbo.Helps", "UserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Helps", "UserID");
            DropColumn("dbo.HelpOffers", "UserID");
        }
    }
}
