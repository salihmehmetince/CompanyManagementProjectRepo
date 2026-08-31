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
                    .Include(x => x.CustomerBuysCompanyHasProductOrServices)
                    .ToList();
            }
        }

        public Customer CustomerGetById(int customerId)
        {
            using (var context = new AppDbContext())
            {
                return context.Customers
                    .Include(x => x.CustomerBuysCompanyHasProductOrServices)
                    .FirstOrDefault(x => x.CustomerId == customerId);
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
                context.Customers.Update(customer);

                return context.SaveChanges() > 0;
            }
        }

        public bool CustomerDelete(int customerId)
        {
            using (var context = new AppDbContext())
            {
                var customer = context.Customers
                    .FirstOrDefault(x => x.CustomerId == customerId);

                if (customer == null)
                    return false;

                context.Customers.Remove(customer);

                return context.SaveChanges() > 0;
            }
        }
    }
}