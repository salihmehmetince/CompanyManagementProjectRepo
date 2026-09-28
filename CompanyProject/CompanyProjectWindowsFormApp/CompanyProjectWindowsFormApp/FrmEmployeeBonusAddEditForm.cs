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

namespace CompanyManagement.BusinessLogic
{
    public partial class FrmEmployeeBonusAddEditForm : Form
    {
        private CompanyGivesBonusToEmployee employeeBonus;

        private BLCompany blCompany=new BLCompany();

        private BLEmployee blEmployee=new BLEmployee();

        private BLEmployeeHasCompanyHasDepartmentType blEmployeeHasCompanyHasDepartmentType =new BLEmployeeHasCompanyHasDepartmentType();
        
        private BLCompanyGivesBonusToEmployee blCompanyGivesBonusToEmployee = new BLCompanyGivesBonusToEmployee();
        private BLUser blUser = new BLUser();
        private User user;
        private List<int> selectedCompanyIds;

        public FrmEmployeeBonusAddEditForm(
            User user,
            List<int> selectedCompanyIds,
            CompanyGivesBonusToEmployee employeeBonus = null)
        {
            this.user = user;
            this.selectedCompanyIds = selectedCompanyIds;

            InitializeComponent();
            LoadCompanies();
            LoadEmployees();

            this.employeeBonus = employeeBonus;

            if (employeeBonus != null)
            {
                LoadEmployeeBonus();
            }

            SetButtonsBorder();
        }
        private void SetButtonsBorder()
        {
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatAppearance.BorderSize = 0;
        }

        private void LoadCompanies()
        {
            List<Company> companies =
                blCompany
                    .CompanyList()
                    .Where(x =>
                        selectedCompanyIds.Contains(
                            x.CompanyId))
                    .ToList();

            CmbCompany.DataSource =
                companies;

            CmbCompany.DisplayMember =
                "CompanyName";

            CmbCompany.ValueMember =
                "CompanyId";
        }
        private void LoadEmployees()
        {
            if (CmbCompany.SelectedValue == null)
                return;

            if (!(CmbCompany.SelectedValue is int))
                return;

            int companyId =
                Convert.ToInt32(
                    CmbCompany.SelectedValue);

            List<EmployeeHasCompanyHasDepartmentType>
                employeeCompanyDepartments =
                blEmployeeHasCompanyHasDepartmentType
                    .EmployeeHasCompanyHasDepartmentTypeList()
                    .Where(x =>
                        x.CompanyHasDepartmentType != null &&
                        x.CompanyHasDepartmentType.CompanyId ==
                        companyId)
                    .ToList();

            List<Employee> employees =
                employeeCompanyDepartments
                    .Select(x => x.Employee)
                    .Where(x => x != null)
                    .GroupBy(x => x.EmployeeId)
                    .Select(x => x.First())
                    .ToList();

            CmbEmployee.DataSource = employees;
            CmbEmployee.DisplayMember = "EmployeeName";
            CmbEmployee.ValueMember = "EmployeeId";

            SetCurrentSalary();

        }

        private void LoadEmployeeBonus()
        {
            LblTitle.Text =
                "Edit Employee Bonus";

            LblDescription.Text =
                "Update employee bonus information";

            CmbCompany.SelectedValue =
                employeeBonus.CompanyId;

            LoadEmployees();

            CmbEmployee.SelectedValue =
                employeeBonus.EmployeeId;

            if (employeeBonus.IsPercentage)
                RBRate.Checked = true;
            else
                RBAmount.Checked = true;

            TxtAmount.Text =
                employeeBonus.CompanyGivesBonusToEmployeeQuantity
                    .ToString();

            CBAffectSalary.Checked =
                employeeBonus.AffectSalary;

            DTPDate.Value = employeeBonus.CompanyGivesBonusToEmployeeDate;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CmbCompany.SelectedValue == null)
            {
                MessageBox.Show(
                    "Please select a company.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (CmbEmployee.SelectedValue == null)
            {
                MessageBox.Show(
                    "Please select an employee.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (!RBAmount.Checked &&
                !RBRate.Checked)
            {
                MessageBox.Show(
                    "Please select amount or rate.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (string.IsNullOrWhiteSpace(TxtAmount.Text))
            {
                MessageBox.Show(
                    "Please enter an amount.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (!decimal.TryParse(
                TxtAmount.Text,
                out decimal amount))
            {
                MessageBox.Show(
                    "Please enter a valid amount.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            if (amount < 0)
            {
                MessageBox.Show(
                    "Amount cannot be negative.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            CompanyGivesBonusToEmployee
                employeeBonusToSave;

            if (employeeBonus == null)
            {
                employeeBonusToSave =
                    new CompanyGivesBonusToEmployee();
            }
            else
            {
                employeeBonusToSave =
                    employeeBonus;
            }

            employeeBonusToSave.CompanyId =
                Convert.ToInt32(
                    CmbCompany.SelectedValue);

            employeeBonusToSave.EmployeeId =
                Convert.ToInt32(
                    CmbEmployee.SelectedValue);

            employeeBonusToSave.CompanyGivesBonusToEmployeeDate =
                DTPDate.Value;

            employeeBonusToSave
                .CompanyGivesBonusToEmployeeQuantity =
                amount;

            employeeBonusToSave.IsPercentage =
                RBRate.Checked;

            employeeBonusToSave.AffectSalary =
                CBAffectSalary.Checked;

            bool result;

            if (employeeBonus == null)
            {
                result =
                    blCompanyGivesBonusToEmployee
                        .CompanyGivesBonusToEmployeeAdd(
                            employeeBonusToSave);
            }
            else
            {
                result =
                    blCompanyGivesBonusToEmployee
                        .CompanyGivesBonusToEmployeeUpdate(
                            employeeBonusToSave);
            }

            if (result)
            {
                if (CBAffectSalary.Checked)
                {
                    Employee employee =
                        blEmployee.EmployeeGetById(
                            employeeBonusToSave.EmployeeId);

                    if (employee != null)
                    {
                        decimal bonusAmount;

                        if (employeeBonusToSave.IsPercentage)
                        {
                            bonusAmount =
                                employee.EmployeeSalary *
                                employeeBonusToSave
                                    .CompanyGivesBonusToEmployeeQuantity /
                                100;
                        }
                        else
                        {
                            bonusAmount =
                                employeeBonusToSave
                                    .CompanyGivesBonusToEmployeeQuantity;
                        }

                        employee.EmployeeSalary +=
                            bonusAmount;

                        User user =
                            blUser.UserGetById(employee.UserId);

                        if (user == null ||
                            !blEmployee.EmployeeUpdate(
                                employee,
                                user))
                        {
                            MessageBox.Show(
                                "Employee bonus was saved, but the employee salary could not be updated.",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                            return;
                        }
                    }
                }

                MessageBox.Show(
                    employeeBonus == null
                        ? "Employee bonus added successfully."
                        : "Employee bonus updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(
                    "Employee bonus could not be saved. Please check the entered information.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void CmbEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetCurrentSalary();
        }

        private void SetCurrentSalary()
        {
            if (CmbEmployee.SelectedValue == null)
                return;

            if (!(CmbEmployee.SelectedValue is int))
                return;

            int employeeId =
                Convert.ToInt32(
                    CmbEmployee.SelectedValue);

            Employee employee =
                blEmployee.EmployeeGetById(employeeId);

            if (employee == null)
                return;

            LblCurrentSalaryAmount.Text =
                employee.EmployeeSalary.ToString("N2");
        }
    }
}
