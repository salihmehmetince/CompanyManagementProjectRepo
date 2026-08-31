using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLUserRole
    {
        DALUserRole dalUserRole = new DALUserRole();

        public List<UserRole> UserRoleList()
        {
            return dalUserRole.UserRoleList();
        }

        public UserRole UserRoleGetById(int userRoleId)
        {
            return dalUserRole.UserRoleGetById(userRoleId);
        }

        public bool UserRoleAdd(UserRole userRole)
        {
            if (userRole == null)
                return false;

            if (!Validation.StringControl(
                userRole.UserRoleName,
                1,
                30))
                return false;

            return dalUserRole.UserRoleAdd(userRole);
        }

        public bool UserRoleUpdate(UserRole userRole)
        {
            if (userRole == null)
                return false;

            var existingUserRole = dalUserRole
                .UserRoleGetById(userRole.UserRoleId);

            if (existingUserRole == null)
                return false;

            if (!Validation.StringControl(
                userRole.UserRoleName,
                1,
                30))
                return false;

            existingUserRole.UserRoleName =
                userRole.UserRoleName;

            return dalUserRole.UserRoleUpdate(existingUserRole);
        }

        public bool UserRoleDelete(int userRoleId)
        {
            var existingUserRole = dalUserRole
                .UserRoleGetById(userRoleId);

            if (existingUserRole == null)
                return false;

            if (existingUserRole.Users != null &&
                existingUserRole.Users.Count > 0)
                return false;

            return dalUserRole.UserRoleDelete(
                existingUserRole.UserRoleId);
        }
    }
}
