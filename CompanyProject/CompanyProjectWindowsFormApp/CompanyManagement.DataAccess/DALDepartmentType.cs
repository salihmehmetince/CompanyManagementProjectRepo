using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALDepartmentType
    {
        public List<DepartmentType> DepartmentTypeList()
        {
            using (var context = new AppDbContext())
            {
                return context.DepartmentTypes
                    .Include(x => x.CompanyHasDepartmentTypes)
                    .ToList();
            }
        }

        public DepartmentType DepartmentTypeGetById(int departmentTypeId)
        {
            using (var context = new AppDbContext())
            {
                return context.DepartmentTypes
                    .Include(x => x.CompanyHasDepartmentTypes)
                    .FirstOrDefault(x => x.DepartmentTypeId == departmentTypeId);
            }
        }

        public bool DepartmentTypeAdd(DepartmentType departmentType)
        {
            using (var context = new AppDbContext())
            {
                context.DepartmentTypes.Add(departmentType);

                return context.SaveChanges() > 0;
            }
        }

        public bool DepartmentTypeUpdate(DepartmentType departmentType)
        {
            using (var context = new AppDbContext())
            {
                context.DepartmentTypes.Update(departmentType);

                return context.SaveChanges() > 0;
            }
        }

        public bool DepartmentTypeDelete(int departmentTypeId)
        {
            using (var context = new AppDbContext())
            {
                var departmentType = context.DepartmentTypes
                    .FirstOrDefault(x => x.DepartmentTypeId == departmentTypeId);

                if (departmentType == null)
                    return false;

                context.DepartmentTypes.Remove(departmentType);

                return context.SaveChanges() > 0;
            }
        }
    }
}