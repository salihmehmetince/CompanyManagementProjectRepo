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
    public partial class FrmProductOrServiceTypeForm : Form
    {
        private BLProductOrServiceType blProductOrService = new BLProductOrServiceType();
        public FrmProductOrServiceTypeForm()
        {
            InitializeComponent();
            setIcon();
            SetButtonsBorder();
            ListProductOrServicesTypes();
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

        private void ListProductOrServicesTypes()
        {
            List<ProductOrServiceType> productOrServicesTypes =
                blProductOrService.ProductOrServiceTypeList();

            var productOrServicesTypeList = productOrServicesTypes.Select(x => new
            {
                x.ProductOrServiceTypeId,
                x.ProductOrServiceTypeName
            }).ToList();

            DgvProductOrServiceTypes.DataSource =
                productOrServicesTypeList;

            LblRecordCount.Text =
                productOrServicesTypes.Count + " product or services types";
        }

        private ProductOrServiceType GetSelectedProductOrServiceType()
        {
            if (DgvProductOrServiceTypes.CurrentRow == null)
                return null;

            int productOrServicesTypeId = Convert.ToInt32(
                DgvProductOrServiceTypes.CurrentRow.Cells["ProductOrServiceTypeId"].Value
            );

            return blProductOrService
                .ProductOrServiceTypeGetById(productOrServicesTypeId);
        }

        private void SearchProductOrServicesTypes()
        {
            string searchText = TxtSearch.Text.Trim().ToLower();

            List<ProductOrServiceType> productOrServicesTypes =
                blProductOrService.ProductOrServiceTypeList();

            if (!string.IsNullOrEmpty(searchText))
            {
                productOrServicesTypes = productOrServicesTypes
                    .Where(x =>
                        x.ProductOrServiceTypeName.ToLower()
                            .Contains(searchText)
                    )
                    .ToList();
            }

            var productOrServicesTypeList = productOrServicesTypes.Select(x => new
            {
                x.ProductOrServiceTypeId,
                x.ProductOrServiceTypeName
            }).ToList();

            DgvProductOrServiceTypes.DataSource =
                productOrServicesTypeList;

            LblRecordCount.Text =
                productOrServicesTypes.Count + " product or services types";
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProductOrServicesTypes();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmProductOrServicesTypeAddEditForm frm =
    new FrmProductOrServicesTypeAddEditForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListProductOrServicesTypes();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ProductOrServiceType productOrServicesType =
    GetSelectedProductOrServiceType();

            if (productOrServicesType == null)
            {
                MessageBox.Show(
                    "Please select a product or services type.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            FrmProductOrServicesTypeAddEditForm frm =
                new FrmProductOrServicesTypeAddEditForm(
                    productOrServicesType);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListProductOrServicesTypes();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ProductOrServiceType productOrServicesType =
    GetSelectedProductOrServiceType();

            if (productOrServicesType == null)
            {
                MessageBox.Show(
                    "Please select a product or services type.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this product or services type?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            if (!blProductOrService.ProductOrServiceTypeDelete(
                productOrServicesType.ProductOrServiceTypeId))
            {
                MessageBox.Show(
                    "Product or services type could not be deleted.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                "Product or services type deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ListProductOrServicesTypes();
        }
    }
}
