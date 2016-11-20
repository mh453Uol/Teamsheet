using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamsheet.Models;

namespace Teamsheet.Entities
{
    public class BaseEntity
    {
        public ApplicationUser CreatedBy { get; set; } 

        [Required]
        [ForeignKey("CreatedBy")]
        public string CreatedById { get; set; }

        public ApplicationUser ModifiedBy { get; set; }

        [Required]
        [ForeignKey("ModifiedBy")]
        public string ModifiedById { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModifiedDate { get; set; }

    }
}
