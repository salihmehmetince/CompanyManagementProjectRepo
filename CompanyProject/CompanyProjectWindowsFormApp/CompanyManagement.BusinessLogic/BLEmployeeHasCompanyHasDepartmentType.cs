using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLEmployeeHasCompanyHasDepartmentType
    {
        DALEmployeeHasCompanyHasDepartmentType
            dalEmployeeHasCompanyHasDepartmentType =
            new DALEmployeeHasCompanyHasDepartmentType();

        DALEmployee dalEmployee =
            new DALEmployee();

        DALCompanyHasDepartmentType
            dalCompanyHasDepartmentType =
            new DALCompanyHasDepartmentType();

        public List<EmployeeHasCompanyHasDepartmentType>
            EmployeeHasCompanyHasDepartmentTypeList()
        {
            return dalEmployeeHasCompanyHasDepartmentType
                .EmployeeHasCompanyHasDepartmentTypeList();
        }

        public EmployeeHasCompanyHasDepartmentType
            EmployeeHasCompanyHasDepartmentTypeGetById(
                int employeeHasCompanyId)
        {
            if (!Validation.IntControl(
                employeeHasCompanyId,
                1,
                int.MaxValue))
                return null;

            return dalEmployeeHasCompanyHasDepartmentType
                .EmployeeHasCompanyHasDepartmentTypeGetById(
                    employeeHasCompanyId);
        }

        public bool EmployeeHasCompanyHasDepartmentTypeAdd(
            EmployeeHasCompanyHasDepartmentType
                employeeHasCompanyHasDepartmentType)
        {
            if (employeeHasCompanyHasDepartmentType == null)
                return false;

            if (!Validation.IntControl(
                employeeHasCompanyHasDepartmentType.EmployeeId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                employeeHasCompanyHasDepartmentType
                    .CompanyHasDepartmentTypeId,
                1,
                int.MaxValue))
                return false;

            var employee =
                dalEmployee.EmployeeGetById(
                    employeeHasCompanyHasDepartmentType.EmployeeId);

            if (employee == null)
                return false;

            var companyHasDepartmentType =
                dalCompanyHasDepartmentType
                    .CompanyHasDepartmentTypeGetById(
                        employeeHasCompanyHasDepartmentType
                            .CompanyHasDepartmentTypeId);

            if (companyHasDepartmentType == null)
                return false;

            return dalEmployeeHasCompanyHasDepartmentType
                .EmployeeHasCompanyHasDepartmentTypeAdd(
                    employeeHasCompanyHasDepartmentType);
        }

        public bool EmployeeHasCompanyHasDepartmentTypeUpdate(
            EmployeeHasCompanyHasDepartmentType
                employeeHasCompanyHasDepartmentType)
        {
            if (employeeHasCompanyHasDepartmentType == null)
                return false;

            if (!Validation.IntControl(
                employeeHasCompanyHasDepartmentType.EmployeeHasCompanyId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                employeeHasCompanyHasDepartmentType.EmployeeId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                employeeHasCompanyHasDepartmentType
                    .CompanyHasDepartmentTypeId,
                1,
                int.MaxValue))
                return false;

            var existingEmployeeHasCompany =
                dalEmployeeHasCompanyHasDepartmentType
                    .EmployeeHasCompanyHasDepartmentTypeGetById(
                        employeeHasCompanyHasDepartmentType
                            .EmployeeHasCompanyId);

            if (existingEmployeeHasCompany == null)
                return false;

            var employee =
                dalEmployee.EmployeeGetById(
                    employeeHasCompanyHasDepartmentType.EmployeeId);

            if (employee == null)
                return false;

            var companyHasDepartmentType =
                dalCompanyHasDepartmentType
                    .CompanyHasDepartmentTypeGetById(
                        employeeHasCompanyHasDepartmentType
                            .CompanyHasDepartmentTypeId);

            if (companyHasDepartmentType == null)
                return false;

            return dalEmployeeHasCompanyHasDepartmentType
                .EmployeeHasCompanyHasDepartmentTypeUpdate(
                    employeeHasCompanyHasDepartmentType);
        }

        public bool EmployeeHasCompanyHasDepartmentTypeDelete(
            int employeeHasCompanyId)
        {
            if (!Validation.IntControl(
                employeeHasCompanyId,
                1,
                int.MaxValue))
                return false;

            var existingEmployeeHasCompany =
                dalEmployeeHasCompanyHasDepartmentType
                    .EmployeeHasCompanyHasDepartmentTypeGetById(
                        employeeHasCompanyId);

            if (existingEmployeeHasCompany == null)
                return false;

            return dalEmployeeHasCompanyHasDepartmentType
                .EmployeeHasCompanyHasDepartmentTypeDelete(
                    employeeHasCompanyId);
        }
    }
}