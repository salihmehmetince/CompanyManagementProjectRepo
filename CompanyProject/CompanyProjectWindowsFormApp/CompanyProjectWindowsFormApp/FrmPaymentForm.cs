using CompanyManagement.BusinessLogic;
using CompanyManagement.DataAccess;
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
    public partial class FrmPaymentForm : Form
    {
        private BLCustomerBuysCompanyHasProductOrService blCustomerBuysCompanyHasProductOrService = new BLCustomerBuysCompanyHasProductOrService();
        private User user;
        private List<int> selectedCompanyIds;
        private BLCompanyHasProductOrService blCompanyHasProductOrService = new BLCompanyHasProductOrService();

        public FrmPaymentForm(
            User user,
            List<int> selectedCompanyIds)
        {
            this.user = user;
            this.selectedCompanyIds = selectedCompanyIds;

            InitializeComponent();
            setIcon();
            SetButtonsBorder();
            ListPayments();
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

        private void ListPayments()
        {
            List<CustomerBuysCompanyHasProductOrService> payments =
                blCustomerBuysCompanyHasProductOrService
                    .CustomerBuysCompanyHasProductOrServiceList()
                    .Where(x =>
                        x.CompanyHasProductOrService != null &&
                        selectedCompanyIds.Contains(
                            x.CompanyHasProductOrService.CompanyId))
                    .ToList();

            var paymentList = payments.Select(x => new
            {
                x.CustomerBuysCompanyHasProductOrServiceId,

                CustomerName =
                    x.Customer != null
                        ? x.Customer.CustomerName
                        : "",

                CompanyName =
                    x.CompanyHasProductOrService != null &&
                    x.CompanyHasProductOrService.Company != null
                        ? x.CompanyHasProductOrService
                            .Company.CompanyName
                        : "",

                ProductOrServiceName =
                    x.CompanyHasProductOrService != null &&
                    x.CompanyHasProductOrService.ProductOrService != null
                        ? x.CompanyHasProductOrService
                            .ProductOrService.ProductOrServiceName
                        : "",

                PaymentTypeName =
                    x.PaymentType != null
                        ? x.PaymentType.PaymentTypeName
                        : "",

                x.CustomerBuysCompanyHasProductOrServiceQuantity,

                TotalPrice =
                    x.CompanyHasProductOrService != null
                        ? x.CompanyHasProductOrService
                            .CompanyHasProductOrServicePrice *
                          x.CustomerBuysCompanyHasProductOrServiceQuantity
                        : 0,

                x.CustomerBuysCompanyHasProductOrServiceDate

            }).ToList();

            DgvPayments.DataSource = paymentList;

            DgvPayments.Columns[
                "CustomerBuysCompanyHasProductOrServiceId"
            ].HeaderText = "Payment ID";

            DgvPayments.Columns[
                "CustomerName"
            ].HeaderText = "Customer";

            DgvPayments.Columns[
                "CompanyName"
            ].HeaderText = "Company";

            DgvPayments.Columns[
                "ProductOrServiceName"
            ].HeaderText = "Product / Service";

            DgvPayments.Columns[
                "PaymentTypeName"
            ].HeaderText = "Payment Type";

            DgvPayments.Columns[
                "CustomerBuysCompanyHasProductOrServiceQuantity"
            ].HeaderText = "Quantity";

            DgvPayments.Columns[
                "TotalPrice"
            ].HeaderText = "Total Price";

            DgvPayments.Columns[
                "CustomerBuysCompanyHasProductOrServiceDate"
            ].HeaderText = "Date";

            LblRecordCount.Text =
                payments.Count + " payments";
        }
        private CustomerBuysCompanyHasProductOrService GetSelectedPayment()
        {
            if (DgvPayments.CurrentRow == null)
                return null;

            int paymentId = Convert.ToInt32(
                DgvPayments.CurrentRow.Cells[
                    "CustomerBuysCompanyHasProductOrServiceId"
                ].Value
            );

            return blCustomerBuysCompanyHasProductOrService
                .CustomerBuysCompanyHasProductOrServiceGetById(paymentId);
        }

        private void SearchPayments()
        {
            string searchText =
                TxtSearch.Text.Trim().ToLower();

            List<CustomerBuysCompanyHasProductOrService> payments =
                blCustomerBuysCompanyHasProductOrService
                    .CustomerBuysCompanyHasProductOrServiceList()
                    .Where(x =>
                        x.CompanyHasProductOrService != null &&
                        selectedCompanyIds.Contains(
                            x.CompanyHasProductOrService.CompanyId))
                    .ToList();

            if (!string.IsNullOrEmpty(searchText))
            {
                payments = payments
                    .Where(x =>
                        (x.Customer != null &&
                         x.Customer.CustomerName
                            .ToLower()
                            .Contains(searchText)) ||

                        (x.CompanyHasProductOrService != null &&
                         x.CompanyHasProductOrService.Company != null &&
                         x.CompanyHasProductOrService.Company.CompanyName
                            .ToLower()
                            .Contains(searchText)) ||

                        (x.CompanyHasProductOrService != null &&
                         x.CompanyHasProductOrService.ProductOrService != null &&
                         x.CompanyHasProductOrService
                            .ProductOrService.ProductOrServiceName
                            .ToLower()
                            .Contains(searchText)) ||

                        (x.PaymentType != null &&
                         x.PaymentType.PaymentTypeName
                            .ToLower()
                            .Contains(searchText)) ||

                        x.CustomerBuysCompanyHasProductOrServiceQuantity
                            .ToString()
                            .Contains(searchText) ||

                        (x.CompanyHasProductOrService != null &&
                         x.CompanyHasProductOrService
                            .CompanyHasProductOrServicePrice
                            .ToString()
                            .Contains(searchText)) ||

                        (
                            x.CompanyHasProductOrService != null
                                ? x.CompanyHasProductOrService
                                    .CompanyHasProductOrServicePrice *
                                  x.CustomerBuysCompanyHasProductOrServiceQuantity
                                : 0
                        )
                        .ToString()
                        .Contains(searchText) ||

                        x.CustomerBuysCompanyHasProductOrServiceDate
                            .ToString("dd.MM.yyyy")
                            .Contains(searchText) ||

                        x.CustomerBuysCompanyHasProductOrServiceDate
                            .ToString("dd/MM/yyyy")
                            .Contains(searchText) ||

                        x.CustomerBuysCompanyHasProductOrServiceDate
                            .ToString("yyyy-MM-dd")
                            .Contains(searchText)
                    )
                    .ToList();
            }

            var paymentList = payments.Select(x => new
            {
                x.CustomerBuysCompanyHasProductOrServiceId,

                CustomerName =
                    x.Customer != null
                        ? x.Customer.CustomerName
                        : "",

                CompanyName =
                    x.CompanyHasProductOrService != null &&
                    x.CompanyHasProductOrService.Company != null
                        ? x.CompanyHasProductOrService.Company.CompanyName
                        : "",

                ProductOrServiceName =
                    x.CompanyHasProductOrService != null &&
                    x.CompanyHasProductOrService.ProductOrService != null
                        ? x.CompanyHasProductOrService
                            .ProductOrService.ProductOrServiceName
                        : "",

                PaymentTypeName =
                    x.PaymentType != null
                        ? x.PaymentType.PaymentTypeName
                        : "",

                x.CustomerBuysCompanyHasProductOrServiceQuantity,

                TotalPrice =
                    x.CompanyHasProductOrService != null
                        ? x.CompanyHasProductOrService
                            .CompanyHasProductOrServicePrice *
                          x.CustomerBuysCompanyHasProductOrServiceQuantity
                        : 0,

                x.CustomerBuysCompanyHasProductOrServiceDate

            }).ToList();

            DgvPayments.DataSource = paymentList;

            DgvPayments.Columns[
                "CustomerBuysCompanyHasProductOrServiceId"
            ].HeaderText = "Payment ID";

            DgvPayments.Columns[
                "CustomerName"
            ].HeaderText = "Customer";

            DgvPayments.Columns[
                "CompanyName"
            ].HeaderText = "Company";

            DgvPayments.Columns[
                "ProductOrServiceName"
            ].HeaderText = "Product / Service";

            DgvPayments.Columns[
                "PaymentTypeName"
            ].HeaderText = "Payment Type";

            DgvPayments.Columns[
                "CustomerBuysCompanyHasProductOrServiceQuantity"
            ].HeaderText = "Quantity";

            DgvPayments.Columns[
                "TotalPrice"
            ].HeaderText = "Total Price";

            DgvPayments.Columns[
                "CustomerBuysCompanyHasProductOrServiceDate"
            ].HeaderText = "Date";

            LblRecordCount.Text =
                payments.Count + " payments";
        }
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchPayments();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmPaymentAddEditForm frm =
                new FrmPaymentAddEditForm(
                    user,
                    selectedCompanyIds);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListPayments();
            }
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            CustomerBuysCompanyHasProductOrService payment =
                GetSelectedPayment();

            if (payment == null)
            {
                MessageBox.Show(
                    "Please select a payment.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            FrmPaymentAddEditForm frm =
                new FrmPaymentAddEditForm(
                    user,
                    selectedCompanyIds,
                    payment);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListPayments();
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            CustomerBuysCompanyHasProductOrService payment =
                GetSelectedPayment();

            if (payment == null)
            {
                MessageBox.Show(
                    "Please select a payment.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this payment?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            CompanyHasProductOrService product =
                blCompanyHasProductOrService
                    .CompanyHasProductOrServiceGetById(
                        payment.CompanyHasProductOrServiceId);

            if (product == null)
            {
                MessageBox.Show(
                    "The product or service could not be found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            product.CompanyHasProductOrServiceQuantity +=
                payment.CustomerBuysCompanyHasProductOrServiceQuantity;

            bool stockResult =
                blCompanyHasProductOrService
                    .CompanyHasProductOrServiceUpdate(product);

            if (!stockResult)
            {
                MessageBox.Show(
                    "The product stock could not be restored.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            bool deleteResult =
                blCustomerBuysCompanyHasProductOrService
                    .CustomerBuysCompanyHasProductOrServiceDelete(
                        payment.CustomerBuysCompanyHasProductOrServiceId);

            if (!deleteResult)
            {
                MessageBox.Show(
                    "Payment could not be deleted.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                "Payment deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ListPayments();
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
                    saveFileDialog.FileName = "Payments.xlsx";
                    saveFileDialog.Title = "Export Payments";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            ExcelExportHelper.ExportToExcel(
                                DgvPayments,
                                Enumerable.Range(0, DgvPayments.Columns.Count).ToArray(),
                                saveFileDialog.FileName,
                                worksheetName: "Payments");

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
                    saveFileDialog.FileName = "Payments.pdf";
                    saveFileDialog.Title = "Export Payments";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            PdfExportHelper.ExportToPdf(
                                DgvPayments,
                                Enumerable.Range(0, DgvPayments.Columns.Count).ToArray(),
                                saveFileDialog.FileName,
                                documentTitle: "Payments");

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
