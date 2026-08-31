using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLTaskHasEmployee
    {
        DALTaskHasEmployee dalTaskHasEmployee =
            new DALTaskHasEmployee();

        DALTask dalTask =
            new DALTask();

        DALEmployee dalEmployee =
            new DALEmployee();

        public List<TaskHasEmployee>
            TaskHasEmployeeList()
        {
            return dalTaskHasEmployee
                .TaskHasEmployeeList();
        }

        public TaskHasEmployee
            TaskHasEmployeeGetById(
                int taskHasEmployeeId)
        {
            if (!Validation.IntControl(
                taskHasEmployeeId,
                1,
                int.MaxValue))
                return null;

            return dalTaskHasEmployee
                .TaskHasEmployeeGetById(
                    taskHasEmployeeId);
        }

        public bool TaskHasEmployeeAdd(
            TaskHasEmployee taskHasEmployee)
        {
            if (taskHasEmployee == null)
                return false;

            if (!Validation.IntControl(
                taskHasEmployee.TaskId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                taskHasEmployee.EmployeeId,
                1,
                int.MaxValue))
                return false;

            var task =
                dalTask
                    .TaskGetById(
                        taskHasEmployee.TaskId);

            if (task == null)
                return false;

            var employee =
                dalEmployee
                    .EmployeeGetById(
                        taskHasEmployee.EmployeeId);

            if (employee == null)
                return false;

            return dalTaskHasEmployee
                .TaskHasEmployeeAdd(
                    taskHasEmployee);
        }

        public bool TaskHasEmployeeUpdate(
            TaskHasEmployee taskHasEmployee)
        {
            if (taskHasEmployee == null)
                return false;

            if (!Validation.IntControl(
                taskHasEmployee.TaskHasEmployeeId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                taskHasEmployee.TaskId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                taskHasEmployee.EmployeeId,
                1,
                int.MaxValue))
                return false;

            var existingTaskHasEmployee =
                dalTaskHasEmployee
                    .TaskHasEmployeeGetById(
                        taskHasEmployee
                            .TaskHasEmployeeId);

            if (existingTaskHasEmployee == null)
                return false;

            var task =
                dalTask
                    .TaskGetById(
                        taskHasEmployee.TaskId);

            if (task == null)
                return false;

            var employee =
                dalEmployee
                    .EmployeeGetById(
                        taskHasEmployee.EmployeeId);

            if (employee == null)
                return false;

            return dalTaskHasEmployee
                .TaskHasEmployeeUpdate(
                    taskHasEmployee);
        }

        public bool TaskHasEmployeeDelete(
            int taskHasEmployeeId)
        {
            if (!Validation.IntControl(
                taskHasEmployeeId,
                1,
                int.MaxValue))
                return false;

            var existingTaskHasEmployee =
                dalTaskHasEmployee
                    .TaskHasEmployeeGetById(
                        taskHasEmployeeId);

            if (existingTaskHasEmployee == null)
                return false;

            return dalTaskHasEmployee
                .TaskHasEmployeeDelete(
                    taskHasEmployeeId);
        }
    }
}
