using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class ProductOrService
    {
        [Key]
        public int ProductOrServiceId { get; set; }

        [Required]
        [StringLength(150)]
        public string ProductOrServiceName { get; set; }

        [Required]
        public bool IsProductOrService { get; set; }

        [Required]
        public int ProductOrServiceTypeId { get; set; }

        public virtual ProductOrServiceType ProductOrServiceType { get; set; }

        public virtual ICollection<CompanyHasProductOrService>
            CompanyHasProductOrServices
        { get; set; }
    }
}