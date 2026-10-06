using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALCustomer
    {
        public List<Customer> CustomerList()
        {
            using (var context = new AppDbContext())
            {
                return context.Customers
                    .Include(x =>
                        x.CustomerBuysCompanyHasProductOrServices)
                    .Include(x =>
                        x.CompanyHasCustomers)
                        .ThenInclude(x =>
                            x.Company)
                    .ToList();
            }
        }
        public Customer CustomerGetById(int customerId)
        {
            using (var context = new AppDbContext())
            {
                return context.Customers
                    .Include(x =>
                        x.CustomerBuysCompanyHasProductOrServices)
                    .Include(x =>
                        x.CompanyHasCustomers)
                        .ThenInclude(x => x.Company)
                    .FirstOrDefault(x =>
                        x.CustomerId == customerId);
            }
        }

        public bool CustomerAdd(Customer customer)
        {
            using (var context = new AppDbContext())
            {
                context.Customers.Add(customer);

                return context.SaveChanges() > 0;
            }
        }

        public bool CustomerUpdate(Customer customer)
        {
            using (var context = new AppDbContext())
            {
                var existingCustomer =
                    context.Customers
                        .FirstOrDefault(x =>
                            x.CustomerId == customer.CustomerId);

                if (existingCustomer == null)
                    return false;

                existingCustomer.CustomerName =
                    customer.CustomerName;

                existingCustomer.CustomerSurname =
                    customer.CustomerSurname;

                existingCustomer.CustomerTelephoneNumber =
                    customer.CustomerTelephoneNumber;

                existingCustomer.CustomerEmail =
                    customer.CustomerEmail;

                return context.SaveChanges() > 0;
            }
        }

        public bool CustomerDelete(int customerId)
        {
            using (var context = new AppDbContext())
            {
                var customer = context.Customers
                    .FirstOrDefault(x =>
                        x.CustomerId == customerId);

                if (customer == null)
                    return false;

                context.Customers.Remove(customer);

                return context.SaveChanges() > 0;
            }
        }
    }
}