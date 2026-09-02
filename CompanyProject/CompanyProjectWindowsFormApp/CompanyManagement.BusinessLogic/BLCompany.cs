using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLCompany
    {
        DALCompany dalCompany = new DALCompany();
        DALCompanyType dalCompanyType = new DALCompanyType();

        public List<Company> CompanyList()
        {
            return dalCompany.CompanyList();
        }

        public Company CompanyGetById(int companyId)
        {
            if (!Validation.IntControl(companyId, 1, int.MaxValue))
                return null;

            return dalCompany.CompanyGetById(companyId);
        }

        public bool CompanyAdd(Company company)
        {
            if (company == null)
                return false;

            if (!Validation.StringControl(
                company.CompanyName, 1, 30))
                return false;

            if (!Validation.StringControl(
                company.CompanyAddress, 1, 250))
                return false;

            if (!Validation.TelephoneControl(
                company.CompanyTelephoneNumber, true))
                return false;

            if (!Validation.EmailControl(
                company.CompanyEmail, true))
                return false;

            if (!Validation.IntControl(
                company.CompanyTypeId, 1, int.MaxValue))
                return false;

            var companyType = dalCompanyType
                .CompanyTypeGetById(company.CompanyTypeId);

            if (companyType == null)
                return false;

            return dalCompany.CompanyAdd(company);
        }

        public bool CompanyUpdate(Company company)
        {
            if (company == null)
                return false;

            if (!Validation.IntControl(
                company.CompanyId, 1, int.MaxValue))
                return false;

            if (!Validation.StringControl(
                company.CompanyName, 1, 30))
                return false;

            if (!Validation.StringControl(
                company.CompanyAddress, 1, 250))
                return false;

            if (!Validation.TelephoneControl(
                company.CompanyTelephoneNumber, true))
                return false;

            if (!Validation.EmailControl(
                company.CompanyEmail, true))
                return false;

            if (!Validation.IntControl(
                company.CompanyTypeId, 1, int.MaxValue))
                return false;

            var existingCompany = dalCompany
                .CompanyGetById(company.CompanyId);

            if (existingCompany == null)
                return false;

            var companyType = dalCompanyType
                .CompanyTypeGetById(company.CompanyTypeId);

            if (companyType == null)
                return false;

            return dalCompany.CompanyUpdate(company);
        }

        public bool CompanyDelete(int companyId)
        {
            if (!Validation.IntControl(
                companyId, 1, int.MaxValue))
                return false;

            var existingCompany = dalCompany
                .CompanyGetById(companyId);

            if (existingCompany == null)
                return false;

            return dalCompany.CompanyDelete(companyId);
        }
    }
}