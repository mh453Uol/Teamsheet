using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Teamsheet.Models
{
    public class CompanyForm
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}