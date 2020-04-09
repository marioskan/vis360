namespace VIS360.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class disid2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DiseaseStatements", new[] { "UserID" });
            AlterColumn("dbo.DiseaseStatements", "UserID", c => c.Int());
            CreateIndex("dbo.DiseaseStatements", "UserID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.DiseaseStatements", new[] { "UserID" });
            AlterColumn("dbo.DiseaseStatements", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.DiseaseStatements", "UserID");
        }
    }
}
