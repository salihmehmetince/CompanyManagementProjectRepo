using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class Meeting
    {
        [Key]
        public int MeetingId { get; set; }

        [Required]
        [StringLength(150)]
        public string MeetingPlot { get; set; }

        [StringLength(1000)]
        public string MeetingDetail { get; set; }

        [Required]
        [StringLength(200)]
        public string MeetingPlace { get; set; }

        [Required]
        public DateTime MeetingDate { get; set; }

        public virtual ICollection<MeetingHasCompanyOwner>
            MeetingHasCompanyOwners
        { get; set; }

        public virtual ICollection<MeetingHasEmployee>
            MeetingHasEmployees
        { get; set; }
    }
}
