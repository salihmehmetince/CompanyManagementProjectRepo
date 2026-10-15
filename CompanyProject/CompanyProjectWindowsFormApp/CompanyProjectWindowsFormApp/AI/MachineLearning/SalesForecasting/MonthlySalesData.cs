using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectWindowsFormApp.AI.MachineLearning.SalesForecasting
{

    public class MonthlySalesData
    {
        public string CompanyName { get; set; }

        public string ProductName { get; set; }

        public float Year { get; set; }

        public float Month { get; set; }

        public float QuantitySold { get; set; }
    }

}
