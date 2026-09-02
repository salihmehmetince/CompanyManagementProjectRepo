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
    public partial class FrmCompanyAddEditForm : Form
    {
        private BLCompany blCompany = new BLCompany();
        private BLCompanyType blCompanyType = new BLCompanyType();

        private Company company;
        public FrmCompanyAddEditForm(Company company = null)
        {
            InitializeComponent();
            SetButtonsBorder();
            this.company = company;

            LoadCompanyTypes();

            if (company != null)
            {
                LoadCompany();
            }
        }

        private void LoadCompany()
        {
            LblTitle.Text = "Edit Company";
            LblDescription.Text = "Update company information";

            TxtCompanyName.Text = company.CompanyName;
            TxtCompanyAddress.Text = company.CompanyAddress;
            MTBTelephoneNumber.Text = company.CompanyTelephoneNumber;
            TxtCompanyEmail.Text = company.CompanyEmail;

            CmbCompanyType.SelectedValue = company.CompanyTypeId;
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

            Company companyToSave;

            if (company == null)
            {
                // Yeni şirket
                companyToSave = new Company();
            }
            else
            {
                // Mevcut şirket
                companyToSave = company;
            }

            companyToSave.CompanyName = TxtCompanyName.Text.Trim();
            companyToSave.CompanyAddress = TxtCompanyAddress.Text.Trim();
            companyToSave.CompanyTelephoneNumber = MTBTelephoneNumber.Text.Trim();
            companyToSave.CompanyEmail = TxtCompanyEmail.Text.Trim();
            companyToSave.CompanyTypeId = Convert.ToInt32(CmbCompanyType.SelectedValue);

            bool result;

            if (company == null)
            {
                result = blCompany.CompanyAdd(companyToSave);
            }
            else
            {
                result = blCompany.CompanyUpdate(companyToSave);
            }

            if (result)
            {
                MessageBox.Show(
                    company == null
                        ? "Company added successfully."
                        : "Company updated successfully.",
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
                    "Company could not be saved. Please check the entered information.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


    }
}
