using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DAL
{
    public class DALCompanyHasCustomer
    {
        public List<CompanyHasCustomer> CompanyHasCustomerList()
        {
            using (var context = new AppDbContext())
            {
                return context.CompanyHasCustomers
                    .Include(x => x.Company)
                    .Include(x => x.Customer)
                    .ToList();
            }
        }

        public CompanyHasCustomer CompanyHasCustomerGetById(
            int companyHasCustomerId)
        {
            using (var context = new AppDbContext())
            {
                return context.CompanyHasCustomers
                    .Include(x => x.Company)
                    .Include(x => x.Customer)
                    .FirstOrDefault(x =>
                        x.CompanyHasCustomerId ==
                        companyHasCustomerId);
            }
        }

        public bool CompanyHasCustomerAdd(
            CompanyHasCustomer companyHasCustomer)
        {
            using (var context = new AppDbContext())
            {
                context.CompanyHasCustomers.Add(companyHasCustomer);

                return context.SaveChanges() > 0;
            }
        }

        public bool CompanyHasCustomerUpdate(
            CompanyHasCustomer companyHasCustomer)
        {
            using (var context = new AppDbContext())
            {
                var existingCompanyHasCustomer =
                    context.CompanyHasCustomers
                        .FirstOrDefault(x =>
                            x.CompanyHasCustomerId ==
                            companyHasCustomer.CompanyHasCustomerId);

                if (existingCompanyHasCustomer == null)
                    return false;

                existingCompanyHasCustomer.CompanyId =
                    companyHasCustomer.CompanyId;

                existingCompanyHasCustomer.CustomerId =
                    companyHasCustomer.CustomerId;

                return context.SaveChanges() > 0;
            }
        }

        public bool CompanyHasCustomerDelete(
            int companyHasCustomerId)
        {
            using (var context = new AppDbContext())
            {
                var companyHasCustomer =
                    context.CompanyHasCustomers
                        .FirstOrDefault(x =>
                            x.CompanyHasCustomerId ==
                            companyHasCustomerId);

                if (companyHasCustomer == null)
                    return false;

                context.CompanyHasCustomers.Remove(
                    companyHasCustomer);

                return context.SaveChanges() > 0;
            }
        }
    }
}
