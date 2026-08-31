using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace CompanyManagement.Entity
{
    public class CompanyOwner
    {
        [Key]
        public int CompanyOwnerId { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 11)]
        public string CompanyOwnerIdentityNumber { get; set; }

        [Required]
        [StringLength(30)]
        public string CompanyOwnerName { get; set; }

        [Required]
        [StringLength(30)]
        public string CompanyOwnerSurname { get; set; }

        public DateTime CompanyOwnerBirthday { get; set; }

        [Required]
        [StringLength(15)]
        public string CompanyOwnerTelephoneNumber { get; set; }

        [StringLength(100)]
        public string CompanyOwnerEmail { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<CompanyOwnerHasCompany>
            CompanyOwnerHasCompanies
        { get; set; }

        public virtual ICollection<MeetingHasCompanyOwner>
            MeetingHasCompanyOwners
        { get; set; }

        public virtual ICollection<TaskHasCompanyOwner>
            TaskHasCompanyOwners
        { get; set; }
    }
}