using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VIS360.Core.Entities;

namespace VIS360.Infrastructure
{
    /// <summary>
    /// Enable-Migrations -ContextTypeName VIS360.Infrastructure.Context -MigrationsDirectory Migrations
    /// Add-Migration -ConfigurationTypeName VIS360.Infrastructure.Migrations.Configuration Initial
    /// Update-Database -ConfigurationTypeName VIS360.Infrastructure.Migrations.Configuration
    /// </summary>
    public class Context : DbContext
    {
        public Context() : base("DefaultConnection")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Demographic> Demographics { get; set; }
        public DbSet<CovidStatus> CovidStatuses { get; set; }
        public DbSet<DiseaseStatement> DiseaseStatements { get; set; }
        public DbSet<Help> Helps { get; set; }
        public DbSet<HelpOffer> HelpOffers { get; set; }
        public DbSet<RoomateRelation> RoomateRelations { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<OtherMember> OtherMembers { get; set; }
        public DbSet<HeartDisease> HeartDiseases { get; set; }
        public DbSet<BreathingDiseases> BreathingDiseaseses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            
            //User -> UserInfo 1-0 or 1-1
            modelbuilder.Entity<User>()
                .HasOptional(u => u.UserInfo)
                .WithRequired(ui => ui.User);

            //User -> Demographic 1-1
            modelbuilder.Entity<User>()
                .HasOptional(u => u.Demographic)
                .WithRequired(d => d.User);

            //User -> CovidStatus 1-*
            modelbuilder.Entity<User>()
                .HasMany(u => u.CovidStatuses)
                .WithOptional(cs => cs.User)
                .HasForeignKey(cs => cs.UserID)
                .WillCascadeOnDelete(true);


            //User -> DiseaseStatement 1-*
            modelbuilder.Entity<User>()
                .HasMany(u => u.DiseaseStatements)
                .WithOptional(ds => ds.User)
                .HasForeignKey(ds => ds.UserID)
                .WillCascadeOnDelete(true);

            //User -> OtherMembers 1-*
            modelbuilder.Entity<User>()
                .HasMany(u => u.OtherMembers)
                .WithRequired(o => o.User)
                .HasForeignKey(o => o.UserID)
                .WillCascadeOnDelete(true);

            //Demographic -> RoomateRelations 1-*       
            modelbuilder.Entity<Demographic>()
                .HasMany(d => d.RoomateRelations)
                .WithRequired(r => r.Demographic)
                .HasForeignKey(r => r.DemographicID)
                .WillCascadeOnDelete(true);

            //Demographic -> Industries 1-*       
            modelbuilder.Entity<Demographic>()
                .HasMany(d => d.Industries)
                .WithRequired(i => i.Demographic)
                .HasForeignKey(i => i.DemographicID)
                .WillCascadeOnDelete(true);

            ////CovidStatus -> OtherMember 1-1
            //modelbuilder.Entity<CovidStatus>()
            //    .HasOptional(c => c.OtherMember)
            //    .WithRequired(o => o.CovidStatus);

            //CovidStatus -> HeartDiseases 1-*
            modelbuilder.Entity<CovidStatus>()
                .HasMany(c => c.HeartDiseases)
                .WithRequired(h => h.CovidStatus)
                .HasForeignKey(h => h.CovidStatusID)
                .WillCascadeOnDelete(true);

            //CovidStatus -> BreathingDiseases 1-*    
            modelbuilder.Entity<CovidStatus>()
                .HasMany(c => c.BreathingDiseases)
                .WithRequired(b => b.CovidStatus)
                .HasForeignKey(b => b.CovidStatusID)
                .WillCascadeOnDelete(true);

            ////DiseaseStatement -> OtherMember 1-1
            //modelbuilder.Entity<DiseaseStatement>()
            //    .HasOptional(d => d.OtherMember)
            //    .WithRequired(o => o.DiseaseStatement);

            //OtheMember -> DiseaseStatement 1 - *
            modelbuilder.Entity<OtherMember>()
                .HasMany(o => o.DiseaseStatements)
                .WithOptional(d => d.OtherMember)
                .HasForeignKey(d => d.OtherMemberID)
                .WillCascadeOnDelete(false);

            //OtheMember -> CovidStatus 1 - *
            modelbuilder.Entity<OtherMember>()
                .HasMany(o => o.CovidStatuses)
                .WithOptional(c => c.OtherMember)
                .HasForeignKey(c => c.OtherMemberID)
                .WillCascadeOnDelete(false);
        }


    }

    //public class Identity : Context
    //{
    //    protected override void OnModelCreating(DbModelBuilder modelbuilder)
    //    {
    //        modelbuilder.Entity<User>()
    //            .Property(u => u.Ud)
    //            .HasDatabaseGeneratedOption(null);
    //        base.OnModelCreating(modelbuilder);
    //    }
    //}
}
