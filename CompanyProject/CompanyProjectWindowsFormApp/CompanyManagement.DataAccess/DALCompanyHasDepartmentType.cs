using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALCompanyHasDepartmentType
    {
        public List<CompanyHasDepartmentType> CompanyHasDepartmentTypeList()
        {
            using (var context = new AppDbContext())
            {
                return context.CompanyHasDepartmentTypes
                    .Include(x => x.Company)
                    .Include(x => x.DepartmentType)
                    .Include(x => x.EmployeeHasCompanyHasDepartmentTypes)
                    .ToList();
            }
        }

        public CompanyHasDepartmentType CompanyHasDepartmentTypeGetById(
            int companyHasDepartmentTypeId)
        {
            using (var context = new AppDbContext())
            {
                return context.CompanyHasDepartmentTypes
                    .Include(x => x.Company)
                    .Include(x => x.DepartmentType)
                    .Include(x => x.EmployeeHasCompanyHasDepartmentTypes)
                    .FirstOrDefault(x =>
                        x.CompanyHasDepartmentTypeId ==
                        companyHasDepartmentTypeId);
            }
        }

        public bool CompanyHasDepartmentTypeAdd(
            CompanyHasDepartmentType companyHasDepartmentType)
        {
            using (var context = new AppDbContext())
            {
                context.CompanyHasDepartmentTypes
                    .Add(companyHasDepartmentType);

                return context.SaveChanges() > 0;
            }
        }

        public bool CompanyHasDepartmentTypeUpdate(
            CompanyHasDepartmentType companyHasDepartmentType)
        {
            using (var context = new AppDbContext())
            {
                context.CompanyHasDepartmentTypes
                    .Update(companyHasDepartmentType);

                return context.SaveChanges() > 0;
            }
        }

        public bool CompanyHasDepartmentTypeDelete(
            int companyHasDepartmentTypeId)
        {
            using (var context = new AppDbContext())
            {
                var companyHasDepartmentType =
                    context.CompanyHasDepartmentTypes
                        .FirstOrDefault(x =>
                            x.CompanyHasDepartmentTypeId ==
                            companyHasDepartmentTypeId);

                if (companyHasDepartmentType == null)
                    return false;

                context.CompanyHasDepartmentTypes
                    .Remove(companyHasDepartmentType);

                return context.SaveChanges() > 0;
            }
        }
    }
}