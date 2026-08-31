using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class CompanyHasDepartmentType
    {
        [Key]
        public int CompanyHasDepartmentTypeId { get; set; }

        [Required]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }

        [Required]
        public int DepartmentTypeId { get; set; }

        public virtual DepartmentType DepartmentType { get; set; }

        public virtual ICollection<EmployeeHasCompanyHasDepartmentType>
        EmployeeHasCompanyHasDepartmentTypes
            { get; set; }
    }
}