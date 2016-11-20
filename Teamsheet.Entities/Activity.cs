using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamsheet.Entities
{
    public class Activity : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Section Section { get; set; }
        public int SectionId { get; set; }
        public ICollection<Entry> Entries { get; set; }
    }
}
