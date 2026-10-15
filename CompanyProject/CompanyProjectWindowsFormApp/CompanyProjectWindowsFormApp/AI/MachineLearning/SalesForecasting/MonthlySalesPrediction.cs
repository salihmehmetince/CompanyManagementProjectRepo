using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectWindowsFormApp.AI.MachineLearning.SalesForecasting
{
    public class MonthlySalesPrediction
    {
        [ColumnName("Score")]
        public float PredictedQuantity { get; set; }
    }
}
