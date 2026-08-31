using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLCompanyHasDepartmentType
    {
        DALCompanyHasDepartmentType dalCompanyHasDepartmentType =
            new DALCompanyHasDepartmentType();

        DALCompany dalCompany = new DALCompany();
        DALDepartmentType dalDepartmentType = new DALDepartmentType();

        public List<CompanyHasDepartmentType>
            CompanyHasDepartmentTypeList()
        {
            return dalCompanyHasDepartmentType
                .CompanyHasDepartmentTypeList();
        }

        public CompanyHasDepartmentType
            CompanyHasDepartmentTypeGetById(
                int companyHasDepartmentTypeId)
        {
            if (!Validation.IntControl(
                companyHasDepartmentTypeId, 1, int.MaxValue))
                return null;

            return dalCompanyHasDepartmentType
                .CompanyHasDepartmentTypeGetById(
                    companyHasDepartmentTypeId);
        }

        public bool CompanyHasDepartmentTypeAdd(
            CompanyHasDepartmentType companyHasDepartmentType)
        {
            if (companyHasDepartmentType == null)
                return false;

            if (!Validation.IntControl(
                companyHasDepartmentType.CompanyId, 1, int.MaxValue))
                return false;

            if (!Validation.IntControl(
                companyHasDepartmentType.DepartmentTypeId, 1, int.MaxValue))
                return false;

            var company = dalCompany
                .CompanyGetById(companyHasDepartmentType.CompanyId);

            if (company == null)
                return false;

            var departmentType = dalDepartmentType
                .DepartmentTypeGetById(
                    companyHasDepartmentType.DepartmentTypeId);

            if (departmentType == null)
                return false;

            return dalCompanyHasDepartmentType
                .CompanyHasDepartmentTypeAdd(
                    companyHasDepartmentType);
        }

        public bool CompanyHasDepartmentTypeUpdate(
            CompanyHasDepartmentType companyHasDepartmentType)
        {
            if (companyHasDepartmentType == null)
                return false;

            if (!Validation.IntControl(
                companyHasDepartmentType.CompanyHasDepartmentTypeId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                companyHasDepartmentType.CompanyId, 1, int.MaxValue))
                return false;

            if (!Validation.IntControl(
                companyHasDepartmentType.DepartmentTypeId, 1, int.MaxValue))
                return false;

            var existingCompanyHasDepartmentType =
                dalCompanyHasDepartmentType
                    .CompanyHasDepartmentTypeGetById(
                        companyHasDepartmentType
                            .CompanyHasDepartmentTypeId);

            if (existingCompanyHasDepartmentType == null)
                return false;

            var company = dalCompany
                .CompanyGetById(companyHasDepartmentType.CompanyId);

            if (company == null)
                return false;

            var departmentType = dalDepartmentType
                .DepartmentTypeGetById(
                    companyHasDepartmentType.DepartmentTypeId);

            if (departmentType == null)
                return false;

            return dalCompanyHasDepartmentType
                .CompanyHasDepartmentTypeUpdate(
                    companyHasDepartmentType);
        }

        public bool CompanyHasDepartmentTypeDelete(
            int companyHasDepartmentTypeId)
        {
            if (!Validation.IntControl(
                companyHasDepartmentTypeId, 1, int.MaxValue))
                return false;

            var existingCompanyHasDepartmentType =
                dalCompanyHasDepartmentType
                    .CompanyHasDepartmentTypeGetById(
                        companyHasDepartmentTypeId);

            if (existingCompanyHasDepartmentType == null)
                return false;

            return dalCompanyHasDepartmentType
                .CompanyHasDepartmentTypeDelete(
                    companyHasDepartmentTypeId);
        }
    }
}
