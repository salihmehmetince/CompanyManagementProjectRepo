using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLDepartmentType
    {
        DALDepartmentType dalDepartmentType =
            new DALDepartmentType();

        public List<DepartmentType> DepartmentTypeList()
        {
            return dalDepartmentType.DepartmentTypeList();
        }

        public DepartmentType DepartmentTypeGetById(
            int departmentTypeId)
        {
            if (!Validation.IntControl(
                departmentTypeId,
                1,
                int.MaxValue))
                return null;

            return dalDepartmentType
                .DepartmentTypeGetById(departmentTypeId);
        }

        public bool DepartmentTypeAdd(
            DepartmentType departmentType)
        {
            if (departmentType == null)
                return false;

            if (!Validation.StringControl(
                departmentType.DepartmentName,
                1,
                50))
                return false;

            return dalDepartmentType
                .DepartmentTypeAdd(departmentType);
        }

        public bool DepartmentTypeUpdate(
            DepartmentType departmentType)
        {
            if (departmentType == null)
                return false;

            if (!Validation.IntControl(
                departmentType.DepartmentTypeId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.StringControl(
                departmentType.DepartmentName,
                1,
                50))
                return false;

            var existingDepartmentType =
                dalDepartmentType
                    .DepartmentTypeGetById(
                        departmentType.DepartmentTypeId);

            if (existingDepartmentType == null)
                return false;

            return dalDepartmentType
                .DepartmentTypeUpdate(departmentType);
        }

        public bool DepartmentTypeDelete(
            int departmentTypeId)
        {
            if (!Validation.IntControl(
                departmentTypeId,
                1,
                int.MaxValue))
                return false;

            var existingDepartmentType =
                dalDepartmentType
                    .DepartmentTypeGetById(departmentTypeId);

            if (existingDepartmentType == null)
                return false;

            return dalDepartmentType
                .DepartmentTypeDelete(departmentTypeId);
        }
    }
}
