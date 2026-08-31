using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALUserRole
    {
        public List<UserRole> UserRoleList()
        {
            using (var context = new AppDbContext())
            {
                return context.UserRoles
                    .Include(x => x.Users)
                    .ToList();
            }
        }

        public UserRole UserRoleGetById(int userRoleId)
        {
            using (var context = new AppDbContext())
            {
                return context.UserRoles
                    .Include(x => x.Users)
                    .FirstOrDefault(x => x.UserRoleId == userRoleId);
            }
        }

        public bool UserRoleAdd(UserRole userRole)
        {
            using (var context = new AppDbContext())
            {
                context.UserRoles.Add(userRole);

                return context.SaveChanges() > 0;
            }
        }

        public bool UserRoleUpdate(UserRole userRole)
        {
            using (var context = new AppDbContext())
            {
                context.UserRoles.Update(userRole);

                return context.SaveChanges() > 0;
            }
        }

        public bool UserRoleDelete(int userRoleId)
        {
            using (var context = new AppDbContext())
            {
                var userRole = context.UserRoles
                    .FirstOrDefault(x => x.UserRoleId == userRoleId);

                if (userRole == null)
                    return false;

                context.UserRoles.Remove(userRole);

                return context.SaveChanges() > 0;
            }
        }
    }
}
