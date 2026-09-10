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
    public partial class FrmProductOrServiceForm : Form
    {

        private BLProductOrService blProductOrService = new BLProductOrService();
        public FrmProductOrServiceForm()
        {
            InitializeComponent();
            setIcon();
            SetButtonsBorder();
            ListProductOrServices();
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

        private void ListProductOrServices()
        {
            List<ProductOrService> productOrServices =
                blProductOrService.ProductOrServiceList();

            var productOrServiceList = productOrServices.Select(x => new
            {
                x.ProductOrServiceId,
                x.ProductOrServiceName,
                x.IsProductOrService,
                x.ProductOrServiceType.ProductOrServiceTypeName,
                ProductOrServiceImage =
                    x.ProductOrServiceImage != null &&
                    x.ProductOrServiceImage.Length > 0
                        ? ByteArrayToImage(x.ProductOrServiceImage)
                        : null
            }).ToList();

            DgvProductOrServices.DataSource = productOrServiceList;

            SetProductOrServiceGrid();

            LblRecordCount.Text =
                productOrServices.Count + " ürün / hizmet";
        }

        private ProductOrService GetSelectedProductOrService()
        {
            if (DgvProductOrServices.CurrentRow == null)
                return null;

            int productOrServiceId = Convert.ToInt32(
                DgvProductOrServices.CurrentRow.Cells["ProductOrServiceId"].Value
            );

            return blProductOrService.ProductOrServiceGetById(
                productOrServiceId
            );
        }

        private void SearchProductOrServices()
        {
            string searchText = TxtSearch.Text.Trim().ToLower();

            List<ProductOrService> productOrServices =
                blProductOrService.ProductOrServiceList();

            if (!string.IsNullOrEmpty(searchText))
            {
                productOrServices = productOrServices
                    .Where(x =>
                        x.ProductOrServiceName.ToLower().Contains(searchText) ||
                        (x.ProductOrServiceType != null &&
                         x.ProductOrServiceType.ProductOrServiceTypeName
                            .ToLower()
                            .Contains(searchText)) ||
                        (x.IsProductOrService
                            ? "ürün"
                            : "hizmet")
                            .Contains(searchText)
                    )
                    .ToList();
            }

            var productOrServiceList = productOrServices.Select(x => new
            {
                x.ProductOrServiceId,
                x.ProductOrServiceName,
                x.IsProductOrService,
                x.ProductOrServiceType.ProductOrServiceTypeName,
                ProductOrServiceImage =
                    x.ProductOrServiceImage != null &&
                    x.ProductOrServiceImage.Length > 0
                        ? ByteArrayToImage(x.ProductOrServiceImage)
                        : null
            }).ToList();

            DgvProductOrServices.DataSource = productOrServiceList;

            SetProductOrServiceGrid();

            LblRecordCount.Text =
                productOrServices.Count + " ürün / hizmet";
        }
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProductOrServices();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmProductOrServiceAddEditForm frm =
    new FrmProductOrServiceAddEditForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListProductOrServices();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ProductOrService productOrService = GetSelectedProductOrService();

            if (productOrService == null)
            {
                MessageBox.Show(
                    "Please select a product or service.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            FrmProductOrServiceAddEditForm frm =
                new FrmProductOrServiceAddEditForm(productOrService);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListProductOrServices();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ProductOrService productOrService = GetSelectedProductOrService();

            if (productOrService == null)
            {
                MessageBox.Show(
                    "Please select a product or service.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this product or service?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            if (!blProductOrService.ProductOrServiceDelete(
                productOrService.ProductOrServiceId))
            {
                MessageBox.Show(
                    "Product or service could not be deleted.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                "Product or service deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ListProductOrServices();
        }

        private void SetProductOrServiceGrid()
        {
            if (DgvProductOrServices.Columns["ProductOrServiceImage"] != null)
            {
                DataGridViewImageColumn imageColumn =
                    DgvProductOrServices.Columns["ProductOrServiceImage"]
                    as DataGridViewImageColumn;

                if (imageColumn != null)
                {
                    imageColumn.ImageLayout =
                        DataGridViewImageCellLayout.Zoom;

                    imageColumn.Width = 80;
                }
            }

            DgvProductOrServices.RowTemplate.Height = 80;
        }

        private Image ByteArrayToImage(byte[] imageBytes)
        {
            using (MemoryStream ms = new MemoryStream(imageBytes))
            using (Image image = Image.FromStream(ms))
            {
                return new Bitmap(image);
            }
        }
    }
}
