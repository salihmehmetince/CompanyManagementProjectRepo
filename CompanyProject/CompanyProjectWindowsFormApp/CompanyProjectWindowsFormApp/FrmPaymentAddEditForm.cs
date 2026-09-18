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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CompanyProjectWindowsFormApp
{
    public partial class FrmPaymentAddEditForm : Form
    {
        private BLCustomerBuysCompanyHasProductOrService blCustomerBuysCompanyHasProductOrService=new BLCustomerBuysCompanyHasProductOrService();
        private CustomerBuysCompanyHasProductOrService customerBuysCompanyHasProductOrService;

        private BLCustomer blCustomer=new BLCustomer();
        private BLCompanyHasProductOrService blCompanyHasProductOrService=new BLCompanyHasProductOrService();
        private BLPaymentType blPaymentType = new BLPaymentType();
        public FrmPaymentAddEditForm(CustomerBuysCompanyHasProductOrService customerBuysCompanyHasProductOrService = null)
        {
            InitializeComponent();
            this.customerBuysCompanyHasProductOrService = customerBuysCompanyHasProductOrService;
            LoadCustomers();
            LoadPaymentTypes();
            LoadProducts();
            SetButtonsBorder();
            if(customerBuysCompanyHasProductOrService!=null)
            {
                LoadPayment();
            }
        }

        private void LoadPayment()
        {
            LblTitle.Text = "Edit Payment";
            LblDescription.Text = "Update payment information";

            CmbCustomer.SelectedValue =
                customerBuysCompanyHasProductOrService.CustomerId;

            CmbProducts.SelectedValue =
                customerBuysCompanyHasProductOrService
                    .CompanyHasProductOrServiceId;

            CmbPaymentTypes.SelectedValue =
                customerBuysCompanyHasProductOrService.PaymentTypeId;

            TxtQuantity.Text =
                customerBuysCompanyHasProductOrService
                    .CustomerBuysCompanyHasProductOrServiceQuantity
                    .ToString();

            DTPDate.Value =
                customerBuysCompanyHasProductOrService
                    .CustomerBuysCompanyHasProductOrServiceDate;
        }
        private void LoadCustomers()
        {
            List<Customer> customers =
                blCustomer.CustomerList();

            CmbCustomer.DataSource = customers;
            CmbCustomer.DisplayMember = "CustomerName";
            CmbCustomer.ValueMember = "CustomerId";
        }

        private void LoadProducts()
        {
            List<CompanyHasProductOrService> products =
                blCompanyHasProductOrService.CompanyHasProductOrServiceList();

            CmbProducts.DataSource = products;
            CmbProducts.DisplayMember = "ProductOrService.ProductOrServiceName";
            CmbProducts.ValueMember = "CompanyHasProductOrServiceId";
        }

        private void LoadPaymentTypes()
        {
            List<PaymentType> paymentTypes =
                blPaymentType.PaymentTypeList();

            CmbPaymentTypes.DataSource = paymentTypes;
            CmbPaymentTypes.DisplayMember = "PaymentTypeName";
            CmbPaymentTypes.ValueMember = "PaymentTypeId";
        }

        private void SetButtonsBorder()
        {
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatAppearance.BorderSize = 0;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CmbCustomer.SelectedValue == null ||
                CmbProducts.SelectedValue == null ||
                CmbPaymentTypes.SelectedValue == null)
            {
                MessageBox.Show(
                    "Please fill in all required fields.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            CustomerBuysCompanyHasProductOrService payment;

            if (customerBuysCompanyHasProductOrService == null)
            {
                payment =
                    new CustomerBuysCompanyHasProductOrService();
            }
            else
            {
                payment =
                    customerBuysCompanyHasProductOrService;
            }

            payment.CustomerId =
                Convert.ToInt32(CmbCustomer.SelectedValue);

            payment.CompanyHasProductOrServiceId =
                Convert.ToInt32(CmbProducts.SelectedValue);

            payment.PaymentTypeId =
                Convert.ToInt32(CmbPaymentTypes.SelectedValue);

            payment.CustomerBuysCompanyHasProductOrServiceQuantity =
                Convert.ToDecimal(TxtQuantity.Text);

            payment.CustomerBuysCompanyHasProductOrServiceDate =
                DTPDate.Value;

            bool result;

            if (customerBuysCompanyHasProductOrService == null)
            {
                result =
                    blCustomerBuysCompanyHasProductOrService
                        .CustomerBuysCompanyHasProductOrServiceAdd(payment);
            }
            else
            {
                result =
                    blCustomerBuysCompanyHasProductOrService
                        .CustomerBuysCompanyHasProductOrServiceUpdate(payment);
            }

            if (!result)
            {
                MessageBox.Show(
                    "Payment could not be saved.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                "Payment saved successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
