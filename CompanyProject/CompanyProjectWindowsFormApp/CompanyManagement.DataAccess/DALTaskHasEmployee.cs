using CompanyManagement.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.DataAccess
{
    public class DALTaskHasEmployee
    {
        public List<TaskHasEmployee> TaskHasEmployeeList()
        {
            using (var context = new AppDbContext())
            {
                return context.TaskHasEmployees
                    .Include(x => x.Task)
                    .Include(x => x.Employee)
                    .ToList();
            }
        }

        public TaskHasEmployee TaskHasEmployeeGetById(int taskHasEmployeeId)
        {
            using (var context = new AppDbContext())
            {
                return context.TaskHasEmployees
                    .Include(x => x.Task)
                    .Include(x => x.Employee)
                    .FirstOrDefault(x =>
                        x.TaskHasEmployeeId == taskHasEmployeeId);
            }
        }

        public bool TaskHasEmployeeAdd(TaskHasEmployee taskHasEmployee)
        {
            using (var context = new AppDbContext())
            {
                context.TaskHasEmployees.Add(taskHasEmployee);

                return context.SaveChanges() > 0;
            }
        }

        public bool TaskHasEmployeeUpdate(TaskHasEmployee taskHasEmployee)
        {
            using (var context = new AppDbContext())
            {
                context.TaskHasEmployees.Update(taskHasEmployee);

                return context.SaveChanges() > 0;
            }
        }

        public bool TaskHasEmployeeDelete(int taskHasEmployeeId)
        {
            using (var context = new AppDbContext())
            {
                var taskHasEmployee = context.TaskHasEmployees
                    .FirstOrDefault(x =>
                        x.TaskHasEmployeeId == taskHasEmployeeId);

                if (taskHasEmployee == null)
                    return false;

                context.TaskHasEmployees.Remove(taskHasEmployee);

                return context.SaveChanges() > 0;
            }
        }
    }
}