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
    public partial class FrmEmployeesForm : Form
    {

        BLEmployee blEmployee = new BLEmployee();
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

        private Employee GetSelectedEmployee()
        {
            if (DgvEmployees.CurrentRow == null)
                return null;

            int employeeId = Convert.ToInt32(
                DgvEmployees.CurrentRow.Cells["EmployeeId"].Value
            );

            return blEmployee.EmployeeGetById(employeeId);
        }

        private void ListEmployees()
        {
            List<Employee> employees = blEmployee.EmployeeList();

            var employeeList = employees.Select(x => new
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
                ProfessionTypeName = x.ProfessionType != null
                    ? x.ProfessionType.ProfessionName
                    : ""
            }).ToList();

            DgvEmployees.DataSource = employeeList;

            LblRecordCount.Text =
                employees.Count + " employees";
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
            Employee employee = GetSelectedEmployee();

            if (employee == null)
            {
                MessageBox.Show("Please select an employee.");
                return;
            }

            using (var form = new FrmEmployeeAddEditForm(employee))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    ListEmployees();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Employee employee = GetSelectedEmployee();

            if (employee == null)
            {
                MessageBox.Show("Please select an employee.");
                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete the selected employee?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            if (blEmployee.EmployeeDelete(employee.EmployeeId))
            {
                ListEmployees();
                MessageBox.Show("Employee deleted successfully.");
            }
            else
            {
                MessageBox.Show("Employee could not be deleted.");
            }
        }

        private void SearchEmployees()
        {
            string searchText = TxtSearch.Text.Trim().ToLower();

            List<Employee> employees =
                blEmployee.EmployeeList();

            if (!string.IsNullOrEmpty(searchText))
            {
                employees = employees
                    .Where(x =>
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
                         x.ProfessionType.ProfessionName.ToLower()
                            .Contains(searchText))
                    )
                    .ToList();
            }

            var employeeList = employees.Select(x => new
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
                ProfessionTypeName = x.ProfessionType != null
                    ? x.ProfessionType.ProfessionName
                    : ""
            }).ToList();

            DgvEmployees.DataSource =
                employeeList;

            LblRecordCount.Text =
                employees.Count + " employees";
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchEmployees();
        }
    }
}
