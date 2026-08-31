using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class PaymentType
    {
        [Key]
        public int PaymentTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentTypeName { get; set; }

        public virtual ICollection<CustomerBuysCompanyHasProductOrService>
            CustomerBuysCompanyHasProductOrServices
        { get; set; }
    }
}