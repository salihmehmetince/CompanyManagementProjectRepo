using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLEmployee
    {
        DALEmployee dalEmployee =
            new DALEmployee();

        DALProfessionType dalProfessionType =
            new DALProfessionType();

        public List<Employee> EmployeeList()
        {
            return dalEmployee.EmployeeList();
        }

        public Employee EmployeeGetById(
            int employeeId)
        {
            if (!Validation.IntControl(
                employeeId,
                1,
                int.MaxValue))
                return null;

            return dalEmployee
                .EmployeeGetById(employeeId);
        }

        public bool EmployeeAdd(
            Employee employee)
        {
            if (employee == null)
                return false;

            if (!Validation.StringControl(
                employee.EmployeeName,
                1,
                30))
                return false;

            if (!Validation.StringControl(
                employee.EmployeeSurname,
                1,
                30))
                return false;

            if (!Validation.StringControl(
                employee.EmployeeIdentityNumber,
                10,
                15))
                return false;

            if (!Validation.BirthDateControl(
                employee.EmployeeBirthday,
                false))
                return false;

            if (!Validation.TelephoneControl(
                employee.EmployeeTelephoneNumber,
                false))
                return false;

            if (!Validation.StringControl(
                employee.EmployeeEmail,
                1,
                100))
                return false;

            if (!Validation.EmailControl(
                employee.EmployeeEmail,
                false))
                return false;

            if (!Validation.StringControl(
                employee.EmployeeAddress,
                0,
                250))
                return false;

            if (!Validation.DecimalControl(
                employee.EmployeeSalary,
                0,
                decimal.MaxValue))
                return false;

            if (!Validation.IntControl(
                employee.EmployeeYearsSpent,
                0,
                100))
                return false;

            if (!Validation.IntControl(
                employee.EmployeeProfessionTypeId,
                1,
                int.MaxValue))
                return false;

            var professionType =
                dalProfessionType
                    .ProfessionTypeGetById(
                        employee.EmployeeProfessionTypeId);

            if (professionType == null)
                return false;

            return dalEmployee
                .EmployeeAdd(employee);
        }

        public bool EmployeeUpdate(
            Employee employee)
        {
            if (employee == null)
                return false;

            if (!Validation.IntControl(
                employee.EmployeeId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.StringControl(
                employee.EmployeeName,
                1,
                30))
                return false;

            if (!Validation.StringControl(
                employee.EmployeeSurname,
                1,
                30))
                return false;

            if (!Validation.StringControl(
                employee.EmployeeIdentityNumber,
                10,
                15))
                return false;

            if (!Validation.BirthDateControl(
                employee.EmployeeBirthday,
                false))
                return false;

            if (!Validation.TelephoneControl(
                employee.EmployeeTelephoneNumber,
                false))
                return false;

            if (!Validation.StringControl(
                employee.EmployeeEmail,
                1,
                100))
                return false;

            if (!Validation.EmailControl(
                employee.EmployeeEmail,
                false))
                return false;

            if (!Validation.StringControl(
                employee.EmployeeAddress,
                0,
                250))
                return false;

            if (!Validation.DecimalControl(
                employee.EmployeeSalary,
                0,
                decimal.MaxValue))
                return false;

            if (!Validation.IntControl(
                employee.EmployeeYearsSpent,
                0,
                100))
                return false;

            if (!Validation.IntControl(
                employee.EmployeeProfessionTypeId,
                1,
                int.MaxValue))
                return false;

            var existingEmployee =
                dalEmployee
                    .EmployeeGetById(employee.EmployeeId);

            if (existingEmployee == null)
                return false;

            var professionType =
                dalProfessionType
                    .ProfessionTypeGetById(
                        employee.EmployeeProfessionTypeId);

            if (professionType == null)
                return false;

            return dalEmployee
                .EmployeeUpdate(employee);
        }

        public bool EmployeeDelete(
            int employeeId)
        {
            if (!Validation.IntControl(
                employeeId,
                1,
                int.MaxValue))
                return false;

            var existingEmployee =
                dalEmployee
                    .EmployeeGetById(employeeId);

            if (existingEmployee == null)
                return false;

            return dalEmployee
                .EmployeeDelete(employeeId);
        }
    }
}
