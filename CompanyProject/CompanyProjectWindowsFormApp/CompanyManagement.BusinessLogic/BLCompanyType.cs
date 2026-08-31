using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLCompanyType
    {
        DALCompanyType dalCompanyType =
            new DALCompanyType();

        public List<CompanyType> CompanyTypeList()
        {
            return dalCompanyType.CompanyTypeList();
        }

        public CompanyType CompanyTypeGetById(
            int companyTypeId)
        {
            if (!Validation.IntControl(
                companyTypeId, 1, int.MaxValue))
                return null;

            return dalCompanyType
                .CompanyTypeGetById(companyTypeId);
        }

        public bool CompanyTypeAdd(
            CompanyType companyType)
        {
            if (companyType == null)
                return false;

            if (!Validation.StringControl(
                companyType.CompanyTypeName,
                1,
                30))
                return false;

            return dalCompanyType
                .CompanyTypeAdd(companyType);
        }

        public bool CompanyTypeUpdate(
            CompanyType companyType)
        {
            if (companyType == null)
                return false;

            if (!Validation.IntControl(
                companyType.CompanyTypeId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.StringControl(
                companyType.CompanyTypeName,
                1,
                30))
                return false;

            var existingCompanyType =
                dalCompanyType
                    .CompanyTypeGetById(
                        companyType.CompanyTypeId);

            if (existingCompanyType == null)
                return false;

            return dalCompanyType
                .CompanyTypeUpdate(companyType);
        }

        public bool CompanyTypeDelete(
            int companyTypeId)
        {
            if (!Validation.IntControl(
                companyTypeId, 1, int.MaxValue))
                return false;

            var existingCompanyType =
                dalCompanyType
                    .CompanyTypeGetById(companyTypeId);

            if (existingCompanyType == null)
                return false;

            return dalCompanyType
                .CompanyTypeDelete(companyTypeId);
        }
    }
}
