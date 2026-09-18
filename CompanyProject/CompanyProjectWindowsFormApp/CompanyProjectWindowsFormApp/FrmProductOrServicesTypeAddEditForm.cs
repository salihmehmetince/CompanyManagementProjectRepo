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
    public partial class FrmProductOrServicesTypeAddEditForm : Form
    {
        private BLProductOrServiceType blProductOrService = new BLProductOrServiceType();
        private ProductOrServiceType productOrServiceType;
        public FrmProductOrServicesTypeAddEditForm(ProductOrServiceType productOrServiceType=null)
        {
            InitializeComponent();
            SetButtonsBorder();
            this.productOrServiceType = productOrServiceType;
            if (productOrServiceType != null) 
            {
                LoadProductOrServicesType();
            }
        }

        private void SetButtonsBorder()
        {
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatAppearance.BorderSize = 0;
        }

        private void LoadProductOrServicesType()
        {
            LblTitle.Text = "Edit Product or Services Type";
            LblDescription.Text =
                "Update product or services type information";

            TxtName.Text =
                productOrServiceType.ProductOrServiceTypeName;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            ProductOrServiceType productOrServicesTypeToSave;

            if (productOrServiceType == null)
            {
                // Yeni ürün veya hizmet türü
                productOrServicesTypeToSave =
                    new ProductOrServiceType();
            }
            else
            {
                // Mevcut ürün veya hizmet türü
                productOrServicesTypeToSave =
                    productOrServiceType;
            }

            productOrServicesTypeToSave.ProductOrServiceTypeName =
                TxtName.Text.Trim();

            bool result;

            if (productOrServiceType == null)
            {
                result =
                    blProductOrService.ProductOrServiceTypeAdd(
                        productOrServicesTypeToSave);
            }
            else
            {
                result =
                    blProductOrService.ProductOrServiceTypeUpdate(
                        productOrServicesTypeToSave);
            }

            if (result)
            {
                MessageBox.Show(
                    productOrServiceType == null
                        ? "Product or services type added successfully."
                        : "Product or services type updated successfully.",
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
                    "Product or services type could not be saved. Please check the entered information.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
