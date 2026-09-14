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
    public partial class FrmPaymentTypeAddEditForm : Form
    {
        private BLPaymentType blPaymentType=new BLPaymentType();
        private PaymentType paymentType;
        public FrmPaymentTypeAddEditForm(PaymentType paymentType=null)
        {
            InitializeComponent();
            SetButtonsBorder();
            this.paymentType = paymentType;
            if(paymentType!=null)
            {
                LoadPaymentType();
            }
        }

        private void SetButtonsBorder()
        {
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatAppearance.BorderSize = 0;
        }

        private void LoadPaymentType()
        {
            LblTitle.Text = "Edit Payment Type";
            LblDescription.Text = "Update payment type information";

            TxtName.Text = paymentType.PaymentTypeName;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            PaymentType paymentTypeToSave;

            if (paymentType == null)
            {
                // Yeni ödeme türü
                paymentTypeToSave = new PaymentType();
            }
            else
            {
                // Mevcut ödeme türü
                paymentTypeToSave = paymentType;
            }

            paymentTypeToSave.PaymentTypeName =
                TxtName.Text.Trim();

            bool result;

            if (paymentType == null)
            {
                result = blPaymentType.PaymentTypeAdd(
                    paymentTypeToSave);
            }
            else
            {
                result = blPaymentType.PaymentTypeUpdate(
                    paymentTypeToSave);
            }

            if (result)
            {
                MessageBox.Show(
                    paymentType == null
                        ? "Payment type added successfully."
                        : "Payment type updated successfully.",
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
                    "Payment type could not be saved. Please check the entered information.",
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
