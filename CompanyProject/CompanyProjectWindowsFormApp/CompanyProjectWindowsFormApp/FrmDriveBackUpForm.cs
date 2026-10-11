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
    public partial class FrmDriveBackUpForm : Form
    {
        public FrmDriveBackUpForm()
        {
            InitializeComponent();
            setIcon();
            SetButtonsBorder();
            ListDriveBackups();
        }

        private void setIcon()
        {
            this.Icon = Properties.Resources.icon_company;
        }


        private void SetButtonsBorder()
        {

            BtnRestore.FlatAppearance.BorderSize = 0;
        }

        private void ListDriveBackups()
        {
            try
            {
                GoogleDriveBackupService driveBackupService =
                    new GoogleDriveBackupService();

                var service = driveBackupService.CreateDriveService();
                var folderRequest = service.Files.List();
                folderRequest.Q = "name = 'CompanyManagementBackups' " +
                                  "and mimeType = 'application/vnd.google-apps.folder' " +
                                  "and trashed = false";
                folderRequest.Fields = "files(id, name)";
                var folders = folderRequest.Execute().Files;

                if (folders == null || folders.Count == 0)
                {
                    DgvDriveBackups.DataSource = null;
                    LblRecordCount.Text = "0 backups";
                    return;
                }

                string folderId = folders[0].Id;

                var fileRequest = service.Files.List();
                fileRequest.Q = "'" + folderId + "' in parents " +
                                "and name contains '.bak' " +
                                "and trashed = false";
                fileRequest.Fields = "files(id, name, createdTime, size)";
                fileRequest.OrderBy = "createdTime desc";

                var files = fileRequest.Execute().Files;

                var backupList = files.Select(x => new
                {
                    x.Name,
                    CreationTime = x.CreatedTimeDateTimeOffset,
                    SizeMB = Math.Round(
                        (x.Size ?? 0) / (1024.0 * 1024.0), 2),
                    FileId = x.Id
                }).ToList();

                DgvDriveBackups.DataSource = backupList;
                LblRecordCount.Text = backupList.Count + " backups";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to list Google Drive backups.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SearchDriveBackups()
        {
            string searchText =
                TxtSearch.Text.Trim().ToLower();

            try
            {
                GoogleDriveBackupService driveBackupService =
                    new GoogleDriveBackupService();

                var service = driveBackupService.CreateDriveService();

                var folderRequest = service.Files.List();
                folderRequest.Q =
                    "name = 'CompanyManagementBackups' " +
                    "and mimeType = 'application/vnd.google-apps.folder' " +
                    "and trashed = false";
                folderRequest.Fields = "files(id, name)";

                var folders = folderRequest.Execute().Files;

                if (folders == null || folders.Count == 0)
                {
                    DgvDriveBackups.DataSource = null;
                    LblRecordCount.Text = "0 backups";
                    return;
                }

                string folderId = folders[0].Id;

                var fileRequest = service.Files.List();
                fileRequest.Q =
                    "'" + folderId + "' in parents " +
                    "and name contains '.bak' " +
                    "and trashed = false";
                fileRequest.Fields =
                    "files(id, name, createdTime, size)";
                fileRequest.OrderBy = "createdTime desc";

                var files = fileRequest.Execute().Files;

                if (files == null)
                {
                    DgvDriveBackups.DataSource = null;
                    LblRecordCount.Text = "0 backups";
                    return;
                }

                var backups = files
                    .Select(x => new
                    {
                        x.Name,
                        CreationTime = x.CreatedTimeDateTimeOffset,
                        SizeMB = Math.Round(
                            (x.Size ?? 0) / (1024.0 * 1024.0), 2),
                        FileId = x.Id
                    })
                    .ToList();

                if (!string.IsNullOrEmpty(searchText))
                {
                    backups = backups
                        .Where(x =>
                            x.Name.ToLower().Contains(searchText) ||
                            (x.CreationTime.HasValue &&
                             x.CreationTime.Value
                                .ToLocalTime()
                                .ToString("dd.MM.yyyy HH:mm:ss")
                                .Contains(searchText)) ||
                            x.SizeMB.ToString().Contains(searchText)
                        )
                        .ToList();
                }

                DgvDriveBackups.DataSource = backups;
                LblRecordCount.Text = backups.Count + " backups";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to search Google Drive backups.\n\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchDriveBackups();
        }

        private string GetSelectedDriveBackup()
        {
            if (DgvDriveBackups.CurrentRow == null)
                return null;

            return Convert.ToString(
                DgvDriveBackups.CurrentRow.Cells["FileId"].Value
            );
        }

        private void BtnRestore_Click(object sender, EventArgs e)
        {
            string fileId = GetSelectedDriveBackup();

            if (string.IsNullOrEmpty(fileId))
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
                "Recent changes may be lost.\n\n" +
                "Do you want to continue?",
                "Confirm Database Restore",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            string temporaryBackupPath = null;

            try
            {
                GoogleDriveBackupService driveBackupService =
                    new GoogleDriveBackupService();

                var driveService = driveBackupService.CreateDriveService();

                var fileRequest = driveService.Files.Get(fileId);

                var driveFile = fileRequest.Execute();

                string temporaryDirectory =
                    @"C:\CompanyManagement\Backups";

                System.IO.Directory.CreateDirectory(temporaryDirectory);

                string fileName = System.IO.Path.GetFileName(driveFile.Name);

                if (string.IsNullOrWhiteSpace(fileName) ||
                    !fileName.EndsWith(
                        ".bak",
                        StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "The selected Drive file is not a valid .bak backup.",
                        "Invalid Backup",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                temporaryBackupPath =
                    System.IO.Path.Combine(temporaryDirectory, fileName);

                using (var stream = new System.IO.FileStream(
                    temporaryBackupPath,
                    System.IO.FileMode.Create,
                    System.IO.FileAccess.Write))
                {
                    fileRequest.Download(stream);
                }

                DatabaseBackupService backupService =
                    new DatabaseBackupService();

                if (!backupService.IsValidBackupFile(temporaryBackupPath))
                {
                    MessageBox.Show(
                        "The downloaded backup file is invalid.",
                        "Invalid Backup",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                bool isSuccessful = backupService.RestoreBackup(
                    temporaryBackupPath,
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
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to restore the Google Drive backup.\n\n" + ex.Message,
                    "Restore Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                if (!string.IsNullOrEmpty(temporaryBackupPath) &&
                    System.IO.File.Exists(temporaryBackupPath))
                {
                    try
                    {
                        System.IO.File.Delete(temporaryBackupPath);
                    }
                    catch
                    {
                        // Geçici dosya silinemezse geri yükleme sonucunu değiştirme.
                    }
                }
            }
        }
    }
}
