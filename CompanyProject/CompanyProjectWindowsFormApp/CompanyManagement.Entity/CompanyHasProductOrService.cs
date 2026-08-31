using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class CompanyHasProductOrService
    {
        [Key]
        public int CompanyHasProductOrServiceId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        [Required]
        public int ProductOrServiceId { get; set; }

        public virtual ProductOrService ProductOrService { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal CompanyHasProductOrServiceQuantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue)]
        public decimal CompanyHasProductOrServicePrice { get; set; }

        public virtual ICollection<CustomerBuysCompanyHasProductOrService>
            CustomerBuysCompanyHasProductOrServices
        { get; set; }
    }
}