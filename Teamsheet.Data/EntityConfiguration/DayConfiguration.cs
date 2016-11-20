using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamsheet.Entities;

namespace Teamsheet.Data.EntityConfiguration
{
    public class DayConfiguration:EntityTypeConfiguration<Day>
    {
        public DayConfiguration()
        {
            HasMany(d => d.Entries)
            .WithRequired(e => e.Day)
            .HasForeignKey(e => e.DayId);
        }
    }
}
