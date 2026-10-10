using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectWindowsFormApp.Services
{
    public class GoogleDriveBackupService
    {
        private const string ApplicationName = "CompanyManagement Backup";

        public Google.Apis.Drive.v3.DriveService CreateDriveService()
        {
            using (var stream = new System.IO.FileStream(
                System.IO.Path.Combine(
                    System.AppDomain.CurrentDomain.BaseDirectory,
                    "Credentials",
                    "credentials.json"),
                System.IO.FileMode.Open,
                System.IO.FileAccess.Read))
            {
                var credential = Google.Apis.Auth.OAuth2.GoogleWebAuthorizationBroker
                    .AuthorizeAsync(
                        Google.Apis.Auth.OAuth2.GoogleClientSecrets
                            .FromStream(stream).Secrets,
                        new[] { Google.Apis.Drive.v3.DriveService.Scope.DriveFile },
                        "user",
                        System.Threading.CancellationToken.None,
                        new Google.Apis.Util.Store.FileDataStore("CompanyManagementToken", true))
                    .GetAwaiter()
                    .GetResult();

                return new Google.Apis.Drive.v3.DriveService(
                    new Google.Apis.Services.BaseClientService.Initializer
                    {
                        HttpClientInitializer = credential,
                        ApplicationName = ApplicationName
                    });
            }
        }

        public void UploadBackup(string backupPath)
        {
            if (!System.IO.File.Exists(backupPath))
            {
                throw new System.IO.FileNotFoundException(
                    "Yedek dosyası bulunamadı.",
                    backupPath);
            }

            var service = CreateDriveService();

            string folderName = "CompanyManagementBackups";

            var folderList = service.Files.List();
            folderList.Q =
                "name = '" + folderName +
                "' and mimeType = 'application/vnd.google-apps.folder' " +
                "and trashed = false";
            folderList.Fields = "files(id, name)";

            var folders = folderList.Execute().Files;

            string folderId;

            if (folders != null && folders.Count > 0)
            {
                folderId = folders[0].Id;
            }
            else
            {
                var folderMetadata = new Google.Apis.Drive.v3.Data.File
                {
                    Name = folderName,
                    MimeType = "application/vnd.google-apps.folder"
                };

                var folder = service.Files.Create(folderMetadata);
                folder.Fields = "id";

                folderId = folder.Execute().Id;
            }

            var fileMetadata = new Google.Apis.Drive.v3.Data.File
            {
                Name = System.IO.Path.GetFileName(backupPath),
                Parents = new System.Collections.Generic.List<string>
        {
            folderId
        }
            };

            using (var stream = new System.IO.FileStream(
                backupPath,
                System.IO.FileMode.Open,
                System.IO.FileAccess.Read))
            {
                var request = service.Files.Create(
                    fileMetadata,
                    stream,
                    "application/octet-stream");

                request.Fields = "id, name";

                var result = request.Upload();

                if (result.Status != Google.Apis.Upload.UploadStatus.Completed)
                {
                    throw new System.Exception(
                        "Yedek Google Drive'a yüklenemedi: " +
                        result.Exception?.Message);
                }
            }
        }
    }
}