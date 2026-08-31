using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class TaskHasEmployee
    {
        [Key]
        public int TaskHasEmployeeId { get; set; }

        [Required]
        public int TaskId { get; set; }

        [ForeignKey(nameof(TaskId))]
        public Task Task { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
