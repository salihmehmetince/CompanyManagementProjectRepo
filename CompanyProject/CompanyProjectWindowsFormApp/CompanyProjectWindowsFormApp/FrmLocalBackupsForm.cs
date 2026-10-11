using CompanyProjectWindowsFormApp.Services;
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
    public partial class FrmLocalBackupsForm : Form
    {
        public FrmLocalBackupsForm()
        {
            InitializeComponent();
            SetButtonsBorder();
            setIcon();
            ListLocalBackups();
        }

        private void setIcon()
        {
            this.Icon = Properties.Resources.icon_company;
        }

        private void ListLocalBackups()
        {
            string backupDirectory = @"C:\CompanyManagement\Backups";

            if (!System.IO.Directory.Exists(backupDirectory))
            {
                DgvLocalBackups.DataSource = null;
                LblRecordCount.Text = "0 backups";
                return;
            }

            List<System.IO.FileInfo> backups =
                System.IO.Directory
                    .GetFiles(backupDirectory, "*.bak")
                    .Select(x => new System.IO.FileInfo(x))
                    .OrderByDescending(x => x.CreationTime)
                    .ToList();

            var backupList =
                backups.Select(x => new
                {
                    x.Name,
                    x.CreationTime,
                    SizeMB = Math.Round(
                        x.Length / (1024.0 * 1024.0), 2),
                    FullPath = x.FullName
                }).ToList();

            DgvLocalBackups.DataSource =
                backupList;

            LblRecordCount.Text =
                backups.Count + " backups";
        }

        private void SetButtonsBorder()
        {

            BtnRestore.FlatAppearance.BorderSize = 0;
        }

        private void SearchLocalBackups()
        {
            string searchText =
                TxtSearch.Text.Trim().ToLower();

            string backupDirectory =
                @"C:\CompanyManagement\Backups";

            List<System.IO.FileInfo> backups =
                System.IO.Directory.Exists(backupDirectory)
                    ? System.IO.Directory
                        .GetFiles(backupDirectory, "*.bak")
                        .Select(x => new System.IO.FileInfo(x))
                        .OrderByDescending(x => x.CreationTime)
                        .ToList()
                    : new List<System.IO.FileInfo>();

            if (!string.IsNullOrEmpty(searchText))
            {
                backups = backups
                    .Where(x =>
                        x.Name.ToLower().Contains(searchText) ||
                        x.CreationTime
                            .ToString("dd.MM.yyyy HH:mm:ss")
                            .Contains(searchText) ||
                        Math.Round(
                            x.Length / (1024.0 * 1024.0), 2)
                            .ToString()
                            .Contains(searchText)
                    )
                    .ToList();
            }

            var backupList =
                backups.Select(x => new
                {
                    x.Name,
                    x.CreationTime,
                    SizeMB = Math.Round(
                        x.Length / (1024.0 * 1024.0), 2),
                    FullPath = x.FullName
                }).ToList();

            DgvLocalBackups.DataSource =
                backupList;

            LblRecordCount.Text =
                backups.Count + " backups";
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchLocalBackups();
        }

        private string GetSelectedLocalBackup()
        {
            if (DgvLocalBackups.CurrentRow == null)
                return null;

            return Convert.ToString(
                DgvLocalBackups.CurrentRow.Cells["FullPath"].Value
            );
        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            string backupPath = GetSelectedLocalBackup();

            if (string.IsNullOrEmpty(backupPath))
            {
                MessageBox.Show(
                    "Please select a backup.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Restoring this backup will replace the current database. " +
                "Recent changes may be lost.\n\nDo you want to continue?",
                "Confirm Database Restore",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            DatabaseBackupService backupService =
                new DatabaseBackupService();

            bool isSuccessful = backupService.RestoreBackup(
                backupPath,
                out string errorMessage);

            if (isSuccessful)
            {
                MessageBox.Show(
                    "Database restored successfully.\n\n" +
                    "A backup of the database before restoration was also created.\n\n" +
                    "The application will now close. Please restart it.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Application.Exit();
            }
            else
            {
                MessageBox.Show(
                    "Database restore failed.\n\n" + errorMessage,
                    "Restore Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
