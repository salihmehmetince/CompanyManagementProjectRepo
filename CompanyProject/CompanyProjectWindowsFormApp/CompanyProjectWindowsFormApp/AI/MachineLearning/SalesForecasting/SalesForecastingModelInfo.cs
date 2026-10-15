using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectWindowsFormApp.AI.MachineLearning.SalesForecasting
{
    public class SalesForecastingModelInfo
    {
        public string ModelId { get; set; }

        public string ModelName { get; set; }

        public string ModelType { get; set; }

        public string Algorithm { get; set; }

        public DateTime TrainingDate { get; set; }

        public string ModelPath { get; set; }

        public float MAE { get; set; }

        public float RMSE { get; set; }
    }
}
