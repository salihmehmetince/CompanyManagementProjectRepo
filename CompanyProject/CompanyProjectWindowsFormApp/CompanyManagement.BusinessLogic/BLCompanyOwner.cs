using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLCompanyOwner
    {
        DALCompanyOwner dalCompanyOwner =
            new DALCompanyOwner();

        public List<CompanyOwner> CompanyOwnerList()
        {
            return dalCompanyOwner.CompanyOwnerList();
        }

        public CompanyOwner CompanyOwnerGetById(
            int companyOwnerId)
        {
            if (!Validation.IntControl(
                companyOwnerId, 1, int.MaxValue))
                return null;

            return dalCompanyOwner
                .CompanyOwnerGetById(companyOwnerId);
        }

        public bool CompanyOwnerAdd(
            CompanyOwner companyOwner)
        {
            if (companyOwner == null)
                return false;

            if (!Validation.StringControl(
                companyOwner.CompanyOwnerIdentityNumber,
                11,
                15))
                return false;

            if (!Validation.StringControl(
                companyOwner.CompanyOwnerName,
                1,
                30))
                return false;

            if (!Validation.StringControl(
                companyOwner.CompanyOwnerSurname,
                1,
                30))
                return false;

            if (!Validation.BirthDateControl(
                companyOwner.CompanyOwnerBirthday,
                false))
                return false;

            if (!Validation.TelephoneControl(
                companyOwner.CompanyOwnerTelephoneNumber,
                false))
                return false;

            if (!Validation.EmailControl(
                companyOwner.CompanyOwnerEmail,
                true))
                return false;

            return dalCompanyOwner
                .CompanyOwnerAdd(companyOwner);
        }

        public bool CompanyOwnerUpdate(
            CompanyOwner companyOwner)
        {
            if (companyOwner == null)
                return false;

            if (!Validation.IntControl(
                companyOwner.CompanyOwnerId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.StringControl(
                companyOwner.CompanyOwnerIdentityNumber,
                11,
                15))
                return false;

            if (!Validation.StringControl(
                companyOwner.CompanyOwnerName,
                1,
                30))
                return false;

            if (!Validation.StringControl(
                companyOwner.CompanyOwnerSurname,
                1,
                30))
                return false;

            if (!Validation.BirthDateControl(
                companyOwner.CompanyOwnerBirthday,
                false))
                return false;

            if (!Validation.TelephoneControl(
                companyOwner.CompanyOwnerTelephoneNumber,
                false))
                return false;

            if (!Validation.EmailControl(
                companyOwner.CompanyOwnerEmail,
                true))
                return false;

            var existingCompanyOwner =
                dalCompanyOwner
                    .CompanyOwnerGetById(
                        companyOwner.CompanyOwnerId);

            if (existingCompanyOwner == null)
                return false;

            return dalCompanyOwner
                .CompanyOwnerUpdate(companyOwner);
        }

        public bool CompanyOwnerDelete(
            int companyOwnerId)
        {
            if (!Validation.IntControl(
                companyOwnerId, 1, int.MaxValue))
                return false;

            var existingCompanyOwner =
                dalCompanyOwner
                    .CompanyOwnerGetById(companyOwnerId);

            if (existingCompanyOwner == null)
                return false;

            return dalCompanyOwner
                .CompanyOwnerDelete(companyOwnerId);
        }
    }
}
