namespace VIS360.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BreathingDiseases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CovidStatusID = c.Int(nullable: false),
                        BreathingDisease = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CovidStatus", t => t.CovidStatusID, cascadeDelete: true)
                .Index(t => t.CovidStatusID);
            
            CreateTable(
                "dbo.CovidStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        OtherMemberID = c.Int(),
                        BloodPressure = c.Boolean(nullable: false),
                        Diabetes = c.Boolean(nullable: false),
                        Smoker = c.Boolean(nullable: false),
                        Overweight = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.OtherMembers", t => t.OtherMemberID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.OtherMemberID);
            
            CreateTable(
                "dbo.HeartDiseases",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CovidStatusID = c.Int(nullable: false),
                        HeartDiseases = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CovidStatus", t => t.CovidStatusID, cascadeDelete: true)
                .Index(t => t.CovidStatusID);
            
            CreateTable(
                "dbo.OtherMembers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        City = c.String(),
                        PeopleLivingWith = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.DiseaseStatements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        OtherMemberID = c.Int(),
                        Coronavirus = c.Boolean(nullable: false),
                        Diagnose = c.Int(nullable: false),
                        DiagnoseDate = c.DateTime(nullable: false, storeType: "date"),
                        HospitalAdmission = c.DateTime(nullable: false, storeType: "date"),
                        HospitalName = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.OtherMembers", t => t.OtherMemberID)
                .Index(t => t.UserID)
                .Index(t => t.OtherMemberID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Ud = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        Provider = c.String(),
                    })
                .PrimaryKey(t => t.Ud);
            
            CreateTable(
                "dbo.Demographics",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        City = c.String(),
                        Country = c.String(),
                        Education = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        FamilyStatus = c.Int(nullable: false),
                        Work = c.Int(nullable: false),
                        Roommates = c.Int(nullable: false),
                        FinancialStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Industries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DemographicID = c.String(nullable: false, maxLength: 128),
                        Industries = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Demographics", t => t.DemographicID, cascadeDelete: true)
                .Index(t => t.DemographicID);
            
            CreateTable(
                "dbo.RoomateRelations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DemographicID = c.String(nullable: false, maxLength: 128),
                        RoomateRelatioships = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Demographics", t => t.DemographicID, cascadeDelete: true)
                .Index(t => t.DemographicID);
            
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        UserID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.HelpOffers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        HelpType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Helps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        HelpType = c.Int(nullable: false),
                        VolunteerPush = c.Boolean(nullable: false),
                        TownPush = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DiseaseStatements", "OtherMemberID", "dbo.OtherMembers");
            DropForeignKey("dbo.UserInfoes", "UserID", "dbo.Users");
            DropForeignKey("dbo.OtherMembers", "UserID", "dbo.Users");
            DropForeignKey("dbo.DiseaseStatements", "UserID", "dbo.Users");
            DropForeignKey("dbo.Demographics", "UserID", "dbo.Users");
            DropForeignKey("dbo.RoomateRelations", "DemographicID", "dbo.Demographics");
            DropForeignKey("dbo.Industries", "DemographicID", "dbo.Demographics");
            DropForeignKey("dbo.CovidStatus", "UserID", "dbo.Users");
            DropForeignKey("dbo.CovidStatus", "OtherMemberID", "dbo.OtherMembers");
            DropForeignKey("dbo.HeartDiseases", "CovidStatusID", "dbo.CovidStatus");
            DropForeignKey("dbo.BreathingDiseases", "CovidStatusID", "dbo.CovidStatus");
            DropIndex("dbo.UserInfoes", new[] { "UserID" });
            DropIndex("dbo.RoomateRelations", new[] { "DemographicID" });
            DropIndex("dbo.Industries", new[] { "DemographicID" });
            DropIndex("dbo.Demographics", new[] { "UserID" });
            DropIndex("dbo.DiseaseStatements", new[] { "OtherMemberID" });
            DropIndex("dbo.DiseaseStatements", new[] { "UserID" });
            DropIndex("dbo.OtherMembers", new[] { "UserID" });
            DropIndex("dbo.HeartDiseases", new[] { "CovidStatusID" });
            DropIndex("dbo.CovidStatus", new[] { "OtherMemberID" });
            DropIndex("dbo.CovidStatus", new[] { "UserID" });
            DropIndex("dbo.BreathingDiseases", new[] { "CovidStatusID" });
            DropTable("dbo.Helps");
            DropTable("dbo.HelpOffers");
            DropTable("dbo.UserInfoes");
            DropTable("dbo.RoomateRelations");
            DropTable("dbo.Industries");
            DropTable("dbo.Demographics");
            DropTable("dbo.Users");
            DropTable("dbo.DiseaseStatements");
            DropTable("dbo.OtherMembers");
            DropTable("dbo.HeartDiseases");
            DropTable("dbo.CovidStatus");
            DropTable("dbo.BreathingDiseases");
        }
    }
}
