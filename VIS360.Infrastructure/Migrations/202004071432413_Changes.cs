namespace VIS360.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
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
                        ID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        City = c.String(),
                        PeopleLivingWith = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.CovidStatus", t => t.ID)
                .Index(t => t.ID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Industries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DemographicID = c.Int(nullable: false),
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
                        DemographicID = c.Int(nullable: false),
                        RoomateRelatioships = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Demographics", t => t.DemographicID, cascadeDelete: true)
                .Index(t => t.DemographicID);
            
            AddColumn("dbo.Demographics", "Country", c => c.String());
            DropColumn("dbo.CovidStatus", "CovidMember");
            DropColumn("dbo.CovidStatus", "HeartDisease");
            DropColumn("dbo.CovidStatus", "BreathingDiseases");
            DropColumn("dbo.CovidStatus", "Age");
            DropColumn("dbo.CovidStatus", "Gender");
            DropColumn("dbo.CovidStatus", "City");
            DropColumn("dbo.CovidStatus", "PeopleLivingWith");
            DropColumn("dbo.DiseaseStatements", "Age");
            DropColumn("dbo.DiseaseStatements", "Gender");
            DropColumn("dbo.DiseaseStatements", "City");
            DropColumn("dbo.DiseaseStatements", "PeopleLivingWith");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DiseaseStatements", "PeopleLivingWith", c => c.Int(nullable: false));
            AddColumn("dbo.DiseaseStatements", "City", c => c.String());
            AddColumn("dbo.DiseaseStatements", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.DiseaseStatements", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.CovidStatus", "PeopleLivingWith", c => c.Int(nullable: false));
            AddColumn("dbo.CovidStatus", "City", c => c.String());
            AddColumn("dbo.CovidStatus", "Gender", c => c.Int(nullable: false));
            AddColumn("dbo.CovidStatus", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.CovidStatus", "BreathingDiseases", c => c.Int(nullable: false));
            AddColumn("dbo.CovidStatus", "HeartDisease", c => c.Int(nullable: false));
            AddColumn("dbo.CovidStatus", "CovidMember", c => c.Int(nullable: false));
            DropForeignKey("dbo.OtherMembers", "ID", "dbo.CovidStatus");
            DropForeignKey("dbo.OtherMembers", "UserID", "dbo.Users");
            DropForeignKey("dbo.RoomateRelations", "DemographicID", "dbo.Demographics");
            DropForeignKey("dbo.Industries", "DemographicID", "dbo.Demographics");
            DropForeignKey("dbo.HeartDiseases", "CovidStatusID", "dbo.CovidStatus");
            DropForeignKey("dbo.BreathingDiseases", "CovidStatusID", "dbo.CovidStatus");
            DropIndex("dbo.RoomateRelations", new[] { "DemographicID" });
            DropIndex("dbo.Industries", new[] { "DemographicID" });
            DropIndex("dbo.OtherMembers", new[] { "UserID" });
            DropIndex("dbo.OtherMembers", new[] { "ID" });
            DropIndex("dbo.HeartDiseases", new[] { "CovidStatusID" });
            DropIndex("dbo.BreathingDiseases", new[] { "CovidStatusID" });
            DropColumn("dbo.Demographics", "Country");
            DropTable("dbo.RoomateRelations");
            DropTable("dbo.Industries");
            DropTable("dbo.OtherMembers");
            DropTable("dbo.HeartDiseases");
            DropTable("dbo.BreathingDiseases");
        }
    }
}
