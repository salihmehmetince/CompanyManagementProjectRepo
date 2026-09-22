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
    public partial class FrmCompanyAddEditForm : Form
    {
        private BLCompany blCompany = new BLCompany();
        private BLCompanyType blCompanyType = new BLCompanyType();

        private Company company;

        private BLCompanyOwner blCompanyOwner=new BLCompanyOwner();
        private BLUser blUser=new BLUser();
        private BLCompanyOwnerHasCompany blCompanyOwnerHasCompany=new BLCompanyOwnerHasCompany();
        public FrmCompanyAddEditForm(Company company = null)
        {
            InitializeComponent();
            SetButtonsBorder();
            this.company = company;

            LoadCompanyTypes();
            LoadCompanyOwners();
            if (company != null)
            {
                LoadCompany();
            }
        }

        private void LoadCompany()
        {
            LblTitle.Text =
                "Edit Company";

            LblDescription.Text =
                "Update company information";

            TxtCompanyName.Text =
                company.CompanyName;

            TxtCompanyAddress.Text =
                company.CompanyAddress;

            MTBTelephoneNumber.Text =
                company.CompanyTelephoneNumber;

            TxtCompanyEmail.Text =
                company.CompanyEmail;

            CmbCompanyType.SelectedValue =
                company.CompanyTypeId;

            List<CompanyOwnerHasCompany>
                companyOwnerHasCompanies =
                blCompanyOwnerHasCompany
                    .CompanyOwnerHasCompanyList()
                    .Where(x =>
                        x.CompanyId ==
                        company.CompanyId)
                    .ToList();

            foreach (DataGridViewRow row
                in DgvCompanyOwners.Rows)
            {
                int companyOwnerId =
                    Convert.ToInt32(row.Tag);

                CompanyOwnerHasCompany
                    companyOwnerHasCompany =
                    companyOwnerHasCompanies
                        .FirstOrDefault(x =>
                            x.CompanyOwnerId ==
                            companyOwnerId);

                if (companyOwnerHasCompany != null)
                {
                    row.Cells["Select"].Value =
                        true;

                    row.Cells["Percentage"].Value =
                        companyOwnerHasCompany
                            .CompanyOwnerPercent;
                }
            }
        }

        private void LoadCompanyTypes()
        {
            List<CompanyType> companyTypes = blCompanyType.CompanyTypeList();

            CmbCompanyType.DataSource = companyTypes;
            CmbCompanyType.DisplayMember = "CompanyTypeName";
            CmbCompanyType.ValueMember = "CompanyTypeId";
        }

        private void SetButtonsBorder()
        {
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatAppearance.BorderSize = 0;
        }

        private void LoadCompanyOwners()
        {
            DgvCompanyOwners.Columns.Clear();
            DgvCompanyOwners.Rows.Clear();

            DgvCompanyOwners.AutoGenerateColumns = false;
            DgvCompanyOwners.AllowUserToAddRows = false;
            DgvCompanyOwners.AllowUserToDeleteRows = false;
            DgvCompanyOwners.ReadOnly = false;
            DgvCompanyOwners.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            DgvCompanyOwners.MultiSelect = false;

            DataGridViewTextBoxColumn
                companyOwnerColumn =
                new DataGridViewTextBoxColumn();

            companyOwnerColumn.Name =
                "CompanyOwner";

            companyOwnerColumn.HeaderText =
                "Company Owner";

            companyOwnerColumn.ReadOnly =
                true;

            DgvCompanyOwners.Columns.Add(
                companyOwnerColumn);


            DataGridViewCheckBoxColumn
                selectColumn =
                new DataGridViewCheckBoxColumn();

            selectColumn.Name =
                "Select";

            selectColumn.HeaderText =
                "Select";

            selectColumn.ReadOnly =
                false;

            DgvCompanyOwners.Columns.Add(
                selectColumn);


            DataGridViewTextBoxColumn
                percentageColumn =
                new DataGridViewTextBoxColumn();

            percentageColumn.Name =
                "Percentage";

            percentageColumn.HeaderText =
                "Percentage (%)";

            percentageColumn.ReadOnly =
                false;

            DgvCompanyOwners.Columns.Add(
                percentageColumn);


            List<CompanyOwnerHasCompany>
                companyOwnerHasCompanies =
                new List<CompanyOwnerHasCompany>();

            if (company != null)
            {
                companyOwnerHasCompanies =
                    blCompanyOwnerHasCompany
                        .CompanyOwnerHasCompanyList()
                        .Where(x =>
                            x.CompanyId ==
                            company.CompanyId)
                        .ToList();
            }


            var companyOwners =
                blCompanyOwner
                    .CompanyOwnerList()
                    .Where(x =>
                    {
                        User user =
                            blUser.UserGetById(x.UserId);

                        return user != null &&
                               user.IsActive;
                    })
                    .ToList();


            foreach (CompanyOwner companyOwner
                in companyOwners)
            {
                CompanyOwnerHasCompany
                    companyOwnerHasCompany =
                    companyOwnerHasCompanies
                        .FirstOrDefault(x =>
                            x.CompanyOwnerId ==
                            companyOwner.CompanyOwnerId);

                bool isSelected =
                    companyOwnerHasCompany != null;

                decimal percentage =
                    companyOwnerHasCompany != null
                        ? companyOwnerHasCompany
                            .CompanyOwnerPercent
                        : 0;

                int rowIndex =
                    DgvCompanyOwners.Rows.Add(
                        companyOwner.CompanyOwnerName +
                        " " +
                        companyOwner.CompanyOwnerSurname,

                        isSelected,

                        percentage);

                DgvCompanyOwners.Rows[rowIndex].Tag =
                    companyOwner.CompanyOwnerId;
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CmbCompanyType.SelectedValue == null)
            {
                MessageBox.Show(
                    "Please select a company type.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            List<DataGridViewRow>
                selectedRows =
                DgvCompanyOwners.Rows
                    .Cast<DataGridViewRow>()
                    .Where(x =>
                        Convert.ToBoolean(
                            x.Cells["Select"].Value))
                    .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select at least one company owner.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            decimal totalPercentage = 0;

            foreach (DataGridViewRow row in selectedRows)
            {
                decimal percentage;

                if (!decimal.TryParse(
                    Convert.ToString(
                        row.Cells["Percentage"].Value),
                    out percentage))
                {
                    MessageBox.Show(
                        "Please enter a valid percentage for all selected company owners.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                if (percentage < 0 ||
                    percentage > 100)
                {
                    MessageBox.Show(
                        "Percentage must be between 0 and 100.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                totalPercentage += percentage;
            }

            if (totalPercentage != 100)
            {
                MessageBox.Show(
                    "The total company owner percentage must be 100%.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            Company companyToSave;

            if (company == null)
            {
                companyToSave =
                    new Company();
            }
            else
            {
                companyToSave =
                    company;
            }

            companyToSave.CompanyName =
                TxtCompanyName.Text.Trim();

            companyToSave.CompanyAddress =
                TxtCompanyAddress.Text.Trim();

            companyToSave.CompanyTelephoneNumber =
                MTBTelephoneNumber.Text.Trim();

            companyToSave.CompanyEmail =
                TxtCompanyEmail.Text.Trim();

            companyToSave.CompanyTypeId =
                Convert.ToInt32(
                    CmbCompanyType.SelectedValue);

            bool result;

            if (company == null)
            {
                result =
                    blCompany.CompanyAdd(
                        companyToSave);
            }
            else
            {
                result =
                    blCompany.CompanyUpdate(
                        companyToSave);
            }

            if (!result)
            {
                MessageBox.Show(
                    "Company could not be saved. Please check the entered information.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            if (company != null)
            {
                List<CompanyOwnerHasCompany>
                    existingCompanyOwnerHasCompanies =
                    blCompanyOwnerHasCompany
                        .CompanyOwnerHasCompanyList()
                        .Where(x =>
                            x.CompanyId ==
                            companyToSave.CompanyId)
                        .ToList();

                foreach (
                    CompanyOwnerHasCompany
                    existingCompanyOwnerHasCompany
                    in existingCompanyOwnerHasCompanies)
                {
                    blCompanyOwnerHasCompany
                        .CompanyOwnerHasCompanyDelete(
                            existingCompanyOwnerHasCompany
                                .CompanyOwnerHasCompanyId);
                }
            }

            foreach (DataGridViewRow row in selectedRows)
            {
                int companyOwnerId =
                    Convert.ToInt32(row.Tag);

                decimal percentage =
                    Convert.ToDecimal(
                        row.Cells["Percentage"].Value);

                CompanyOwnerHasCompany
                    companyOwnerHasCompany =
                    new CompanyOwnerHasCompany
                    {
                        CompanyId =
                            companyToSave.CompanyId,

                        CompanyOwnerId =
                            companyOwnerId,

                        CompanyOwnerPercent =
                            percentage
                    };

                if (!blCompanyOwnerHasCompany
                    .CompanyOwnerHasCompanyAdd(
                        companyOwnerHasCompany))
                {
                    MessageBox.Show(
                        "Company was saved, but company owner information could not be saved.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );

                    return;
                }
            }

            MessageBox.Show(
                company == null
                    ? "Company added successfully."
                    : "Company updated successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            DialogResult =
                DialogResult.OK;

            Close();
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


    }
}
