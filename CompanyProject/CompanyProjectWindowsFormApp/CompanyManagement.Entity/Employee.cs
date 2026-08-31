using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.Entity
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(30)]
        public string EmployeeName { get; set; }

        [Required]
        [StringLength(30)]
        public string EmployeeSurname { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 10)]
        public string EmployeeIdentityNumber { get; set; }

        [Required]
        public DateTime EmployeeBirthday { get; set; }

        [Required]
        [StringLength(15)]
        public string EmployeeTelephoneNumber { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string EmployeeEmail { get; set; }

        [StringLength(250)]
        public string EmployeeAddress { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal EmployeeSalary { get; set; }

        [Required]
        [Range(0, 100)]
        public int EmployeeYearsSpent { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public int EmployeeProfessionTypeId { get; set; }

        public virtual ProfessionType ProfessionType { get; set; }

        public virtual ICollection<EmployeeHasCompanyHasDepartmentType>
            EmployeeHasCompanies
        { get; set; }

        public virtual ICollection<CompanyGivesBonusToEmployee>
            CompanyGivesBonusToEmployees
        { get; set; }

        public virtual ICollection<MeetingHasEmployee>
            MeetingHasEmployees
        { get; set; }

        public virtual ICollection<TaskHasEmployee>
            TaskHasEmployees
        { get; set; }
    }
}
