using System;
using System.Collections.Generic;
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
                .WithOptional(c => c.User);
                

            //User -> DiseaseStatement 1-*
            modelbuilder.Entity<User>()
                .HasMany(u => u.DiseaseStatements)
                .WithOptional(d => d.User);

        }
    }
}
