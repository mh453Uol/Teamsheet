﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teamsheet.Entities
{
    public class Section : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Activity> Activities { get; set; }
    }
}