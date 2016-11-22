using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamsheet.Entities;

namespace Teamsheet.Data.EntityConfiguration
{
    public class SectionConfiguration : EntityTypeConfiguration<Section>
    {
        public SectionConfiguration()
        {
            Property(s => s.Name)
            .HasMaxLength(125)
            .IsRequired();

            Property(s => s.Description)
            .HasMaxLength(255)
            .IsRequired();

            HasMany(s => s.Activities)
            .WithRequired(a => a.Section)
            .HasForeignKey(a => a.SectionId);

            HasRequired(s => s.CreatedBy)
            .WithMany()
            .WillCascadeOnDelete(false);

            HasRequired(s => s.ModifiedBy)
            .WithMany()
            .WillCascadeOnDelete(false);
        }
    }
}
