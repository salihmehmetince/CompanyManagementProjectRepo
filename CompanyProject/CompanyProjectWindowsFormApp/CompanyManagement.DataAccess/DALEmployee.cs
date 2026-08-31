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
                    .FirstOrDefault(x => x.EmployeeId == employeeId);
            }
        }

        public bool EmployeeAdd(Employee employee)
        {
            using (var context = new AppDbContext())
            {
                context.Employees.Add(employee);

                return context.SaveChanges() > 0;
            }
        }

        public bool EmployeeUpdate(Employee employee)
        {
            using (var context = new AppDbContext())
            {
                context.Employees.Update(employee);

                return context.SaveChanges() > 0;
            }
        }

        public bool EmployeeDelete(int employeeId)
        {
            using (var context = new AppDbContext())
            {
                var employee = context.Employees
                    .FirstOrDefault(x => x.EmployeeId == employeeId);

                if (employee == null)
                    return false;

                context.Employees.Remove(employee);

                return context.SaveChanges() > 0;
            }
        }
    }
}