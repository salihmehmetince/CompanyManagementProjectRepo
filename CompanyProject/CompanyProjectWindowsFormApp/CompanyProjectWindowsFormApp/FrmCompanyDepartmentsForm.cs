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
    public partial class FrmCompanyDepartmentsForm : Form
    {
        private BLDepartmentType blDepartmentType = new BLDepartmentType();
        private BLCompany blCompany=new BLCompany();
        private BLCompanyHasDepartmentType blCompanyHasDepartmentType=new BLCompanyHasDepartmentType();
        public FrmCompanyDepartmentsForm()
        {
            InitializeComponent();
            setIcon();
            SetButtonsBorder();
            ListCompanyHasDepartmentTypes();
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

        private void ListCompanyHasDepartmentTypes()
        {
            List<CompanyHasDepartmentType> companyHasDepartmentTypes =
                blCompanyHasDepartmentType
                    .CompanyHasDepartmentTypeList();

            var companyHasDepartmentTypeList =
                companyHasDepartmentTypes.Select(x => new
                {
                    x.CompanyHasDepartmentTypeId,
                    CompanyName =
                        x.Company.CompanyName,
                    DepartmentName =
                        x.DepartmentType.DepartmentName
                }).ToList();

            DgvCompanyDepartmentTypes.DataSource =
                companyHasDepartmentTypeList;

            LblRecordCount.Text =
                companyHasDepartmentTypes.Count +
                " company department records";
        }

        private CompanyHasDepartmentType
    GetSelectedCompanyHasDepartmentType()
        {
            if (DgvCompanyDepartmentTypes.CurrentRow == null)
                return null;

            int companyHasDepartmentTypeId =
                Convert.ToInt32(
                    DgvCompanyDepartmentTypes
                        .CurrentRow
                        .Cells["CompanyHasDepartmentTypeId"]
                        .Value
                );

            return blCompanyHasDepartmentType
                .CompanyHasDepartmentTypeGetById(
                    companyHasDepartmentTypeId);
        }

        private void SearchCompanyHasDepartmentTypes()
        {
            string searchText =
                TxtSearch.Text.Trim().ToLower();

            List<CompanyHasDepartmentType>
                companyHasDepartmentTypes =
                blCompanyHasDepartmentType
                    .CompanyHasDepartmentTypeList();

            if (!string.IsNullOrEmpty(searchText))
            {
                companyHasDepartmentTypes =
                    companyHasDepartmentTypes
                        .Where(x =>
                            x.Company.CompanyName
                                .ToLower()
                                .Contains(searchText)
                            ||
                            x.DepartmentType.DepartmentName
                                .ToLower()
                                .Contains(searchText)
                        )
                        .ToList();
            }

            var companyHasDepartmentTypeList =
                companyHasDepartmentTypes.Select(x => new
                {
                    x.CompanyHasDepartmentTypeId,

                    CompanyName =
                        x.Company.CompanyName,

                    DepartmentName =
                        x.DepartmentType.DepartmentName

                }).ToList();

            DgvCompanyDepartmentTypes.DataSource =
                companyHasDepartmentTypeList;

            LblRecordCount.Text =
                companyHasDepartmentTypes.Count +
                " company department records";
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchCompanyHasDepartmentTypes();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmCompanyHasDepartmentTypeAddEditForm frm =
    new FrmCompanyHasDepartmentTypeAddEditForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListCompanyHasDepartmentTypes();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            CompanyHasDepartmentType companyHasDepartmentType =
    GetSelectedCompanyHasDepartmentType();

            if (companyHasDepartmentType == null)
            {
                MessageBox.Show(
                    "Please select a company department.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            FrmCompanyHasDepartmentTypeAddEditForm frm =
                new FrmCompanyHasDepartmentTypeAddEditForm(
                    companyHasDepartmentType);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListCompanyHasDepartmentTypes();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            CompanyHasDepartmentType companyHasDepartmentType =
    GetSelectedCompanyHasDepartmentType();

            if (companyHasDepartmentType == null)
            {
                MessageBox.Show(
                    "Please select a company department.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this company department?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            if (!blCompanyHasDepartmentType.CompanyHasDepartmentTypeDelete(
                companyHasDepartmentType.CompanyHasDepartmentTypeId))
            {
                MessageBox.Show(
                    "Company department could not be deleted.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                "Company department deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ListCompanyHasDepartmentTypes();
        }
    }
}
