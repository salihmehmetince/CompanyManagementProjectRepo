using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLCustomer
    {
        DALCustomer dalCustomer =
            new DALCustomer();

        public List<Customer> CustomerList()
        {
            return dalCustomer.CustomerList();
        }

        public Customer CustomerGetById(
            int customerId)
        {
            if (!Validation.IntControl(
                customerId, 1, int.MaxValue))
                return null;

            return dalCustomer
                .CustomerGetById(customerId);
        }

        public bool CustomerAdd(
            Customer customer)
        {
            if (customer == null)
                return false;

            if (!Validation.StringControl(
                customer.CustomerName,
                1,
                30))
                return false;

            if (!Validation.StringControl(
                customer.CustomerSurname,
                1,
                30))
                return false;

            if (!Validation.TelephoneControl(
                customer.CustomerTelephoneNumber,
                false))
                return false;

            if (!Validation.EmailControl(
                customer.CustomerEmail,
                true))
                return false;

            return dalCustomer
                .CustomerAdd(customer);
        }

        public bool CustomerUpdate(
            Customer customer)
        {
            if (customer == null)
                return false;

            if (!Validation.IntControl(
                customer.CustomerId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.StringControl(
                customer.CustomerName,
                1,
                30))
                return false;

            if (!Validation.StringControl(
                customer.CustomerSurname,
                1,
                30))
                return false;

            if (!Validation.TelephoneControl(
                customer.CustomerTelephoneNumber,
                false))
                return false;

            if (!Validation.EmailControl(
                customer.CustomerEmail,
                true))
                return false;

            var existingCustomer =
                dalCustomer
                    .CustomerGetById(customer.CustomerId);

            if (existingCustomer == null)
                return false;

            return dalCustomer
                .CustomerUpdate(customer);
        }

        public bool CustomerDelete(
            int customerId)
        {
            if (!Validation.IntControl(
                customerId, 1, int.MaxValue))
                return false;

            var existingCustomer =
                dalCustomer
                    .CustomerGetById(customerId);

            if (existingCustomer == null)
                return false;

            return dalCustomer
                .CustomerDelete(customerId);
        }
    }
}
