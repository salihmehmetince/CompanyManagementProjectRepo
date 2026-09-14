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
    public partial class FrmDepartmentTypesForm : Form
    {
        private BLDepartmentType blDepartmentType=new BLDepartmentType();
        public FrmDepartmentTypesForm()
        {
            InitializeComponent();
            setIcon();
            SetButtonsBorder();
            ListDepartmentTypes();
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

        private void ListDepartmentTypes()
        {
            List<DepartmentType> departmentTypes =
                blDepartmentType.DepartmentTypeList();

            var departmentTypeList = departmentTypes.Select(x => new
            {
                x.DepartmentTypeId,
                x.DepartmentName
            }).ToList();

            DgvDepartmentTypes.DataSource = departmentTypeList;

            LblRecordCount.Text =
                departmentTypes.Count + " department types";
        }

        private DepartmentType GetSelectedDepartmentType()
        {
            if (DgvDepartmentTypes.CurrentRow == null)
                return null;

            int departmentTypeId = Convert.ToInt32(
                DgvDepartmentTypes.CurrentRow.Cells["DepartmentTypeId"].Value
            );

            return blDepartmentType.DepartmentTypeGetById(departmentTypeId);
        }

        private void SearchDepartmentTypes()
        {
            string searchText = TxtSearch.Text.Trim().ToLower();

            List<DepartmentType> departmentTypes =
                blDepartmentType.DepartmentTypeList();

            if (!string.IsNullOrEmpty(searchText))
            {
                departmentTypes = departmentTypes
                    .Where(x =>
                        x.DepartmentName.ToLower()
                            .Contains(searchText)
                    )
                    .ToList();
            }

            var departmentTypeList = departmentTypes.Select(x => new
            {
                x.DepartmentTypeId,
                x.DepartmentName
            }).ToList();

            DgvDepartmentTypes.DataSource = departmentTypeList;

            LblRecordCount.Text =
                departmentTypes.Count + " department types";
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchDepartmentTypes();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmDepartmentTypeAddEditForm frm =
    new FrmDepartmentTypeAddEditForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListDepartmentTypes();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            DepartmentType departmentType = GetSelectedDepartmentType();

            if (departmentType == null)
            {
                MessageBox.Show(
                    "Please select a department type.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            FrmDepartmentTypeAddEditForm frm =
                new FrmDepartmentTypeAddEditForm(departmentType);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListDepartmentTypes();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DepartmentType departmentType = GetSelectedDepartmentType();

            if (departmentType == null)
            {
                MessageBox.Show(
                    "Please select a department type.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this department type?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            if (!blDepartmentType.DepartmentTypeDelete(
                departmentType.DepartmentTypeId))
            {
                MessageBox.Show(
                    "Department type could not be deleted.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                "Department type deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ListDepartmentTypes();
        }
    }
}
