using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class DepartmentType
    {
        [Key]
        public int DepartmentTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string DepartmentName { get; set; }

        public virtual ICollection<CompanyHasDepartmentType>
            CompanyHasDepartmentTypes
        { get; set; }
    }
}