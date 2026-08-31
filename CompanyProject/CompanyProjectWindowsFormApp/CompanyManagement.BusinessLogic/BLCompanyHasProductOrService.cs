using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLCompanyHasProductOrService
    {
        DALCompanyHasProductOrService dalCompanyHasProductOrService =
            new DALCompanyHasProductOrService();

        DALCompany dalCompany = new DALCompany();
        DALProductOrService dalProductOrService =
            new DALProductOrService();

        public List<CompanyHasProductOrService>
            CompanyHasProductOrServiceList()
        {
            return dalCompanyHasProductOrService
                .CompanyHasProductOrServiceList();
        }

        public CompanyHasProductOrService
            CompanyHasProductOrServiceGetById(
                int companyHasProductOrServiceId)
        {
            if (!Validation.IntControl(
                companyHasProductOrServiceId, 1, int.MaxValue))
                return null;

            return dalCompanyHasProductOrService
                .CompanyHasProductOrServiceGetById(
                    companyHasProductOrServiceId);
        }

        public bool CompanyHasProductOrServiceAdd(
            CompanyHasProductOrService companyHasProductOrService)
        {
            if (companyHasProductOrService == null)
                return false;

            if (!Validation.IntControl(
                companyHasProductOrService.CompanyId, 1, int.MaxValue))
                return false;

            if (!Validation.IntControl(
                companyHasProductOrService.ProductOrServiceId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.DecimalControl(
                companyHasProductOrService
                    .CompanyHasProductOrServiceQuantity,
                0,
                decimal.MaxValue))
                return false;

            if (!Validation.DecimalControl(
                companyHasProductOrService
                    .CompanyHasProductOrServicePrice,
                0,
                decimal.MaxValue))
                return false;

            var company = dalCompany
                .CompanyGetById(companyHasProductOrService.CompanyId);

            if (company == null)
                return false;

            var productOrService = dalProductOrService
                .ProductOrServiceGetById(
                    companyHasProductOrService.ProductOrServiceId);

            if (productOrService == null)
                return false;

            return dalCompanyHasProductOrService
                .CompanyHasProductOrServiceAdd(
                    companyHasProductOrService);
        }

        public bool CompanyHasProductOrServiceUpdate(
            CompanyHasProductOrService companyHasProductOrService)
        {
            if (companyHasProductOrService == null)
                return false;

            if (!Validation.IntControl(
                companyHasProductOrService
                    .CompanyHasProductOrServiceId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                companyHasProductOrService.CompanyId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                companyHasProductOrService.ProductOrServiceId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.DecimalControl(
                companyHasProductOrService
                    .CompanyHasProductOrServiceQuantity,
                0,
                decimal.MaxValue))
                return false;

            if (!Validation.DecimalControl(
                companyHasProductOrService
                    .CompanyHasProductOrServicePrice,
                0,
                decimal.MaxValue))
                return false;

            var existingCompanyHasProductOrService =
                dalCompanyHasProductOrService
                    .CompanyHasProductOrServiceGetById(
                        companyHasProductOrService
                            .CompanyHasProductOrServiceId);

            if (existingCompanyHasProductOrService == null)
                return false;

            var company = dalCompany
                .CompanyGetById(companyHasProductOrService.CompanyId);

            if (company == null)
                return false;

            var productOrService = dalProductOrService
                .ProductOrServiceGetById(
                    companyHasProductOrService.ProductOrServiceId);

            if (productOrService == null)
                return false;

            return dalCompanyHasProductOrService
                .CompanyHasProductOrServiceUpdate(
                    companyHasProductOrService);
        }

        public bool CompanyHasProductOrServiceDelete(
            int companyHasProductOrServiceId)
        {
            if (!Validation.IntControl(
                companyHasProductOrServiceId, 1, int.MaxValue))
                return false;

            var existingCompanyHasProductOrService =
                dalCompanyHasProductOrService
                    .CompanyHasProductOrServiceGetById(
                        companyHasProductOrServiceId);

            if (existingCompanyHasProductOrService == null)
                return false;

            return dalCompanyHasProductOrService
                .CompanyHasProductOrServiceDelete(
                    companyHasProductOrServiceId);
        }
    }
}
