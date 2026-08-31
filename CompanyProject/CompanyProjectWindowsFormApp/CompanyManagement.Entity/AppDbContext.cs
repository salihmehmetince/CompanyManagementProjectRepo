using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CompanyManagement.Entity
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString =
                    ConfigurationManager
                        .ConnectionStrings["CompanyManagementConnection"]
                        .ConnectionString;

                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<CompanyOwner> CompanyOwners { get; set; }
        public DbSet<CompanyOwnerHasCompany> CompanyOwnerHasCompanies { get; set; }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyType> CompanyTypes { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeHasCompanyHasDepartmentType> EmployeeHasCompanyHasDepartmentTypes { get; set; }
        public DbSet<MeetingHasEmployee> MeetingHasEmployees { get; set; }
        public DbSet<TaskHasEmployee> TaskHasEmployees { get; set; }

        public DbSet<DepartmentType> DepartmentTypes { get; set; }
        public DbSet<CompanyHasDepartmentType> CompanyHasDepartmentTypes { get; set; }

        public DbSet<ProfessionType> ProfessionTypes { get; set; }

        public DbSet<Meeting> Meetings { get; set; }
        public DbSet<MeetingHasCompanyOwner> MeetingHasCompanyOwners { get; set; }

        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskHasCompanyOwner> TaskHasCompanyOwners { get; set; }

        public DbSet<ProductOrServiceType> ProductOrServiceTypes { get; set; }
        public DbSet<ProductOrService> ProductsOrServices { get; set; }
        public DbSet<CompanyHasProductOrService> CompanyHasProductOrServices { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }

        public DbSet<CustomerBuysCompanyHasProductOrService>
            CustomerBuysCompanyHasProductOrServices
        { get; set; }

        public DbSet<CompanyGivesBonusToEmployee>
            CompanyGivesBonusToEmployees
        { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Admin 1 - 1 User
            modelBuilder.Entity<Admin>()
                .HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<Admin>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // CompanyOwner 1 - 1 User
            modelBuilder.Entity<CompanyOwner>()
                .HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<CompanyOwner>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee 1 - 1 User
            modelBuilder.Entity<Employee>()
                .HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<Employee>(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // UserRole 1 - N User
            modelBuilder.Entity<User>()
                .HasOne(x => x.UserRole)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.UserRoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // CompanyType 1 - N Company
            modelBuilder.Entity<Company>()
                .HasOne(x => x.CompanyType)
                .WithMany(x => x.Companies)
                .HasForeignKey(x => x.CompanyTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Company 1 - N CompanyHasProductOrService
            modelBuilder.Entity<CompanyHasProductOrService>()
                .HasOne(x => x.Company)
                .WithMany(x => x.CompanyHasProductOrServices)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Company 1 - N CompanyOwnerHasCompany
            modelBuilder.Entity<CompanyOwnerHasCompany>()
                .HasOne(x => x.Company)
                .WithMany(x => x.CompanyOwnerHasCompanies)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Company 1 - N CompanyHasDepartmentType
            modelBuilder.Entity<CompanyHasDepartmentType>()
                .HasOne(x => x.Company)
                .WithMany(x => x.CompanyHasDepartmentTypes)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Company 1 - N CompanyGivesBonusToEmployee
            modelBuilder.Entity<CompanyGivesBonusToEmployee>()
                .HasOne(x => x.Company)
                .WithMany(x => x.CompanyGivesBonusToEmployees)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Company 1 - N CompanyGivesBonusToEmployee
            modelBuilder.Entity<CompanyGivesBonusToEmployee>()
                .HasOne(x => x.Company)
                .WithMany(x => x.CompanyGivesBonusToEmployees)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee 1 - N CompanyGivesBonusToEmployee
            modelBuilder.Entity<CompanyGivesBonusToEmployee>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.CompanyGivesBonusToEmployees)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);
            // CompanyHasDepartmentType N - 1 DepartmentType
            modelBuilder.Entity<CompanyHasDepartmentType>()
                .HasOne(x => x.DepartmentType)
                .WithMany(x => x.CompanyHasDepartmentTypes)
                .HasForeignKey(x => x.DepartmentTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // CompanyHasDepartmentType 1 - N EmployeeHasCompanyHasDepartmentType
            modelBuilder.Entity<EmployeeHasCompanyHasDepartmentType>()
                .HasOne(x => x.CompanyHasDepartmentType)
                .WithMany(x => x.EmployeeHasCompanyHasDepartmentTypes)
                .HasForeignKey(x => x.CompanyHasDepartmentTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Company 1 - N CompanyHasProductOrService
            modelBuilder.Entity<CompanyHasProductOrService>()
                .HasOne(x => x.Company)
                .WithMany(x => x.CompanyHasProductOrServices)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // ProductOrService 1 - N CompanyHasProductOrService
            modelBuilder.Entity<CompanyHasProductOrService>()
                .HasOne(x => x.ProductOrService)
                .WithMany(x => x.CompanyHasProductOrServices)
                .HasForeignKey(x => x.ProductOrServiceId)
                .OnDelete(DeleteBehavior.Restrict);
            // CompanyOwner 1 - N CompanyOwnerHasCompany
            modelBuilder.Entity<CompanyOwnerHasCompany>()
                .HasOne(x => x.CompanyOwner)
                .WithMany(x => x.CompanyOwnerHasCompanies)
                .HasForeignKey(x => x.CompanyOwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            // CompanyOwner 1 - N MeetingHasCompanyOwner
            modelBuilder.Entity<MeetingHasCompanyOwner>()
                .HasOne(x => x.CompanyOwner)
                .WithMany(x => x.MeetingHasCompanyOwners)
                .HasForeignKey(x => x.CompanyOwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            // CompanyOwner 1 - N TaskHasCompanyOwner
            modelBuilder.Entity<TaskHasCompanyOwner>()
                .HasOne(x => x.CompanyOwner)
                .WithMany(x => x.TaskHasCompanyOwners)
                .HasForeignKey(x => x.CompanyOwnerId)
                .OnDelete(DeleteBehavior.Restrict);
            // CompanyOwner 1 - N CompanyOwnerHasCompany
            modelBuilder.Entity<CompanyOwnerHasCompany>()
                .HasOne(x => x.CompanyOwner)
                .WithMany(x => x.CompanyOwnerHasCompanies)
                .HasForeignKey(x => x.CompanyOwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Company 1 - N CompanyOwnerHasCompany
            modelBuilder.Entity<CompanyOwnerHasCompany>()
                .HasOne(x => x.Company)
                .WithMany(x => x.CompanyOwnerHasCompanies)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            // CompanyType 1 - N Company
            modelBuilder.Entity<Company>()
                .HasOne(x => x.CompanyType)
                .WithMany(x => x.Companies)
                .HasForeignKey(x => x.CompanyTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Customer 1 - N CustomerBuysCompanyHasProductOrService
            modelBuilder.Entity<CustomerBuysCompanyHasProductOrService>()
                .HasOne(x => x.Customer)
                .WithMany(x => x.CustomerBuysCompanyHasProductOrServices)
                .HasForeignKey(x => x.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // CompanyHasProductOrService 1 - N CustomerBuysCompanyHasProductOrService
            modelBuilder.Entity<CustomerBuysCompanyHasProductOrService>()
                .HasOne(x => x.CompanyHasProductOrService)
                .WithMany(x => x.CustomerBuysCompanyHasProductOrServices)
                .HasForeignKey(x => x.CompanyHasProductOrServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // PaymentType 1 - N CustomerBuysCompanyHasProductOrService
            modelBuilder.Entity<CustomerBuysCompanyHasProductOrService>()
                .HasOne(x => x.PaymentType)
                .WithMany(x => x.CustomerBuysCompanyHasProductOrServices)
                .HasForeignKey(x => x.PaymentTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // DepartmentType 1 - N CompanyHasDepartmentType
            modelBuilder.Entity<CompanyHasDepartmentType>()
                .HasOne(x => x.DepartmentType)
                .WithMany(x => x.CompanyHasDepartmentTypes)
                .HasForeignKey(x => x.DepartmentTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            // ProfessionType 1 - N Employee
            modelBuilder.Entity<Employee>()
                .HasOne(x => x.ProfessionType)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.EmployeeProfessionTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee 1 - N EmployeeHasCompanyHasDepartmentType
            modelBuilder.Entity<EmployeeHasCompanyHasDepartmentType>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.EmployeeHasCompanies)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee 1 - N CompanyGivesBonusToEmployee
            modelBuilder.Entity<CompanyGivesBonusToEmployee>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.CompanyGivesBonusToEmployees)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee 1 - N MeetingHasEmployee
            modelBuilder.Entity<MeetingHasEmployee>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.MeetingHasEmployees)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee 1 - N TaskHasEmployee
            modelBuilder.Entity<TaskHasEmployee>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.TaskHasEmployees)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee 1 - N EmployeeHasCompanyHasDepartmentType
            modelBuilder.Entity<EmployeeHasCompanyHasDepartmentType>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.EmployeeHasCompanies)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // CompanyHasDepartmentType 1 - N EmployeeHasCompanyHasDepartmentType
            modelBuilder.Entity<EmployeeHasCompanyHasDepartmentType>()
                .HasOne(x => x.CompanyHasDepartmentType)
                .WithMany(x => x.EmployeeHasCompanyHasDepartmentTypes)
                .HasForeignKey(x => x.CompanyHasDepartmentTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Meeting 1 - N MeetingHasCompanyOwner
            modelBuilder.Entity<MeetingHasCompanyOwner>()
                .HasOne(x => x.Meeting)
                .WithMany(x => x.MeetingHasCompanyOwners)
                .HasForeignKey(x => x.MeetingId)
                .OnDelete(DeleteBehavior.Restrict);

            // Meeting 1 - N MeetingHasEmployee
            modelBuilder.Entity<MeetingHasEmployee>()
                .HasOne(x => x.Meeting)
                .WithMany(x => x.MeetingHasEmployees)
                .HasForeignKey(x => x.MeetingId)
                .OnDelete(DeleteBehavior.Restrict);
            // Meeting 1 - N MeetingHasCompanyOwner
            modelBuilder.Entity<MeetingHasCompanyOwner>()
                .HasOne(x => x.Meeting)
                .WithMany(x => x.MeetingHasCompanyOwners)
                .HasForeignKey(x => x.MeetingId)
                .OnDelete(DeleteBehavior.Restrict);

            // CompanyOwner 1 - N MeetingHasCompanyOwner
            modelBuilder.Entity<MeetingHasCompanyOwner>()
                .HasOne(x => x.CompanyOwner)
                .WithMany(x => x.MeetingHasCompanyOwners)
                .HasForeignKey(x => x.CompanyOwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Meeting 1 - N MeetingHasEmployee
            modelBuilder.Entity<MeetingHasEmployee>()
                .HasOne(x => x.Meeting)
                .WithMany(x => x.MeetingHasEmployees)
                .HasForeignKey(x => x.MeetingId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee 1 - N MeetingHasEmployee
            modelBuilder.Entity<MeetingHasEmployee>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.MeetingHasEmployees)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // PaymentType 1 - N CustomerBuysCompanyHasProductOrService
            modelBuilder.Entity<CustomerBuysCompanyHasProductOrService>()
                .HasOne(x => x.PaymentType)
                .WithMany(x => x.CustomerBuysCompanyHasProductOrServices)
                .HasForeignKey(x => x.PaymentTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // ProductOrServiceType 1 - N ProductOrService
            modelBuilder.Entity<ProductOrService>()
                .HasOne(x => x.ProductOrServiceType)
                .WithMany(x => x.ProductsOrServices)
                .HasForeignKey(x => x.ProductOrServiceTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            // ProductOrService 1 - N CompanyHasProductOrService
            modelBuilder.Entity<CompanyHasProductOrService>()
                .HasOne(x => x.ProductOrService)
                .WithMany(x => x.CompanyHasProductOrServices)
                .HasForeignKey(x => x.ProductOrServiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // ProfessionType 1 - N Employee
            modelBuilder.Entity<Employee>()
                .HasOne(x => x.ProfessionType)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.EmployeeProfessionTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            // Task 1 - N TaskHasCompanyOwner
            modelBuilder.Entity<TaskHasCompanyOwner>()
                .HasOne(x => x.Task)
                .WithMany(x => x.TaskHasCompanyOwners)
                .HasForeignKey(x => x.TaskId)
                .OnDelete(DeleteBehavior.Restrict);

            // Task 1 - N TaskHasEmployee
            modelBuilder.Entity<TaskHasEmployee>()
                .HasOne(x => x.Task)
                .WithMany(x => x.TaskHasEmployees)
                .HasForeignKey(x => x.TaskId)
                .OnDelete(DeleteBehavior.Restrict);

            // Task 1 - N TaskHasCompanyOwner
            modelBuilder.Entity<TaskHasCompanyOwner>()
                .HasOne(x => x.Task)
                .WithMany(x => x.TaskHasCompanyOwners)
                .HasForeignKey(x => x.TaskId)
                .OnDelete(DeleteBehavior.Restrict);

            // CompanyOwner 1 - N TaskHasCompanyOwner
            modelBuilder.Entity<TaskHasCompanyOwner>()
                .HasOne(x => x.CompanyOwner)
                .WithMany(x => x.TaskHasCompanyOwners)
                .HasForeignKey(x => x.CompanyOwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Task 1 - N TaskHasEmployee
            modelBuilder.Entity<TaskHasEmployee>()
                .HasOne(x => x.Task)
                .WithMany(x => x.TaskHasEmployees)
                .HasForeignKey(x => x.TaskId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee 1 - N TaskHasEmployee
            modelBuilder.Entity<TaskHasEmployee>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.TaskHasEmployees)
                .HasForeignKey(x => x.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // User Roles seed
            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    UserRoleId = 1,
                    UserRoleName = "Admin"
                },
                new UserRole
                {
                    UserRoleId = 2,
                    UserRoleName = "CompanyOwner"
                },
                new UserRole
                {
                    UserRoleId = 3,
                    UserRoleName = "Employee"
                }
            );
        }
    }
}