using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALCompany
    {
        public List<Company> CompanyList()
        {
            using (var context = new AppDbContext())
            {
                return context.Companies
                    .Include(x => x.CompanyType)
                    .Include(x => x.CompanyHasProductOrServices)
                    .Include(x => x.CompanyOwnerHasCompanies)
                    .Include(x => x.CompanyHasDepartmentTypes)
                    .Include(x => x.CompanyGivesBonusToEmployees)
                    .Include(x => x.EmployeeHasCompanyHasDepartmentTypes)
                    .ToList();
            }
        }

        public Company CompanyGetById(int companyId)
        {
            using (var context = new AppDbContext())
            {
                return context.Companies
                    .Include(x => x.CompanyType)
                    .Include(x => x.CompanyHasProductOrServices)
                    .Include(x => x.CompanyOwnerHasCompanies)
                    .Include(x => x.CompanyHasDepartmentTypes)
                    .Include(x => x.CompanyGivesBonusToEmployees)
                    .Include(x => x.EmployeeHasCompanyHasDepartmentTypes)
                    .FirstOrDefault(x => x.CompanyId == companyId);
            }
        }

        public bool CompanyAdd(Company company)
        {
            using (var context = new AppDbContext())
            {
                context.Companies.Add(company);

                return context.SaveChanges() > 0;
            }
        }

        public bool CompanyUpdate(Company company)
        {
            using (var context = new AppDbContext())
            {
                var existingCompany = context.Companies
                    .FirstOrDefault(x => x.CompanyId == company.CompanyId);

                if (existingCompany == null)
                    return false;

                existingCompany.CompanyName = company.CompanyName;
                existingCompany.CompanyAddress = company.CompanyAddress;
                existingCompany.CompanyTelephoneNumber = company.CompanyTelephoneNumber;
                existingCompany.CompanyEmail = company.CompanyEmail;
                existingCompany.CompanyTypeId = company.CompanyTypeId;

                return context.SaveChanges() > 0;
            }
        }

        public bool CompanyDelete(int companyId)
        {
            using (var context = new AppDbContext())
            {
                var company = context.Companies
                    .FirstOrDefault(x => x.CompanyId == companyId);

                if (company == null)
                    return false;

                context.Companies.Remove(company);

                return context.SaveChanges() > 0;
            }
        }
    }
}