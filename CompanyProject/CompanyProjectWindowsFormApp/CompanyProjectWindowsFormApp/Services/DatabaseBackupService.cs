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
    }
}