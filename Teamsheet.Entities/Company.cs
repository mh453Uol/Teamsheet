using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teamsheet.Models;

namespace Teamsheet.Entities
{
    public class Company : BaseEntity
    {
        public Company()
        {
            Employees = new List<ApplicationUser>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }

        public ICollection<ApplicationUser> Employees { get; set; }
    }
}
