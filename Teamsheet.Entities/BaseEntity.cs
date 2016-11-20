using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teamsheet.Entities
{
    public class BaseEntity
    {
        [Required]
        [MaxLength(125)]
        public string CreatedBy { get; set; } //ApplicationUser

        [MaxLength]
        [Required]
        public string ModifiedBy { get; set; } //ApplicationUser

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime CreatedDate { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModifiedDate { get; set; }

    }
}
