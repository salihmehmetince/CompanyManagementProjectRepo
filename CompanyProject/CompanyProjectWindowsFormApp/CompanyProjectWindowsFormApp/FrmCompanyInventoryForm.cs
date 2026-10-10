using CompanyManagement.BusinessLogic;
using CompanyManagement.Entity;
using CompanyProjectWindowsFormApp.Helper;
using CompanyProjectWindowsFormApp.Helpers;
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
        private User user;
        private List<int> selectedCompanyIds;

        public FrmCompanyInventoryForm(
            User user,
            List<int> selectedCompanyIds)
        {
            this.user = user;
            this.selectedCompanyIds = selectedCompanyIds;

            InitializeComponent();
            setIcon();
            SetButtonsBorder();
            ListItems();
            CreateExportMenu();
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
            BtnExport.FlatAppearance.BorderSize = 0;
        }

        private void ListItems()
        {
            List<CompanyHasProductOrService>
                companyHasProductOrServices =
                blCompanyHasProductOrService
                    .CompanyHasProductOrServiceList()
                    .Where(x =>
                        selectedCompanyIds.Contains(
                            x.CompanyId))
                    .ToList();

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
            string searchText =
                TxtSearch.Text.Trim().ToLower();

            List<CompanyHasProductOrService>
                companyHasProductOrServices =
                blCompanyHasProductOrService
                    .CompanyHasProductOrServiceList()
                    .Where(x =>
                        selectedCompanyIds.Contains(
                            x.CompanyId))
                    .ToList();

            if (!string.IsNullOrEmpty(searchText))
            {
                companyHasProductOrServices =
                    companyHasProductOrServices
                        .Where(x =>
                            x.Company.CompanyName
                                .ToLower()
                                .Contains(searchText) ||
                            x.ProductOrService
                                .ProductOrServiceName
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
                new FrmCompanyHasItemsAddEditForm(
                    user,
                    selectedCompanyIds);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListItems();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            CompanyHasProductOrService item =
                GetSelectedItem();

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
                new FrmCompanyHasItemsAddEditForm(
                    user,
                    selectedCompanyIds,
                    item);

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
        private void CreateExportMenu()
        {
            ContextMenuStrip exportMenu = new ContextMenuStrip();

            ToolStripMenuItem excelItem = new ToolStripMenuItem("Excel'e Aktar");
            ToolStripMenuItem pdfItem = new ToolStripMenuItem("PDF'e Aktar");

            exportMenu.Items.Add(excelItem);
            exportMenu.Items.Add(pdfItem);

            excelItem.Click += (sender, e) =>
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
                    saveFileDialog.DefaultExt = "xlsx";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.FileName = "Company_Inventories.xlsx";
                    saveFileDialog.Title = "Export Company_Inventories";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            ExcelExportHelper.ExportToExcel(
                                DgvItems,
                                Enumerable.Range(0, DgvItems.Columns.Count).ToArray(),
                                saveFileDialog.FileName,
                                worksheetName: "Company_Inventories");

                            MessageBox.Show(
                                "Veriler Excel dosyasına aktarıldı.",
                                "Export Successful",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                                "Excel aktarımı başarısız oldu.\n" + ex.Message,
                                "Export Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
            };

            pdfItem.Click += (sender, e) =>
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Dosyası (*.pdf)|*.pdf";
                    saveFileDialog.DefaultExt = "pdf";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.FileName = "Company Inventories.pdf";
                    saveFileDialog.Title = "Export Company Inventories";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            PdfExportHelper.ExportToPdf(
                                DgvItems,
                                Enumerable.Range(0, DgvItems.Columns.Count).ToArray(),
                                saveFileDialog.FileName,
                                documentTitle: "Company Inventories");

                            MessageBox.Show(
                                "Veriler PDF dosyasına aktarıldı.",
                                "Export Successful",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                                "PDF aktarımı başarısız oldu.\n" + ex.Message,
                                "Export Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
            };


            BtnExport.Click += (sender, e) =>
            {
                exportMenu.Show(BtnExport, new Point(0, BtnExport.Height));
            };
        }

    }
}
