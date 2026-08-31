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

        public bool CompanyOwnerAdd(CompanyOwner companyOwner)
        {
            using (var context = new AppDbContext())
            {
                context.CompanyOwners.Add(companyOwner);

                return context.SaveChanges() > 0;
            }
        }

        public bool CompanyOwnerUpdate(CompanyOwner companyOwner)
        {
            using (var context = new AppDbContext())
            {
                context.CompanyOwners.Update(companyOwner);

                return context.SaveChanges() > 0;
            }
        }

        public bool CompanyOwnerDelete(int companyOwnerId)
        {
            using (var context = new AppDbContext())
            {
                var companyOwner = context.CompanyOwners
                    .FirstOrDefault(x => x.CompanyOwnerId == companyOwnerId);

                if (companyOwner == null)
                    return false;

                context.CompanyOwners.Remove(companyOwner);

                return context.SaveChanges() > 0;
            }
        }
    }
}