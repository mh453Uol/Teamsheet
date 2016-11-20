using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Teamsheet.Entities
{
    public class Week
    {
        public int Id { get; set; }
        public ICollection<Day> Days { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "[0:dd/MM/yyyy}")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime EndDate { get; set; }

    }
}