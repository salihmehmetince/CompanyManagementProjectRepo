using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectWindowsFormApp.AI.MachineLearning.SalesForecasting
{
    public class SalesForecastingModelRegistryService
    {
        private readonly string _basePath =
    @"C:\CompanyManagement\AI\forecasting";

        private string RegistryPath =>
            Path.Combine(_basePath, "sales-forecasting-model-registry.json");

        public SalesForecastingModelRegistryService()
        {
            Directory.CreateDirectory(_basePath);

            if (!File.Exists(RegistryPath))
            {
                File.WriteAllText(RegistryPath, "[]");
            }
        }

        public List<SalesForecastingModelInfo> GetModels()
        {
            string json = File.ReadAllText(RegistryPath);

            return JsonConvert.DeserializeObject<List<SalesForecastingModelInfo>>(json)
                   ?? new List<SalesForecastingModelInfo>();
        }

        public bool AddModel(SalesForecastingModelInfo model)
        {
            if (model == null ||
                string.IsNullOrWhiteSpace(model.ModelName) ||
                string.IsNullOrWhiteSpace(model.ModelPath) ||
                !File.Exists(model.ModelPath))
            {
                return false;
            }

            List<SalesForecastingModelInfo> models = GetModels();

            if (models.Any(m => m.ModelId == model.ModelId))
            {
                return false;
            }

            models.Add(model);

            SaveModels(models);

            return true;
        }

        public bool DeleteModel(string modelId)
        {
            List<SalesForecastingModelInfo> models = GetModels();

            SalesForecastingModelInfo model = models.FirstOrDefault(
                m => m.ModelId == modelId);

            if (model == null)
            {
                return false;
            }

            models.Remove(model);

            SaveModels(models);

            return true;
        }

        private void SaveModels(List<SalesForecastingModelInfo> models)
        {
            string json = JsonConvert.SerializeObject(
                models, Formatting.Indented);

            File.WriteAllText(RegistryPath, json);
        }
    }
}
