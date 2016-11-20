using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teamsheet.Entities
{
    public class Day
    {
        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        public ICollection<Entry> Entries { get; set; }

        public Week Week { get; set; }

        public int WeekId { get; set; }
    }
}