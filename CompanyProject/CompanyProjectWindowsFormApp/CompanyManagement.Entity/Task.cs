using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        [StringLength(150)]
        public string TaskName { get; set; }

        [StringLength(1000)]
        public string TaskDetails { get; set; }

        [Required]
        public DateTime TaskBeginningDate { get; set; }

        [Required]
        public bool IsCompleted { get; set; }

        [Range(0, 10000)]
        public int DaysPassedToComplete { get; set; }

        public DateTime? TaskFinishDate { get; set; }

        public virtual ICollection<TaskHasCompanyOwner>
            TaskHasCompanyOwners
        { get; set; }

        public virtual ICollection<TaskHasEmployee>
            TaskHasEmployees
        { get; set; }
    }
}