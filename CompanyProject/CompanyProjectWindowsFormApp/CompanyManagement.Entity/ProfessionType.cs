using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class ProfessionType
    {
        [Key]
        public int ProfessionTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProfessionName { get; set; }

        public virtual ICollection<Employee>
        Employees
            { get; set; }
    }
}
