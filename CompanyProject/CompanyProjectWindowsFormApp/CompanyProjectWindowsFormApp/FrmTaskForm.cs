using CompanyManagement.BusinessLogic;
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
    public partial class FrmTaskForm : Form
    {
        private BLTask blTask=new BLTask();
        public FrmTaskForm()
        {
            InitializeComponent();
            setIcon();
            SetButtonsBorder();
            ListTasks();
        }
        private void setIcon()
        {
            this.Icon = Properties.Resources.icon_company;
        }


        private void SetButtonsBorder()
        {
            BtnAdd.FlatAppearance.BorderSize = 0;
            BtnEdit.FlatAppearance.BorderSize = 0;
            BtnDelete.FlatAppearance.BorderSize = 0;
        }

        private void ListTasks()
        {
            List<CompanyManagement.Entity.Task> tasks = blTask.TaskList();

            var taskList = tasks.Select(x => new
            {
                x.TaskId,
                x.TaskName,
                x.TaskBeginningDate,
                x.IsCompleted,
                x.TaskFinishDate
            }).ToList();

            DgvTasks.DataSource = taskList;

            LblRecordCount.Text = tasks.Count + " tasks";
        }

        private CompanyManagement.Entity.Task GetSelectedTask()
        {
            if (DgvTasks.CurrentRow == null)
                return null;

            int taskId = Convert.ToInt32(
                DgvTasks.CurrentRow.Cells["TaskId"].Value
            );

            return blTask.TaskGetById(taskId);
        }

        private void SearchTasks()
        {
            string searchText = TxtSearch.Text.Trim().ToLower();

            List<CompanyManagement.Entity.Task> tasks = blTask.TaskList();

            if (!string.IsNullOrEmpty(searchText))
            {
                tasks = tasks
                    .Where(x =>
                        x.TaskName.ToLower().Contains(searchText) ||
                        (x.TaskDetails != null &&
                         x.TaskDetails.ToLower().Contains(searchText)) ||
                        x.TaskBeginningDate
                            .ToString("dd.MM.yyyy")
                            .Contains(searchText) ||
                        (x.TaskFinishDate.HasValue &&
                         x.TaskFinishDate.Value
                            .ToString("dd.MM.yyyy")
                            .Contains(searchText))
                    )
                    .ToList();
            }

            var taskList = tasks.Select(x => new
            {
                x.TaskId,
                x.TaskName,
                x.TaskBeginningDate,
                x.IsCompleted,
                x.TaskFinishDate
            }).ToList();

            DgvTasks.DataSource = taskList;

            LblRecordCount.Text = tasks.Count + " tasks";
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchTasks();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            FrmTaskAddEditForm frm =
    new FrmTaskAddEditForm();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListTasks();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            CompanyManagement.Entity.Task task = GetSelectedTask();

            if (task == null)
            {
                MessageBox.Show(
                    "Please select a task.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            FrmTaskAddEditForm frm =
                new FrmTaskAddEditForm(task);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListTasks();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            CompanyManagement.Entity.Task task = GetSelectedTask();

            if (task == null)
            {
                MessageBox.Show(
                    "Please select a task.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this task?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
                return;

            if (!blTask.TaskDelete(task.TaskId))
            {
                MessageBox.Show(
                    "Task could not be deleted.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            MessageBox.Show(
                "Task deleted successfully.",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ListTasks();
        }
    }
}
