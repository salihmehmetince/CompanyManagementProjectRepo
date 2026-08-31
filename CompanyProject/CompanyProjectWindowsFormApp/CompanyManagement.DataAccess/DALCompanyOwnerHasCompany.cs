using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALCompanyOwnerHasCompany
    {
        public List<CompanyOwnerHasCompany> CompanyOwnerHasCompanyList()
        {
            using (var context = new AppDbContext())
            {
                return context.CompanyOwnerHasCompanies
                    .Include(x => x.CompanyOwner)
                    .Include(x => x.Company)
                    .ToList();
            }
        }

        public CompanyOwnerHasCompany CompanyOwnerHasCompanyGetById(
            int companyOwnerHasCompanyId)
        {
            using (var context = new AppDbContext())
            {
                return context.CompanyOwnerHasCompanies
                    .Include(x => x.CompanyOwner)
                    .Include(x => x.Company)
                    .FirstOrDefault(x =>
                        x.CompanyOwnerHasCompanyId ==
                        companyOwnerHasCompanyId);
            }
        }

        public bool CompanyOwnerHasCompanyAdd(
            CompanyOwnerHasCompany companyOwnerHasCompany)
        {
            using (var context = new AppDbContext())
            {
                context.CompanyOwnerHasCompanies
                    .Add(companyOwnerHasCompany);

                return context.SaveChanges() > 0;
            }
        }

        public bool CompanyOwnerHasCompanyUpdate(
            CompanyOwnerHasCompany companyOwnerHasCompany)
        {
            using (var context = new AppDbContext())
            {
                context.CompanyOwnerHasCompanies
                    .Update(companyOwnerHasCompany);

                return context.SaveChanges() > 0;
            }
        }

        public bool CompanyOwnerHasCompanyDelete(
            int companyOwnerHasCompanyId)
        {
            using (var context = new AppDbContext())
            {
                var companyOwnerHasCompany =
                    context.CompanyOwnerHasCompanies
                        .FirstOrDefault(x =>
                            x.CompanyOwnerHasCompanyId ==
                            companyOwnerHasCompanyId);

                if (companyOwnerHasCompany == null)
                    return false;

                context.CompanyOwnerHasCompanies
                    .Remove(companyOwnerHasCompany);

                return context.SaveChanges() > 0;
            }
        }
    }
}