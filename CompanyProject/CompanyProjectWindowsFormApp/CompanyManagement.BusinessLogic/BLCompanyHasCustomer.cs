using CompanyManagement.DAL;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BLL
{
    public class BLCompanyHasCustomer
    {
        private DALCompanyHasCustomer dalCompanyHasCustomer =
            new DALCompanyHasCustomer();

        public List<CompanyHasCustomer>
            CompanyHasCustomerList()
        {
            return dalCompanyHasCustomer
                .CompanyHasCustomerList();
        }

        public CompanyHasCustomer
            CompanyHasCustomerGetById(
                int companyHasCustomerId)
        {
            return dalCompanyHasCustomer
                .CompanyHasCustomerGetById(
                    companyHasCustomerId);
        }

        public bool CompanyHasCustomerAdd(
            CompanyHasCustomer companyHasCustomer)
        {
            if (companyHasCustomer.CompanyId <= 0 ||
                companyHasCustomer.CustomerId <= 0)
                return false;

            return dalCompanyHasCustomer
                .CompanyHasCustomerAdd(
                    companyHasCustomer);
        }

        public bool CompanyHasCustomerUpdate(
            CompanyHasCustomer companyHasCustomer)
        {
            if (companyHasCustomer.CompanyHasCustomerId <= 0 ||
                companyHasCustomer.CompanyId <= 0 ||
                companyHasCustomer.CustomerId <= 0)
                return false;

            return dalCompanyHasCustomer
                .CompanyHasCustomerUpdate(
                    companyHasCustomer);
        }

        public bool CompanyHasCustomerDelete(
            int companyHasCustomerId)
        {
            if (companyHasCustomerId <= 0)
                return false;

            return dalCompanyHasCustomer
                .CompanyHasCustomerDelete(
                    companyHasCustomerId);
        }
    }
}
