using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALCompanyType
    {
        public List<CompanyType> CompanyTypeList()
        {
            using (var context = new AppDbContext())
            {
                return context.CompanyTypes
                    .Include(x => x.Companies)
                    .ToList();
            }
        }

        public CompanyType CompanyTypeGetById(int companyTypeId)
        {
            using (var context = new AppDbContext())
            {
                return context.CompanyTypes
                    .Include(x => x.Companies)
                    .FirstOrDefault(x => x.CompanyTypeId == companyTypeId);
            }
        }

        public bool CompanyTypeAdd(CompanyType companyType)
        {
            using (var context = new AppDbContext())
            {
                context.CompanyTypes.Add(companyType);

                return context.SaveChanges() > 0;
            }
        }

        public bool CompanyTypeUpdate(CompanyType companyType)
        {
            using (var context = new AppDbContext())
            {
                context.CompanyTypes.Update(companyType);

                return context.SaveChanges() > 0;
            }
        }

        public bool CompanyTypeDelete(int companyTypeId)
        {
            using (var context = new AppDbContext())
            {
                var companyType = context.CompanyTypes
                    .FirstOrDefault(x => x.CompanyTypeId == companyTypeId);

                if (companyType == null)
                    return false;

                context.CompanyTypes.Remove(companyType);

                return context.SaveChanges() > 0;
            }
        }
    }
}