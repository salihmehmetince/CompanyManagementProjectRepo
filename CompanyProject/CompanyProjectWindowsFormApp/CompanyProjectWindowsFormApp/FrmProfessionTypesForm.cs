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
    public partial class FrmProfessionTypesForm : Form
    {

        private BLProfessionType blProfessionType=new BLProfessionType();
        public FrmProfessionTypesForm()
        {
            InitializeComponent();
            setIcon();
            SetButtonsBorder();
            ListProfessionTypes();
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

        private void ListProfessionTypes()
        {
            List<ProfessionType> professionTypes =
                blProfessionType.ProfessionTypeList();

            var professionTypeList = professionTypes.Select(x => new
            {
                x.ProfessionTypeId,
                x.ProfessionName
            }).ToList();

            DgvProfessionTypes.DataSource = professionTypeList;

            LblRecordCount.Text =
                professionTypes.Count + " profession types";
        }

        private ProfessionType GetSelectedProfessionType()
        {
            if (DgvProfessionTypes.CurrentRow == null)
                return null;

            int professionTypeId = Convert.ToInt32(
                DgvProfessionTypes.CurrentRow.Cells["ProfessionTypeId"].Value
            );

            return blProfessionType.ProfessionTypeGetById(professionTypeId);
        }

        private void SearchProfessionTypes()
        {
            string searchText = TxtSearch.Text.Trim().ToLower();

            List<ProfessionType> professionTypes =
                blProfessionType.ProfessionTypeList();

            if (!string.IsNullOrEmpty(searchText))
            {
                professionTypes = professionTypes
                    .Where(x =>
                        x.ProfessionName.ToLower()
                            .Contains(searchText)
                    )
                    .ToList();
            }

            var professionTypeList = professionTypes.Select(x => new
            {
                x.ProfessionTypeId,
                x.ProfessionName
            }).ToList();

            DgvProfessionTypes.DataSource = professionTypeList;

            LblRecordCount.Text =
                professionTypes.Count + " profession types";
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProfessionTypes();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmProfessionTypeAddEditForm frm =
    new FrmProfessionTypeAddEditForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListProfessionTypes();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            ProfessionType professionType = GetSelectedProfessionType();

            if (professionType == null)
            {
                MessageBox.Show(
                    "Please select a profession type.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            FrmProfessionTypeAddEditForm frm =
                new FrmProfessionTypeAddEditForm(professionType);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListProfessionTypes();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ProfessionType professionType = GetSelectedProfessionType();

            if (professionType == null)
            {
                MessageBox.Show(
                    "Please select a profession type.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this profession type?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            if (!blProfessionType.ProfessionTypeDelete(
                professionType.ProfessionTypeId))
            {
                MessageBox.Show(
                    "Profession type could not be deleted.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                "Profession type deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ListProfessionTypes();
        }
    }
}
