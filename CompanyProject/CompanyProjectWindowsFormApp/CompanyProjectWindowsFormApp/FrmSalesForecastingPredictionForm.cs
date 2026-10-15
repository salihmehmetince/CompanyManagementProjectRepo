using CompanyManagement.BusinessLogic;
using CompanyProjectWindowsFormApp.AI.MachineLearning.SalesForecasting;
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
    public partial class FrmSalesForecastingPredictionForm : Form
    {
        private readonly SalesForecastingModelInfo selectedModel;

        public FrmSalesForecastingPredictionForm(
    SalesForecastingModelInfo selectedModel)
        {
            InitializeComponent();

            if (selectedModel == null)
            {
                MessageBox.Show(
                    "Sales forecasting model could not be found.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Close();
                return;
            }

            this.selectedModel = selectedModel;

            SetModeData();
            DgvPredictionData.CellValueChanged +=
    DgvPredictionData_CellValueChanged;

            DgvPredictionData.CurrentCellDirtyStateChanged +=
                DgvPredictionData_CurrentCellDirtyStateChanged;
            LoadPredictionDataGridView();
        }


        private void SetModeData()
        {
            LblModelName.Text = this.selectedModel.ModelName;
            LblAlgorithm.Text = this.selectedModel.Algorithm;
        }

        private void LoadPredictionDataGridView()
        {
            DgvPredictionData.Columns.Clear();
            DgvPredictionData.Rows.Clear();

            DgvPredictionData.AutoGenerateColumns = false;
            DgvPredictionData.AllowUserToAddRows = false;
            DgvPredictionData.AllowUserToDeleteRows = false;
            DgvPredictionData.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            DgvPredictionData.MultiSelect = false;
            DgvPredictionData.RowHeadersVisible = false;
            DgvPredictionData.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            BLCompany blCompany = new BLCompany();
            BLProductOrService blProductOrService =
                new BLProductOrService();

            var companies = blCompany.CompanyList();

            var products = blProductOrService.ProductOrServiceList()
                .Where(x => x.IsProductOrService)
                .ToList();

            DgvPredictionData.Columns.Add(
                new DataGridViewComboBoxColumn
                {
                    Name = "Company",
                    HeaderText = "Company",
                    DataSource = companies,
                    DisplayMember = "CompanyName",
                    ValueMember = "CompanyId",
                    DisplayStyle =
                        DataGridViewComboBoxDisplayStyle.DropDownButton
                });

            DgvPredictionData.Columns.Add(
                new DataGridViewComboBoxColumn
                {
                    Name = "Product",
                    HeaderText = "Product",
                    DataSource = products,
                    DisplayMember = "ProductOrServiceName",
                    ValueMember = "ProductOrServiceId",
                    DisplayStyle =
                        DataGridViewComboBoxDisplayStyle.DropDownButton
                });

            DgvPredictionData.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Year",
                    HeaderText = "Year"
                });

            DataGridViewComboBoxColumn monthColumn =
                new DataGridViewComboBoxColumn
                {
                    Name = "Month",
                    HeaderText = "Month"
                };

            monthColumn.Items.AddRange(
                "1", "2", "3", "4", "5", "6",
                "7", "8", "9", "10", "11", "12");

            DgvPredictionData.Columns.Add(monthColumn);

            DgvPredictionData.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "PreviousMonthSales",
                    HeaderText = "Previous Month Sales"
                });

            DgvPredictionData.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "ThreeMonthAverage",
                    HeaderText = "Three Month Average"
                });

            DgvPredictionData.Columns["PreviousMonthSales"].ReadOnly = true;
            DgvPredictionData.Columns["ThreeMonthAverage"].ReadOnly = true;

            for (int i = 0; i < 5; i++)
            {
                DgvPredictionData.Rows.Add();
            }
        }

        private void BtnAddRow_Click(object sender, EventArgs e)
        {
            DgvPredictionData.Rows.Add();
        }

        private void BtnRemoveRow_Click(object sender, EventArgs e)
        {
            if (DgvPredictionData.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a row to remove.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            foreach (DataGridViewRow row in DgvPredictionData.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    DgvPredictionData.Rows.Remove(row);
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }


        private void BtnRunForecast_Click(object sender, EventArgs e)
        {
            if (DgvPredictionData.Rows.Count == 0)
            {
                MessageBox.Show(
                    "Please add at least one prediction row.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in DgvPredictionData.Rows)
            {
                if (row.IsNewRow)
                    continue;

                if (row.Cells["Company"].Value == null ||
                    row.Cells["Product"].Value == null ||
                    row.Cells["Year"].Value == null ||
                    row.Cells["Month"].Value == null ||
                    row.Cells["PreviousMonthSales"].Value == null ||
                    row.Cells["ThreeMonthAverage"].Value == null)
                {
                    MessageBox.Show(
                        "Please fill in all fields in every row.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                int year;
                int month;
                float previousMonthSales;
                float threeMonthAverage;

                if (!int.TryParse(row.Cells["Year"].Value.ToString(), out year) ||
                    !int.TryParse(row.Cells["Month"].Value.ToString(), out month) ||
                    !float.TryParse(row.Cells["PreviousMonthSales"].Value.ToString(), out previousMonthSales) ||
                    !float.TryParse(row.Cells["ThreeMonthAverage"].Value.ToString(), out threeMonthAverage))
                {
                    MessageBox.Show(
                        "Please enter valid numeric values.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (year < 1 || month < 1 || month > 12 ||
                    previousMonthSales < 0 || threeMonthAverage < 0)
                {
                    MessageBox.Show(
                        "Please enter valid year, month, and sales values.",
                        "Warning",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                Microsoft.ML.MLContext mlContext =
                    new Microsoft.ML.MLContext();

                var model = mlContext.Model.Load(
                    this.selectedModel.ModelPath,
                    out Microsoft.ML.DataViewSchema inputSchema);

                ConfigurePredictionResultsDataGridView();

                using (var predictionEngine =
                    mlContext.Model.CreatePredictionEngine<
                        MonthlySalesModelData,
                        MonthlySalesPrediction>(model))
                {
                    foreach (DataGridViewRow row in DgvPredictionData.Rows)
                    {
                        if (row.IsNewRow)
                            continue;

                        MonthlySalesModelData input =
                            new MonthlySalesModelData
                            {
                                CompanyName =
                                    row.Cells["Company"].FormattedValue.ToString(),

                                ProductName =
                                    row.Cells["Product"].FormattedValue.ToString(),

                                Year = Convert.ToSingle(row.Cells["Year"].Value),
                                Month = Convert.ToSingle(row.Cells["Month"].Value),

                                PreviousMonthSales = Convert.ToSingle(
                                    row.Cells["PreviousMonthSales"].Value),

                                ThreeMonthAverage = Convert.ToSingle(
                                    row.Cells["ThreeMonthAverage"].Value),

                                QuantitySold = 0
                            };

                        MonthlySalesPrediction prediction =
                            predictionEngine.Predict(input);

                        DgvPredictionResults.Rows.Add(
                            input.CompanyName,
                            input.ProductName,
                            input.Year,
                            input.Month,
                            input.PreviousMonthSales,
                            input.ThreeMonthAverage,
                            prediction.PredictedQuantity);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred during prediction: " + ex.Message,
                    "Prediction Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        private void ConfigurePredictionResultsDataGridView()
        {
            DgvPredictionResults.Columns.Clear();
            DgvPredictionResults.Rows.Clear();

            DgvPredictionResults.AutoGenerateColumns = false;
            DgvPredictionResults.ReadOnly = true;
            DgvPredictionResults.AllowUserToAddRows = false;
            DgvPredictionResults.AllowUserToDeleteRows = false;
            DgvPredictionResults.RowHeadersVisible = false;
            DgvPredictionResults.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            DgvPredictionResults.MultiSelect = false;
            DgvPredictionResults.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            DgvPredictionResults.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Company",
                    HeaderText = "Company"
                });

            DgvPredictionResults.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Product",
                    HeaderText = "Product"
                });

            DgvPredictionResults.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Year",
                    HeaderText = "Year"
                });

            DgvPredictionResults.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "Month",
                    HeaderText = "Month"
                });

            DgvPredictionResults.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "PreviousMonthSales",
                    HeaderText = "Previous Month Sales"
                });

            DgvPredictionResults.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "ThreeMonthAverage",
                    HeaderText = "Three Month Average"
                });

            DgvPredictionResults.Columns.Add(
                new DataGridViewTextBoxColumn
                {
                    Name = "PredictedQuantity",
                    HeaderText = "Predicted Amount"
                });
        }

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            if (DgvPredictionResults.Rows.Count == 0)
            {
                MessageBox.Show(
                    "There are no prediction results to export.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel File (*.xlsx)|*.xlsx";
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.AddExtension = true;
                saveFileDialog.FileName = "SalesForecastingResults.xlsx";
                saveFileDialog.Title = "Export Sales Forecasting Results";

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                int[] columnIndices = Enumerable
                    .Range(0, DgvPredictionResults.Columns.Count)
                    .ToArray();

                try
                {
                    ExcelExportHelper.ExportToExcel(
                        DgvPredictionResults,
                        columnIndices,
                        saveFileDialog.FileName);

                    MessageBox.Show(
                        "Prediction results exported to Excel successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Excel export failed: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void BtnExportPdf_Click(object sender, EventArgs e)
        {
            if (DgvPredictionResults.Rows.Count == 0)
            {
                MessageBox.Show(
                    "There are no prediction results to export.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF File (*.pdf)|*.pdf";
                saveFileDialog.DefaultExt = "pdf";
                saveFileDialog.AddExtension = true;
                saveFileDialog.FileName = "SalesForecastingResults.pdf";
                saveFileDialog.Title = "Export Sales Forecasting Results";

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                int[] columnIndices = Enumerable
                    .Range(0, DgvPredictionResults.Columns.Count)
                    .ToArray();

                try
                {
                    PdfExportHelper.ExportToPdf(
                        DgvPredictionResults,
                        columnIndices,
                        saveFileDialog.FileName,
                        "Sales Forecasting Results");

                    MessageBox.Show(
                        "Prediction results exported to PDF successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "PDF export failed: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void CalculateHistoricalSales(DataGridViewRow row)
        {
            if (row.IsNewRow ||
                row.Cells["Company"].Value == null ||
                row.Cells["Product"].Value == null ||
                row.Cells["Year"].Value == null ||
                row.Cells["Month"].Value == null)
            {
                return;
            }

            int companyId = Convert.ToInt32(
                row.Cells["Company"].Value);

            int productId = Convert.ToInt32(
                row.Cells["Product"].Value);

            int year;
            int month;

            if (!int.TryParse(
                    row.Cells["Year"].Value.ToString(), out year) ||
                !int.TryParse(
                    row.Cells["Month"].Value.ToString(), out month) ||
                year < 1 || month < 1 || month > 12)
            {
                return;
            }

            DateTime targetMonth = new DateTime(year, month, 1);
            DateTime threeMonthsStart = targetMonth.AddMonths(-3);

            BLCustomerBuysCompanyHasProductOrService blSales =
                new BLCustomerBuysCompanyHasProductOrService();

            var sales = blSales.CustomerBuysCompanyHasProductOrServiceList()
                .Where(x =>
                    x.CompanyHasProductOrService != null &&
                    x.CompanyHasProductOrService.CompanyId == companyId &&
                    x.CompanyHasProductOrService.ProductOrServiceId == productId &&
                    x.CustomerBuysCompanyHasProductOrServiceDate >= threeMonthsStart &&
                    x.CustomerBuysCompanyHasProductOrServiceDate < targetMonth)
                .ToList();

            DateTime previousMonth = targetMonth.AddMonths(-1);

            double previousMonthSales = sales
                .Where(x =>
                    x.CustomerBuysCompanyHasProductOrServiceDate >= previousMonth &&
                    x.CustomerBuysCompanyHasProductOrServiceDate < targetMonth)
                .Sum(x => Convert.ToDouble(
                    x.CustomerBuysCompanyHasProductOrServiceQuantity));

            double threeMonthAverage = sales.Sum(x =>
                Convert.ToDouble(
                    x.CustomerBuysCompanyHasProductOrServiceQuantity)) / 3.0;

            row.Cells["PreviousMonthSales"].Value = previousMonthSales;
            row.Cells["ThreeMonthAverage"].Value = threeMonthAverage;
        }

        private void DgvPredictionData_CellValueChanged(
    object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CalculateHistoricalSales(
                    DgvPredictionData.Rows[e.RowIndex]);
            }
        }

        private void DgvPredictionData_CurrentCellDirtyStateChanged(
            object sender, EventArgs e)
        {
            if (DgvPredictionData.IsCurrentCellDirty)
            {
                DgvPredictionData.CommitEdit(
                    DataGridViewDataErrorContexts.Commit);
            }
        }

    }
}
