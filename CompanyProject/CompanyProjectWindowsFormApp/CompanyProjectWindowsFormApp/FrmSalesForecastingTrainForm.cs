using CompanyManagement.Entity;
using CompanyProjectWindowsFormApp.AI.MachineLearning.SalesForecasting;
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
    public partial class FrmSalesForecastingTrainForm : Form
    {

        private User user;
        private List<int> selectedCompanyIds;
        public FrmSalesForecastingTrainForm(
            User user,
            List<int> selectedCompanyIds)
        {
            InitializeComponent();
            this.user = user;
            this.selectedCompanyIds = selectedCompanyIds;
            LoadTrainingOptions();
            SetButtonsBorder();
        }

        private void LoadTrainingOptions()
        {
            RdoSDCA.Checked = true;

            ChkCompany.Checked = true;
            ChkProduct.Checked = true;
            ChkYear.Checked = true;
            ChkMonth.Checked = true;

            ChkPreviousMonthSales.Checked = true;
            ChkThreeMonthAverage.Checked = true;

            CmbTrainTestRatio.Items.Clear();

            CmbTrainTestRatio.Items.Add("70% Training / 30% Test");
            CmbTrainTestRatio.Items.Add("80% Training / 20% Test");
            CmbTrainTestRatio.Items.Add("90% Training / 10% Test");

            CmbTrainTestRatio.SelectedIndex = 1;
        }

        private void SetButtonsBorder()
        {
            BtnTrainModel.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatAppearance.BorderSize = 0;
        }


        private void BtnTrainModel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtModelName.Text))
            {
                MessageBox.Show(
                    "Please enter a model name.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!RdoSDCA.Checked &&
                !RdoFastTree.Checked &&
                !RdoFastForest.Checked)
            {
                MessageBox.Show(
                    "Please select an algorithm.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!ChkCompany.Checked &&
                !ChkProduct.Checked &&
                !ChkYear.Checked &&
                !ChkMonth.Checked &&
                !ChkPreviousMonthSales.Checked &&
                !ChkThreeMonthAverage.Checked)
            {
                MessageBox.Show(
                    "Please select at least one feature.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (CmbTrainTestRatio.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select a training/test ratio.",
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            float trainRatio = 0.80f;

            switch (CmbTrainTestRatio.SelectedIndex)
            {
                case 0:
                    trainRatio = 0.70f;
                    break;

                case 1:
                    trainRatio = 0.80f;
                    break;

                case 2:
                    trainRatio = 0.90f;
                    break;
            }

            SalesForecastingTrainingOptions options =
                new SalesForecastingTrainingOptions
                {
                    ModelName = TxtModelName.Text.Trim(),

                    Algorithm = RdoSDCA.Checked
                        ? "SDCA"
                        : RdoFastTree.Checked
                            ? "FastTree"
                            : "FastForest",

                    UseCompany = ChkCompany.Checked,
                    UseProduct = ChkProduct.Checked,
                    UseYear = ChkYear.Checked,
                    UseMonth = ChkMonth.Checked,

                    UsePreviousMonthSales =
                        ChkPreviousMonthSales.Checked,

                    UseThreeMonthAverage =
                        ChkThreeMonthAverage.Checked,

                    TrainRatio = trainRatio
                };

            try
            {
                MonthlySalesModelTrainer trainer =
                    new MonthlySalesModelTrainer();

                SalesForecastingTrainingResult result =
                    trainer.TrainModel(options);

                SalesForecastingModelRegistryService registry =
                    new SalesForecastingModelRegistryService();

                SalesForecastingModelInfo modelInfo =
                    new SalesForecastingModelInfo
                    {
                        ModelId = Guid.NewGuid().ToString("N"),
                        ModelName = result.ModelName,
                        ModelType = "SalesForecasting",
                        Algorithm = result.Algorithm,
                        TrainingDate = result.TrainingDate,
                        ModelPath = result.ModelPath,
                        MAE = result.MAE,
                        RMSE = result.RMSE
                    };

                if (!registry.AddModel(modelInfo))
                {
                    MessageBox.Show(
                        "Model trained, but it could not be added to the registry.",
                        "Sales Forecasting",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show(
                    "Model training completed successfully.\n\n" +
                    "Model: " + result.ModelName + "\n" +
                    "Algorithm: " + result.Algorithm + "\n" +
                    "MAE: " + result.MAE.ToString("F2") + "\n" +
                    "RMSE: " + result.RMSE.ToString("F2") + "\n" +
                    "R²: " + result.RSquared.ToString("F2") + "\n" +
                    "Training records: " + result.TrainingRecordCount + "\n" +
                    "Test records: " + result.TestRecordCount,
                    "Sales Forecasting",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred during model training:\n" +
                    ex.Message,
                    "Sales Forecasting",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
