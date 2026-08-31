using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLCompanyGivesBonusToEmployee
    {
        DALCompanyGivesBonusToEmployee dalCompanyGivesBonusToEmployee =
            new DALCompanyGivesBonusToEmployee();

        DALCompany dalCompany = new DALCompany();
        DALEmployee dalEmployee = new DALEmployee();

        public List<CompanyGivesBonusToEmployee>
            CompanyGivesBonusToEmployeeList()
        {
            return dalCompanyGivesBonusToEmployee
                .CompanyGivesBonusToEmployeeList();
        }

        public CompanyGivesBonusToEmployee
            CompanyGivesBonusToEmployeeGetById(
                int companyGivesBonusToEmployeeId)
        {
            if (!Validation.IntControl(
                companyGivesBonusToEmployeeId, 1, int.MaxValue))
                return null;

            return dalCompanyGivesBonusToEmployee
                .CompanyGivesBonusToEmployeeGetById(
                    companyGivesBonusToEmployeeId);
        }

        public bool CompanyGivesBonusToEmployeeAdd(
            CompanyGivesBonusToEmployee companyGivesBonusToEmployee)
        {
            if (companyGivesBonusToEmployee == null)
                return false;

            if (!Validation.IntControl(
                companyGivesBonusToEmployee.CompanyId, 1, int.MaxValue))
                return false;

            if (!Validation.IntControl(
                companyGivesBonusToEmployee.EmployeeId, 1, int.MaxValue))
                return false;

            if (!Validation.DateTimeControl(
                companyGivesBonusToEmployee.CompanyGivesBonusToEmployeeDate,
                false))
                return false;

            if (!Validation.DecimalControl(
                companyGivesBonusToEmployee.CompanyGivesBonusToEmployeeQuantity,
                0,
                decimal.MaxValue))
                return false;

            var company = dalCompany
                .CompanyGetById(companyGivesBonusToEmployee.CompanyId);

            if (company == null)
                return false;

            var employee = dalEmployee
                .EmployeeGetById(companyGivesBonusToEmployee.EmployeeId);

            if (employee == null)
                return false;

            return dalCompanyGivesBonusToEmployee
                .CompanyGivesBonusToEmployeeAdd(
                    companyGivesBonusToEmployee);
        }

        public bool CompanyGivesBonusToEmployeeUpdate(
            CompanyGivesBonusToEmployee companyGivesBonusToEmployee)
        {
            if (companyGivesBonusToEmployee == null)
                return false;

            if (!Validation.IntControl(
                companyGivesBonusToEmployee.CompanyGivesBonusToEmployeeId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                companyGivesBonusToEmployee.CompanyId, 1, int.MaxValue))
                return false;

            if (!Validation.IntControl(
                companyGivesBonusToEmployee.EmployeeId, 1, int.MaxValue))
                return false;

            if (!Validation.DateTimeControl(
                companyGivesBonusToEmployee.CompanyGivesBonusToEmployeeDate,
                false))
                return false;

            if (!Validation.DecimalControl(
                companyGivesBonusToEmployee.CompanyGivesBonusToEmployeeQuantity,
                0,
                decimal.MaxValue))
                return false;

            var existingCompanyGivesBonus =
                dalCompanyGivesBonusToEmployee
                    .CompanyGivesBonusToEmployeeGetById(
                        companyGivesBonusToEmployee
                            .CompanyGivesBonusToEmployeeId);

            if (existingCompanyGivesBonus == null)
                return false;

            var company = dalCompany
                .CompanyGetById(companyGivesBonusToEmployee.CompanyId);

            if (company == null)
                return false;

            var employee = dalEmployee
                .EmployeeGetById(companyGivesBonusToEmployee.EmployeeId);

            if (employee == null)
                return false;

            return dalCompanyGivesBonusToEmployee
                .CompanyGivesBonusToEmployeeUpdate(
                    companyGivesBonusToEmployee);
        }

        public bool CompanyGivesBonusToEmployeeDelete(
            int companyGivesBonusToEmployeeId)
        {
            if (!Validation.IntControl(
                companyGivesBonusToEmployeeId, 1, int.MaxValue))
                return false;

            var existingCompanyGivesBonus =
                dalCompanyGivesBonusToEmployee
                    .CompanyGivesBonusToEmployeeGetById(
                        companyGivesBonusToEmployeeId);

            if (existingCompanyGivesBonus == null)
                return false;

            return dalCompanyGivesBonusToEmployee
                .CompanyGivesBonusToEmployeeDelete(
                    companyGivesBonusToEmployeeId);
        }
    }
}