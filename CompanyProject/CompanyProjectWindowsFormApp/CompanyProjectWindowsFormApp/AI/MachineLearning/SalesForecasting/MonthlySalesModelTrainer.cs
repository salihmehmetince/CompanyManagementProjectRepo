
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.ML;

namespace CompanyProjectWindowsFormApp.AI.MachineLearning.SalesForecasting
{
    public class MonthlySalesModelTrainer
    {
        private readonly MLContext _mlContext;

        public MonthlySalesModelTrainer()
        {
            _mlContext = new MLContext(seed: 42);
        }

        public SalesForecastingTrainingResult TrainModel(
            SalesForecastingTrainingOptions options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            if (string.IsNullOrWhiteSpace(options.ModelName))
                throw new InvalidOperationException("Model adı boş olamaz.");

            if (options.TrainRatio <= 0 || options.TrainRatio >= 1)
                throw new InvalidOperationException(
                    "Eğitim oranı 0 ile 1 arasında olmalıdır.");

            if (!options.UseCompany &&
                !options.UseProduct &&
                !options.UseYear &&
                !options.UseMonth &&
                !options.UsePreviousMonthSales &&
                !options.UseThreeMonthAverage)
            {
                throw new InvalidOperationException(
                    "En az bir özellik seçilmelidir.");
            }

            List<MonthlySalesData> monthlySales =
                new MonthlySalesDataService().GetMonthlySales();

            if (monthlySales == null || monthlySales.Count == 0)
                throw new InvalidOperationException(
                    "Satış verisi bulunamadı.");

            List<MonthlySalesModelData> sales =
                BuildFeatureRows(monthlySales);

            if (sales.Count < 10)
                throw new InvalidOperationException(
                    "Model eğitimi için yeterli satış verisi yok.");

            int trainCount = (int)(sales.Count * options.TrainRatio);

            if (trainCount < 2 || sales.Count - trainCount < 1)
                throw new InvalidOperationException(
                    "Eğitim ve test verisi sayısı yetersiz.");

            List<MonthlySalesModelData> trainSales =
                sales.Take(trainCount).ToList();

            List<MonthlySalesModelData> testSales =
                sales.Skip(trainCount).ToList();

            var trainData =
                _mlContext.Data.LoadFromEnumerable(trainSales);

            var testData =
                _mlContext.Data.LoadFromEnumerable(testSales);

            IEstimator<ITransformer> pipeline = null;

            if (options.UseCompany)
            {
                pipeline = _mlContext.Transforms.Categorical
                    .OneHotEncoding(
                        outputColumnName: "CompanyEncoded",
                        inputColumnName:
                            nameof(MonthlySalesModelData.CompanyName));
            }

            if (options.UseProduct)
            {
                var productTransform =
                    _mlContext.Transforms.Categorical.OneHotEncoding(
                        outputColumnName: "ProductEncoded",
                        inputColumnName:
                            nameof(MonthlySalesModelData.ProductName));

                if (pipeline == null)
                    pipeline = productTransform;
                else
                    pipeline = pipeline.Append(productTransform);
            }

            List<string> featureColumns = new List<string>();

            if (options.UseCompany)
                featureColumns.Add("CompanyEncoded");

            if (options.UseProduct)
                featureColumns.Add("ProductEncoded");

            if (options.UseYear)
                featureColumns.Add(nameof(MonthlySalesModelData.Year));

            if (options.UseMonth)
                featureColumns.Add(nameof(MonthlySalesModelData.Month));

            if (options.UsePreviousMonthSales)
                featureColumns.Add(
                    nameof(MonthlySalesModelData.PreviousMonthSales));

            if (options.UseThreeMonthAverage)
                featureColumns.Add(
                    nameof(MonthlySalesModelData.ThreeMonthAverage));

            if (pipeline == null)
            {
                pipeline = _mlContext.Transforms.Concatenate(
                    "Features", featureColumns.ToArray());
            }
            else
            {
                pipeline = pipeline.Append(
                    _mlContext.Transforms.Concatenate(
                        "Features", featureColumns.ToArray()));
            }

            switch (options.Algorithm)
            {
                case "SDCA":
                    pipeline = pipeline.Append(
                        _mlContext.Regression.Trainers.Sdca(
                            labelColumnName:
                                nameof(MonthlySalesModelData.QuantitySold),
                            featureColumnName: "Features"));
                    break;

                case "FastTree":
                    pipeline = pipeline.Append(
                        _mlContext.Regression.Trainers.FastTree(
                            labelColumnName:
                                nameof(MonthlySalesModelData.QuantitySold),
                            featureColumnName: "Features"));
                    break;

                case "FastForest":
                    pipeline = pipeline.Append(
                        _mlContext.Regression.Trainers.FastForest(
                            labelColumnName:
                                nameof(MonthlySalesModelData.QuantitySold),
                            featureColumnName: "Features"));
                    break;

                default:
                    throw new InvalidOperationException(
                        "Geçersiz algoritma seçildi.");
            }

            ITransformer model = pipeline.Fit(trainData);

            var predictions = model.Transform(testData);

            var metrics = _mlContext.Regression.Evaluate(
                predictions,
                labelColumnName:
                    nameof(MonthlySalesModelData.QuantitySold));

            string modelDirectory = Path.Combine(
                @"C:\CompanyManagement\AI\forecasting",
                Guid.NewGuid().ToString("N"));

            Directory.CreateDirectory(modelDirectory);

            string modelPath =
                Path.Combine(modelDirectory, "model.zip");

            _mlContext.Model.Save(model, trainData.Schema, modelPath);

            return new SalesForecastingTrainingResult
            {
                ModelName = options.ModelName,
                Algorithm = options.Algorithm,
                TrainingDate = DateTime.Now,
                ModelPath = modelPath,
                MAE = (float)metrics.MeanAbsoluteError,
                RMSE = (float)metrics.RootMeanSquaredError,
                RSquared = (float)metrics.RSquared,
                TrainingRecordCount = trainSales.Count,
                TestRecordCount = testSales.Count
            };
        }

        private List<MonthlySalesModelData> BuildFeatureRows(
            List<MonthlySalesData> monthlySales)
        {
            List<MonthlySalesModelData> result =
                new List<MonthlySalesModelData>();

            DateTime lastMonth = monthlySales
                .Select(x => new DateTime((int)x.Year, (int)x.Month, 1))
                .Max();

            var groups = monthlySales
                .GroupBy(x => new
                {
                    x.CompanyName,
                    x.ProductName
                });

            foreach (var group in groups)
            {
                Dictionary<DateTime, float> quantities =
                    group.GroupBy(x => new DateTime((int)x.Year, (int)x.Month, 1))
                        .ToDictionary(
                            x => x.Key,
                            x => x.Sum(y => y.QuantitySold));

                DateTime currentMonth = quantities.Keys.Min();

                while (currentMonth <= lastMonth)
                {
                    float currentQuantity =
                        quantities.ContainsKey(currentMonth)
                            ? quantities[currentMonth]
                            : 0f;

                    DateTime previousMonth =
                        currentMonth.AddMonths(-1);

                    DateTime twoMonthsAgo =
                        currentMonth.AddMonths(-2);

                    DateTime threeMonthsAgo =
                        currentMonth.AddMonths(-3);

                    float previousMonthSales =
                        quantities.ContainsKey(previousMonth)
                            ? quantities[previousMonth]
                            : 0f;

                    float twoMonthsAgoSales =
                        quantities.ContainsKey(twoMonthsAgo)
                            ? quantities[twoMonthsAgo]
                            : 0f;

                    float threeMonthsAgoSales =
                        quantities.ContainsKey(threeMonthsAgo)
                            ? quantities[threeMonthsAgo]
                            : 0f;

                    result.Add(new MonthlySalesModelData
                    {
                        CompanyName = group.Key.CompanyName,
                        ProductName = group.Key.ProductName,
                        Year = currentMonth.Year,
                        Month = currentMonth.Month,
                        QuantitySold = currentQuantity,
                        PreviousMonthSales = previousMonthSales,
                        ThreeMonthAverage =
                            (previousMonthSales +
                             twoMonthsAgoSales +
                             threeMonthsAgoSales) / 3f
                    });

                    currentMonth = currentMonth.AddMonths(1);
                }
            }

            return result
                .OrderBy(x => x.Year)
                .ThenBy(x => x.Month)
                .ThenBy(x => x.CompanyName)
                .ThenBy(x => x.ProductName)
                .ToList();
        }
    }
}
