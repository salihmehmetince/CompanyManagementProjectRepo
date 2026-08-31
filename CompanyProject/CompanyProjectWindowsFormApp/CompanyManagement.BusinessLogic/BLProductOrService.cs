using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLProductOrService
    {
        DALProductOrService dalProductOrService =
            new DALProductOrService();

        DALProductOrServiceType dalProductOrServiceType =
            new DALProductOrServiceType();

        public List<ProductOrService> ProductOrServiceList()
        {
            return dalProductOrService
                .ProductOrServiceList();
        }

        public ProductOrService ProductOrServiceGetById(
            int productOrServiceId)
        {
            if (!Validation.IntControl(
                productOrServiceId,
                1,
                int.MaxValue))
                return null;

            return dalProductOrService
                .ProductOrServiceGetById(productOrServiceId);
        }

        public bool ProductOrServiceAdd(
            ProductOrService productOrService)
        {
            if (productOrService == null)
                return false;

            if (!Validation.StringControl(
                productOrService.ProductOrServiceName,
                1,
                150))
                return false;

            if (!Validation.IntControl(
                productOrService.ProductOrServiceTypeId,
                1,
                int.MaxValue))
                return false;

            var productOrServiceType =
                dalProductOrServiceType
                    .ProductOrServiceTypeGetById(
                        productOrService.ProductOrServiceTypeId);

            if (productOrServiceType == null)
                return false;

            return dalProductOrService
                .ProductOrServiceAdd(productOrService);
        }

        public bool ProductOrServiceUpdate(
            ProductOrService productOrService)
        {
            if (productOrService == null)
                return false;

            if (!Validation.IntControl(
                productOrService.ProductOrServiceId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.StringControl(
                productOrService.ProductOrServiceName,
                1,
                150))
                return false;

            if (!Validation.IntControl(
                productOrService.ProductOrServiceTypeId,
                1,
                int.MaxValue))
                return false;

            var existingProductOrService =
                dalProductOrService
                    .ProductOrServiceGetById(
                        productOrService.ProductOrServiceId);

            if (existingProductOrService == null)
                return false;

            var productOrServiceType =
                dalProductOrServiceType
                    .ProductOrServiceTypeGetById(
                        productOrService.ProductOrServiceTypeId);

            if (productOrServiceType == null)
                return false;

            return dalProductOrService
                .ProductOrServiceUpdate(productOrService);
        }

        public bool ProductOrServiceDelete(
            int productOrServiceId)
        {
            if (!Validation.IntControl(
                productOrServiceId,
                1,
                int.MaxValue))
                return false;

            var existingProductOrService =
                dalProductOrService
                    .ProductOrServiceGetById(
                        productOrServiceId);

            if (existingProductOrService == null)
                return false;

            return dalProductOrService
                .ProductOrServiceDelete(productOrServiceId);
        }
    }
}
