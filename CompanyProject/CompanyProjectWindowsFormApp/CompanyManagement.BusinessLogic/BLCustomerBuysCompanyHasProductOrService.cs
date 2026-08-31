using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLCustomerBuysCompanyHasProductOrService
    {
        DALCustomerBuysCompanyHasProductOrService
            dalCustomerBuysCompanyHasProductOrService =
            new DALCustomerBuysCompanyHasProductOrService();

        DALCustomer dalCustomer =
            new DALCustomer();

        DALCompanyHasProductOrService
            dalCompanyHasProductOrService =
            new DALCompanyHasProductOrService();

        DALPaymentType dalPaymentType =
            new DALPaymentType();

        public List<CustomerBuysCompanyHasProductOrService>
            CustomerBuysCompanyHasProductOrServiceList()
        {
            return dalCustomerBuysCompanyHasProductOrService
                .CustomerBuysCompanyHasProductOrServiceList();
        }

        public CustomerBuysCompanyHasProductOrService
            CustomerBuysCompanyHasProductOrServiceGetById(
                int customerBuysCompanyHasProductOrServiceId)
        {
            if (!Validation.IntControl(
                customerBuysCompanyHasProductOrServiceId,
                1,
                int.MaxValue))
                return null;

            return dalCustomerBuysCompanyHasProductOrService
                .CustomerBuysCompanyHasProductOrServiceGetById(
                    customerBuysCompanyHasProductOrServiceId);
        }

        public bool CustomerBuysCompanyHasProductOrServiceAdd(
            CustomerBuysCompanyHasProductOrService
                customerBuysCompanyHasProductOrService)
        {
            if (customerBuysCompanyHasProductOrService == null)
                return false;

            if (!Validation.IntControl(
                customerBuysCompanyHasProductOrService.CustomerId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                customerBuysCompanyHasProductOrService
                    .CompanyHasProductOrServiceId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                customerBuysCompanyHasProductOrService.PaymentTypeId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.DecimalControl(
                customerBuysCompanyHasProductOrService
                    .CustomerBuysCompanyHasProductOrServiceQuantity,
                0,
                decimal.MaxValue))
                return false;

            if (!Validation.DateTimeControl(
                customerBuysCompanyHasProductOrService
                    .CustomerBuysCompanyHasProductOrServiceDate,
                false))
                return false;

            var customer = dalCustomer
                .CustomerGetById(
                    customerBuysCompanyHasProductOrService.CustomerId);

            if (customer == null)
                return false;

            var companyHasProductOrService =
                dalCompanyHasProductOrService
                    .CompanyHasProductOrServiceGetById(
                        customerBuysCompanyHasProductOrService
                            .CompanyHasProductOrServiceId);

            if (companyHasProductOrService == null)
                return false;

            var paymentType = dalPaymentType
                .PaymentTypeGetById(
                    customerBuysCompanyHasProductOrService.PaymentTypeId);

            if (paymentType == null)
                return false;

            return dalCustomerBuysCompanyHasProductOrService
                .CustomerBuysCompanyHasProductOrServiceAdd(
                    customerBuysCompanyHasProductOrService);
        }

        public bool CustomerBuysCompanyHasProductOrServiceUpdate(
            CustomerBuysCompanyHasProductOrService
                customerBuysCompanyHasProductOrService)
        {
            if (customerBuysCompanyHasProductOrService == null)
                return false;

            if (!Validation.IntControl(
                customerBuysCompanyHasProductOrService
                    .CustomerBuysCompanyHasProductOrServiceId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                customerBuysCompanyHasProductOrService.CustomerId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                customerBuysCompanyHasProductOrService
                    .CompanyHasProductOrServiceId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                customerBuysCompanyHasProductOrService.PaymentTypeId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.DecimalControl(
                customerBuysCompanyHasProductOrService
                    .CustomerBuysCompanyHasProductOrServiceQuantity,
                0,
                decimal.MaxValue))
                return false;

            if (!Validation.DateTimeControl(
                customerBuysCompanyHasProductOrService
                    .CustomerBuysCompanyHasProductOrServiceDate,
                false))
                return false;

            var existingCustomerBuys =
                dalCustomerBuysCompanyHasProductOrService
                    .CustomerBuysCompanyHasProductOrServiceGetById(
                        customerBuysCompanyHasProductOrService
                            .CustomerBuysCompanyHasProductOrServiceId);

            if (existingCustomerBuys == null)
                return false;

            var customer = dalCustomer
                .CustomerGetById(
                    customerBuysCompanyHasProductOrService.CustomerId);

            if (customer == null)
                return false;

            var companyHasProductOrService =
                dalCompanyHasProductOrService
                    .CompanyHasProductOrServiceGetById(
                        customerBuysCompanyHasProductOrService
                            .CompanyHasProductOrServiceId);

            if (companyHasProductOrService == null)
                return false;

            var paymentType = dalPaymentType
                .PaymentTypeGetById(
                    customerBuysCompanyHasProductOrService.PaymentTypeId);

            if (paymentType == null)
                return false;

            return dalCustomerBuysCompanyHasProductOrService
                .CustomerBuysCompanyHasProductOrServiceUpdate(
                    customerBuysCompanyHasProductOrService);
        }

        public bool CustomerBuysCompanyHasProductOrServiceDelete(
            int customerBuysCompanyHasProductOrServiceId)
        {
            if (!Validation.IntControl(
                customerBuysCompanyHasProductOrServiceId,
                1,
                int.MaxValue))
                return false;

            var existingCustomerBuys =
                dalCustomerBuysCompanyHasProductOrService
                    .CustomerBuysCompanyHasProductOrServiceGetById(
                        customerBuysCompanyHasProductOrServiceId);

            if (existingCustomerBuys == null)
                return false;

            return dalCustomerBuysCompanyHasProductOrService
                .CustomerBuysCompanyHasProductOrServiceDelete(
                    customerBuysCompanyHasProductOrServiceId);
        }
    }
}
