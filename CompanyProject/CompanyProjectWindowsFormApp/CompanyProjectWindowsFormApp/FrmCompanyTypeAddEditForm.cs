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
    public partial class FrmCompanyTypeAddEditForm : Form
    {
        private BLCompanyType blCompanyType=new BLCompanyType();
        private CompanyType companyType;
        public FrmCompanyTypeAddEditForm(CompanyType companyType=null)
        {
            InitializeComponent();
            SetButtonsBorder();
            this.companyType = companyType;
            if (companyType != null) 
            {
                LoadCompanyType();
            }
        }

        private void SetButtonsBorder()
        {
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatAppearance.BorderSize = 0;
        }

        private void LoadCompanyType()
        {
            LblTitle.Text = "Edit Company Type";
            LblDescription.Text = "Update company type information";

            TxtName.Text =
                companyType.CompanyTypeName;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            CompanyType companyTypeToSave;

            if (companyType == null)
            {
                // Yeni şirket türü
                companyTypeToSave = new CompanyType();
            }
            else
            {
                // Mevcut şirket türü
                companyTypeToSave = companyType;
            }

            companyTypeToSave.CompanyTypeName =
                TxtName.Text.Trim();

            bool result;

            if (companyType == null)
            {
                result = blCompanyType.CompanyTypeAdd(
                    companyTypeToSave);
            }
            else
            {
                result = blCompanyType.CompanyTypeUpdate(
                    companyTypeToSave);
            }

            if (result)
            {
                MessageBox.Show(
                    companyType == null
                        ? "Company type added successfully."
                        : "Company type updated successfully.",
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
                    "Company type could not be saved. Please check the entered information.",
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
