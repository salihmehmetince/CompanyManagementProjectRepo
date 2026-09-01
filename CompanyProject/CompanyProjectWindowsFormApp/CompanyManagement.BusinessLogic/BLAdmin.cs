using CompanyManagement.BusinessLogic;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BLAdmin
{
    DALAdmin dalAdmin = new DALAdmin();

    public bool AdminAdd(Admin admin)
    {
        if (admin == null)
            return false;

        if (!Validation.StringControl(
            admin.AdminName,
            1,
            30))
            return false;

        if (!Validation.StringControl(
            admin.AdminSurname,
            1,
            30))
            return false;

        if (!Validation.TelephoneControl(
            admin.AdminTelephoneNumber,
            false))
            return false;

        if (!string.IsNullOrWhiteSpace(
            admin.AdminEmail))
        {
            if (!Validation.EmailControl(
                admin.AdminEmail,
                false))
                return false;
        }

        if (admin.UserId <= 0)
            return false;

        return dalAdmin.AdminAdd(admin);
    }

    public bool AdminUpdate(Admin admin)
    {
        if (admin == null)
            return false;

        if (admin.AdminId <= 0)
            return false;

        if (!Validation.StringControl(
            admin.AdminName,
            1,
            30))
            return false;

        if (!Validation.StringControl(
            admin.AdminSurname,
            1,
            30))
            return false;

        if (!Validation.TelephoneControl(
            admin.AdminTelephoneNumber,
            false))
            return false;

        if (!string.IsNullOrWhiteSpace(
            admin.AdminEmail))
        {
            if (!Validation.EmailControl(
                admin.AdminEmail,
                false))
                return false;
        }

        if (admin.UserId <= 0)
            return false;

        return dalAdmin.AdminUpdate(admin);
    }

    public bool AdminDelete(int adminId)
    {
        if (adminId <= 0)
            return false;

        return dalAdmin.AdminDelete(adminId);
    }

    public Admin AdminGetById(int adminId)
    {
        if (adminId <= 0)
            return null;

        return dalAdmin.AdminGetById(adminId);
    }

    public List<Admin> AdminList()
    {
        return dalAdmin.AdminList();
    }

    public bool FirstAdminAdd(Admin admin, User user)
    {
        if (admin == null)
            return false;

        if (user == null)
            return false;

        if (!Validation.StringControl(
            admin.AdminName,
            1,
            30))
            return false;

        if (!Validation.StringControl(
            admin.AdminSurname,
            1,
            30))
            return false;

        if (!Validation.TelephoneControl(
            admin.AdminTelephoneNumber,
            false))
            return false;

        if (!string.IsNullOrWhiteSpace(
            admin.AdminEmail))
        {
            if (!Validation.EmailControl(
                admin.AdminEmail,
                false))
                return false;
        }

        if (!Validation.StringControl(
            user.Username,
            1,
            50))
            return false;

        if (string.IsNullOrWhiteSpace(
            user.PasswordHash))
            return false;

        if (user.UserRoleId <= 0)
            return false;

        return dalAdmin.FirstAdminAdd(
            admin,
            user);
    }
}