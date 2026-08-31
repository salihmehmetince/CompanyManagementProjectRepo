using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }

        [Required]
        [StringLength(30)]
        public string UserRoleName { get; set; }

        public virtual ICollection<User>
            Users
        { get; set; }
    }
}
