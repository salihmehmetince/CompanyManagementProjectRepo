using CompanyManagement.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLTask
    {
        DALTask dalTask =
            new DALTask();

        public List<CompanyManagement.Entity.Task> TaskList()
        {
            return dalTask.TaskList();
        }

        public CompanyManagement.Entity.Task TaskGetById(
            int taskId)
        {
            if (!Validation.IntControl(
                taskId,
                1,
                int.MaxValue))
                return null;

            return dalTask.TaskGetById(taskId);
        }

        public bool TaskAdd(
    CompanyManagement.Entity.Task task,
    List<int> companyOwnerIds,
    List<int> employeeIds)
        {
            if (task == null)
                return false;

            if (companyOwnerIds == null)
                companyOwnerIds = new List<int>();

            if (employeeIds == null)
                employeeIds = new List<int>();

            if (!Validation.StringControl(
                task.TaskName,
                1,
                150))
                return false;

            if (!Validation.StringControl(
                task.TaskDetails,
                0,
                1000))
                return false;

            if (!Validation.DateTimeControl(
                task.TaskBeginningDate,
                false))
                return false;

            if (task.TaskFinishDate.HasValue &&
                !Validation.DateTimeControl(
                    task.TaskFinishDate.Value,
                    false))
                return false;

            if (task.TaskFinishDate.HasValue &&
                task.TaskFinishDate.Value.Date < task.TaskBeginningDate.Date)
                return false;

            companyOwnerIds = companyOwnerIds
                .Where(x => Validation.IntControl(
                    x,
                    1,
                    int.MaxValue))
                .Distinct()
                .ToList();

            employeeIds = employeeIds
                .Where(x => Validation.IntControl(
                    x,
                    1,
                    int.MaxValue))
                .Distinct()
                .ToList();

            if (companyOwnerIds.Count == 0 ||
    employeeIds.Count == 0)
                return false;

            return dalTask.TaskAdd(
                task,
                companyOwnerIds,
                employeeIds);
        }

        public bool TaskUpdate(
            CompanyManagement.Entity.Task task,
            List<int> companyOwnerIds,
            List<int> employeeIds)
        {
            if (task == null)
                return false;

            if (companyOwnerIds == null)
                companyOwnerIds = new List<int>();

            if (employeeIds == null)
                employeeIds = new List<int>();

            if (!Validation.IntControl(
                task.TaskId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.StringControl(
                task.TaskName,
                1,
                150))
                return false;

            if (!Validation.StringControl(
                task.TaskDetails,
                0,
                1000))
                return false;

            if (!Validation.DateTimeControl(
                task.TaskBeginningDate,
                false))
                return false;

            if (task.TaskFinishDate.HasValue &&
                !Validation.DateTimeControl(
                    task.TaskFinishDate.Value,
                    false))
                return false;

            if (task.TaskFinishDate.HasValue &&
                task.TaskFinishDate.Value.Date < task.TaskBeginningDate.Date)
                return false;

            var existingTask =
                dalTask.TaskGetById(task.TaskId);

            if (existingTask == null)
                return false;

            companyOwnerIds = companyOwnerIds
                .Where(x => Validation.IntControl(
                    x,
                    1,
                    int.MaxValue))
                .Distinct()
                .ToList();

            employeeIds = employeeIds
                .Where(x => Validation.IntControl(
                    x,
                    1,
                    int.MaxValue))
                .Distinct()
                .ToList();

            if (companyOwnerIds.Count == 0 ||
    employeeIds.Count == 0)
                return false;

            return dalTask.TaskUpdate(
                task,
                companyOwnerIds,
                employeeIds);
        }

        public bool TaskDelete(int taskId)
        {
            if (!Validation.IntControl(
                taskId,
                1,
                int.MaxValue))
                return false;

            var existingTask =
                dalTask.TaskGetById(taskId);

            if (existingTask == null)
                return false;

            return dalTask.TaskDelete(taskId);
        }
    }
}
