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
    public partial class FrmCompanyTypesForm : Form
    {
        private BLCompanyType blCompanyType=new BLCompanyType();
        public FrmCompanyTypesForm()
        {
            InitializeComponent();
            setIcon();
            SetButtonsBorder();
            ListCompanyTypes();
        }

        private void setIcon()
        {
            this.Icon = Properties.Resources.icon_company;
        }


        private void SetButtonsBorder()
        {
            BtnAdd.FlatAppearance.BorderSize = 0;
            BtnEdit.FlatAppearance.BorderSize = 0;
            BtnDelete.FlatAppearance.BorderSize = 0;
        }

        private void ListCompanyTypes()
        {
            List<CompanyType> companyTypes =
                blCompanyType.CompanyTypeList();

            var companyTypeList = companyTypes.Select(x => new
            {
                x.CompanyTypeId,
                x.CompanyTypeName
            }).ToList();

            DgvCompanyTypes.DataSource = companyTypeList;

            LblRecordCount.Text =
                companyTypes.Count + " company types";
        }

        private CompanyType GetSelectedCompanyType()
        {
            if (DgvCompanyTypes.CurrentRow == null)
                return null;

            int companyTypeId = Convert.ToInt32(
                DgvCompanyTypes.CurrentRow.Cells["CompanyTypeId"].Value
            );

            return blCompanyType.CompanyTypeGetById(companyTypeId);
        }

        private void SearchCompanyTypes()
        {
            string searchText = TxtSearch.Text.Trim().ToLower();

            List<CompanyType> companyTypes =
                blCompanyType.CompanyTypeList();

            if (!string.IsNullOrEmpty(searchText))
            {
                companyTypes = companyTypes
                    .Where(x =>
                        x.CompanyTypeName.ToLower()
                            .Contains(searchText)
                    )
                    .ToList();
            }

            var companyTypeList = companyTypes.Select(x => new
            {
                x.CompanyTypeId,
                x.CompanyTypeName
            }).ToList();

            DgvCompanyTypes.DataSource = companyTypeList;

            LblRecordCount.Text =
                companyTypes.Count + " company types";
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchCompanyTypes();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmCompanyTypeAddEditForm frm =
    new FrmCompanyTypeAddEditForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListCompanyTypes();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            CompanyType companyType = GetSelectedCompanyType();

            if (companyType == null)
            {
                MessageBox.Show(
                    "Please select a company type.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            FrmCompanyTypeAddEditForm frm =
                new FrmCompanyTypeAddEditForm(companyType);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListCompanyTypes();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            CompanyType companyType = GetSelectedCompanyType();

            if (companyType == null)
            {
                MessageBox.Show(
                    "Please select a company type.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this company type?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            if (!blCompanyType.CompanyTypeDelete(companyType.CompanyTypeId))
            {
                MessageBox.Show(
                    "Company type could not be deleted.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                "Company type deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ListCompanyTypes();
        }
    }
}
