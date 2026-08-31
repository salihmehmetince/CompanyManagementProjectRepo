using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLProductOrServiceType
    {
        DALProductOrServiceType dalProductOrServiceType =
            new DALProductOrServiceType();

        public List<ProductOrServiceType>
            ProductOrServiceTypeList()
        {
            return dalProductOrServiceType
                .ProductOrServiceTypeList();
        }

        public ProductOrServiceType
            ProductOrServiceTypeGetById(
                int productOrServiceTypeId)
        {
            if (!Validation.IntControl(
                productOrServiceTypeId,
                1,
                int.MaxValue))
                return null;

            return dalProductOrServiceType
                .ProductOrServiceTypeGetById(
                    productOrServiceTypeId);
        }

        public bool ProductOrServiceTypeAdd(
            ProductOrServiceType productOrServiceType)
        {
            if (productOrServiceType == null)
                return false;

            if (!Validation.StringControl(
                productOrServiceType.ProductOrServiceTypeName,
                1,
                50))
                return false;

            return dalProductOrServiceType
                .ProductOrServiceTypeAdd(
                    productOrServiceType);
        }

        public bool ProductOrServiceTypeUpdate(
            ProductOrServiceType productOrServiceType)
        {
            if (productOrServiceType == null)
                return false;

            if (!Validation.IntControl(
                productOrServiceType.ProductOrServiceTypeId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.StringControl(
                productOrServiceType.ProductOrServiceTypeName,
                1,
                50))
                return false;

            var existingProductOrServiceType =
                dalProductOrServiceType
                    .ProductOrServiceTypeGetById(
                        productOrServiceType
                            .ProductOrServiceTypeId);

            if (existingProductOrServiceType == null)
                return false;

            return dalProductOrServiceType
                .ProductOrServiceTypeUpdate(
                    productOrServiceType);
        }

        public bool ProductOrServiceTypeDelete(
            int productOrServiceTypeId)
        {
            if (!Validation.IntControl(
                productOrServiceTypeId,
                1,
                int.MaxValue))
                return false;

            var existingProductOrServiceType =
                dalProductOrServiceType
                    .ProductOrServiceTypeGetById(
                        productOrServiceTypeId);

            if (existingProductOrServiceType == null)
                return false;

            return dalProductOrServiceType
                .ProductOrServiceTypeDelete(
                    productOrServiceTypeId);
        }
    }
}
