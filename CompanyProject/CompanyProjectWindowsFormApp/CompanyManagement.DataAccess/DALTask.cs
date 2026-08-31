using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = CompanyManagement.Entity.Task;

namespace CompanyManagement.DataAccess
{
    public class DALTask
    {
        public List<Task> TaskList()
        {
            using (var context = new AppDbContext())
            {
                return context.Tasks
                    .Include(x => x.TaskHasCompanyOwners)
                    .Include(x => x.TaskHasEmployees)
                    .ToList();
            }
        }

        public Task TaskGetById(int taskId)
        {
            using (var context = new AppDbContext())
            {
                return context.Tasks
                    .Include(x => x.TaskHasCompanyOwners)
                    .Include(x => x.TaskHasEmployees)
                    .FirstOrDefault(x => x.TaskId == taskId);
            }
        }

        public bool TaskAdd(Task task)
        {
            using (var context = new AppDbContext())
            {
                context.Tasks.Add(task);

                return context.SaveChanges() > 0;
            }
        }

        public bool TaskUpdate(Task task)
        {
            using (var context = new AppDbContext())
            {
                context.Tasks.Update(task);

                return context.SaveChanges() > 0;
            }
        }

        public bool TaskDelete(int taskId)
        {
            using (var context = new AppDbContext())
            {
                var task = context.Tasks
                    .FirstOrDefault(x => x.TaskId == taskId);

                if (task == null)
                    return false;

                context.Tasks.Remove(task);

                return context.SaveChanges() > 0;
            }
        }
    }
}