using CompanyManagement.DataAccess;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagement.BusinessLogic
{
    public class BLTaskHasCompanyOwner
    {
        DALTaskHasCompanyOwner dalTaskHasCompanyOwner =
            new DALTaskHasCompanyOwner();

        DALTask dalTask =
            new DALTask();

        DALCompanyOwner dalCompanyOwner =
            new DALCompanyOwner();

        public List<TaskHasCompanyOwner>
            TaskHasCompanyOwnerList()
        {
            return dalTaskHasCompanyOwner
                .TaskHasCompanyOwnerList();
        }

        public TaskHasCompanyOwner
            TaskHasCompanyOwnerGetById(
                int taskHasCompanyOwnerId)
        {
            if (!Validation.IntControl(
                taskHasCompanyOwnerId,
                1,
                int.MaxValue))
                return null;

            return dalTaskHasCompanyOwner
                .TaskHasCompanyOwnerGetById(
                    taskHasCompanyOwnerId);
        }

        public bool TaskHasCompanyOwnerAdd(
            TaskHasCompanyOwner taskHasCompanyOwner)
        {
            if (taskHasCompanyOwner == null)
                return false;

            if (!Validation.IntControl(
                taskHasCompanyOwner.TaskId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                taskHasCompanyOwner.CompanyOwnerId,
                1,
                int.MaxValue))
                return false;

            var task =
                dalTask
                    .TaskGetById(
                        taskHasCompanyOwner.TaskId);

            if (task == null)
                return false;

            var companyOwner =
                dalCompanyOwner
                    .CompanyOwnerGetById(
                        taskHasCompanyOwner.CompanyOwnerId);

            if (companyOwner == null)
                return false;

            return dalTaskHasCompanyOwner
                .TaskHasCompanyOwnerAdd(
                    taskHasCompanyOwner);
        }

        public bool TaskHasCompanyOwnerUpdate(
            TaskHasCompanyOwner taskHasCompanyOwner)
        {
            if (taskHasCompanyOwner == null)
                return false;

            if (!Validation.IntControl(
                taskHasCompanyOwner.TaskHasCompanyOwnerId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                taskHasCompanyOwner.TaskId,
                1,
                int.MaxValue))
                return false;

            if (!Validation.IntControl(
                taskHasCompanyOwner.CompanyOwnerId,
                1,
                int.MaxValue))
                return false;

            var existingTaskHasCompanyOwner =
                dalTaskHasCompanyOwner
                    .TaskHasCompanyOwnerGetById(
                        taskHasCompanyOwner
                            .TaskHasCompanyOwnerId);

            if (existingTaskHasCompanyOwner == null)
                return false;

            var task =
                dalTask
                    .TaskGetById(
                        taskHasCompanyOwner.TaskId);

            if (task == null)
                return false;

            var companyOwner =
                dalCompanyOwner
                    .CompanyOwnerGetById(
                        taskHasCompanyOwner.CompanyOwnerId);

            if (companyOwner == null)
                return false;

            return dalTaskHasCompanyOwner
                .TaskHasCompanyOwnerUpdate(
                    taskHasCompanyOwner);
        }

        public bool TaskHasCompanyOwnerDelete(
            int taskHasCompanyOwnerId)
        {
            if (!Validation.IntControl(
                taskHasCompanyOwnerId,
                1,
                int.MaxValue))
                return false;

            var existingTaskHasCompanyOwner =
                dalTaskHasCompanyOwner
                    .TaskHasCompanyOwnerGetById(
                        taskHasCompanyOwnerId);

            if (existingTaskHasCompanyOwner == null)
                return false;

            return dalTaskHasCompanyOwner
                .TaskHasCompanyOwnerDelete(
                    taskHasCompanyOwnerId);
        }
    }
}
