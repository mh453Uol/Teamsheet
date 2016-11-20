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

        public DateTime Duration { get; set; }

        public Day Day { get; set; }

        public int DayId { get; set; }

        public Activity Activity { get; set; }

        public int ActivityId { get; set; }

    }
}
