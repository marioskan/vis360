namespace VIS360.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Demographics", "TK", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Demographics", "TK");
        }
    }
}
