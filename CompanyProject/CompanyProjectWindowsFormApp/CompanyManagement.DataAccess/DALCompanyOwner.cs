using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALCompanyOwner
    {
        public List<CompanyOwner> CompanyOwnerList()
        {
            using (var context = new AppDbContext())
            {
                return context.CompanyOwners
                    .Include(x => x.CompanyOwnerHasCompanies)
                    .Include(x => x.MeetingHasCompanyOwners)
                    .Include(x => x.TaskHasCompanyOwners)
                    .ToList();
            }
        }

        public CompanyOwner CompanyOwnerGetById(int companyOwnerId)
        {
            using (var context = new AppDbContext())
            {
                return context.CompanyOwners
                    .Include(x => x.CompanyOwnerHasCompanies)
                    .Include(x => x.MeetingHasCompanyOwners)
                    .Include(x => x.TaskHasCompanyOwners)
                    .FirstOrDefault(x => x.CompanyOwnerId == companyOwnerId);
            }
        }

        public bool CompanyOwnerAdd(CompanyOwner companyOwner, User user)
        {
            using (var context = new AppDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Users.Add(user);
                    context.SaveChanges();

                    companyOwner.UserId = user.UserId;

                    context.CompanyOwners.Add(companyOwner);
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

        public bool CompanyOwnerUpdate(
            CompanyOwner companyOwner,
            User user)
        {
            using (var context = new AppDbContext())
            using (var transaction =
                context.Database.BeginTransaction())
            {
                try
                {
                    var existingCompanyOwner =
                        context.CompanyOwners
                            .FirstOrDefault(x =>
                                x.CompanyOwnerId ==
                                companyOwner.CompanyOwnerId);

                    if (existingCompanyOwner == null)
                        return false;

                    var existingUser =
                        context.Users
                            .FirstOrDefault(x =>
                                x.UserId == companyOwner.UserId);

                    if (existingUser == null)
                        return false;

                    existingCompanyOwner.CompanyOwnerIdentityNumber =
                        companyOwner.CompanyOwnerIdentityNumber;

                    existingCompanyOwner.CompanyOwnerName =
                        companyOwner.CompanyOwnerName;

                    existingCompanyOwner.CompanyOwnerSurname =
                        companyOwner.CompanyOwnerSurname;

                    existingCompanyOwner.CompanyOwnerBirthday =
                        companyOwner.CompanyOwnerBirthday;

                    existingCompanyOwner.CompanyOwnerTelephoneNumber =
                        companyOwner.CompanyOwnerTelephoneNumber;

                    existingCompanyOwner.CompanyOwnerEmail =
                        companyOwner.CompanyOwnerEmail;

                    existingUser.Username =
                        user.Username;

                    if (!string.IsNullOrWhiteSpace(user.PasswordHash))
                    {
                        existingUser.PasswordHash =
                            user.PasswordHash;
                    }

                    existingUser.IsActive =
                        user.IsActive;

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

        public bool CompanyOwnerUpdate(CompanyOwner companyOwner)
        {
            using (var context = new AppDbContext())
            {
                var existingCompanyOwner = context.CompanyOwners
                    .FirstOrDefault(x =>
                        x.CompanyOwnerId == companyOwner.CompanyOwnerId);

                if (existingCompanyOwner == null)
                    return false;

                existingCompanyOwner.CompanyOwnerIdentityNumber =
                    companyOwner.CompanyOwnerIdentityNumber;

                existingCompanyOwner.CompanyOwnerName =
                    companyOwner.CompanyOwnerName;

                existingCompanyOwner.CompanyOwnerSurname =
                    companyOwner.CompanyOwnerSurname;

                existingCompanyOwner.CompanyOwnerBirthday =
                    companyOwner.CompanyOwnerBirthday;

                existingCompanyOwner.CompanyOwnerTelephoneNumber =
                    companyOwner.CompanyOwnerTelephoneNumber;

                existingCompanyOwner.CompanyOwnerEmail =
                    companyOwner.CompanyOwnerEmail;

                existingCompanyOwner.UserId =
                    companyOwner.UserId;

                return context.SaveChanges() > 0;
            }
        }
        public bool CompanyOwnerDelete(int companyOwnerId)
        {
            using (var context = new AppDbContext())
            using (var transaction =
                context.Database.BeginTransaction())
            {
                try
                {
                    var companyOwner = context.CompanyOwners
                        .FirstOrDefault(x =>
                            x.CompanyOwnerId == companyOwnerId);

                    if (companyOwner == null)
                        return false;

                    var user = context.Users
                        .FirstOrDefault(x =>
                            x.UserId == companyOwner.UserId);

                    context.CompanyOwners.Remove(companyOwner);

                    if (user != null)
                        context.Users.Remove(user);

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
}