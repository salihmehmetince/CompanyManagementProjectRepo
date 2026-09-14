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
    public partial class FrmCustomerAddEditForm : Form
    {

        private BLCustomer blCustomer = new BLCustomer();
        private Customer customer;
        public FrmCustomerAddEditForm(Customer customer=null)
        {
            InitializeComponent();
            this.customer = customer;
            if (customer != null) 
            {
                LoadCustomer();
            }
        }

        private void LoadCustomer()
        {
            LblTitle.Text = "Edit Customer";
            LblDescription.Text = "Update customer information";

            TxtEmployeeName.Text = customer.CustomerName;
            TxtSurname.Text = customer.CustomerSurname;
            MTBTelephoneNumber.Text = customer.CustomerTelephoneNumber;
            TxtEmail.Text = customer.CustomerEmail;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Customer customerToSave;

            if (customer == null)
            {
                // Yeni müşteri
                customerToSave = new Customer();
            }
            else
            {
                // Mevcut müşteri
                customerToSave = customer;
            }

            customerToSave.CustomerName = TxtEmployeeName.Text.Trim();
            customerToSave.CustomerSurname = TxtSurname.Text.Trim();
            customerToSave.CustomerTelephoneNumber =
                MTBTelephoneNumber.Text.Trim();
            customerToSave.CustomerEmail = TxtEmail.Text.Trim();

            bool result;

            if (customer == null)
            {
                result = blCustomer.CustomerAdd(customerToSave);
            }
            else
            {
                result = blCustomer.CustomerUpdate(customerToSave);
            }

            if (result)
            {
                MessageBox.Show(
                    customer == null
                        ? "Customer added successfully."
                        : "Customer updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(
                    "Customer could not be saved. Please check the entered information.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
