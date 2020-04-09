namespace VIS360.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class disid3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CovidStatus", new[] { "UserID" });
            DropIndex("dbo.CovidStatus", new[] { "OtherMemberID" });
            AlterColumn("dbo.CovidStatus", "UserID", c => c.Int());
            AlterColumn("dbo.CovidStatus", "OtherMemberID", c => c.Int());
            CreateIndex("dbo.CovidStatus", "UserID");
            CreateIndex("dbo.CovidStatus", "OtherMemberID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.CovidStatus", new[] { "OtherMemberID" });
            DropIndex("dbo.CovidStatus", new[] { "UserID" });
            AlterColumn("dbo.CovidStatus", "OtherMemberID", c => c.Int(nullable: false));
            AlterColumn("dbo.CovidStatus", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.CovidStatus", "OtherMemberID");
            CreateIndex("dbo.CovidStatus", "UserID");
        }
    }
}
