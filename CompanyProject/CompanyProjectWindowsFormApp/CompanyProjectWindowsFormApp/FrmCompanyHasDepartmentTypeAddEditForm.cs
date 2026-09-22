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
    public partial class FrmCompanyHasDepartmentTypeAddEditForm : Form
    {
        private BLCompanyHasDepartmentType blCompanyHasDepartmentType=new BLCompanyHasDepartmentType();
        private BLCompany blCompany=new BLCompany();
        private BLDepartmentType blDepartmentType=new BLDepartmentType();
        private CompanyHasDepartmentType companyHasDepartmentType;
        public FrmCompanyHasDepartmentTypeAddEditForm(CompanyHasDepartmentType companyHasDepartmentType=null)
        {
            InitializeComponent();
            SetButtonsBorder();
            LoadCompanies();
            LoadDepartments();
            this.companyHasDepartmentType = companyHasDepartmentType;
            if (companyHasDepartmentType != null) 
            {
                LoadCompanyHasDepartment();
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

        private void LoadDepartments()
        {
            List<DepartmentType> departments=
                blDepartmentType.DepartmentTypeList();
            CmbDepartments.DataSource = departments;
            CmbDepartments.DisplayMember = "DepartmentName";
            CmbDepartments.ValueMember = "DepartmentTypeId";
        }


        private void LoadCompanyHasDepartment()
        {
            LblTitle.Text =
                "Edit Company Department";

            LblDescription.Text =
                "Update company department information";

            CmbCompany.SelectedValue =
                companyHasDepartmentType.CompanyId;

            CmbDepartments.SelectedValue =
                companyHasDepartmentType.DepartmentTypeId;

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

            if (CmbDepartments.SelectedValue == null)
            {
                MessageBox.Show(
                    "Please select a department type.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            CompanyHasDepartmentType
                companyHasDepartmentTypeToSave;

            if (companyHasDepartmentType == null)
            {
                // Yeni şirket departmanı
                companyHasDepartmentTypeToSave =
                    new CompanyHasDepartmentType();
            }
            else
            {
                // Mevcut şirket departmanı
                companyHasDepartmentTypeToSave =
                    companyHasDepartmentType;
            }

            companyHasDepartmentTypeToSave.CompanyId =
                Convert.ToInt32(CmbCompany.SelectedValue);

            companyHasDepartmentTypeToSave.DepartmentTypeId =
                Convert.ToInt32(CmbDepartments.SelectedValue);

            bool result;

            if (companyHasDepartmentType == null)
            {
                result =
                    blCompanyHasDepartmentType
                        .CompanyHasDepartmentTypeAdd(
                            companyHasDepartmentTypeToSave);
            }
            else
            {
                result =
                    blCompanyHasDepartmentType
                        .CompanyHasDepartmentTypeUpdate(
                            companyHasDepartmentTypeToSave);
            }

            if (result)
            {
                MessageBox.Show(
                    companyHasDepartmentType == null
                        ? "Company department added successfully."
                        : "Company department updated successfully.",
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
                    "Company department could not be saved. Please check the entered information.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
