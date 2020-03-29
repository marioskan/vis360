namespace VIS360.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DiseaseStatements", "CovidMember", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DiseaseStatements", "CovidMember");
        }
    }
}
