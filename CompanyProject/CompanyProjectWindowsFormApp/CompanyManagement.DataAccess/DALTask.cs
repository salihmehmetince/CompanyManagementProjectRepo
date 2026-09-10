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

        public bool TaskAdd(
            Task task,
            List<int> companyOwnerIds,
            List<int> employeeIds)
        {
            using (var context = new AppDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.Tasks.Add(task);

                    context.SaveChanges();

                    foreach (int companyOwnerId in companyOwnerIds)
                    {
                        context.TaskHasCompanyOwners.Add(
                            new TaskHasCompanyOwner
                            {
                                TaskId = task.TaskId,
                                CompanyOwnerId = companyOwnerId
                            });
                    }

                    foreach (int employeeId in employeeIds)
                    {
                        context.TaskHasEmployees.Add(
                            new TaskHasEmployee
                            {
                                TaskId = task.TaskId,
                                EmployeeId = employeeId
                            });
                    }

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

        public bool TaskUpdate(
            Task task,
            List<int> companyOwnerIds,
            List<int> employeeIds)
        {
            using (var context = new AppDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var existingTask = context.Tasks
                        .FirstOrDefault(x => x.TaskId == task.TaskId);

                    if (existingTask == null)
                        return false;

                    existingTask.TaskName = task.TaskName;
                    existingTask.TaskDetails = task.TaskDetails;
                    existingTask.TaskBeginningDate = task.TaskBeginningDate;
                    existingTask.IsCompleted = task.IsCompleted;
                    existingTask.TaskFinishDate = task.TaskFinishDate;

                    var existingCompanyOwners =
                        context.TaskHasCompanyOwners
                            .Where(x => x.TaskId == task.TaskId)
                            .ToList();

                    context.TaskHasCompanyOwners
                        .RemoveRange(existingCompanyOwners);

                    var existingEmployees =
                        context.TaskHasEmployees
                            .Where(x => x.TaskId == task.TaskId)
                            .ToList();

                    context.TaskHasEmployees
                        .RemoveRange(existingEmployees);

                    foreach (int companyOwnerId in companyOwnerIds)
                    {
                        context.TaskHasCompanyOwners.Add(
                            new TaskHasCompanyOwner
                            {
                                TaskId = task.TaskId,
                                CompanyOwnerId = companyOwnerId
                            });
                    }

                    foreach (int employeeId in employeeIds)
                    {
                        context.TaskHasEmployees.Add(
                            new TaskHasEmployee
                            {
                                TaskId = task.TaskId,
                                EmployeeId = employeeId
                            });
                    }

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

        public bool TaskDelete(int taskId)
        {
            using (var context = new AppDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var task = context.Tasks
                        .FirstOrDefault(x => x.TaskId == taskId);

                    if (task == null)
                        return false;

                    var companyOwnerRelations =
                        context.TaskHasCompanyOwners
                            .Where(x => x.TaskId == taskId)
                            .ToList();

                    context.TaskHasCompanyOwners
                        .RemoveRange(companyOwnerRelations);

                    var employeeRelations =
                        context.TaskHasEmployees
                            .Where(x => x.TaskId == taskId)
                            .ToList();

                    context.TaskHasEmployees
                        .RemoveRange(employeeRelations);

                    context.Tasks.Remove(task);

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