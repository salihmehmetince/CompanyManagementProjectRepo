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
    public partial class FrmProfessionTypeAddEditForm : Form
    {
        private BLProfessionType blProfessionType=new BLProfessionType();
        private ProfessionType professionType;
        public FrmProfessionTypeAddEditForm(ProfessionType professionType=null)
        {
            InitializeComponent();
            SetButtonsBorder();
            this.professionType = professionType;
            if (professionType != null) 
            {
                LoadProfessionType();
            }
        }

        private void SetButtonsBorder()
        {
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatAppearance.BorderSize = 0;
        }

        private void LoadProfessionType()
        {
            LblTitle.Text = "Edit Profession Type";
            LblDescription.Text = "Update profession type information";

            TxtName.Text =
                professionType.ProfessionName;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            ProfessionType professionTypeToSave;

            if (professionType == null)
            {
                // Yeni meslek türü
                professionTypeToSave = new ProfessionType();
            }
            else
            {
                // Mevcut meslek türü
                professionTypeToSave = professionType;
            }

            professionTypeToSave.ProfessionName =
                TxtName.Text.Trim();

            bool result;

            if (professionType == null)
            {
                result = blProfessionType.ProfessionTypeAdd(
                    professionTypeToSave);
            }
            else
            {
                result = blProfessionType.ProfessionTypeUpdate(
                    professionTypeToSave);
            }

            if (result)
            {
                MessageBox.Show(
                    professionType == null
                        ? "Profession type added successfully."
                        : "Profession type updated successfully.",
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
                    "Profession type could not be saved. Please check the entered information.",
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
