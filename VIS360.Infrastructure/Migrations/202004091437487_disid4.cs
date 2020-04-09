namespace VIS360.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class disid4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DiseaseStatements", "DiagnoseDate", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.DiseaseStatements", "HospitalAdmission", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DiseaseStatements", "HospitalAdmission", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DiseaseStatements", "DiagnoseDate", c => c.DateTime(nullable: false));
        }
    }
}
