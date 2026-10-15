using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectWindowsFormApp.AI.MachineLearning.SalesForecasting
{
    public class MonthlySalesDataService
    {
        public List<MonthlySalesData> GetMonthlySales()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var sales = context.CustomerBuysCompanyHasProductOrServices
                    .Where(s => s.CompanyHasProductOrService
                        .ProductOrService.IsProductOrService)
                    .GroupBy(s => new
                    {
                        s.CompanyHasProductOrService.Company.CompanyName,
                        s.CompanyHasProductOrService.ProductOrService
                            .ProductOrServiceName,
                        s.CustomerBuysCompanyHasProductOrServiceDate.Year,
                        s.CustomerBuysCompanyHasProductOrServiceDate.Month
                    })
                    .Select(g => new MonthlySalesData
                    {
                        CompanyName = g.Key.CompanyName,
                        ProductName = g.Key.ProductOrServiceName,
                        Year = g.Key.Year,
                        Month = g.Key.Month,
                        QuantitySold = (float)g.Sum(s =>
                            s.CustomerBuysCompanyHasProductOrServiceQuantity)
                    })
                    .OrderBy(s => s.Year)
                    .ThenBy(s => s.Month)
                    .ToList();

                return sales;
            }
        }
    }
}
