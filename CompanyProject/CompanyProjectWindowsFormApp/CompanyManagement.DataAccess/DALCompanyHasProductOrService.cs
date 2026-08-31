using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALCompanyHasProductOrService
    {
        public List<CompanyHasProductOrService> CompanyHasProductOrServiceList()
        {
            using (var context = new AppDbContext())
            {
                return context.CompanyHasProductOrServices
                    .Include(x => x.Company)
                    .Include(x => x.ProductOrService)
                    .Include(x => x.CustomerBuysCompanyHasProductOrServices)
                    .ToList();
            }
        }

        public CompanyHasProductOrService CompanyHasProductOrServiceGetById(
            int companyHasProductOrServiceId)
        {
            using (var context = new AppDbContext())
            {
                return context.CompanyHasProductOrServices
                    .Include(x => x.Company)
                    .Include(x => x.ProductOrService)
                    .Include(x => x.CustomerBuysCompanyHasProductOrServices)
                    .FirstOrDefault(x =>
                        x.CompanyHasProductOrServiceId ==
                        companyHasProductOrServiceId);
            }
        }

        public bool CompanyHasProductOrServiceAdd(
            CompanyHasProductOrService companyHasProductOrService)
        {
            using (var context = new AppDbContext())
            {
                context.CompanyHasProductOrServices
                    .Add(companyHasProductOrService);

                return context.SaveChanges() > 0;
            }
        }

        public bool CompanyHasProductOrServiceUpdate(
            CompanyHasProductOrService companyHasProductOrService)
        {
            using (var context = new AppDbContext())
            {
                context.CompanyHasProductOrServices
                    .Update(companyHasProductOrService);

                return context.SaveChanges() > 0;
            }
        }

        public bool CompanyHasProductOrServiceDelete(
            int companyHasProductOrServiceId)
        {
            using (var context = new AppDbContext())
            {
                var companyHasProductOrService =
                    context.CompanyHasProductOrServices
                        .FirstOrDefault(x =>
                            x.CompanyHasProductOrServiceId ==
                            companyHasProductOrServiceId);

                if (companyHasProductOrService == null)
                    return false;

                context.CompanyHasProductOrServices
                    .Remove(companyHasProductOrService);

                return context.SaveChanges() > 0;
            }
        }
    }
}