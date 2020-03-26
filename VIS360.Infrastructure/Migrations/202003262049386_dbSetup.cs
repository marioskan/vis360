namespace VIS360.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CovidStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CovidMember = c.Int(nullable: false),
                        HeartDisease = c.Int(nullable: false),
                        BreathingDiseases = c.Int(nullable: false),
                        BloodPressure = c.Boolean(nullable: false),
                        Diabetes = c.Boolean(nullable: false),
                        Smoker = c.Boolean(nullable: false),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        City = c.String(),
                        PeopleLivingWith = c.Int(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Demographics",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        City = c.String(),
                        Education = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        FamilyStatus = c.Int(nullable: false),
                        Work = c.Int(nullable: false),
                        Roommates = c.Int(nullable: false),
                        FinancialStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.DiseaseStatements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Coronavirus = c.Boolean(nullable: false),
                        Diagnose = c.Int(nullable: false),
                        DiagnoseDate = c.DateTime(nullable: false),
                        HospitalAdmission = c.DateTime(nullable: false),
                        HospitalName = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        City = c.String(),
                        PeopleLivingWith = c.Int(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.HelpOffers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HelpType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Helps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HelpType = c.Int(nullable: false),
                        VolunteerPush = c.Boolean(nullable: false),
                        TownPush = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInfoes", "ID", "dbo.Users");
            DropForeignKey("dbo.DiseaseStatements", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Demographics", "ID", "dbo.Users");
            DropForeignKey("dbo.CovidStatus", "User_ID", "dbo.Users");
            DropIndex("dbo.UserInfoes", new[] { "ID" });
            DropIndex("dbo.DiseaseStatements", new[] { "User_ID" });
            DropIndex("dbo.Demographics", new[] { "ID" });
            DropIndex("dbo.CovidStatus", new[] { "User_ID" });
            DropTable("dbo.Helps");
            DropTable("dbo.HelpOffers");
            DropTable("dbo.UserInfoes");
            DropTable("dbo.DiseaseStatements");
            DropTable("dbo.Demographics");
            DropTable("dbo.CovidStatus");
        }
    }
}
