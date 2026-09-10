using CompanyManagement.BusinessLogic;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyProjectWindowsFormApp
{
    public partial class FrmProductOrServiceAddEditForm : Form
    {
        private BLProductOrService blProductOrService =
    new BLProductOrService();

        private BLProductOrServiceType blProductOrServiceType =
            new BLProductOrServiceType();

        private ProductOrService productOrService;

        private byte[] selectedImage;
        public FrmProductOrServiceAddEditForm(ProductOrService productOrService=null)
        {
            InitializeComponent();
            SetButtonsBorder();
            this.productOrService = productOrService;
            LoadProductOrServiceTypes();
            if(productOrService != null )
            {
                LoadProductOrService();
            }

        }

        private void SetButtonsBorder()
        {
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatAppearance.BorderSize = 0;
        }

        private void LoadProductOrServiceTypes()
        {
            List<ProductOrServiceType> productOrServiceTypes =
                blProductOrServiceType.ProductOrServiceTypeList();

            CmbProductOrServiceType.DataSource = productOrServiceTypes;
            CmbProductOrServiceType.DisplayMember = "ProductOrServiceTypeName";
            CmbProductOrServiceType.ValueMember = "ProductOrServiceTypeId";
        }

        private void LoadProductOrService()
        {
            LblTitle.Text = "Edit Product / Service";
            LblDescription.Text = "Update product or service information";

            TxtName.Text =
                productOrService.ProductOrServiceName;

            CmbProductOrServiceType.SelectedValue =
                productOrService.ProductOrServiceTypeId;

            if (productOrService.IsProductOrService)
                RBIsProduct.Checked = true;
            else
                RBIsService.Checked = true;

            if (productOrService.ProductOrServiceImage != null &&
                productOrService.ProductOrServiceImage.Length > 0)
            {
                selectedImage =
                    productOrService.ProductOrServiceImage;

                using (MemoryStream ms =
                    new MemoryStream(selectedImage))
                using (Image image = Image.FromStream(ms))
                {
                    PBProductOrServiceImage.Image =
                        new Bitmap(image);
                }
            }
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CmbProductOrServiceType.SelectedValue == null)
            {
                MessageBox.Show(
                    "Please select a product or service type.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            ProductOrService productOrServiceToSave;

            if (productOrService == null)
            {
                // Yeni ürün / hizmet
                productOrServiceToSave = new ProductOrService();
            }
            else
            {
                // Mevcut ürün / hizmet
                productOrServiceToSave = productOrService;
            }

            productOrServiceToSave.ProductOrServiceName =
                TxtName.Text.Trim();

            productOrServiceToSave.IsProductOrService =
                RBIsProduct.Checked;

            productOrServiceToSave.ProductOrServiceTypeId =
                Convert.ToInt32(CmbProductOrServiceType.SelectedValue);

            productOrServiceToSave.ProductOrServiceImage =
                selectedImage;

            bool result;

            if (productOrService == null)
            {
                result = blProductOrService.ProductOrServiceAdd(
                    productOrServiceToSave);
            }
            else
            {
                result = blProductOrService.ProductOrServiceUpdate(
                    productOrServiceToSave);
            }

            if (result)
            {
                MessageBox.Show(
                    productOrService == null
                        ? "Product or service added successfully."
                        : "Product or service updated successfully.",
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
                    "Product or service could not be saved. Please check the entered information.",
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

        private void BtnChooseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Product / Service Image";
                openFileDialog.Filter =
                    "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                selectedImage =
                    File.ReadAllBytes(openFileDialog.FileName);

                using (MemoryStream ms =
                    new MemoryStream(selectedImage))
                using (Image image = Image.FromStream(ms))
                {
                    PBProductOrServiceImage.Image =
                        new Bitmap(image);
                }
            }

        }
    }
}
