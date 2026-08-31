using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLUser
    {
        DALUser dalUser = new DALUser();
        DALUserRole dalUserRole = new DALUserRole();

        public List<User> UserList()
        {
            return dalUser.UserList();
        }

        public User UserGetById(int userId)
        {
            return dalUser.UserGetById(userId);
        }

        public User UserGetByUsername(string username)
        {
            if (!Validation.StringControl(username, 1, 50))
                return null;

            return dalUser.UserGetByUsername(username);
        }

        public bool UserAdd(User user)
        {
            if (user == null)
                return false;

            if (!Validation.StringControl(
                user.Username,
                1,
                50))
                return false;

            if (!Validation.StringControl(
                user.PasswordHash,
                1,
                250))
                return false;

            if (dalUser.UserGetByUsername(user.Username) != null)
                return false;

            var userRole = dalUserRole
                .UserRoleGetById(user.UserRoleId);

            if (userRole == null)
                return false;

            return dalUser.UserAdd(user);
        }

        public bool UserUpdate(User user)
        {
            if (user == null)
                return false;

            var existingUser = dalUser
                .UserGetById(user.UserId);

            if (existingUser == null)
                return false;

            if (!Validation.StringControl(
                user.Username,
                1,
                50))
                return false;

            if (!Validation.StringControl(
                user.PasswordHash,
                1,
                250))
                return false;

            var usernameUser = dalUser
                .UserGetByUsername(user.Username);

            if (usernameUser != null &&
                usernameUser.UserId != user.UserId)
                return false;

            var userRole = dalUserRole
                .UserRoleGetById(user.UserRoleId);

            if (userRole == null)
                return false;

            return dalUser.UserUpdate(user);
        }

        public bool UserDelete(int userId)
        {
            var existingUser = dalUser
                .UserGetById(userId);

            if (existingUser == null)
                return false;

            return dalUser.UserDelete(userId);
        }
    }
}