using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamsheet.Entities
{
    public class Entry
    {
        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Duration { get; set; }

        public Week Week { get; set; }

        public int WeekId { get; set; }

        public Activity Activity { get; set; }

        public int ActivityId { get; set; }

    }
}
