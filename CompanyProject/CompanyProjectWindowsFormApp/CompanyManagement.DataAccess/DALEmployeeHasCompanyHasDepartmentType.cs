using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALEmployeeHasCompanyHasDepartmentType
    {
        public List<EmployeeHasCompanyHasDepartmentType>
            EmployeeHasCompanyHasDepartmentTypeList()
        {
            using (var context = new AppDbContext())
            {
                return context.EmployeeHasCompanyHasDepartmentTypes
                    .Include(x => x.Employee)
                    .Include(x => x.CompanyHasDepartmentType)
                    .ToList();
            }
        }

        public EmployeeHasCompanyHasDepartmentType
            EmployeeHasCompanyHasDepartmentTypeGetById(
                int employeeHasCompanyId)
        {
            using (var context = new AppDbContext())
            {
                return context.EmployeeHasCompanyHasDepartmentTypes
                    .Include(x => x.Employee)
                    .Include(x => x.CompanyHasDepartmentType)
                    .FirstOrDefault(
                        x => x.EmployeeHasCompanyId == employeeHasCompanyId);
            }
        }

        public bool EmployeeHasCompanyHasDepartmentTypeAdd(
            EmployeeHasCompanyHasDepartmentType
                employeeHasCompanyHasDepartmentType)
        {
            using (var context = new AppDbContext())
            {
                context.EmployeeHasCompanyHasDepartmentTypes
                    .Add(employeeHasCompanyHasDepartmentType);

                return context.SaveChanges() > 0;
            }
        }

        public bool EmployeeHasCompanyHasDepartmentTypeUpdate(
            EmployeeHasCompanyHasDepartmentType
                employeeHasCompanyHasDepartmentType)
        {
            using (var context = new AppDbContext())
            {
                context.EmployeeHasCompanyHasDepartmentTypes
                    .Update(employeeHasCompanyHasDepartmentType);

                return context.SaveChanges() > 0;
            }
        }

        public bool EmployeeHasCompanyHasDepartmentTypeDelete(
            int employeeHasCompanyId)
        {
            using (var context = new AppDbContext())
            {
                var employeeHasCompany =
                    context.EmployeeHasCompanyHasDepartmentTypes
                        .FirstOrDefault(
                            x => x.EmployeeHasCompanyId ==
                                 employeeHasCompanyId);

                if (employeeHasCompany == null)
                    return false;

                context.EmployeeHasCompanyHasDepartmentTypes
                    .Remove(employeeHasCompany);

                return context.SaveChanges() > 0;
            }
        }
    }
}
