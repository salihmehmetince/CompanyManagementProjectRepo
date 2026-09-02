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
    public partial class FrmCompaniesForm : Form
    {
        private BLCompany blCompany = new BLCompany();

        public FrmCompaniesForm()
        {
            InitializeComponent();
            SetButtonsBorder();
            ListCompanies();
            setIcon();
        }

        private void setIcon()
        {
            this.Icon = Properties.Resources.icon_company;
        }

        private void ListCompanies()
        {
            List<Company> companies = blCompany.CompanyList();

            var companyList = companies.Select(x => new
            {
                x.CompanyId,
                x.CompanyName,
                x.CompanyAddress,
                x.CompanyTelephoneNumber,
                x.CompanyEmail,
                CompanyTypeName = x.CompanyType != null
                    ? x.CompanyType.CompanyTypeName
                    : ""
            }).ToList();

            DgvCompanies.DataSource = companyList;

            LblRecordCount.Text = companies.Count + " companies";
        }
        private void SetButtonsBorder()
        {
            BtnAdd.FlatAppearance.BorderSize = 0;
            BtnEdit.FlatAppearance.BorderSize = 0;
            BtnDelete.FlatAppearance.BorderSize = 0;
        }

        private Company GetSelectedCompany()
        {
            if (DgvCompanies.CurrentRow == null)
                return null;

            int companyId = Convert.ToInt32(
                DgvCompanies.CurrentRow.Cells["CompanyId"].Value
            );

            return blCompany.CompanyGetById(companyId);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Company company = GetSelectedCompany();

            if (company == null)
            {
                MessageBox.Show(
                    "Please select a company.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            FrmCompanyAddEditForm frmCompanyAddEdit = new FrmCompanyAddEditForm(company);

            if (frmCompanyAddEdit.ShowDialog() == DialogResult.OK)
            {
                ListCompanies();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmCompanyAddEditForm frmCompanyAddEdit = new FrmCompanyAddEditForm();

            if (frmCompanyAddEdit.ShowDialog() == DialogResult.OK)
            {
                ListCompanies();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Company company = GetSelectedCompany();

            if (company == null)
            {
                MessageBox.Show(
                    "Please select a company.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this company?",
                "Delete Company",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result != DialogResult.Yes)
                return;

            bool deleted = blCompany.CompanyDelete(company.CompanyId);

            if (deleted)
            {
                MessageBox.Show(
                    "Company deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ListCompanies();
            }
            else
            {
                MessageBox.Show(
                    "Company could not be deleted.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void SearchCompanies()
        {
            string searchText = TxtSearch.Text.Trim().ToLower();

            List<Company> companies = blCompany.CompanyList();

            if (!string.IsNullOrEmpty(searchText))
            {
                companies = companies
                    .Where(x =>
                        x.CompanyName.ToLower().Contains(searchText) ||
                        x.CompanyAddress.ToLower().Contains(searchText) ||
                        x.CompanyTelephoneNumber.ToLower().Contains(searchText) ||
                        x.CompanyEmail.ToLower().Contains(searchText) ||
                        (x.CompanyType != null &&
                         x.CompanyType.CompanyTypeName.ToLower().Contains(searchText))
                    )
                    .ToList();
            }

            var companyList = companies.Select(x => new
            {
                x.CompanyId,
                x.CompanyName,
                x.CompanyAddress,
                x.CompanyTelephoneNumber,
                x.CompanyEmail,
                CompanyTypeName = x.CompanyType != null
                    ? x.CompanyType.CompanyTypeName
                    : ""
            }).ToList();

            DgvCompanies.DataSource = companyList;

            LblRecordCount.Text = companies.Count + " companies";
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchCompanies();
        }
    }
}
