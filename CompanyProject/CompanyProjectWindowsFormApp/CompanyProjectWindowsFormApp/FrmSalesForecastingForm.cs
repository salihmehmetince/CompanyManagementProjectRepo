using CompanyManagement.Entity;
using CompanyProjectWindowsFormApp.AI.MachineLearning.SalesForecasting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyProjectWindowsFormApp
{
    public partial class FrmSalesForecastingForm : Form
    {
        private User user;
        private List<int> selectedCompanyIds;
        private readonly SalesForecastingModelRegistryService
    salesForecastingModelRegistryService =
        new SalesForecastingModelRegistryService();
        public FrmSalesForecastingForm(
            User user,
            List<int> selectedCompanyIds)
        {
            InitializeComponent();
            this.user = user;
            this.selectedCompanyIds = selectedCompanyIds;
            setIcon();
            SetButtonsBorder();
            ListSalesForecasting();
        }

        private void setIcon()
        {
            this.Icon = Properties.Resources.icon_company;
        }


        private void SetButtonsBorder()
        {
            BtnTrainModel.FlatAppearance.BorderSize = 0;
            BtnUseModel.FlatAppearance.BorderSize = 0;
            BtnDeleteModel.FlatAppearance.BorderSize = 0;
        }

        private void ListSalesForecasting()
        {
            List<SalesForecastingModelInfo> models =
                salesForecastingModelRegistryService
                    .GetModels();

            var modelList =
                models.Select(x => new
                {
                    x.ModelId,
                    x.ModelName,
                    x.ModelType,
                    x.Algorithm,
                    x.TrainingDate,
                    x.MAE,
                    x.RMSE
                }).ToList();

            DgvSalesForecasting.DataSource =
                modelList;

            LblRecordCount.Text =
                models.Count +
                " models";
        }

        private SalesForecastingModelInfo GetSelectedSalesForecasting()
        {
            if (DgvSalesForecasting.CurrentRow == null)
                return null;

            string modelId = Convert.ToString(
                DgvSalesForecasting.CurrentRow.Cells["ModelId"].Value
            );

            return salesForecastingModelRegistryService
                .GetModels()
                .FirstOrDefault(x => x.ModelId == modelId);
        }

        private void SearchSalesForecasting()
        {
            string searchText =
                TxtSearch.Text.Trim().ToLower();

            List<SalesForecastingModelInfo> models =
                salesForecastingModelRegistryService
                    .GetModels();

            if (!string.IsNullOrEmpty(searchText))
            {
                models = models
                    .Where(x =>
                        x.ModelName.ToLower().Contains(searchText) ||
                        x.ModelType.ToLower().Contains(searchText) ||
                        x.Algorithm.ToLower().Contains(searchText) ||
                        x.TrainingDate
                            .ToString("dd.MM.yyyy")
                            .Contains(searchText))
                    .ToList();
            }

            var modelList =
                models.Select(x => new
                {
                    x.ModelId,
                    x.ModelName,
                    x.ModelType,
                    x.Algorithm,
                    x.TrainingDate,
                    x.MAE,
                    x.RMSE
                }).ToList();

            DgvSalesForecasting.DataSource =
                modelList;

            LblRecordCount.Text =
                models.Count +
                " models";
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchSalesForecasting();
        }

        private void BtnTrainModel_Click(object sender, EventArgs e)
        {
            FrmSalesForecastingTrainForm frm =
                new FrmSalesForecastingTrainForm(user,selectedCompanyIds);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListSalesForecasting();
            }
        }


        private void BtnUseModel_Click(object sender, EventArgs e)
        {
            SalesForecastingModelInfo selectedModel =
                GetSelectedSalesForecasting();

            if (selectedModel == null)
            {
                MessageBox.Show(
                    "Please select a model.",
                    "Sales Forecasting",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!File.Exists(selectedModel.ModelPath))
            {
                MessageBox.Show(
                    "The selected model file could not be found.",
                    "Sales Forecasting",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            FrmSalesForecastingPredictionForm frm =
                new FrmSalesForecastingPredictionForm(selectedModel);

            frm.ShowDialog();
        }

    }
}
