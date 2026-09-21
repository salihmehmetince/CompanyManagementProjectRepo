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
    public partial class FrmCompanyHasItemsAddEditForm : Form
    {
        private BLCompanyHasProductOrService blCompanyHasProductOrService=new BLCompanyHasProductOrService();
        private CompanyHasProductOrService companyHasItem;
        private BLCompany blCompany=new BLCompany();
        private BLProductOrService blProductOrService=new BLProductOrService();
        public FrmCompanyHasItemsAddEditForm(CompanyHasProductOrService companyHasItem=null)
        {
            InitializeComponent();
            this.companyHasItem = companyHasItem;
            SetButtonsBorder();
            LoadCompanies();
            LoadProductOrServices();
            if(companyHasItem!=null)
            {
                LoadCompanyHasItem();
            }
        }

        private void SetButtonsBorder()
        {
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatAppearance.BorderSize = 0;
        }

        private void LoadCompanies()
        {
            List<Company> companies =
                blCompany.CompanyList();

            CmbCompany.DataSource = companies;
            CmbCompany.DisplayMember = "CompanyName";
            CmbCompany.ValueMember = "CompanyId";
        }

        private void LoadProductOrServices()
        {
            List<ProductOrService> productOrServices =
                blProductOrService.ProductOrServiceList();

            CmbProductOrService.DataSource = productOrServices;
            CmbProductOrService.DisplayMember = "ProductOrServiceName";
            CmbProductOrService.ValueMember = "ProductOrServiceId";
        }

        private void LoadCompanyHasItem()
        {
            LblTitle.Text = "Edit Company Product / Service";
            LblDescription.Text = "Update company product / service information";

            CmbCompany.SelectedValue =
                companyHasItem.CompanyId;

            CmbProductOrService.SelectedValue =
                companyHasItem.ProductOrServiceId;

            TxtQuantity.Text =
                companyHasItem
                    .CompanyHasProductOrServiceQuantity
                    .ToString();

            TxtPrice.Text =
                companyHasItem
                    .CompanyHasProductOrServicePrice
                    .ToString();
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

            if (CmbProductOrService.SelectedValue == null)
            {
                MessageBox.Show(
                    "Please select a product or service.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            CompanyHasProductOrService companyHasProductOrServiceToSave;

            if (companyHasItem == null)
            {
                companyHasProductOrServiceToSave =
                    new CompanyHasProductOrService();
            }
            else
            {
                companyHasProductOrServiceToSave =
                    companyHasItem;
            }

            companyHasProductOrServiceToSave.CompanyId =
                Convert.ToInt32(CmbCompany.SelectedValue);

            companyHasProductOrServiceToSave.ProductOrServiceId =
                Convert.ToInt32(CmbProductOrService.SelectedValue);

            companyHasProductOrServiceToSave.CompanyHasProductOrServiceQuantity =
                Convert.ToDecimal(TxtQuantity.Text);

            companyHasProductOrServiceToSave.CompanyHasProductOrServicePrice =
                Convert.ToDecimal(TxtPrice.Text);

            bool result;

            if (companyHasItem == null)
            {
                result =
                    blCompanyHasProductOrService
                        .CompanyHasProductOrServiceAdd(
                            companyHasProductOrServiceToSave);
            }
            else
            {
                result =
                    blCompanyHasProductOrService
                        .CompanyHasProductOrServiceUpdate(
                            companyHasProductOrServiceToSave);
            }

            if (result)
            {
                MessageBox.Show(
                    companyHasItem == null
                        ? "Company product / service added successfully."
                        : "Company product / service updated successfully.",
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
                    "Company product / service could not be saved. Please check the entered information.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
