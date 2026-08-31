using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class MeetingHasCompanyOwner
    {
        [Key]
        public int MeetingHasCompanyOwnerId { get; set; }

        [Required]
        public int MeetingId { get; set; }

        public virtual Meeting Meeting { get; set; }

        [Required]
        public int CompanyOwnerId { get; set; }

        public virtual CompanyOwner CompanyOwner { get; set; }
    }
}