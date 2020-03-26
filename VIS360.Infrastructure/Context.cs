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

        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {

        }
    }
}
