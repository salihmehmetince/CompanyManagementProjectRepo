using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALEmployee
    {
        public List<Employee> EmployeeList()
        {
            using (var context = new AppDbContext())
            {
                return context.Employees
                    .Include(x => x.ProfessionType)
                    .Include(x => x.EmployeeHasCompanies)
                    .Include(x => x.CompanyGivesBonusToEmployees)
                    .Include(x => x.MeetingHasEmployees)
                    .Include(x => x.TaskHasEmployees)
                    .ToList();
            }
        }

        public Employee EmployeeGetById(int employeeId)
        {
            using (var context = new AppDbContext())
            {
                return context.Employees
                    .Include(x => x.ProfessionType)
                    .Include(x => x.EmployeeHasCompanies)
                    .Include(x => x.CompanyGivesBonusToEmployees)
                    .Include(x => x.MeetingHasEmployees)
                    .Include(x => x.TaskHasEmployees)
                    .Include(x => x.User)
                    .FirstOrDefault(x => x.EmployeeId == employeeId);
            }
        }

        public bool EmployeeAdd(Employee employee, User user)
        {
            using (var context = new AppDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Users.Add(user);
                    context.SaveChanges();

                    employee.UserId = user.UserId;

                    context.Employees.Add(employee);
                    context.SaveChanges();

                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();

                    return false;
                }
            }
        }
        public bool EmployeeUpdate(Employee employee, User user)
        {
            using (var context = new AppDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var existingEmployee = context.Employees
                        .FirstOrDefault(x =>
                            x.EmployeeId == employee.EmployeeId);

                    if (existingEmployee == null)
                        return false;

                    var existingUser = context.Users
                        .FirstOrDefault(x =>
                            x.UserId == employee.UserId);

                    if (existingUser == null)
                        return false;

                    existingEmployee.EmployeeName =
                        employee.EmployeeName;

                    existingEmployee.EmployeeSurname =
                        employee.EmployeeSurname;

                    existingEmployee.EmployeeIdentityNumber =
                        employee.EmployeeIdentityNumber;

                    existingEmployee.EmployeeBirthday =
                        employee.EmployeeBirthday;

                    existingEmployee.EmployeeTelephoneNumber =
                        employee.EmployeeTelephoneNumber;

                    existingEmployee.EmployeeEmail =
                        employee.EmployeeEmail;

                    existingEmployee.EmployeeAddress =
                        employee.EmployeeAddress;

                    existingEmployee.EmployeeSalary =
                        employee.EmployeeSalary;

                    existingEmployee.EmployeeHireDate =
                        employee.EmployeeHireDate;

                    existingEmployee.EmployeeProfessionTypeId =
                        employee.EmployeeProfessionTypeId;

                    existingUser.Username =
                        user.Username;

                    if (!string.IsNullOrWhiteSpace(user.PasswordHash))
                    {
                        existingUser.PasswordHash =
                            user.PasswordHash;
                    }

                    existingUser.IsActive =
                        user.IsActive;

                    context.SaveChanges();

                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();

                    return false;
                }
            }
        }
        public bool EmployeeDelete(int employeeId)
        {
            using (var context = new AppDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var employee = context.Employees
                        .FirstOrDefault(x => x.EmployeeId == employeeId);

                    if (employee == null)
                        return false;

                    var user = context.Users
                        .FirstOrDefault(x => x.UserId == employee.UserId);

                    context.Employees.Remove(employee);

                    if (user != null)
                        context.Users.Remove(user);

                    context.SaveChanges();

                    transaction.Commit();

                    return true;
                }
                catch
                {
                    transaction.Rollback();

                    return false;
                }
            }
        }
    }
}