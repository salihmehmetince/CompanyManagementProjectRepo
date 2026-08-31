using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALUser
    {
        public List<User> UserList()
        {
            using (var context = new AppDbContext())
            {
                return context.Users
                    .Include(x => x.UserRole)
                    .ToList();
            }
        }

        public User UserGetById(int userId)
        {
            using (var context = new AppDbContext())
            {
                return context.Users
                    .Include(x => x.UserRole)
                    .FirstOrDefault(x => x.UserId == userId);
            }
        }

        public User UserGetByUsername(string username)
        {
            using (var context = new AppDbContext())
            {
                return context.Users
                    .Include(x => x.UserRole)
                    .FirstOrDefault(x => x.Username == username);
            }
        }

        public bool UserAdd(User user)
        {
            using (var context = new AppDbContext())
            {
                context.Users.Add(user);

                return context.SaveChanges() > 0;
            }
        }

        public bool UserUpdate(User user)
        {
            using (var context = new AppDbContext())
            {
                context.Users.Update(user);

                return context.SaveChanges() > 0;
            }
        }

        public bool UserDelete(int userId)
        {
            using (var context = new AppDbContext())
            {
                var user = context.Users
                    .FirstOrDefault(x => x.UserId == userId);

                if (user == null)
                    return false;

                context.Users.Remove(user);

                return context.SaveChanges() > 0;
            }
        }
    }
}
