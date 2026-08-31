using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALTaskHasCompanyOwner
    {
        public List<TaskHasCompanyOwner> TaskHasCompanyOwnerList()
        {
            using (var context = new AppDbContext())
            {
                return context.TaskHasCompanyOwners
                    .Include(x => x.Task)
                    .Include(x => x.CompanyOwner)
                    .ToList();
            }
        }

        public TaskHasCompanyOwner TaskHasCompanyOwnerGetById(
            int taskHasCompanyOwnerId)
        {
            using (var context = new AppDbContext())
            {
                return context.TaskHasCompanyOwners
                    .Include(x => x.Task)
                    .Include(x => x.CompanyOwner)
                    .FirstOrDefault(x =>
                        x.TaskHasCompanyOwnerId == taskHasCompanyOwnerId);
            }
        }

        public bool TaskHasCompanyOwnerAdd(
            TaskHasCompanyOwner taskHasCompanyOwner)
        {
            using (var context = new AppDbContext())
            {
                context.TaskHasCompanyOwners.Add(taskHasCompanyOwner);

                return context.SaveChanges() > 0;
            }
        }

        public bool TaskHasCompanyOwnerUpdate(
            TaskHasCompanyOwner taskHasCompanyOwner)
        {
            using (var context = new AppDbContext())
            {
                context.TaskHasCompanyOwners.Update(taskHasCompanyOwner);

                return context.SaveChanges() > 0;
            }
        }

        public bool TaskHasCompanyOwnerDelete(int taskHasCompanyOwnerId)
        {
            using (var context = new AppDbContext())
            {
                var taskHasCompanyOwner =
                    context.TaskHasCompanyOwners
                        .FirstOrDefault(x =>
                            x.TaskHasCompanyOwnerId ==
                            taskHasCompanyOwnerId);

                if (taskHasCompanyOwner == null)
                    return false;

                context.TaskHasCompanyOwners.Remove(taskHasCompanyOwner);

                return context.SaveChanges() > 0;
            }
        }
    }
}