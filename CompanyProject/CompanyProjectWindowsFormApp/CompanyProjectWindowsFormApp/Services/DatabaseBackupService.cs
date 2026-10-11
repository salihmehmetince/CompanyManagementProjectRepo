using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectWindowsFormApp.Services
{
    public class DatabaseBackupService
    {
        public bool CreateBackup(out string backupPath, out string errorMessage)
        {
            backupPath = null;
            errorMessage = null;

            try
            {
                string connectionString =
                    System.Configuration.ConfigurationManager
                    .ConnectionStrings["CompanyManagementConnection"]
                    .ConnectionString;

                var builder =
                    new System.Data.SqlClient.SqlConnectionStringBuilder(connectionString);

                string databaseName = builder.InitialCatalog;

                if (string.IsNullOrWhiteSpace(databaseName))
                {
                    throw new System.InvalidOperationException(
                        "Bağlantı dizesinde veritabanı adı bulunamadı.");
                }

                builder.InitialCatalog = "master";

                string backupDirectory = @"C:\CompanyManagement\Backups";

                System.IO.Directory.CreateDirectory(backupDirectory);

                string timestamp =
                    System.DateTime.Now.ToString("yyyyMMdd_HHmmss");

                backupPath = System.IO.Path.Combine(
                    backupDirectory,
                    databaseName + "_" + timestamp + ".bak");

                string safeDatabaseName = databaseName.Replace("]", "]]");
                string safeBackupPath = backupPath.Replace("'", "''");

                using (var connection =
                    new System.Data.SqlClient.SqlConnection(
                        builder.ConnectionString))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText =
                            "BACKUP DATABASE [" + safeDatabaseName + "] " +
                            "TO DISK = N'" + safeBackupPath + "' " +
                            "WITH INIT, CHECKSUM;";

                        command.CommandTimeout = 0;
                        command.ExecuteNonQuery();

                        command.CommandText =
                            "RESTORE VERIFYONLY FROM DISK = N'" +
                            safeBackupPath +
                            "' WITH CHECKSUM;";

                        command.ExecuteNonQuery();
                    }
                }

                var backupFiles = System.IO.Directory
                    .GetFiles(backupDirectory, databaseName + "_*.bak")
                    .Select(file => new System.IO.FileInfo(file))
                    .OrderByDescending(file => file.CreationTime)
                    .ToList();

                foreach (var oldBackup in backupFiles.Skip(5))
                {
                    oldBackup.Delete();
                }
                return true;
            }
            catch (System.Exception ex)
            {
                errorMessage = ex.Message;
                backupPath = null;

                return false;
            }
        }

        public bool IsValidBackupFile(string backupPath)
        {
            return !string.IsNullOrWhiteSpace(backupPath)
                && System.IO.File.Exists(backupPath)
                && string.Equals(
                    System.IO.Path.GetExtension(backupPath),
                    ".bak",
                    System.StringComparison.OrdinalIgnoreCase);
        }


        public bool RestoreBackup(string backupPath, out string errorMessage)
        {
            errorMessage = null;
            bool singleUserMode = false;
            string databaseName = null;
            string masterConnectionString = null;

            try
            {
                if (!IsValidBackupFile(backupPath))
                {
                    throw new System.InvalidOperationException(
                        "Geçerli bir .bak yedek dosyası seçilmedi.");
                }

                bool backupSuccessful = CreateBackup(
                    out string preRestoreBackupPath,
                    out string backupErrorMessage);

                if (!backupSuccessful)
                {
                    throw new System.InvalidOperationException(
                        "Geri yükleme öncesinde mevcut veritabanının yedeği alınamadı. " +
                        "Geri yükleme iptal edildi.\n\n" + backupErrorMessage);
                }

                string connectionString =
                    System.Configuration.ConfigurationManager
                    .ConnectionStrings["CompanyManagementConnection"]
                    .ConnectionString;

                var builder =
                    new System.Data.SqlClient.SqlConnectionStringBuilder(
                        connectionString);

                databaseName = builder.InitialCatalog;

                if (string.IsNullOrWhiteSpace(databaseName))
                {
                    throw new System.InvalidOperationException(
                        "Veritabanı adı bulunamadı.");
                }

                builder.InitialCatalog = "master";
                masterConnectionString = builder.ConnectionString;

                string safeDatabaseName = databaseName.Replace("]", "]]");
                string safeBackupPath = backupPath.Replace("'", "''");

                using (var connection =
                    new System.Data.SqlClient.SqlConnection(
                        masterConnectionString))
                {
                    connection.Open();

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandTimeout = 0;

                        command.CommandText =
                            "ALTER DATABASE [" + safeDatabaseName +
                            "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";

                        command.ExecuteNonQuery();
                        singleUserMode = true;

                        command.CommandText =
                            "RESTORE DATABASE [" + safeDatabaseName +
                            "] FROM DISK = N'" + safeBackupPath +
                            "' WITH REPLACE, CHECKSUM;";

                        command.ExecuteNonQuery();

                        command.CommandText =
                            "ALTER DATABASE [" + safeDatabaseName +
                            "] SET MULTI_USER;";

                        command.ExecuteNonQuery();
                        singleUserMode = false;
                    }
                }

                return true;
            }
            catch (System.Exception ex)
            {
                errorMessage = ex.Message;

                if (singleUserMode &&
                    !string.IsNullOrWhiteSpace(databaseName) &&
                    !string.IsNullOrWhiteSpace(masterConnectionString))
                {
                    try
                    {
                        string safeDatabaseName =
                            databaseName.Replace("]", "]]");

                        using (var connection =
                            new System.Data.SqlClient.SqlConnection(
                                masterConnectionString))
                        {
                            connection.Open();

                            using (var command = connection.CreateCommand())
                            {
                                command.CommandTimeout = 0;
                                command.CommandText =
                                    "ALTER DATABASE [" + safeDatabaseName +
                                    "] SET MULTI_USER;";

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    catch (System.Exception restoreModeException)
                    {
                        errorMessage +=
                            "\n\nVeritabanını MULTI_USER moduna döndürme hatası: " +
                            restoreModeException.Message;
                    }
                }

                return false;
            }
        }
    }
}