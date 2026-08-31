using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CompanyManagement.DataAccess
{
    public class DALCompanyGivesBonusToEmployee
    {
        public List<CompanyGivesBonusToEmployee> CompanyGivesBonusToEmployeeList()
        {
            using (var context = new AppDbContext())
            {
                return context.CompanyGivesBonusToEmployees
                    .Include(x => x.Company)
                    .Include(x => x.Employee)
                    .ToList();
            }
        }

        public CompanyGivesBonusToEmployee CompanyGivesBonusToEmployeeGetById(
            int companyGivesBonusToEmployeeId)
        {
            using (var context = new AppDbContext())
            {
                return context.CompanyGivesBonusToEmployees
                    .Include(x => x.Company)
                    .Include(x => x.Employee)
                    .FirstOrDefault(x =>
                        x.CompanyGivesBonusToEmployeeId ==
                        companyGivesBonusToEmployeeId);
            }
        }

        public bool CompanyGivesBonusToEmployeeAdd(
            CompanyGivesBonusToEmployee companyGivesBonusToEmployee)
        {
            using (var context = new AppDbContext())
            {
                context.CompanyGivesBonusToEmployees
                    .Add(companyGivesBonusToEmployee);

                return context.SaveChanges() > 0;
            }
        }

        public bool CompanyGivesBonusToEmployeeUpdate(
            CompanyGivesBonusToEmployee companyGivesBonusToEmployee)
        {
            using (var context = new AppDbContext())
            {
                context.CompanyGivesBonusToEmployees
                    .Update(companyGivesBonusToEmployee);

                return context.SaveChanges() > 0;
            }
        }

        public bool CompanyGivesBonusToEmployeeDelete(
            int companyGivesBonusToEmployeeId)
        {
            using (var context = new AppDbContext())
            {
                var bonus = context.CompanyGivesBonusToEmployees
                    .FirstOrDefault(x =>
                        x.CompanyGivesBonusToEmployeeId ==
                        companyGivesBonusToEmployeeId);

                if (bonus == null)
                    return false;

                context.CompanyGivesBonusToEmployees.Remove(bonus);

                return context.SaveChanges() > 0;
            }
        }
    }
}