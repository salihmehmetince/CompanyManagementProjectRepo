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
    public partial class FrmCompanyInventoryForm : Form
    {
        private BLCompanyHasProductOrService blCompanyHasProductOrService = new BLCompanyHasProductOrService();
        public FrmCompanyInventoryForm()
        {
            InitializeComponent();
            setIcon();
            SetButtonsBorder();
            ListItems();
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

        private void ListItems()
        {
            List<CompanyHasProductOrService> companyHasProductOrServices =
                blCompanyHasProductOrService
                    .CompanyHasProductOrServiceList();

            var companyHasProductOrServiceList =
                companyHasProductOrServices.Select(x => new
                {
                    x.CompanyHasProductOrServiceId,
                    x.Company.CompanyName,
                    x.ProductOrService.ProductOrServiceName,
                    x.CompanyHasProductOrServiceQuantity,
                    x.CompanyHasProductOrServicePrice
                }).ToList();

            DgvItems.DataSource =
                companyHasProductOrServiceList;

            LblRecordCount.Text =
                companyHasProductOrServices.Count +
                " company products/services";
        }

        private CompanyHasProductOrService GetSelectedItem()
        {
            if (DgvItems.CurrentRow == null)
                return null;

            int companyHasProductOrServiceId = Convert.ToInt32(
                DgvItems.CurrentRow.Cells[
                    "CompanyHasProductOrServiceId"
                ].Value
            );

            return blCompanyHasProductOrService
                .CompanyHasProductOrServiceGetById(
                    companyHasProductOrServiceId);
        }

        private void SearchItems()
        {
            string searchText = TxtSearch.Text.Trim().ToLower();

            List<CompanyHasProductOrService> companyHasProductOrServices =
                blCompanyHasProductOrService
                    .CompanyHasProductOrServiceList();

            if (!string.IsNullOrEmpty(searchText))
            {
                companyHasProductOrServices =
                    companyHasProductOrServices
                        .Where(x =>
                            x.Company.CompanyName
                                .ToLower()
                                .Contains(searchText) ||
                            x.ProductOrService.ProductOrServiceName
                                .ToLower()
                                .Contains(searchText) ||
                            x.CompanyHasProductOrServiceQuantity
                                .ToString()
                                .Contains(searchText) ||
                            x.CompanyHasProductOrServicePrice
                                .ToString()
                                .Contains(searchText)
                        )
                        .ToList();
            }

            var companyHasProductOrServiceList =
                companyHasProductOrServices.Select(x => new
                {
                    x.CompanyHasProductOrServiceId,
                    x.Company.CompanyName,
                    x.ProductOrService.ProductOrServiceName,
                    x.CompanyHasProductOrServiceQuantity,
                    x.CompanyHasProductOrServicePrice
                }).ToList();

            DgvItems.DataSource =
                companyHasProductOrServiceList;

            LblRecordCount.Text =
                companyHasProductOrServices.Count +
                " company products/services";
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchItems();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmCompanyHasItemsAddEditForm frm =
    new FrmCompanyHasItemsAddEditForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListItems();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            CompanyHasProductOrService item = GetSelectedItem();

            if (item == null)
            {
                MessageBox.Show(
                    "Please select an item.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            FrmCompanyHasItemsAddEditForm frm =
                new FrmCompanyHasItemsAddEditForm(item);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListItems();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            CompanyHasProductOrService item = GetSelectedItem();

            if (item == null)
            {
                MessageBox.Show(
                    "Please select an item.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this item?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            if (!blCompanyHasProductOrService
                .CompanyHasProductOrServiceDelete(
                    item.CompanyHasProductOrServiceId))
            {
                MessageBox.Show(
                    "Item could not be deleted.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                "Item deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ListItems();
        }
    }
}
