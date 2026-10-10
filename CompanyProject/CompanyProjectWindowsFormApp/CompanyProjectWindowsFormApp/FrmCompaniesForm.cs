using CompanyManagement.BusinessLogic;
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
    public partial class FrmCompaniesForm : Form
    {
        private BLCompany blCompany = new BLCompany();
        private BLCompanyOwnerHasCompany blCompanyOwnerHasCompany=new BLCompanyOwnerHasCompany();
        public FrmCompaniesForm()
        {
            InitializeComponent();
            SetButtonsBorder();
            ListCompanies();
            setIcon();
            CreateExportMenu();
        }

        private void setIcon()
        {
            this.Icon = Properties.Resources.icon_company;
        }

        private void ListCompanies()
        {
            List<Company> companies = blCompany.CompanyList();

            var companyList = companies.Select(x => new
            {
                x.CompanyId,
                x.CompanyName,
                x.CompanyAddress,
                x.CompanyTelephoneNumber,
                x.CompanyEmail,
                CompanyTypeName = x.CompanyType != null
                    ? x.CompanyType.CompanyTypeName
                    : ""
            }).ToList();

            DgvCompanies.DataSource = companyList;

            LblRecordCount.Text = companies.Count + " companies";
        }
        private void SetButtonsBorder()
        {
            BtnAdd.FlatAppearance.BorderSize = 0;
            BtnEdit.FlatAppearance.BorderSize = 0;
            BtnDelete.FlatAppearance.BorderSize = 0;
            BtnExport.FlatAppearance.BorderSize = 0;
        }

        private Company GetSelectedCompany()
        {
            if (DgvCompanies.CurrentRow == null)
                return null;

            int companyId = Convert.ToInt32(
                DgvCompanies.CurrentRow.Cells["CompanyId"].Value
            );

            return blCompany.CompanyGetById(companyId);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Company company = GetSelectedCompany();

            if (company == null)
            {
                MessageBox.Show(
                    "Please select a company.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            FrmCompanyAddEditForm frmCompanyAddEdit = new FrmCompanyAddEditForm(company);

            if (frmCompanyAddEdit.ShowDialog() == DialogResult.OK)
            {
                ListCompanies();
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmCompanyAddEditForm frmCompanyAddEdit = new FrmCompanyAddEditForm();

            if (frmCompanyAddEdit.ShowDialog() == DialogResult.OK)
            {
                ListCompanies();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Company company =
                GetSelectedCompany();

            if (company == null)
            {
                MessageBox.Show(
                    "Please select a company.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            DialogResult result =
                MessageBox.Show(
                    "Are you sure you want to delete this company?",
                    "Delete Company",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (result != DialogResult.Yes)
                return;

            List<CompanyOwnerHasCompany>
                companyOwnerHasCompanies =
                    blCompanyOwnerHasCompany
                        .CompanyOwnerHasCompanyList()
                        .Where(x =>
                            x.CompanyId ==
                            company.CompanyId)
                        .ToList();

            foreach (CompanyOwnerHasCompany
                companyOwnerHasCompany
                in companyOwnerHasCompanies)
            {
                blCompanyOwnerHasCompany
                    .CompanyOwnerHasCompanyDelete(
                        companyOwnerHasCompany
                            .CompanyOwnerHasCompanyId);
            }

            bool deleted =
                blCompany.CompanyDelete(
                    company.CompanyId);

            if (deleted)
            {
                MessageBox.Show(
                    "Company deleted successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ListCompanies();
            }
            else
            {
                MessageBox.Show(
                    "Company could not be deleted.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void SearchCompanies()
        {
            string searchText = TxtSearch.Text.Trim().ToLower();

            List<Company> companies = blCompany.CompanyList();

            if (!string.IsNullOrEmpty(searchText))
            {
                companies = companies
                    .Where(x =>
                        x.CompanyName.ToLower().Contains(searchText) ||
                        x.CompanyAddress.ToLower().Contains(searchText) ||
                        x.CompanyTelephoneNumber.ToLower().Contains(searchText) ||
                        x.CompanyEmail.ToLower().Contains(searchText) ||
                        (x.CompanyType != null &&
                         x.CompanyType.CompanyTypeName.ToLower().Contains(searchText))
                    )
                    .ToList();
            }

            var companyList = companies.Select(x => new
            {
                x.CompanyId,
                x.CompanyName,
                x.CompanyAddress,
                x.CompanyTelephoneNumber,
                x.CompanyEmail,
                CompanyTypeName = x.CompanyType != null
                    ? x.CompanyType.CompanyTypeName
                    : ""
            }).ToList();

            DgvCompanies.DataSource = companyList;

            LblRecordCount.Text = companies.Count + " companies";
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchCompanies();
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
                    saveFileDialog.FileName = "Companies.xlsx";
                    saveFileDialog.Title = "Export Companies";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            ExcelExportHelper.ExportToExcel(
                                DgvCompanies,
                                Enumerable.Range(0, DgvCompanies.Columns.Count).ToArray(),
                                saveFileDialog.FileName,
                                worksheetName: "Companies");

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
                    saveFileDialog.FileName = "Companies.pdf";
                    saveFileDialog.Title = "Export Companies";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            PdfExportHelper.ExportToPdf(
                                DgvCompanies,
                                Enumerable.Range(0, DgvCompanies.Columns.Count).ToArray(),
                                saveFileDialog.FileName,
                                documentTitle: "Companies");

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
