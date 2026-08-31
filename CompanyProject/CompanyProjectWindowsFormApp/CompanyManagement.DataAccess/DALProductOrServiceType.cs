using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALProductOrServiceType
    {
        public List<ProductOrServiceType> ProductOrServiceTypeList()
        {
            using (var context = new AppDbContext())
            {
                return context.ProductOrServiceTypes
                    .Include(x => x.ProductsOrServices)
                    .ToList();
            }
        }

        public ProductOrServiceType ProductOrServiceTypeGetById(
            int productOrServiceTypeId)
        {
            using (var context = new AppDbContext())
            {
                return context.ProductOrServiceTypes
                    .Include(x => x.ProductsOrServices)
                    .FirstOrDefault(x =>
                        x.ProductOrServiceTypeId == productOrServiceTypeId);
            }
        }

        public bool ProductOrServiceTypeAdd(
            ProductOrServiceType productOrServiceType)
        {
            using (var context = new AppDbContext())
            {
                context.ProductOrServiceTypes.Add(productOrServiceType);

                return context.SaveChanges() > 0;
            }
        }

        public bool ProductOrServiceTypeUpdate(
            ProductOrServiceType productOrServiceType)
        {
            using (var context = new AppDbContext())
            {
                context.ProductOrServiceTypes.Update(productOrServiceType);

                return context.SaveChanges() > 0;
            }
        }

        public bool ProductOrServiceTypeDelete(int productOrServiceTypeId)
        {
            using (var context = new AppDbContext())
            {
                var productOrServiceType =
                    context.ProductOrServiceTypes
                        .FirstOrDefault(x =>
                            x.ProductOrServiceTypeId ==
                            productOrServiceTypeId);

                if (productOrServiceType == null)
                    return false;

                context.ProductOrServiceTypes.Remove(productOrServiceType);

                return context.SaveChanges() > 0;
            }
        }
    }
}