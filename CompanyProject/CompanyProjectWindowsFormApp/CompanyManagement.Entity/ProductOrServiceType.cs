using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class ProductOrServiceType
    {
        [Key]
        public int ProductOrServiceTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductOrServiceTypeName { get; set; }

        public virtual ICollection<ProductOrService>
            ProductsOrServices
        { get; set; }
    }
}
