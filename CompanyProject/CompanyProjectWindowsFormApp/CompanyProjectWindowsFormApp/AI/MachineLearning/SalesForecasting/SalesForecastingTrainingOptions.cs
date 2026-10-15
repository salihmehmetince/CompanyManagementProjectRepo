using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectWindowsFormApp.AI.MachineLearning.SalesForecasting
{
    public class SalesForecastingTrainingOptions
    {
        public string ModelName { get; set; }

        public string Algorithm { get; set; }

        public bool UseCompany { get; set; }

        public bool UseProduct { get; set; }

        public bool UseYear { get; set; }

        public bool UseMonth { get; set; }

        public bool UsePreviousMonthSales { get; set; }

        public bool UseThreeMonthAverage { get; set; }

        public float TrainRatio { get; set; }
    }
}
