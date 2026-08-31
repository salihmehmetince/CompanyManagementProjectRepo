using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class MeetingHasEmployee
    {
        [Key]
        public int MeetingHasEmployeeId { get; set; }

        [Required]
        public int MeetingId { get; set; }

        public Meeting Meeting { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }
    }
}
