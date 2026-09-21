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
    public partial class FrmPaymentForm : Form
    {
        private BLCustomerBuysCompanyHasProductOrService blCustomerBuysCompanyHasProductOrService = new BLCustomerBuysCompanyHasProductOrService();
        public FrmPaymentForm()
        {
            InitializeComponent();
            setIcon();
            SetButtonsBorder();
            ListPayments();
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

        private void ListPayments()
        {
            List<CustomerBuysCompanyHasProductOrService> payments =
                blCustomerBuysCompanyHasProductOrService
                    .CustomerBuysCompanyHasProductOrServiceList();

            var paymentList = payments.Select(x => new
            {
                x.CustomerBuysCompanyHasProductOrServiceId,

                CustomerName =
                    x.Customer != null
                        ? x.Customer.CustomerName
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
            string searchText = TxtSearch.Text.Trim().ToLower();

            List<CustomerBuysCompanyHasProductOrService> payments =
                blCustomerBuysCompanyHasProductOrService
                    .CustomerBuysCompanyHasProductOrServiceList();

            if (!string.IsNullOrEmpty(searchText))
            {
                payments = payments
                    .Where(x =>
                        x.Customer.CustomerName
                            .ToLower()
                            .Contains(searchText) ||

                        x.CompanyHasProductOrService
                            .ProductOrService.ProductOrServiceName
                            .ToLower()
                            .Contains(searchText) ||

                        x.PaymentType.PaymentTypeName
                            .ToLower()
                            .Contains(searchText) ||

                        x.CustomerBuysCompanyHasProductOrServiceQuantity
                            .ToString()
                            .Contains(searchText) ||

                        x.CompanyHasProductOrService
                            .CompanyHasProductOrServicePrice
                            .ToString()
                            .Contains(searchText) ||

                        (
                            x.CompanyHasProductOrService
                                .CompanyHasProductOrServicePrice *
                            x.CustomerBuysCompanyHasProductOrServiceQuantity
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
                    x.Customer.CustomerName,

                ProductOrServiceName =
                    x.CompanyHasProductOrService
                        .ProductOrService
                        .ProductOrServiceName,

                PaymentTypeName =
                    x.PaymentType.PaymentTypeName,

                x.CustomerBuysCompanyHasProductOrServiceQuantity,

                TotalPrice =
                    x.CompanyHasProductOrService
                        .CompanyHasProductOrServicePrice *
                    x.CustomerBuysCompanyHasProductOrServiceQuantity,

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
    new FrmPaymentAddEditForm();

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
                new FrmPaymentAddEditForm(payment);

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

            if (!blCustomerBuysCompanyHasProductOrService
                .CustomerBuysCompanyHasProductOrServiceDelete(
                    payment.CustomerBuysCompanyHasProductOrServiceId))
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
    }
}
