using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required]
        [StringLength(30)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(250)]
        public string CompanyAddress { get; set; }

        [StringLength(15)]
        public string CompanyTelephoneNumber { get; set; }

        [StringLength(100)]
        public string CompanyEmail { get; set; }

        [Required]
        public int CompanyTypeId { get; set; }

        public virtual CompanyType CompanyType { get; set; }

        public virtual ICollection<CompanyHasProductOrService>
            CompanyHasProductOrServices
        { get; set; }

        public virtual ICollection<CompanyOwnerHasCompany>
            CompanyOwnerHasCompanies
        { get; set; }

        public virtual ICollection<CompanyHasDepartmentType>
            CompanyHasDepartmentTypes
        { get; set; }

        public virtual ICollection<CompanyGivesBonusToEmployee>
            CompanyGivesBonusToEmployees
        { get; set; }

        public virtual ICollection<EmployeeHasCompanyHasDepartmentType>
            EmployeeHasCompanyHasDepartmentTypes
        { get; set; }
    }
}