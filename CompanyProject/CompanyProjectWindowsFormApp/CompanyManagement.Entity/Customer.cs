using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(30)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(30)]
        public string CustomerSurname { get; set; }

        [Required]
        [StringLength(15)]
        public string CustomerTelephoneNumber { get; set; }

        [StringLength(100)]
        [EmailAddress]
        public string CustomerEmail { get; set; }

        public virtual ICollection<CustomerBuysCompanyHasProductOrService>
            CustomerBuysCompanyHasProductOrServices
        { get; set; }
    }
}