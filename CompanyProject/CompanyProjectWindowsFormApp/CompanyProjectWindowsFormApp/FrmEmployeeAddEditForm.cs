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
using System.Xml.Linq;

namespace CompanyProjectWindowsFormApp
{
    public partial class FrmEmployeeAddEditForm : Form
    {
        private BLEmployee bLEmployee=new BLEmployee();
        private BLEmployeeHasCompanyHasDepartmentType blEmployeeHasCompanyHasDepartmentType=new BLEmployeeHasCompanyHasDepartmentType();
        private Employee employee;
        private EmployeeHasCompanyHasDepartmentType employeeHasCompanyHasDepartmentType;
        private BLCompany blCompany=new BLCompany();
        private BLCompanyHasDepartmentType blCompanyHasDepartmentType = new BLCompanyHasDepartmentType();
        public FrmEmployeeAddEditForm(Employee employee=null, EmployeeHasCompanyHasDepartmentType employeeHasCompanyHasDepartmentType=null)
        {
            InitializeComponent();
            this.employee = employee;
            this.employeeHasCompanyHasDepartmentType = employeeHasCompanyHasDepartmentType;
            LoadProfessionTypes();
            LoadCompanies();
            LoadDepartments();
            if (employee != null) 
            {
                LoadEmployee();
            }
        }

        private void LoadEmployee()
        {
            LblTitle.Text =
                "Edit Employee";

            LblDescription.Text =
                "Update employee information";

            TxtIdentityNumber.Text =
                employee.EmployeeIdentityNumber;

            TxtEmployeeName.Text =
                employee.EmployeeName;

            TxtSurname.Text =
                employee.EmployeeSurname;

            DTPBirthday.Value =
                employee.EmployeeBirthday;

            DTPHireDate.Value =
                employee.EmployeeHireDate;

            MTBTelephoneNumber.Text =
                employee.EmployeeTelephoneNumber;

            TxtEmail.Text =
                employee.EmployeeEmail;

            RTBAddress.Text =
                employee.EmployeeAddress;

            TxtSalary.Text =
                employee.EmployeeSalary.ToString();

            TxtUsername.Text =
                employee.User.Username;

            CMBProfessionType.SelectedValue =
                employee.EmployeeProfessionTypeId;

            if (employeeHasCompanyHasDepartmentType != null)
            {
                CompanyHasDepartmentType
                    companyHasDepartmentType =
                        employeeHasCompanyHasDepartmentType
                            .CompanyHasDepartmentType;

                if (companyHasDepartmentType != null)
                {
                    CmbCompany.SelectedValue =
                        companyHasDepartmentType.CompanyId;

                    LoadDepartments();

                    CmbDepartment.SelectedValue =
                        companyHasDepartmentType
                            .CompanyHasDepartmentTypeId;
                }
            }
        }

        private void LoadProfessionTypes()
        {

            BLProfessionType blProfessionType = new BLProfessionType();
            CMBProfessionType.DataSource =
                blProfessionType.ProfessionTypeList();

            CMBProfessionType.DisplayMember =
                "ProfessionName";

            CMBProfessionType.ValueMember =
                "ProfessionTypeId";

            CMBProfessionType.SelectedIndex = -1;
        }

        private void LoadDepartments()
        {
            CmbDepartment.DataSource = null;

            List<CompanyHasDepartmentType>
                companyHasDepartmentTypes =
                blCompanyHasDepartmentType
                    .CompanyHasDepartmentTypeList();

            if (CmbCompany.SelectedValue is int)
            {
                int companyId =
                    Convert.ToInt32(
                        CmbCompany.SelectedValue);

                companyHasDepartmentTypes =
                    companyHasDepartmentTypes
                        .Where(x =>
                            x.CompanyId == companyId)
                        .ToList();
            }

            CmbDepartment.DataSource =
                companyHasDepartmentTypes
                    .Select(x => new
                    {
                        x.CompanyHasDepartmentTypeId,

                        DepartmentName =
                            x.DepartmentType.DepartmentName
                    })
                    .ToList();

            CmbDepartment.DisplayMember =
                "DepartmentName";

            CmbDepartment.ValueMember =
                "CompanyHasDepartmentTypeId";

            CmbDepartment.SelectedIndex = -1;
        }
        private void LoadCompanies()
        {
            CmbCompany.DataSource =
                blCompany.CompanyList();

            CmbCompany.DisplayMember =
                "CompanyName";

            CmbCompany.ValueMember =
                "CompanyId";

            CmbCompany.SelectedIndex = -1;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                decimal salary;

                if (!decimal.TryParse(
                    TxtSalary.Text.Trim(),
                    out salary))
                {
                    MessageBox.Show(
                        "Please enter a valid salary.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    TxtSalary.Focus();
                    return;
                }

                if (CmbCompany.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Please select a company.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    CmbCompany.Focus();
                    return;
                }

                if (CmbDepartment.SelectedValue == null)
                {
                    MessageBox.Show(
                        "Please select a department.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    CmbDepartment.Focus();
                    return;
                }

                int companyHasDepartmentTypeId =
                    Convert.ToInt32(
                        CmbDepartment.SelectedValue);

                if (employee == null)
                {
                    // ADD

                    if (TxtPassword.Text !=
                        TxtPasswordComfirmation.Text)
                    {
                        MessageBox.Show(
                            "Passwords do not match.",
                            "Validation Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);

                        TxtPasswordComfirmation.Focus();
                        return;
                    }

                    var employeeRole =
                        new BLUserRole()
                            .UserRoleList()
                            .FirstOrDefault(x =>
                                x.UserRoleName == "Employee");

                    if (employeeRole == null)
                    {
                        MessageBox.Show(
                            "Employee rolü bulunamadı.",
                            "Hata",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return;
                    }

                    var user = new User
                    {
                        Username =
                            TxtUsername.Text.Trim(),

                        PasswordHash =
                            PasswordHelper.PasswordHash(
                                TxtPassword.Text),

                        IsActive = true,

                        UserRoleId =
                            employeeRole.UserRoleId
                    };

                    var employeeToSave = new Employee
                    {
                        EmployeeIdentityNumber =
                            TxtIdentityNumber.Text.Trim(),

                        EmployeeName =
                            TxtEmployeeName.Text.Trim(),

                        EmployeeSurname =
                            TxtSurname.Text.Trim(),

                        EmployeeBirthday =
                            DTPBirthday.Value,

                        EmployeeHireDate =
                            DTPHireDate.Value,

                        EmployeeTelephoneNumber =
                            MTBTelephoneNumber.Text.Trim(),

                        EmployeeEmail =
                            string.IsNullOrWhiteSpace(
                                TxtEmail.Text)
                                ? null
                                : TxtEmail.Text.Trim(),

                        EmployeeAddress =
                            string.IsNullOrWhiteSpace(
                                RTBAddress.Text)
                                ? null
                                : RTBAddress.Text.Trim(),

                        EmployeeSalary =
                            salary,

                        EmployeeProfessionTypeId =
                            Convert.ToInt32(
                                CMBProfessionType.SelectedValue)
                    };

                    if (!bLEmployee.EmployeeAdd(
                        employeeToSave,
                        user))
                    {
                        MessageBox.Show(
                            "Employee could not be added.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return;
                    }

                    EmployeeHasCompanyHasDepartmentType
                        employeeHasCompanyHasDepartmentTypeToSave =
                            new EmployeeHasCompanyHasDepartmentType
                            {
                                EmployeeId =
                                    employeeToSave.EmployeeId,

                                CompanyHasDepartmentTypeId =
                                    companyHasDepartmentTypeId
                            };

                    if (!blEmployeeHasCompanyHasDepartmentType
                        .EmployeeHasCompanyHasDepartmentTypeAdd(
                            employeeHasCompanyHasDepartmentTypeToSave))
                    {
                        MessageBox.Show(
                            "Employee was added, but company department assignment could not be added.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return;
                    }

                    MessageBox.Show(
                        "Employee added successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DialogResult =
                        DialogResult.OK;

                    Close();

                    return;
                }

                // UPDATE

                if (TxtPassword.Text !=
                    TxtPasswordComfirmation.Text)
                {
                    MessageBox.Show(
                        "Passwords do not match.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    TxtPasswordComfirmation.Focus();
                    return;
                }

                var userToUpdate = new User
                {
                    UserId =
                        employee.UserId,

                    Username =
                        TxtUsername.Text.Trim(),

                    PasswordHash =
                        string.IsNullOrWhiteSpace(
                            TxtPassword.Text)
                            ? null
                            : PasswordHelper.PasswordHash(
                                TxtPassword.Text),

                    IsActive = true,

                    UserRoleId =
                        employee.User != null
                            ? employee.User.UserRoleId
                            : 3
                };

                employee.EmployeeIdentityNumber =
                    TxtIdentityNumber.Text.Trim();

                employee.EmployeeName =
                    TxtEmployeeName.Text.Trim();

                employee.EmployeeSurname =
                    TxtSurname.Text.Trim();

                employee.EmployeeBirthday =
                    DTPBirthday.Value;

                employee.EmployeeHireDate =
                    DTPHireDate.Value;

                employee.EmployeeTelephoneNumber =
                    MTBTelephoneNumber.Text.Trim();

                employee.EmployeeEmail =
                    string.IsNullOrWhiteSpace(
                        TxtEmail.Text)
                        ? null
                        : TxtEmail.Text.Trim();

                employee.EmployeeAddress =
                    string.IsNullOrWhiteSpace(
                        RTBAddress.Text)
                        ? null
                        : RTBAddress.Text.Trim();

                employee.EmployeeSalary =
                    salary;

                employee.EmployeeProfessionTypeId =
                    Convert.ToInt32(
                        CMBProfessionType.SelectedValue);

                if (!bLEmployee.EmployeeUpdate(
                    employee,
                    userToUpdate))
                {
                    MessageBox.Show(
                        "Employee could not be updated.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                if (employeeHasCompanyHasDepartmentType == null)
                {
                    employeeHasCompanyHasDepartmentType =
                        new EmployeeHasCompanyHasDepartmentType
                        {
                            EmployeeId =
                                employee.EmployeeId,

                            CompanyHasDepartmentTypeId =
                                companyHasDepartmentTypeId
                        };

                    if (!blEmployeeHasCompanyHasDepartmentType
                        .EmployeeHasCompanyHasDepartmentTypeAdd(
                            employeeHasCompanyHasDepartmentType))
                    {
                        MessageBox.Show(
                            "Employee updated, but company department assignment could not be added.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return;
                    }
                }
                else
                {
                    employeeHasCompanyHasDepartmentType
                        .EmployeeId =
                            employee.EmployeeId;

                    employeeHasCompanyHasDepartmentType
                        .CompanyHasDepartmentTypeId =
                            companyHasDepartmentTypeId;

                    if (!blEmployeeHasCompanyHasDepartmentType
                        .EmployeeHasCompanyHasDepartmentTypeUpdate(
                            employeeHasCompanyHasDepartmentType))
                    {
                        MessageBox.Show(
                            "Employee updated, but company department assignment could not be updated.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return;
                    }
                }

                MessageBox.Show(
                    "Employee updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult =
                    DialogResult.OK;

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Employee işleminde beklenmeyen bir hata oluş.\n\n"
                    + ex.Message,
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            string password = TxtPassword.Text;

            if (string.IsNullOrEmpty(password))
            {
                LblPasswordStrength.Text = "Password strength: -";
                LblPasswordStrength.ForeColor = Color.FromArgb(100, 116, 139);
                return;
            }

            int score = 0;

            if (password.Length >= 8)
                score++;

            if (password.Any(char.IsUpper))
                score++;

            if (password.Any(char.IsLower))
                score++;

            if (password.Any(char.IsDigit))
                score++;

            if (password.Any(ch => !char.IsLetterOrDigit(ch)))
                score++;

            if (score <= 2)
            {
                LblPasswordStrength.Text = "Password strength: Weak";
                LblPasswordStrength.ForeColor = Color.FromArgb(220, 38, 38);
            }
            else if (score <= 4)
            {
                LblPasswordStrength.Text = "Password strength: Medium";
                LblPasswordStrength.ForeColor = Color.FromArgb(234, 179, 8);
            }
            else
            {
                LblPasswordStrength.Text = "Password strength: Strong";
                LblPasswordStrength.ForeColor = Color.FromArgb(22, 163, 74);
            }
        }

        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = !ChkShowPassword.Checked;
        }

        private void ChkShowPasswordConfirmation_CheckedChanged(object sender, EventArgs e)
        {
            TxtPasswordComfirmation.UseSystemPasswordChar = !ChkShowPasswordConfirmation.Checked;
        }

        private void CmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDepartments();
        }
    }
}
