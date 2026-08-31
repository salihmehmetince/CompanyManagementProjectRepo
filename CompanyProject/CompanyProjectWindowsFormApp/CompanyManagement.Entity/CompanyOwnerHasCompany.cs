using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class CompanyOwnerHasCompany
    {
        [Key]
        public int CompanyOwnerHasCompanyId { get; set; }

        [Required]
        public int CompanyOwnerId { get; set; }

        [Required]
        public int CompanyOwnerPercent {  get; set; }

        public virtual CompanyOwner CompanyOwner { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}