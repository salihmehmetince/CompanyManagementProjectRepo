using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class CompanyType
    {
        [Key]
        public int CompanyTypeId { get; set; }

        [Required]
        [StringLength(30)]
        public string CompanyTypeName { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
