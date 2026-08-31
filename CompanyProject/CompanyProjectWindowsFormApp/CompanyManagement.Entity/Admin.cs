using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Admin
{
    [Key]
    public int AdminId { get; set; }

    [Required]
    [StringLength(30)]
    public string AdminName { get; set; }

    [Required]
    [StringLength(30)]
    public string AdminSurname { get; set; }

    [Required]
    [StringLength(15)]
    public string AdminTelephoneNumber { get; set; }

    [StringLength(100)]
    public string AdminEmail { get; set; }

    [Required]
    public int UserId { get; set; }

    public virtual User User { get; set; }
}
