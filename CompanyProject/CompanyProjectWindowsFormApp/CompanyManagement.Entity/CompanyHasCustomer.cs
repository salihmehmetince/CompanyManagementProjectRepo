using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class CompanyHasCustomer
    {
        [Key]
        public int CompanyHasCustomerId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}