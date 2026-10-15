using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectWindowsFormApp.AI.MachineLearning.SalesForecasting
{
    public class SalesForecastingTrainingResult
    {
        public string ModelName { get; set; }

        public string Algorithm { get; set; }

        public DateTime TrainingDate { get; set; }

        public string ModelPath { get; set; }

        public float MAE { get; set; }

        public float RMSE { get; set; }

        public float RSquared { get; set; }

        public int TrainingRecordCount { get; set; }

        public int TestRecordCount { get; set; }
    }
}
