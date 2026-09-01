using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompanyProjectWindowsFormApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BLAdmin blAdmin = new BLAdmin();

            var admins = blAdmin.AdminList();

            if (admins == null || admins.Count == 0)
            {
                using (FrmFirstAdminForm firstAdminForm = new FrmFirstAdminForm())
                {
                    if (firstAdminForm.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }
                }
            }

            Application.Run(new FrmLoginForm());
        }
    }
}
