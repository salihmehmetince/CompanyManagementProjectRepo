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
        public FrmCustomerForm()
        {
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
            List<Customer> customers = blCustomer.CustomerList();

            var customerList = customers.Select(x => new
            {
                x.CustomerId,
                x.CustomerName,
                x.CustomerSurname,
                x.CustomerTelephoneNumber,
                x.CustomerEmail
            }).ToList();

            DgvCustomers.DataSource = customerList;

            LblRecordCount.Text = customers.Count + " customers";
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
            string searchText = TxtSearch.Text.Trim().ToLower();

            List<Customer> customers =
                blCustomer.CustomerList();

            if (!string.IsNullOrEmpty(searchText))
            {
                customers = customers
                    .Where(x =>
                        x.CustomerName.ToLower().Contains(searchText) ||
                        x.CustomerSurname.ToLower().Contains(searchText) ||
                        x.CustomerTelephoneNumber.ToLower().Contains(searchText) ||
                        (x.CustomerEmail != null &&
                         x.CustomerEmail.ToLower().Contains(searchText))
                    )
                    .ToList();
            }

            var customerList = customers.Select(x => new
            {
                x.CustomerId,
                x.CustomerName,
                x.CustomerSurname,
                x.CustomerTelephoneNumber,
                x.CustomerEmail
            }).ToList();

            DgvCustomers.DataSource = customerList;

            LblRecordCount.Text =
                customers.Count + " customers";
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchCustomers();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmCustomerAddEditForm frm =
    new FrmCustomerAddEditForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListCustomers();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
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

            FrmCustomerAddEditForm frm =
                new FrmCustomerAddEditForm(customer);

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
