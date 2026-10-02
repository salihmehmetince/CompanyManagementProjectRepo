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
    public partial class FrmCustomerForm : Form
    {
        private BLCustomer blCustomer = new BLCustomer();
        private User user;
        private List<int> selectedCompanyIds;

        public FrmCustomerForm(
            User user,
            List<int> selectedCompanyIds)
        {
            this.user = user;
            this.selectedCompanyIds = selectedCompanyIds;

            InitializeComponent();
            setIcon();
            SetButtonsBorder();
            ListCustomers();
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

        private void ListCustomers()
        {
            List<Customer> customers =
                blCustomer
                    .CustomerList()
                    .Where(x =>
                        x.CompanyHasCustomers.Any(y =>
                            selectedCompanyIds.Contains(
                                y.CompanyId)))
                    .ToList();

            var customerList =
                customers.Select(x => new
                {
                    x.CustomerId,
                    x.CustomerName,
                    x.CustomerSurname,
                    x.CustomerTelephoneNumber,
                    x.CustomerEmail,
                    CompanyName =
                        string.Join(", ",
                            x.CompanyHasCustomers
                                .Where(y =>
                                    selectedCompanyIds.Contains(
                                        y.CompanyId))
                                .Select(y =>
                                    y.Company.CompanyName))
                }).ToList();

            DgvCustomers.DataSource =
                customerList;

            LblRecordCount.Text =
                customers.Count + " customers";
        }
        private Customer GetSelectedCustomer()
        {
            if (DgvCustomers.CurrentRow == null)
                return null;

            int customerId = Convert.ToInt32(
                DgvCustomers.CurrentRow.Cells["CustomerId"].Value
            );

            return blCustomer.CustomerGetById(customerId);
        }

        private void SearchCustomers()
        {
            string searchText =
                TxtSearch.Text.Trim().ToLower();

            List<Customer> customers =
                blCustomer
                    .CustomerList()
                    .Where(x =>
                        x.CompanyHasCustomers.Any(y =>
                            selectedCompanyIds.Contains(
                                y.CompanyId)))
                    .ToList();

            if (!string.IsNullOrEmpty(searchText))
            {
                customers = customers
                    .Where(x =>
                        x.CustomerName.ToLower()
                            .Contains(searchText) ||
                        x.CustomerSurname.ToLower()
                            .Contains(searchText) ||
                        x.CustomerTelephoneNumber.ToLower()
                            .Contains(searchText) ||
                        (x.CustomerEmail != null &&
                         x.CustomerEmail.ToLower()
                            .Contains(searchText)) ||
                        x.CompanyHasCustomers.Any(y =>
                            selectedCompanyIds.Contains(
                                y.CompanyId) &&
                            y.Company != null &&
                            y.Company.CompanyName
                                .ToLower()
                                .Contains(searchText))
                    )
                    .ToList();
            }

            var customerList =
                customers.Select(x => new
                {
                    x.CustomerId,
                    x.CustomerName,
                    x.CustomerSurname,
                    x.CustomerTelephoneNumber,
                    x.CustomerEmail,
                    CompanyName =
                        string.Join(", ",
                            x.CompanyHasCustomers
                                .Where(y =>
                                    selectedCompanyIds.Contains(
                                        y.CompanyId) &&
                                    y.Company != null)
                                .Select(y =>
                                    y.Company.CompanyName))
                }).ToList();

            DgvCustomers.DataSource =
                customerList;

            LblRecordCount.Text =
                customers.Count +
                " customers";
        }
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchCustomers();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmCustomerAddEditForm frm =
                new FrmCustomerAddEditForm(
                    user,
                    selectedCompanyIds);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListCustomers();
            }
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Customer customer =
                GetSelectedCustomer();

            if (customer == null)
            {
                MessageBox.Show(
                    "Please select a customer.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            FrmCustomerAddEditForm frm =
                new FrmCustomerAddEditForm(
                    user,
                    selectedCompanyIds,
                    customer);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListCustomers();
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Customer customer = GetSelectedCustomer();

            if (customer == null)
            {
                MessageBox.Show(
                    "Please select a customer.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this customer?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            if (!blCustomer.CustomerDelete(customer.CustomerId))
            {
                MessageBox.Show(
                    "Customer could not be deleted.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                "Customer deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ListCustomers();
        }
    }
}
