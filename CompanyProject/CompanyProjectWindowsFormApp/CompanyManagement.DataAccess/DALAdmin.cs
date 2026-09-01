using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DALAdmin
{
    public bool AdminAdd(Admin admin)
    {
        using (var context = new AppDbContext())
        {
            context.Admins.Add(admin);
            context.SaveChanges();

            return true;
        }
    }

    public bool AdminUpdate(Admin admin)
    {
        using (var context = new AppDbContext())
        {
            var existingAdmin = context.Admins
                .FirstOrDefault(x => x.AdminId == admin.AdminId);

            if (existingAdmin == null)
                return false;

            existingAdmin.AdminName = admin.AdminName;
            existingAdmin.AdminSurname = admin.AdminSurname;
            existingAdmin.AdminTelephoneNumber =
                admin.AdminTelephoneNumber;
            existingAdmin.AdminEmail = admin.AdminEmail;
            existingAdmin.UserId = admin.UserId;

            context.SaveChanges();

            return true;
        }
    }

    public bool AdminDelete(int adminId)
    {
        using (var context = new AppDbContext())
        {
            var admin = context.Admins
                .FirstOrDefault(x => x.AdminId == adminId);

            if (admin == null)
                return false;

            context.Admins.Remove(admin);
            context.SaveChanges();

            return true;
        }
    }

    public Admin AdminGetById(int adminId)
    {
        using (var context = new AppDbContext())
        {
            return context.Admins
                .FirstOrDefault(x => x.AdminId == adminId);
        }
    }

    public List<Admin> AdminList()
    {
        using (var context = new AppDbContext())
        {
            return context.Admins.ToList();
        }
    }

    public bool FirstAdminAdd(Admin admin, User user)
    {
        using (var context = new AppDbContext())
        using (var transaction =
            context.Database.BeginTransaction())
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();

                admin.UserId = user.UserId;

                context.Admins.Add(admin);
                context.SaveChanges();

                transaction.Commit();

                return true;
            }
            catch
            {
                transaction.Rollback();

                return false;
            }
        }
    }
}