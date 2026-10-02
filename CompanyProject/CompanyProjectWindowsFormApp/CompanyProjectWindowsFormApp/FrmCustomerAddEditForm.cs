using CompanyManagement.BLL;
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

namespace CompanyProjectWindowsFormApp
{
    public partial class FrmCustomerAddEditForm : Form
    {

        private BLCustomer blCustomer = new BLCustomer();
        private Customer customer;
        private BLCompany blCompany = new BLCompany();
        private BLCompanyHasCustomer blCompanyHasCustomer=new BLCompanyHasCustomer();

        private User user;
        private List<int> selectedCompanyIds;

        public FrmCustomerAddEditForm(
            User user,
            List<int> selectedCompanyIds,
            Customer customer = null)
        {
            this.user = user;
            this.selectedCompanyIds = selectedCompanyIds;

            InitializeComponent();
            this.customer = customer;

            LoadCompanies();

            if (customer != null)
            {
                LoadCustomer();
            }
        }

        private void LoadCompanies()
        {
            List<Company> companies =
                blCompany
                    .CompanyList()
                    .Where(x =>
                        selectedCompanyIds.Contains(
                            x.CompanyId))
                    .ToList();

            CLBCompanies.DataSource =
                companies;

            CLBCompanies.DisplayMember =
                "CompanyName";

            CLBCompanies.ValueMember =
                "CompanyId";
        }
        private void LoadCustomer()
        {
            LblTitle.Text = "Edit Customer";
            LblDescription.Text = "Update customer information";

            TxtEmployeeName.Text =
                customer.CustomerName;

            TxtSurname.Text =
                customer.CustomerSurname;

            MTBTelephoneNumber.Text =
                customer.CustomerTelephoneNumber;

            TxtEmail.Text =
                customer.CustomerEmail;

            for (int i = 0; i < CLBCompanies.Items.Count; i++)
            {
                Company company =
                    CLBCompanies.Items[i] as Company;

                if (company == null)
                    continue;

                bool isSelected =
                    customer.CompanyHasCustomers.Any(x =>
                        x.CompanyId == company.CompanyId);

                CLBCompanies.SetItemChecked(
                    i,
                    isSelected);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            List<Company> selectedCompanies =
                CLBCompanies.CheckedItems
                    .Cast<Company>()
                    .ToList();

            if (selectedCompanies.Count == 0)
            {
                MessageBox.Show(
                    "Please select at least one company.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            Customer customerToSave;

            if (customer == null)
            {
                customerToSave = new Customer();
            }
            else
            {
                customerToSave = customer;
            }

            customerToSave.CustomerName =
                TxtEmployeeName.Text.Trim();

            customerToSave.CustomerSurname =
                TxtSurname.Text.Trim();

            customerToSave.CustomerTelephoneNumber =
                MTBTelephoneNumber.Text.Trim();

            customerToSave.CustomerEmail =
                TxtEmail.Text.Trim();

            bool result;

            if (customer == null)
            {
                result =
                    blCustomer.CustomerAdd(
                        customerToSave);
            }
            else
            {
                result =
                    blCustomer.CustomerUpdate(
                        customerToSave);
            }

            if (!result)
            {
                MessageBox.Show(
                    "Customer could not be saved. Please check the entered information.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            if (customer != null)
            {
                List<CompanyHasCustomer> oldCompanyHasCustomers =
                    blCompanyHasCustomer
                        .CompanyHasCustomerList()
                        .Where(x =>
                            x.CustomerId ==
                            customerToSave.CustomerId)
                        .ToList();

                foreach (CompanyHasCustomer oldCompanyHasCustomer
                    in oldCompanyHasCustomers)
                {
                    blCompanyHasCustomer
                        .CompanyHasCustomerDelete(
                            oldCompanyHasCustomer
                                .CompanyHasCustomerId);
                }
            }

            foreach (Company company in selectedCompanies)
            {
                CompanyHasCustomer companyHasCustomer =
                    new CompanyHasCustomer();

                companyHasCustomer.CompanyId =
                    company.CompanyId;

                companyHasCustomer.CustomerId =
                    customerToSave.CustomerId;

                bool companyResult =
                    blCompanyHasCustomer
                        .CompanyHasCustomerAdd(
                            companyHasCustomer);

                if (!companyResult)
                {
                    MessageBox.Show(
                        "Customer was saved, but the company relationship could not be saved.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }
            }

            MessageBox.Show(
                customer == null
                    ? "Customer added successfully."
                    : "Customer updated successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
