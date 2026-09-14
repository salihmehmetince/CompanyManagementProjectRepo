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
    public partial class FrmPaymentTypeForm : Form
    {

        private BLPaymentType blPaymentType=new BLPaymentType();
        public FrmPaymentTypeForm()
        {
            InitializeComponent();
            setIcon();
            SetButtonsBorder();
            ListPaymentTypes();
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

        private void ListPaymentTypes()
        {
            List<PaymentType> paymentTypes =
                blPaymentType.PaymentTypeList();

            var paymentTypeList = paymentTypes.Select(x => new
            {
                x.PaymentTypeId,
                x.PaymentTypeName
            }).ToList();

            DgvPaymentTypes.DataSource = paymentTypeList;

            LblRecordCount.Text =
                paymentTypes.Count + " payment types";
        }

        private PaymentType GetSelectedPaymentType()
        {
            if (DgvPaymentTypes.CurrentRow == null)
                return null;

            int paymentTypeId = Convert.ToInt32(
                DgvPaymentTypes.CurrentRow.Cells["PaymentTypeId"].Value
            );

            return blPaymentType.PaymentTypeGetById(paymentTypeId);
        }

        private void SearchPaymentTypes()
        {
            string searchText = TxtSearch.Text.Trim().ToLower();

            List<PaymentType> paymentTypes =
                blPaymentType.PaymentTypeList();

            if (!string.IsNullOrEmpty(searchText))
            {
                paymentTypes = paymentTypes
                    .Where(x =>
                        x.PaymentTypeName.ToLower()
                            .Contains(searchText)
                    )
                    .ToList();
            }

            var paymentTypeList = paymentTypes.Select(x => new
            {
                x.PaymentTypeId,
                x.PaymentTypeName
            }).ToList();

            DgvPaymentTypes.DataSource = paymentTypeList;

            LblRecordCount.Text =
                paymentTypes.Count + " payment types";
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchPaymentTypes();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmPaymentTypeAddEditForm frm =
    new FrmPaymentTypeAddEditForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListPaymentTypes();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            PaymentType paymentType = GetSelectedPaymentType();

            if (paymentType == null)
            {
                MessageBox.Show(
                    "Please select a payment type.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            FrmPaymentTypeAddEditForm frm =
                new FrmPaymentTypeAddEditForm(paymentType);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListPaymentTypes();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            PaymentType paymentType = GetSelectedPaymentType();

            if (paymentType == null)
            {
                MessageBox.Show(
                    "Please select a payment type.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this payment type?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            if (!blPaymentType.PaymentTypeDelete(paymentType.PaymentTypeId))
            {
                MessageBox.Show(
                    "Payment type could not be deleted.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                "Payment type deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ListPaymentTypes();
        }
    }
}
