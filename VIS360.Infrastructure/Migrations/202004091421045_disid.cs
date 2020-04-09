namespace VIS360.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class disid : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DiseaseStatements", new[] { "OtherMemberID" });
            AlterColumn("dbo.DiseaseStatements", "OtherMemberID", c => c.Int());
            CreateIndex("dbo.DiseaseStatements", "OtherMemberID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.DiseaseStatements", new[] { "OtherMemberID" });
            AlterColumn("dbo.DiseaseStatements", "OtherMemberID", c => c.Int(nullable: false));
            CreateIndex("dbo.DiseaseStatements", "OtherMemberID");
        }
    }
}
