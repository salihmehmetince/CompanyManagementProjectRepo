using CompanyManagement.BusinessLogic;
using CompanyManagement.DataAccess;
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

        private BLCompany blCompany =new BLCompany();
        private User user;
        private List<int> selectedCompanyIds;

        public FrmPaymentAddEditForm(
            User user,
            List<int> selectedCompanyIds,
            CustomerBuysCompanyHasProductOrService
                customerBuysCompanyHasProductOrService = null)
        {
            this.user = user;
            this.selectedCompanyIds = selectedCompanyIds;

            InitializeComponent();

            this.customerBuysCompanyHasProductOrService =
                customerBuysCompanyHasProductOrService;

            LoadCustomers();
            LoadPaymentTypes();
            LoadProducts();
            LoadCompanies();
            SetButtonsBorder();

            if (customerBuysCompanyHasProductOrService != null)
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
                blCustomer
                    .CustomerList()
                    .Where(x =>
                        x.CompanyHasCustomers.Any(y =>
                            selectedCompanyIds.Contains(
                                y.CompanyId)))
                    .ToList();

            CmbCustomer.DataSource =
                customers;

            CmbCustomer.DisplayMember =
                "CustomerName";

            CmbCustomer.ValueMember =
                "CustomerId";
        }
        private void LoadProducts()
        {
            if (CmbCompany.SelectedItem == null)
                return;

            Company company = CmbCompany.SelectedItem as Company;

            if (company == null)
                return;

            int companyId = company.CompanyId;

            var products =
                blCompanyHasProductOrService
                    .CompanyHasProductOrServiceList()
                    .Where(x => x.CompanyId == companyId)
                    .Select(x => new
                    {
                        x.CompanyHasProductOrServiceId,
                        ProductOrServiceName =
                            x.ProductOrService.ProductOrServiceName,
                        x.CompanyHasProductOrServiceQuantity
                    })
                    .ToList();

            CmbProducts.DataSource = products;
            CmbProducts.DisplayMember = "ProductOrServiceName";
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

        private void LoadCompanies()
        {
            int customerId;

            if (CmbCustomer.SelectedValue == null ||
                !int.TryParse(
                    CmbCustomer.SelectedValue.ToString(),
                    out customerId))
            {
                CmbCompany.DataSource = null;
                return;
            }

            List<Company> companies =
                blCustomer
                    .CustomerGetById(customerId)
                    .CompanyHasCustomers
                    .Where(x =>
                        selectedCompanyIds.Contains(
                            x.CompanyId) &&
                        x.Company != null)
                    .Select(x => x.Company)
                    .ToList();

            CmbCompany.DataSource =
                companies;

            CmbCompany.DisplayMember =
                "CompanyName";

            CmbCompany.ValueMember =
                "CompanyId";
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
                CmbCompany.SelectedValue == null ||
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

            decimal quantity;

            if (!decimal.TryParse(TxtQuantity.Text, out quantity) ||
                quantity <= 0)
            {
                MessageBox.Show(
                    "Please enter a valid quantity.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int customerId =
                Convert.ToInt32(
                    CmbCustomer.SelectedValue);

            int companyId =
                Convert.ToInt32(
                    CmbCompany.SelectedValue);

            int companyHasProductOrServiceId =
                Convert.ToInt32(
                    CmbProducts.SelectedValue);

            Customer customer =
                blCustomer
                    .CustomerGetById(
                        customerId);

            if (customer == null)
            {
                MessageBox.Show(
                    "Customer could not be found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            bool customerBelongsToCompany =
                customer.CompanyHasCustomers.Any(x =>
                    x.CompanyId == companyId);

            if (!customerBelongsToCompany)
            {
                MessageBox.Show(
                    "The selected customer is not registered with the selected company.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            CompanyHasProductOrService companyHasProductOrService =
                blCompanyHasProductOrService
                    .CompanyHasProductOrServiceGetById(
                        companyHasProductOrServiceId);

            if (companyHasProductOrService == null)
            {
                MessageBox.Show(
                    "Product or service could not be found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (companyHasProductOrService.CompanyId != companyId)
            {
                MessageBox.Show(
                    "The selected product does not belong to the selected company.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Edit durumunda eski ürün ve miktarı sakla
            decimal oldQuantity = 0;
            int oldProductId = 0;

            if (customerBuysCompanyHasProductOrService != null)
            {
                oldQuantity =
                    customerBuysCompanyHasProductOrService
                        .CustomerBuysCompanyHasProductOrServiceQuantity;

                oldProductId =
                    customerBuysCompanyHasProductOrService
                        .CompanyHasProductOrServiceId;
            }

            // Yeni ödeme veya edit edilen yeni ürün için stok kontrolü
            if (companyHasProductOrService
                    .CompanyHasProductOrServiceQuantity < quantity)
            {
                MessageBox.Show(
                    "There is not enough stock for this product.",
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
                customerId;

            payment.CompanyHasProductOrServiceId =
                companyHasProductOrServiceId;

            payment.PaymentTypeId =
                Convert.ToInt32(
                    CmbPaymentTypes.SelectedValue);

            payment.CustomerBuysCompanyHasProductOrServiceQuantity =
                quantity;

            payment.CustomerBuysCompanyHasProductOrServiceDate =
                DTPDate.Value;

            bool result;

            if (customerBuysCompanyHasProductOrService == null)
            {
                result =
                    blCustomerBuysCompanyHasProductOrService
                        .CustomerBuysCompanyHasProductOrServiceAdd(
                            payment);
            }
            else
            {
                result =
                    blCustomerBuysCompanyHasProductOrService
                        .CustomerBuysCompanyHasProductOrServiceUpdate(
                            payment);
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

            // Yeni ödeme
            if (customerBuysCompanyHasProductOrService == null)
            {
                companyHasProductOrService
                    .CompanyHasProductOrServiceQuantity -=
                    quantity;

                bool stockResult =
                    blCompanyHasProductOrService
                        .CompanyHasProductOrServiceUpdate(
                            companyHasProductOrService);

                if (!stockResult)
                {
                    MessageBox.Show(
                        "Payment was saved, but the stock could not be updated.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }
            else
            {
                // Edit:
                // Önce eski ürüne eski miktarı geri ekle
                CompanyHasProductOrService oldProduct =
                    blCompanyHasProductOrService
                        .CompanyHasProductOrServiceGetById(
                            oldProductId);

                if (oldProduct == null)
                {
                    MessageBox.Show(
                        "The old product could not be found.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                oldProduct
                    .CompanyHasProductOrServiceQuantity +=
                    oldQuantity;

                bool oldStockResult =
                    blCompanyHasProductOrService
                        .CompanyHasProductOrServiceUpdate(
                            oldProduct);

                if (!oldStockResult)
                {
                    MessageBox.Show(
                        "The old product stock could not be restored.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                // Sonra yeni üründen yeni miktarı çıkar
                companyHasProductOrService
                    .CompanyHasProductOrServiceQuantity -=
                    quantity;

                bool newStockResult =
                    blCompanyHasProductOrService
                        .CompanyHasProductOrServiceUpdate(
                            companyHasProductOrService);

                if (!newStockResult)
                {
                    MessageBox.Show(
                        "The new product stock could not be updated.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            MessageBox.Show(
                customerBuysCompanyHasProductOrService == null
                    ? "Payment added successfully."
                    : "Payment updated successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }
        private void CmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbProducts.SelectedItem == null)
                return;

            dynamic product = CmbProducts.SelectedItem;

            LblInstockQuantity.Text =
                "In Stock: " +
                product.CompanyHasProductOrServiceQuantity.ToString();
        }

        private void CmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }
    }
}
