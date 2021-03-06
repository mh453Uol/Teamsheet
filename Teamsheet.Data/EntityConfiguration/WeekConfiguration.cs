﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamsheet.Entities;

namespace Teamsheet.Data.EntityConfiguration
{
    public class WeekConfiguration : EntityTypeConfiguration<Week>
    {
        public WeekConfiguration()
        {
            HasMany(c => c.Entries)
            .WithRequired(e => e.Week)
            .HasForeignKey(e => e.WeekId);
        }
    }
}
