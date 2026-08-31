using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(250)]
        public string PasswordHash { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [Required]
        public int UserRoleId { get; set; }

        public virtual UserRole UserRole { get; set; }
    }
}
