using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamsheet.Entities;

namespace Teamsheet.Data.EntityConfiguration
{
    public class CompanyConfiguration:EntityTypeConfiguration<Company>
    {
        public CompanyConfiguration()
        {
            Property(c => c.Name)
            .HasMaxLength(255)
            .IsRequired();

            Property(c => c.AddressLine1)
            .HasMaxLength(125)
            .IsRequired();

            Property(c => c.AddressLine2)
            .HasMaxLength(125)
            .IsRequired();

            Property(c => c.Country)
            .HasMaxLength(60)
            .IsRequired();

            HasMany(c => c.Employees)
            .WithOptional(e => e.Company)
            .HasForeignKey(e => e.CompanyId);

            HasRequired(c => c.CreatedBy)
            .WithMany()
            .WillCascadeOnDelete(false);

            HasRequired(c => c.ModifiedBy)
            .WithMany()
            .WillCascadeOnDelete(false);
        }
    }
}
