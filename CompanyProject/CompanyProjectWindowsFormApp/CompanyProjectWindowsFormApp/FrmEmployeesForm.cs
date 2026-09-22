using CompanyManagement.BusinessLogic;
using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyProjectWindowsFormApp
{
    public partial class FrmEmployeesForm : Form
    {

        private BLEmployee blEmployee = new BLEmployee();
        private BLEmployeeHasCompanyHasDepartmentType blEmployeeHasCompanyHasDepartmentType=new BLEmployeeHasCompanyHasDepartmentType();
        private BLCompany blCompany = new BLCompany();
        private BLDepartmentType blDepartmentType = new BLDepartmentType();
        private BLUser blUser = new BLUser();
        
        public FrmEmployeesForm()
        {
            InitializeComponent();
            SetButtonsBorder();
            setIcon();
            ListEmployees();
        }

        private void SetButtonsBorder()
        {
            BtnAdd.FlatAppearance.BorderSize = 0;
            BtnEdit.FlatAppearance.BorderSize = 0;
            BtnDelete.FlatAppearance.BorderSize = 0;
        }

        private void setIcon()
        {
            this.Icon = Properties.Resources.icon_company;
        }

        private (
            Employee Employee,
            EmployeeHasCompanyHasDepartmentType
                EmployeeHasCompanyHasDepartmentType)
            GetSelectedEmployee()
        {
            if (DgvEmployees.CurrentRow == null)
                return (null, null);

            int employeeId =
                Convert.ToInt32(
                    DgvEmployees.CurrentRow
                        .Cells["EmployeeId"]
                        .Value);

            Employee employee =
                blEmployee.EmployeeGetById(employeeId);

            EmployeeHasCompanyHasDepartmentType
                employeeHasCompanyHasDepartmentType =
                    blEmployeeHasCompanyHasDepartmentType
                        .EmployeeHasCompanyHasDepartmentTypeList()
                        .FirstOrDefault(x =>
                            x.EmployeeId == employeeId);

            return (
                employee,
                employeeHasCompanyHasDepartmentType
            );
        }

        private void ListEmployees()
        {
            List<Employee> employees =
                blEmployee.EmployeeList();

            List<EmployeeHasCompanyHasDepartmentType>
                employeeHasCompanyHasDepartmentTypes =
                blEmployeeHasCompanyHasDepartmentType
                    .EmployeeHasCompanyHasDepartmentTypeList();

            employees = employees
                .Where(x =>
                {
                    User user =
                        blUser.UserGetById(x.UserId);

                    return user != null &&
                           user.IsActive;
                })
                .ToList();

            var employeeList = employees.Select(x =>
            {
                EmployeeHasCompanyHasDepartmentType
                    employeeHasCompanyHasDepartmentType =
                        employeeHasCompanyHasDepartmentTypes
                            .FirstOrDefault(y =>
                                y.EmployeeId == x.EmployeeId);

                string companyName = "";
                string departmentName = "";

                if (employeeHasCompanyHasDepartmentType != null)
                {
                    CompanyHasDepartmentType
                        companyHasDepartmentType =
                        employeeHasCompanyHasDepartmentType
                            .CompanyHasDepartmentType;

                    if (companyHasDepartmentType != null)
                    {
                        Company company =
                            blCompany.CompanyGetById(
                                companyHasDepartmentType.CompanyId);

                        DepartmentType departmentType =
                            blDepartmentType.DepartmentTypeGetById(
                                companyHasDepartmentType.DepartmentTypeId);

                        companyName =
                            company != null
                                ? company.CompanyName
                                : "";

                        departmentName =
                            departmentType != null
                                ? departmentType.DepartmentName
                                : "";
                    }
                }

                return new
                {
                    x.EmployeeId,
                    x.EmployeeIdentityNumber,
                    x.EmployeeName,
                    x.EmployeeSurname,
                    x.EmployeeBirthday,
                    x.EmployeeHireDate,
                    x.EmployeeTelephoneNumber,
                    x.EmployeeEmail,
                    x.EmployeeSalary,

                    ProfessionTypeName =
                        x.ProfessionType != null
                            ? x.ProfessionType.ProfessionName
                            : "",

                    CompanyName =
                        companyName,

                    DepartmentName =
                        departmentName
                };
            }).ToList();

            DgvEmployees.DataSource =
                employeeList;

            LblRecordCount.Text =
                employees.Count +
                " employees";
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new FrmEmployeeAddEditForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    ListEmployees();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var selectedEmployee =
                GetSelectedEmployee();

            Employee employee =
                selectedEmployee.Employee;

            EmployeeHasCompanyHasDepartmentType
                employeeHasCompanyHasDepartmentType =
                    selectedEmployee
                        .EmployeeHasCompanyHasDepartmentType;

            if (employee == null)
            {
                MessageBox.Show("Please select an employee.");
                return;
            }

            using (var form =
                new FrmEmployeeAddEditForm(
                    employee,
                    employeeHasCompanyHasDepartmentType))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    ListEmployees();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var selectedEmployee =
                GetSelectedEmployee();

            Employee employee =
                selectedEmployee.Employee;

            if (employee == null)
            {
                MessageBox.Show(
                    "Please select an employee.");

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to deactivate the selected employee?",
                    "Deactivate Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            User user =
                blUser.UserGetById(
                    employee.UserId);

            if (user == null)
            {
                MessageBox.Show(
                    "Employee user record could not be found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            user.IsActive = false;

            if (blUser.UserUpdate(user))
            {
                ListEmployees();

                MessageBox.Show(
                    "Employee deactivated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "Employee could not be deactivated.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void SearchEmployees()
        {
            string searchText =
                TxtSearch.Text.Trim().ToLower();

            List<Employee> employees =
                blEmployee.EmployeeList();

            List<EmployeeHasCompanyHasDepartmentType>
                employeeHasCompanyHasDepartmentTypes =
                blEmployeeHasCompanyHasDepartmentType
                    .EmployeeHasCompanyHasDepartmentTypeList();

            employees = employees
                .Where(x =>
                {
                    User user =
                        blUser.UserGetById(x.UserId);

                    return user != null &&
                           user.IsActive;
                })
                .ToList();

            if (!string.IsNullOrEmpty(searchText))
            {
                employees = employees
                    .Where(x =>
                    {
                        EmployeeHasCompanyHasDepartmentType
                            employeeHasCompanyHasDepartmentType =
                                employeeHasCompanyHasDepartmentTypes
                                    .FirstOrDefault(y =>
                                        y.EmployeeId == x.EmployeeId);

                        string companyName = "";
                        string departmentName = "";

                        if (employeeHasCompanyHasDepartmentType != null &&
                            employeeHasCompanyHasDepartmentType
                                .CompanyHasDepartmentType != null)
                        {
                            CompanyHasDepartmentType
                                companyHasDepartmentType =
                                    employeeHasCompanyHasDepartmentType
                                        .CompanyHasDepartmentType;

                            Company company =
                                blCompany.CompanyGetById(
                                    companyHasDepartmentType.CompanyId);

                            DepartmentType departmentType =
                                blDepartmentType.DepartmentTypeGetById(
                                    companyHasDepartmentType.DepartmentTypeId);

                            companyName =
                                company != null
                                    ? company.CompanyName
                                    : "";

                            departmentName =
                                departmentType != null
                                    ? departmentType.DepartmentName
                                    : "";
                        }

                        return
                            x.EmployeeIdentityNumber.ToLower()
                                .Contains(searchText) ||

                            x.EmployeeName.ToLower()
                                .Contains(searchText) ||

                            x.EmployeeSurname.ToLower()
                                .Contains(searchText) ||

                            x.EmployeeTelephoneNumber.ToLower()
                                .Contains(searchText) ||

                            x.EmployeeEmail.ToLower()
                                .Contains(searchText) ||

                            (x.ProfessionType != null &&
                             x.ProfessionType.ProfessionName
                                .ToLower()
                                .Contains(searchText)) ||

                            companyName.ToLower()
                                .Contains(searchText) ||

                            departmentName.ToLower()
                                .Contains(searchText);
                    })
                    .ToList();
            }

            var employeeList = employees.Select(x =>
            {
                EmployeeHasCompanyHasDepartmentType
                    employeeHasCompanyHasDepartmentType =
                        employeeHasCompanyHasDepartmentTypes
                            .FirstOrDefault(y =>
                                y.EmployeeId == x.EmployeeId);

                string companyName = "";
                string departmentName = "";

                if (employeeHasCompanyHasDepartmentType != null &&
                    employeeHasCompanyHasDepartmentType
                        .CompanyHasDepartmentType != null)
                {
                    CompanyHasDepartmentType
                        companyHasDepartmentType =
                        employeeHasCompanyHasDepartmentType
                            .CompanyHasDepartmentType;

                    Company company =
                        blCompany.CompanyGetById(
                            companyHasDepartmentType.CompanyId);

                    DepartmentType departmentType =
                        blDepartmentType.DepartmentTypeGetById(
                            companyHasDepartmentType.DepartmentTypeId);

                    companyName =
                        company != null
                            ? company.CompanyName
                            : "";

                    departmentName =
                        departmentType != null
                            ? departmentType.DepartmentName
                            : "";
                }

                return new
                {
                    x.EmployeeId,
                    x.EmployeeIdentityNumber,
                    x.EmployeeName,
                    x.EmployeeSurname,
                    x.EmployeeBirthday,
                    x.EmployeeHireDate,
                    x.EmployeeTelephoneNumber,
                    x.EmployeeEmail,
                    x.EmployeeSalary,

                    ProfessionTypeName =
                        x.ProfessionType != null
                            ? x.ProfessionType.ProfessionName
                            : "",

                    CompanyName =
                        companyName,

                    DepartmentName =
                        departmentName
                };
            }).ToList();

            DgvEmployees.DataSource =
                employeeList;

            LblRecordCount.Text =
                employees.Count +
                " employees";
        }
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchEmployees();
        }
    }
}
