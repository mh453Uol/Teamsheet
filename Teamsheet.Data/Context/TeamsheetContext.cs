using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamsheet.Core.Configuration;
using Teamsheet.Data.EntityConfiguration;
using Teamsheet.Entities;
using Teamsheet.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Teamsheet.Data.Context
{
    public class TeamsheetContext : IdentityDbContext<ApplicationUser>
    {
        public TeamsheetContext() : base(ConfigHelper.GetConnectionString(), throwIfV1Schema: false)
        {

        }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Week> Weeks { get; set; }
        public DbSet<Company> Companies { get; set; }

        public static TeamsheetContext Create()
        {
            return new TeamsheetContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SectionConfiguration());
            modelBuilder.Configurations.Add(new EntryConfiguration());
            modelBuilder.Configurations.Add(new ActivityConfiguration());
            modelBuilder.Configurations.Add(new WeekConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new CompanyConfiguration());
            //modelBuilder.Configurations.Add(new BaseEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
