using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALProductOrService
    {
        public List<ProductOrService> ProductOrServiceList()
        {
            using (var context = new AppDbContext())
            {
                return context.ProductsOrServices
                    .Include(x => x.ProductOrServiceType)
                    .Include(x => x.CompanyHasProductOrServices)
                    .ToList();
            }
        }

        public ProductOrService ProductOrServiceGetById(int productOrServiceId)
        {
            using (var context = new AppDbContext())
            {
                return context.ProductsOrServices
                    .Include(x => x.ProductOrServiceType)
                    .Include(x => x.CompanyHasProductOrServices)
                    .FirstOrDefault(x =>
                        x.ProductOrServiceId == productOrServiceId);
            }
        }

        public bool ProductOrServiceAdd(ProductOrService productOrService)
        {
            using (var context = new AppDbContext())
            {
                context.ProductsOrServices.Add(productOrService);

                return context.SaveChanges() > 0;
            }
        }

        public bool ProductOrServiceUpdate(ProductOrService productOrService)
        {
            using (var context = new AppDbContext())
            {
                context.ProductsOrServices.Update(productOrService);

                return context.SaveChanges() > 0;
            }
        }

        public bool ProductOrServiceDelete(int productOrServiceId)
        {
            using (var context = new AppDbContext())
            {
                var productOrService = context.ProductsOrServices
                    .FirstOrDefault(x =>
                        x.ProductOrServiceId == productOrServiceId);

                if (productOrService == null)
                    return false;

                context.ProductsOrServices.Remove(productOrService);

                return context.SaveChanges() > 0;
            }
        }
    }
}