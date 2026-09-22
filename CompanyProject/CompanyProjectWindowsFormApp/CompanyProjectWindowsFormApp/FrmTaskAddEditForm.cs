using CompanyManagement.BusinessLogic;
using CompanyManagement.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyProjectWindowsFormApp
{
    public partial class FrmTaskAddEditForm : Form
    {
        private BLTask blTask = new BLTask();
        private CompanyManagement.Entity.Task task;
        private BLUser blUser = new BLUser();
        private BLTaskHasCompanyOwner blTaskHasCompanyOwner =
            new BLTaskHasCompanyOwner();

        private BLTaskHasEmployee blTaskHasEmployee =
            new BLTaskHasEmployee();

        private BLCompanyOwner blCompanyOwner =
            new BLCompanyOwner();

        private BLEmployee blEmployee =
            new BLEmployee();
        public FrmTaskAddEditForm(CompanyManagement.Entity.Task task=null)
        {
            InitializeComponent();
            SetButtonsBorder();
            LoadCompanyOwners();
            LoadEmployees();
            this.task = task;

            if(task != null )
            {
                LoadTask();
            }
        }

        private void SetButtonsBorder()
        {
            BtnSave.FlatAppearance.BorderSize = 0;
            BtnCancel.FlatAppearance.BorderSize = 0;
        }

        private void LoadCompanyOwners()
        {
            var companyOwners =
                blCompanyOwner
                    .CompanyOwnerList()
                    .Where(x =>
                    {
                        User user =
                            blUser.UserGetById(x.UserId);

                        return user != null &&
                               user.IsActive;
                    })
                    .Select(x => new
                    {
                        x.CompanyOwnerId,
                        FullName =
                            x.CompanyOwnerName + " " +
                            x.CompanyOwnerSurname
                    })
                    .ToList();

            CLBCompanyOwners.DataSource =
                companyOwners;

            CLBCompanyOwners.DisplayMember =
                "FullName";

            CLBCompanyOwners.ValueMember =
                "CompanyOwnerId";
        }

        private void LoadEmployees()
        {
            var employees =
                blEmployee
                    .EmployeeList()
                    .Where(x =>
                    {
                        User user =
                            blUser.UserGetById(x.UserId);

                        return user != null &&
                               user.IsActive;
                    })
                    .Select(x => new
                    {
                        x.EmployeeId,
                        FullName =
                            x.EmployeeName + " " +
                            x.EmployeeSurname
                    })
                    .ToList();

            CLBEmployees.DataSource =
                employees;

            CLBEmployees.DisplayMember =
                "FullName";

            CLBEmployees.ValueMember =
                "EmployeeId";
        }

        private void LoadTask()
        {
            LblTitle.Text = "Edit Task";
            LblDescription.Text = "Update task information";

            TxtName.Text = task.TaskName;
            RTBDetail.Text = task.TaskDetails;
            DTPBeginningDate.Value = task.TaskBeginningDate;
            CBIsCompleted.Checked = task.IsCompleted;

            if (task.TaskFinishDate.HasValue)
            {
                DTPFinishDate.Value = task.TaskFinishDate.Value;
                CBNoFinishDate.Checked = false;
            }
            else
            {
                CBNoFinishDate.Checked = true;
            }

            var taskCompanyOwners =
                blTaskHasCompanyOwner
                    .TaskHasCompanyOwnerList()
                    .Where(x => x.TaskId == task.TaskId)
                    .Select(x => x.CompanyOwnerId)
                    .ToList();

            for (int i = 0; i < CLBCompanyOwners.Items.Count; i++)
            {
                dynamic companyOwner = CLBCompanyOwners.Items[i];

                if (taskCompanyOwners.Contains(
                    (int)companyOwner.CompanyOwnerId))
                {
                    CLBCompanyOwners.SetItemChecked(i, true);
                }
            }

            var taskEmployees =
                blTaskHasEmployee
                    .TaskHasEmployeeList()
                    .Where(x => x.TaskId == task.TaskId)
                    .Select(x => x.EmployeeId)
                    .ToList();

            for (int i = 0; i < CLBEmployees.Items.Count; i++)
            {
                dynamic employee = CLBEmployees.Items[i];

                if (taskEmployees.Contains(
                    (int)employee.EmployeeId))
                {
                    CLBEmployees.SetItemChecked(i, true);
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            CompanyManagement.Entity.Task taskToSave;

            if (task == null)
            {
                taskToSave = new CompanyManagement.Entity.Task();
            }
            else
            {
                taskToSave = task;
            }

            taskToSave.TaskName =
                TxtName.Text.Trim();

            taskToSave.TaskDetails =
                string.IsNullOrWhiteSpace(
                    RTBDetail.Text)
                    ? null
                    : RTBDetail.Text.Trim();

            taskToSave.TaskBeginningDate =
                DTPBeginningDate.Value;

            taskToSave.IsCompleted =
                CBIsCompleted.Checked;

            taskToSave.TaskFinishDate =
                CBNoFinishDate.Checked
                    ? (DateTime?)null
                    : DTPFinishDate.Value;

            List<int> companyOwnerIds =
                CLBCompanyOwners.CheckedItems
                    .Cast<dynamic>()
                    .Select(x => (int)x.CompanyOwnerId)
                    .ToList();

            List<int> employeeIds =
                CLBEmployees.CheckedItems
                    .Cast<dynamic>()
                    .Select(x => (int)x.EmployeeId)
                    .ToList();

            bool result;

            if (task == null)
            {
                result = blTask.TaskAdd(
                    taskToSave,
                    companyOwnerIds,
                    employeeIds);
            }
            else
            {
                result = blTask.TaskUpdate(
                    taskToSave,
                    companyOwnerIds,
                    employeeIds);
            }

            if (!result)
            {
                MessageBox.Show(
                    "Task could not be saved.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                task == null
                    ? "Task added successfully."
                    : "Task updated successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
