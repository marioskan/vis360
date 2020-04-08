namespace VIS360.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes2 : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.OtherMembers", "ID", "dbo.DiseaseStatements", "ID");
            DropColumn("dbo.DiseaseStatements", "CovidMember");
            DropColumn("dbo.DiseaseStatements", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DiseaseStatements", "Name", c => c.String());
            AddColumn("dbo.DiseaseStatements", "CovidMember", c => c.Int(nullable: false));
            DropForeignKey("dbo.OtherMembers", "ID", "dbo.DiseaseStatements");
        }
    }
}
