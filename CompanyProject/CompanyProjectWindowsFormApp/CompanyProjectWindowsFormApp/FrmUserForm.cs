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
    public partial class FrmUserForm : Form
    {
        private BLUser blUser=new BLUser();
        public FrmUserForm()
        {
            InitializeComponent();
            setIcon();
            SetButtonsBorder();
            ListUsers();
        }

        private void setIcon()
        {
            this.Icon = Properties.Resources.icon_company;
        }


        private void SetButtonsBorder()
        {
            BtnEdit.FlatAppearance.BorderSize = 0;
        }

        private void ListUsers()
        {
            List<User> users =
                blUser.UserList();

            var userList = users.Select(x => new
            {
                x.UserId,
                x.Username,
                Role = x.UserRole.UserRoleName,
                Status = x.IsActive ? "Active" : "Passive"
            }).ToList();

            DgvUsers.DataSource = userList;

            LblRecordCount.Text =
                users.Count + " users";
        }

        private User GetSelectedUser()
        {
            if (DgvUsers.CurrentRow == null)
                return null;

            int userId = Convert.ToInt32(
                DgvUsers.CurrentRow.Cells["UserId"].Value
            );

            return blUser.UserGetById(userId);
        }

        private void SearchUsers()
        {
            string searchText = TxtSearch.Text.Trim().ToLower();

            List<User> users =
                blUser.UserList();

            if (!string.IsNullOrEmpty(searchText))
            {
                users = users
                    .Where(x =>
                        x.Username.ToLower()
                            .Contains(searchText) ||
                        x.UserRole.UserRoleName.ToLower()
                            .Contains(searchText)
                    )
                    .ToList();
            }

            var userList = users.Select(x => new
            {
                x.UserId,
                x.Username,
                Role = x.UserRole.UserRoleName,
                Status = x.IsActive ? "Active" : "Passive"
            }).ToList();

            DgvUsers.DataSource = userList;

            LblRecordCount.Text =
                users.Count + " users";
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchUsers();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            User user = GetSelectedUser();

            if (user == null)
            {
                MessageBox.Show(
                    "Please select a user.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            FrmUserEditForm frm =
                new FrmUserEditForm(user);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                ListUsers();
            }
        }
    }
}
