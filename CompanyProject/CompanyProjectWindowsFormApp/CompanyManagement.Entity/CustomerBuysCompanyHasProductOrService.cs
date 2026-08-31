using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class CustomerBuysCompanyHasProductOrService
    {
        [Key]
        public int CustomerBuysCompanyHasProductOrServiceId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        [Required]
        public int CompanyHasProductOrServiceId { get; set; }

        public virtual CompanyHasProductOrService
            CompanyHasProductOrService
        { get; set; }

        [Required]
        public int PaymentTypeId { get; set; }

        public virtual PaymentType PaymentType { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal CustomerBuysCompanyHasProductOrServiceQuantity { get; set; }

        [Required]
        public DateTime CustomerBuysCompanyHasProductOrServiceDate { get; set; }
    }
}