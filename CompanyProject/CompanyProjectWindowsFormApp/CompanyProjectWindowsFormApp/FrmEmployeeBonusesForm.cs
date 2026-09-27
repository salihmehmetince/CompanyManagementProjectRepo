using CompanyManagement.BusinessLogic;
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
    public partial class FrmEmployeeBonusesForm : Form
    {

        private BLCompanyGivesBonusToEmployee blCompanyGivesBonusToEmployee = new BLCompanyGivesBonusToEmployee();
        public FrmEmployeeBonusesForm()
        {
            InitializeComponent();
            SetButtonsBorder();
            setIcon();
            ListEmployeeBonuses();
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

        private void ListEmployeeBonuses()
        {
            List<CompanyGivesBonusToEmployee>
                employeeBonuses =
                blCompanyGivesBonusToEmployee
                    .CompanyGivesBonusToEmployeeList();

            var employeeBonusList =
                employeeBonuses.Select(x => new
                {
                    x.CompanyGivesBonusToEmployeeId,
                    x.CompanyGivesBonusToEmployeeDate,
                    x.CompanyGivesBonusToEmployeeQuantity,
                    x.IsPercentage,
                    x.AffectSalary,

                    CompanyName =
                        x.Company != null
                            ? x.Company.CompanyName
                            : "",

                    EmployeeName =
                        x.Employee != null
                            ? x.Employee.EmployeeName + " " +
                              x.Employee.EmployeeSurname
                            : ""
                }).ToList();

            DgvEmployeeBonuses.DataSource =
                employeeBonusList;

            LblRecordCount.Text =
                employeeBonuses.Count +
                " employee bonuses";
        }
        private CompanyGivesBonusToEmployee GetSelectedEmployeeBonus()
        {
            if (DgvEmployeeBonuses.CurrentRow == null)
                return null;

            int employeeBonusId =
                Convert.ToInt32(
                    DgvEmployeeBonuses.CurrentRow
                        .Cells["CompanyGivesBonusToEmployeeId"]
                        .Value
                );

            return blCompanyGivesBonusToEmployee
                .CompanyGivesBonusToEmployeeGetById(
                    employeeBonusId);
        }

        private void SearchEmployeeBonuses()
        {
            string searchText =
                TxtSearch.Text.Trim().ToLower();

            List<CompanyGivesBonusToEmployee>
                employeeBonuses =
                blCompanyGivesBonusToEmployee
                    .CompanyGivesBonusToEmployeeList();

            if (!string.IsNullOrEmpty(searchText))
            {
                employeeBonuses = employeeBonuses
                    .Where(x =>
                        (x.Company != null &&
                         x.Company.CompanyName
                            .ToLower()
                            .Contains(searchText)) ||

                        (x.Employee != null &&
                         (
                            x.Employee.EmployeeName
                                .ToLower()
                                .Contains(searchText) ||

                            x.Employee.EmployeeSurname
                                .ToLower()
                                .Contains(searchText)
                         )) ||

                        x.CompanyGivesBonusToEmployeeQuantity
                            .ToString()
                            .Contains(searchText) ||

                        x.CompanyGivesBonusToEmployeeDate
                            .ToString("dd.MM.yyyy")
                            .Contains(searchText) ||

                        x.IsPercentage
                            .ToString()
                            .ToLower()
                            .Contains(searchText) ||

                        x.AffectSalary
                            .ToString()
                            .ToLower()
                            .Contains(searchText)
                    )
                    .ToList();
            }

            var employeeBonusList =
                employeeBonuses.Select(x => new
                {
                    x.CompanyGivesBonusToEmployeeId,

                    CompanyName =
                        x.Company != null
                            ? x.Company.CompanyName
                            : "",

                    EmployeeName =
                        x.Employee != null
                            ? x.Employee.EmployeeName + " " +
                              x.Employee.EmployeeSurname
                            : "",

                    x.CompanyGivesBonusToEmployeeDate,

                    x.CompanyGivesBonusToEmployeeQuantity,
                    x.IsPercentage,
                    x.AffectSalary
                }).ToList();

            DgvEmployeeBonuses.DataSource =
                employeeBonusList;

            LblRecordCount.Text =
                employeeBonuses.Count +
                " employee bonuses";
        }
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchEmployeeBonuses();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmEmployeeBonusAddEditForm frm =
    new FrmEmployeeBonusAddEditForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListEmployeeBonuses();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            CompanyGivesBonusToEmployee employeeBonus =
                GetSelectedEmployeeBonus();

            if (employeeBonus == null)
            {
                MessageBox.Show(
                    "Please select an employee bonus.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (employeeBonus.AffectSalary)
            {
                MessageBox.Show(
                    "This employee bonus cannot be edited because it affects the employee salary.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            FrmEmployeeBonusAddEditForm frm =
                new FrmEmployeeBonusAddEditForm(employeeBonus);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListEmployeeBonuses();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            CompanyGivesBonusToEmployee employeeBonus =
                GetSelectedEmployeeBonus();

            if (employeeBonus == null)
            {
                MessageBox.Show(
                    "Please select an employee bonus.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (employeeBonus.AffectSalary)
            {
                MessageBox.Show(
                    "This employee bonus cannot be deleted because it affects the employee salary.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this employee bonus?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            if (!blCompanyGivesBonusToEmployee
                .CompanyGivesBonusToEmployeeDelete(
                    employeeBonus.CompanyGivesBonusToEmployeeId))
            {
                MessageBox.Show(
                    "Employee bonus could not be deleted.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                "Employee bonus deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ListEmployeeBonuses();
        }
    }
}
