using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALCustomerBuysCompanyHasProductOrService
    {
        public List<CustomerBuysCompanyHasProductOrService>
            CustomerBuysCompanyHasProductOrServiceList()
        {
            using (var context = new AppDbContext())
            {
                return context.CustomerBuysCompanyHasProductOrServices
                    .Include(x => x.Customer)
                    .Include(x => x.CompanyHasProductOrService)
                    .Include(x => x.PaymentType)
                    .ToList();
            }
        }

        public CustomerBuysCompanyHasProductOrService
            CustomerBuysCompanyHasProductOrServiceGetById(
                int customerBuysCompanyHasProductOrServiceId)
        {
            using (var context = new AppDbContext())
            {
                return context.CustomerBuysCompanyHasProductOrServices
                    .Include(x => x.Customer)
                    .Include(x => x.CompanyHasProductOrService)
                    .Include(x => x.PaymentType)
                    .FirstOrDefault(x =>
                        x.CustomerBuysCompanyHasProductOrServiceId ==
                        customerBuysCompanyHasProductOrServiceId);
            }
        }

        public bool CustomerBuysCompanyHasProductOrServiceAdd(
            CustomerBuysCompanyHasProductOrService
                customerBuysCompanyHasProductOrService)
        {
            using (var context = new AppDbContext())
            {
                context.CustomerBuysCompanyHasProductOrServices
                    .Add(customerBuysCompanyHasProductOrService);

                return context.SaveChanges() > 0;
            }
        }

        public bool CustomerBuysCompanyHasProductOrServiceUpdate(
            CustomerBuysCompanyHasProductOrService
                customerBuysCompanyHasProductOrService)
        {
            using (var context = new AppDbContext())
            {
                context.CustomerBuysCompanyHasProductOrServices
                    .Update(customerBuysCompanyHasProductOrService);

                return context.SaveChanges() > 0;
            }
        }

        public bool CustomerBuysCompanyHasProductOrServiceDelete(
            int customerBuysCompanyHasProductOrServiceId)
        {
            using (var context = new AppDbContext())
            {
                var customerBuysCompanyHasProductOrService =
                    context.CustomerBuysCompanyHasProductOrServices
                        .FirstOrDefault(x =>
                            x.CustomerBuysCompanyHasProductOrServiceId ==
                            customerBuysCompanyHasProductOrServiceId);

                if (customerBuysCompanyHasProductOrService == null)
                    return false;

                context.CustomerBuysCompanyHasProductOrServices
                    .Remove(customerBuysCompanyHasProductOrService);

                return context.SaveChanges() > 0;
            }
        }
    }
}