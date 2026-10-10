using CompanyManagement.BusinessLogic;
using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using CompanyProjectWindowsFormApp.Helper;
using CompanyProjectWindowsFormApp.Helpers;
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
    public partial class FrmCompanyOwnersForm : Form
    {

        BLCompanyOwner blCompanyOwner = new BLCompanyOwner();
        private BLUser blUser = new BLUser();
        public FrmCompanyOwnersForm()
        {
            InitializeComponent();
            SetButtonsBorder();
            setIcon();
            ListCompanyOwners();
            CreateExportMenu();
        }

        private void SetButtonsBorder()
        {
            BtnAdd.FlatAppearance.BorderSize = 0;
            BtnEdit.FlatAppearance.BorderSize = 0;
            BtnDelete.FlatAppearance.BorderSize = 0;
            BtnExport.FlatAppearance.BorderSize = 0;
        }

        private void setIcon()
        {
            this.Icon = Properties.Resources.icon_company;
        }

        private CompanyOwner GetSelectedCompanyOwner()
        {
            if (DgvCompanyOwners.CurrentRow == null)
                return null;

            int companyOwnerId = Convert.ToInt32(
                DgvCompanyOwners.CurrentRow.Cells["CompanyOwnerId"].Value
            );

            return blCompanyOwner.CompanyOwnerGetById(companyOwnerId);
        }

        private void ListCompanyOwners()
        {
            List<CompanyOwner> companyOwners =
                blCompanyOwner.CompanyOwnerList();

            companyOwners = companyOwners
                .Where(x =>
                {
                    User user =
                        blUser.UserGetById(x.UserId);

                    return user != null &&
                           user.IsActive;
                })
                .ToList();

            var companyOwnerList = companyOwners.Select(x => new
            {
                x.CompanyOwnerId,
                x.CompanyOwnerIdentityNumber,
                x.CompanyOwnerName,
                x.CompanyOwnerSurname,
                x.CompanyOwnerBirthday,
                x.CompanyOwnerTelephoneNumber,
                x.CompanyOwnerEmail

            }).ToList();

            DgvCompanyOwners.DataSource =
                companyOwnerList;

            LblRecordCount.Text =
                companyOwners.Count +
                " company owners";
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new FrmCompanyOwnerAddEditForm())
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    ListCompanyOwners();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            CompanyOwner companyOwner = GetSelectedCompanyOwner();

            if (companyOwner == null)
            {
                MessageBox.Show("Please select a company owner.");
                return;
            }

            using (var form = new FrmCompanyOwnerAddEditForm(companyOwner))
            {
                if (form.ShowDialog(this) == DialogResult.OK)
                    ListCompanyOwners();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            CompanyOwner companyOwner =
                GetSelectedCompanyOwner();

            if (companyOwner == null)
            {
                MessageBox.Show(
                    "Please select a company owner.");

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to deactivate the selected company owner?",
                    "Deactivate Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            User user =
                blUser.UserGetById(
                    companyOwner.UserId);

            if (user == null)
            {
                MessageBox.Show(
                    "Company owner user record could not be found.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            user.IsActive = false;

            if (blUser.UserUpdate(user))
            {
                ListCompanyOwners();

                MessageBox.Show(
                    "Company owner deactivated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(
                    "Company owner could not be deactivated.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchCompanyOwners();
        }

        private void SearchCompanyOwners()
        {
            string searchText =
                TxtSearch.Text.Trim().ToLower();

            List<CompanyOwner> companyOwners =
                blCompanyOwner.CompanyOwnerList();

            companyOwners = companyOwners
                .Where(x =>
                {
                    User user =
                        blUser.UserGetById(x.UserId);

                    return user != null &&
                           user.IsActive;
                })
                .ToList();

            if (!string.IsNullOrEmpty(searchText))
            {
                companyOwners = companyOwners
                    .Where(x =>
                        x.CompanyOwnerIdentityNumber.ToLower()
                            .Contains(searchText) ||

                        x.CompanyOwnerName.ToLower()
                            .Contains(searchText) ||

                        x.CompanyOwnerSurname.ToLower()
                            .Contains(searchText) ||

                        x.CompanyOwnerTelephoneNumber.ToLower()
                            .Contains(searchText) ||

                        (x.CompanyOwnerEmail != null &&
                         x.CompanyOwnerEmail.ToLower()
                            .Contains(searchText))
                    )
                    .ToList();
            }

            var companyOwnerList = companyOwners.Select(x => new
            {
                x.CompanyOwnerId,
                x.CompanyOwnerIdentityNumber,
                x.CompanyOwnerName,
                x.CompanyOwnerSurname,
                x.CompanyOwnerBirthday,
                x.CompanyOwnerTelephoneNumber,
                x.CompanyOwnerEmail

            }).ToList();

            DgvCompanyOwners.DataSource =
                companyOwnerList;

            LblRecordCount.Text =
                companyOwners.Count +
                " company owners";
        }

        private void CreateExportMenu()
        {
            ContextMenuStrip exportMenu = new ContextMenuStrip();

            ToolStripMenuItem excelItem = new ToolStripMenuItem("Excel'e Aktar");
            ToolStripMenuItem pdfItem = new ToolStripMenuItem("PDF'e Aktar");

            exportMenu.Items.Add(excelItem);
            exportMenu.Items.Add(pdfItem);

            excelItem.Click += (sender, e) =>
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Dosyası (*.xlsx)|*.xlsx";
                    saveFileDialog.DefaultExt = "xlsx";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.FileName = "Company Owners.xlsx";
                    saveFileDialog.Title = "Export Company Owners";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            ExcelExportHelper.ExportToExcel(
                                DgvCompanyOwners,
                                Enumerable.Range(0, DgvCompanyOwners.Columns.Count).ToArray(),
                                saveFileDialog.FileName,
                                worksheetName: "Company Owners");

                            MessageBox.Show(
                                "Veriler Excel dosyasına aktarıldı.",
                                "Export Successful",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                                "Excel aktarımı başarısız oldu.\n" + ex.Message,
                                "Export Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
            };

            pdfItem.Click += (sender, e) =>
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "PDF Dosyası (*.pdf)|*.pdf";
                    saveFileDialog.DefaultExt = "pdf";
                    saveFileDialog.AddExtension = true;
                    saveFileDialog.FileName = "Company Owners.pdf";
                    saveFileDialog.Title = "Export Company Owners";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            PdfExportHelper.ExportToPdf(
                                DgvCompanyOwners,
                                Enumerable.Range(0, DgvCompanyOwners.Columns.Count).ToArray(),
                                saveFileDialog.FileName,
                                documentTitle: "Company Owners");

                            MessageBox.Show(
                                "Veriler PDF dosyasına aktarıldı.",
                                "Export Successful",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(
                                "PDF aktarımı başarısız oldu.\n" + ex.Message,
                                "Export Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                    }
                }
            };


            BtnExport.Click += (sender, e) =>
            {
                exportMenu.Show(BtnExport, new Point(0, BtnExport.Height));
            };
        }

    }
}
