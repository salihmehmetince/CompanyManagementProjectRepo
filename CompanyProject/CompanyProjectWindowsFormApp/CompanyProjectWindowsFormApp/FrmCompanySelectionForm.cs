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
    public partial class FrmCompanySelectionForm : Form
    {

        private User user;

        public User SelectedUser { get; private set; }

        public List<int> SelectedCompanyIds { get; private set; }
        public FrmCompanySelectionForm(User user)
        {
            this.user = user;
            SelectedUser = user;
            SelectedCompanyIds = new List<int>();

            InitializeComponent();

            LoadCompanies();

            setIcon();
        }

        private void setIcon()
        {
            this.Icon = Properties.Resources.icon_company;
        }
        private void LoadCompanies()
        {
            BLCompany blCompany = new BLCompany();

            List<Company> companies;

            if (user.UserRoleId == 1)
            {
                companies = blCompany.CompanyList();
            }
            else if (user.UserRoleId == 2)
            {
                BLCompanyOwnerHasCompany blCompanyOwnerHasCompany =
                    new BLCompanyOwnerHasCompany();

                List<CompanyOwnerHasCompany> companyOwnerHasCompanies =
                    blCompanyOwnerHasCompany.CompanyOwnerHasCompanyList();

                companies = companyOwnerHasCompanies
                    .Where(x =>
                        x.CompanyOwner != null &&
                        x.CompanyOwner.UserId == user.UserId &&
                        x.Company != null)
                    .Select(x => x.Company)
                    .ToList();
            }
            else
            {
                BLEmployeeHasCompanyHasDepartmentType
                    blEmployeeHasCompanyHasDepartmentType =
                    new BLEmployeeHasCompanyHasDepartmentType();

                List<EmployeeHasCompanyHasDepartmentType>
                    employeeHasCompanyHasDepartmentTypes =
                    blEmployeeHasCompanyHasDepartmentType
                        .EmployeeHasCompanyHasDepartmentTypeList();

                companies = employeeHasCompanyHasDepartmentTypes
                    .Where(x =>
                        x.Employee != null &&
                        x.Employee.UserId == user.UserId &&
                        x.CompanyHasDepartmentType != null &&
                        x.CompanyHasDepartmentType.Company != null)
                    .Select(x => x.CompanyHasDepartmentType.Company)
                    .Take(1)
                    .ToList();
            }

            DgvCompanies.DataSource = null;
            DgvCompanies.Columns.Clear();

            DataGridViewCheckBoxColumn checkColumn =
                new DataGridViewCheckBoxColumn();

            checkColumn.Name = "Select";
            checkColumn.HeaderText = "Select";
            checkColumn.Width = 60;

            DgvCompanies.Columns.Add(checkColumn);

            DataGridViewTextBoxColumn companyNameColumn =
                new DataGridViewTextBoxColumn();

            companyNameColumn.Name = "CompanyName";
            companyNameColumn.HeaderText = "Company Name";
            companyNameColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            DgvCompanies.Columns.Add(companyNameColumn);

            foreach (Company company in companies)
            {
                int rowIndex = DgvCompanies.Rows.Add();

                DgvCompanies.Rows[rowIndex].Cells["Select"].Value =
                    user.UserRoleId == 3;

                DgvCompanies.Rows[rowIndex].Cells["CompanyName"].Value =
                    company.CompanyName;

                DgvCompanies.Rows[rowIndex].Tag = company.CompanyId;
            }
        }
        private void btnContinue_Click(object sender, EventArgs e)
        {
            SelectedCompanyIds.Clear();

            foreach (DataGridViewRow row in DgvCompanies.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    int companyId = Convert.ToInt32(row.Tag);

                    SelectedCompanyIds.Add(companyId);
                }
            }

            if (SelectedCompanyIds.Count == 0)
            {
                MessageBox.Show(
                    "Please select at least one company.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void DgvCompanies_CellContentClick(
    object sender,
    DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (DgvCompanies.Columns[e.ColumnIndex].Name != "Select")
                return;

            DgvCompanies.EndEdit();

            int selectedCount = 0;

            foreach (DataGridViewRow row in DgvCompanies.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Select"].Value))
                {
                    selectedCount++;
                }
            }

            LblRecordCount.Text = "Selected: " + selectedCount;
        }
    }
}
