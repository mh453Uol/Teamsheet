using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teamsheet.Entities
{
    public class Week
    {
        public Week()
        {
            this.Entries = new List<Entry>();
        }
        public int Id { get; set; }
        public ICollection<Entry> Entries { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "[0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }

    }
}