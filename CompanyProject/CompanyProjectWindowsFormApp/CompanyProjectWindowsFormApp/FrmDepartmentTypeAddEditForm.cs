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
    public partial class FrmDepartmentTypeAddEditForm : Form
    {
        private BLDepartmentType blDepartmentType=new BLDepartmentType();
        private DepartmentType departmentType;
        public FrmDepartmentTypeAddEditForm(DepartmentType departmentType=null)
        {
            InitializeComponent();
            SetButtonsBorder();
            this.departmentType = departmentType;
            if (departmentType != null) 
            {
                LoadDepartmentType();
            }
        }

        private void SetButtonsBorder()
        {
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatAppearance.BorderSize = 0;
        }

        private void LoadDepartmentType()
        {
            LblTitle.Text = "Edit Department Type";
            LblDescription.Text = "Update department type information";

            TxtName.Text =
                departmentType.DepartmentName;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            DepartmentType departmentTypeToSave;

            if (departmentType == null)
            {
                // Yeni departman türü
                departmentTypeToSave = new DepartmentType();
            }
            else
            {
                // Mevcut departman türü
                departmentTypeToSave = departmentType;
            }

            departmentTypeToSave.DepartmentName =
                TxtName.Text.Trim();

            bool result;

            if (departmentType == null)
            {
                result = blDepartmentType.DepartmentTypeAdd(
                    departmentTypeToSave);
            }
            else
            {
                result = blDepartmentType.DepartmentTypeUpdate(
                    departmentTypeToSave);
            }

            if (result)
            {
                MessageBox.Show(
                    departmentType == null
                        ? "Department type added successfully."
                        : "Department type updated successfully.",
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
                    "Department type could not be saved. Please check the entered information.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
