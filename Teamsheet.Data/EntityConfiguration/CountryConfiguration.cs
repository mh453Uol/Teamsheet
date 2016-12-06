using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamsheet.Entities;

namespace Teamsheet.Data.EntityConfiguration
{
    public class CountryConfiguration:EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            Property(a => a.Name)
            .HasMaxLength(60)
            .IsRequired();
        }
    }
}
