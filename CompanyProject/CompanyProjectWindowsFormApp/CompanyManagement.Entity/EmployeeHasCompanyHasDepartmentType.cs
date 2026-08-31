using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class EmployeeHasCompanyHasDepartmentType
    {
        [Key]
        public int EmployeeHasCompanyId { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        [Required]
        public int CompanyHasDepartmentTypeId { get; set; }

        public virtual CompanyHasDepartmentType
            CompanyHasDepartmentType
        { get; set; }
    }
}