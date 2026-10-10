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
    public partial class FrmEmployeeBonusesForm : Form
    {

        private BLCompanyGivesBonusToEmployee blCompanyGivesBonusToEmployee = new BLCompanyGivesBonusToEmployee();
        private User user;
        private List<int> selectedCompanyIds;

        public FrmEmployeeBonusesForm(
            User user,
            List<int> selectedCompanyIds)
        {
            this.user = user;
            this.selectedCompanyIds = selectedCompanyIds;

            InitializeComponent();
            SetButtonsBorder();
            setIcon();
            ListEmployeeBonuses();
            CreateExportMenu();
        }
        private void SetButtonsBorder()
        {
            BtnAdd.FlatAppearance.BorderSize = 0;
            BtnEdit.FlatAppearance.BorderSize = 0;
            BtnDelete.FlatAppearance.BorderSize = 0;
        }

        private void setIcon()
        {
            this.Icon = Properties.Resources.icon_company;
        }

        private void ListEmployeeBonuses()
        {
            List<CompanyGivesBonusToEmployee>
                employeeBonuses =
                blCompanyGivesBonusToEmployee
                    .CompanyGivesBonusToEmployeeList()
                    .Where(x =>
                        x.Company != null &&
                        selectedCompanyIds.Contains(
                            x.CompanyId))
                    .ToList();

            var employeeBonusList =
                employeeBonuses.Select(x => new
                {
                    x.CompanyGivesBonusToEmployeeId,
                    x.CompanyGivesBonusToEmployeeDate,
                    x.CompanyGivesBonusToEmployeeQuantity,
                    x.IsPercentage,
                    x.AffectSalary,

                    CompanyName =
                        x.Company != null
                            ? x.Company.CompanyName
                            : "",

                    EmployeeName =
                        x.Employee != null
                            ? x.Employee.EmployeeName + " " +
                              x.Employee.EmployeeSurname
                            : ""
                }).ToList();

            DgvEmployeeBonuses.DataSource =
                employeeBonusList;

            LblRecordCount.Text =
                employeeBonuses.Count +
                " employee bonuses";
        }
        private CompanyGivesBonusToEmployee GetSelectedEmployeeBonus()
        {
            if (DgvEmployeeBonuses.CurrentRow == null)
                return null;

            int employeeBonusId =
                Convert.ToInt32(
                    DgvEmployeeBonuses.CurrentRow
                        .Cells["CompanyGivesBonusToEmployeeId"]
                        .Value
                );

            return blCompanyGivesBonusToEmployee
                .CompanyGivesBonusToEmployeeGetById(
                    employeeBonusId);
        }

        private void SearchEmployeeBonuses()
        {
            string searchText =
                TxtSearch.Text.Trim().ToLower();

            List<CompanyGivesBonusToEmployee>
                employeeBonuses =
                blCompanyGivesBonusToEmployee
                    .CompanyGivesBonusToEmployeeList()
                    .Where(x =>
                        x.Company != null &&
                        selectedCompanyIds.Contains(
                            x.CompanyId))
                    .ToList();

            if (!string.IsNullOrEmpty(searchText))
            {
                employeeBonuses = employeeBonuses
                    .Where(x =>
                        (x.Company != null &&
                         x.Company.CompanyName
                            .ToLower()
                            .Contains(searchText)) ||

                        (x.Employee != null &&
                         (
                            x.Employee.EmployeeName
                                .ToLower()
                                .Contains(searchText) ||

                            x.Employee.EmployeeSurname
                                .ToLower()
                                .Contains(searchText)
                         )) ||

                        x.CompanyGivesBonusToEmployeeQuantity
                            .ToString()
                            .Contains(searchText) ||

                        x.CompanyGivesBonusToEmployeeDate
                            .ToString("dd.MM.yyyy")
                            .Contains(searchText) ||

                        x.IsPercentage
                            .ToString()
                            .ToLower()
                            .Contains(searchText) ||

                        x.AffectSalary
                            .ToString()
                            .ToLower()
                            .Contains(searchText)
                    )
                    .ToList();
            }

            var employeeBonusList =
                employeeBonuses.Select(x => new
                {
                    x.CompanyGivesBonusToEmployeeId,

                    CompanyName =
                        x.Company != null
                            ? x.Company.CompanyName
                            : "",

                    EmployeeName =
                        x.Employee != null
                            ? x.Employee.EmployeeName + " " +
                              x.Employee.EmployeeSurname
                            : "",

                    x.CompanyGivesBonusToEmployeeDate,

                    x.CompanyGivesBonusToEmployeeQuantity,
                    x.IsPercentage,
                    x.AffectSalary
                }).ToList();

            DgvEmployeeBonuses.DataSource =
                employeeBonusList;

            LblRecordCount.Text =
                employeeBonuses.Count +
                " employee bonuses";
        }
        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchEmployeeBonuses();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmEmployeeBonusAddEditForm frm =
                new FrmEmployeeBonusAddEditForm(
                    user,
                    selectedCompanyIds);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListEmployeeBonuses();
            }
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            CompanyGivesBonusToEmployee employeeBonus =
                GetSelectedEmployeeBonus();

            if (employeeBonus == null)
            {
                MessageBox.Show(
                    "Please select an employee bonus.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (employeeBonus.AffectSalary)
            {
                MessageBox.Show(
                    "This employee bonus cannot be edited because it affects the employee salary.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            FrmEmployeeBonusAddEditForm frm =
                new FrmEmployeeBonusAddEditForm(
                    user,
                    selectedCompanyIds,
                    employeeBonus);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListEmployeeBonuses();
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            CompanyGivesBonusToEmployee employeeBonus =
                GetSelectedEmployeeBonus();

            if (employeeBonus == null)
            {
                MessageBox.Show(
                    "Please select an employee bonus.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (employeeBonus.AffectSalary)
            {
                MessageBox.Show(
                    "This employee bonus cannot be deleted because it affects the employee salary.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this employee bonus?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            if (!blCompanyGivesBonusToEmployee
                .CompanyGivesBonusToEmployeeDelete(
                    employeeBonus.CompanyGivesBonusToEmployeeId))
            {
                MessageBox.Show(
                    "Employee bonus could not be deleted.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                "Employee bonus deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ListEmployeeBonuses();
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
                    saveFileDialog.FileName = "Employee Bonuses.xlsx";
                    saveFileDialog.Title = "Export Employee Bonuses";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            ExcelExportHelper.ExportToExcel(
                                DgvEmployeeBonuses,
                                Enumerable.Range(0, DgvEmployeeBonuses.Columns.Count).ToArray(),
                                saveFileDialog.FileName,
                                worksheetName: "Employee Bonuses");

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
                    saveFileDialog.FileName = "Employee Bonuses.pdf";
                    saveFileDialog.Title = "Export Employee Bonuses";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            PdfExportHelper.ExportToPdf(
                                DgvEmployeeBonuses,
                                Enumerable.Range(0, DgvEmployeeBonuses.Columns.Count).ToArray(),
                                saveFileDialog.FileName,
                                documentTitle: "Employee Bonuses");

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
