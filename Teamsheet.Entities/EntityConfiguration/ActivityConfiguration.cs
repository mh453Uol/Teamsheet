using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamsheet.Entities;

namespace Teamsheet.Data.EntityConfiguration
{
    public class ActivityConfiguration:EntityTypeConfiguration<Activity>
    {
        public ActivityConfiguration()
        {
            Property(a => a.Name)
            .HasMaxLength(125)
            .IsRequired();

            Property(a => a.Description)
            .HasMaxLength(255)
            .IsRequired();

            HasMany(a => a.Entries)
            .WithRequired(e => e.Activity)
            .HasForeignKey(e => e.ActivityId);
        }
    }
}
