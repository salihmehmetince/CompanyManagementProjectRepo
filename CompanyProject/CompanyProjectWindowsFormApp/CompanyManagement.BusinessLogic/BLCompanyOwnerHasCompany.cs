using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLCompanyOwnerHasCompany
    {
        DALCompanyOwnerHasCompany dalCompanyOwnerHasCompany =
            new DALCompanyOwnerHasCompany();

        DALCompanyOwner dalCompanyOwner =
            new DALCompanyOwner();

        DALCompany dalCompany =
            new DALCompany();

        public List<CompanyOwnerHasCompany>
            CompanyOwnerHasCompanyList()
        {
            return dalCompanyOwnerHasCompany
                .CompanyOwnerHasCompanyList();
        }

        public CompanyOwnerHasCompany
            CompanyOwnerHasCompanyGetById(
                int companyOwnerHasCompanyId)
        {
            if (!Validation.IntControl(
                companyOwnerHasCompanyId, 1, int.MaxValue))
                return null;

            return dalCompanyOwnerHasCompany
                .CompanyOwnerHasCompanyGetById(
                    companyOwnerHasCompanyId);
        }

        public bool CompanyOwnerHasCompanyAdd(
            CompanyOwnerHasCompany companyOwnerHasCompany)
        {
            if (companyOwnerHasCompany == null)
                return false;

            if (!Validation.IntControl(
                companyOwnerHasCompany.CompanyOwnerId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                companyOwnerHasCompany.CompanyId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                companyOwnerHasCompany.CompanyOwnerPercent,
                0,
                100))
                return false;

            var companyOwner = dalCompanyOwner
                .CompanyOwnerGetById(
                    companyOwnerHasCompany.CompanyOwnerId);

            if (companyOwner == null)
                return false;

            var company = dalCompany
                .CompanyGetById(
                    companyOwnerHasCompany.CompanyId);

            if (company == null)
                return false;

            return dalCompanyOwnerHasCompany
                .CompanyOwnerHasCompanyAdd(
                    companyOwnerHasCompany);
        }

        public bool CompanyOwnerHasCompanyUpdate(
            CompanyOwnerHasCompany companyOwnerHasCompany)
        {
            if (companyOwnerHasCompany == null)
                return false;

            if (!Validation.IntControl(
                companyOwnerHasCompany.CompanyOwnerHasCompanyId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                companyOwnerHasCompany.CompanyOwnerId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                companyOwnerHasCompany.CompanyId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                companyOwnerHasCompany.CompanyOwnerPercent,
                0,
                100))
                return false;

            var existingCompanyOwnerHasCompany =
                dalCompanyOwnerHasCompany
                    .CompanyOwnerHasCompanyGetById(
                        companyOwnerHasCompany
                            .CompanyOwnerHasCompanyId);

            if (existingCompanyOwnerHasCompany == null)
                return false;

            var companyOwner = dalCompanyOwner
                .CompanyOwnerGetById(
                    companyOwnerHasCompany.CompanyOwnerId);

            if (companyOwner == null)
                return false;

            var company = dalCompany
                .CompanyGetById(
                    companyOwnerHasCompany.CompanyId);

            if (company == null)
                return false;

            return dalCompanyOwnerHasCompany
                .CompanyOwnerHasCompanyUpdate(
                    companyOwnerHasCompany);
        }

        public bool CompanyOwnerHasCompanyDelete(
            int companyOwnerHasCompanyId)
        {
            if (!Validation.IntControl(
                companyOwnerHasCompanyId,
                1,
                int.MaxValue))
                return false;

            var existingCompanyOwnerHasCompany =
                dalCompanyOwnerHasCompany
                    .CompanyOwnerHasCompanyGetById(
                        companyOwnerHasCompanyId);

            if (existingCompanyOwnerHasCompany == null)
                return false;

            return dalCompanyOwnerHasCompany
                .CompanyOwnerHasCompanyDelete(
                    companyOwnerHasCompanyId);
        }
    }
}