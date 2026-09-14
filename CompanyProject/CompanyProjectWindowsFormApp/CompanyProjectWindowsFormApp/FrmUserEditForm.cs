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
    public partial class FrmUserEditForm : Form
    {
        private BLUser blUser=new BLUser();
        private User user;
        public FrmUserEditForm(User user=null)
        {
            InitializeComponent();
            this.user = user;
            if (user != null) 
            {
                LoadUser();
            }
        }

        private void LoadUser()
        {
            LblTitle.Text = "Edit User";
            LblDescription.Text = "Update user account information";

            TxtUsername.Text =
                user.Username;

            TxtUserRole.Text =
                user.UserRole != null
                    ? user.UserRole.UserRoleName
                    : "";

            TxtPassword.Text = "";

            TxtPasswordComfirmation.Text = "";

            CBIsActive.Checked =
                user.IsActive;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void TxtPassword_TextChanged(object sender, EventArgs e)
        {
            string password = TxtPassword.Text;

            if (string.IsNullOrEmpty(password))
            {
                LblPasswordStrength.Text = "Password strength: -";
                LblPasswordStrength.ForeColor = Color.FromArgb(100, 116, 139);
                return;
            }

            int score = 0;

            if (password.Length >= 8)
                score++;

            if (password.Any(char.IsUpper))
                score++;

            if (password.Any(char.IsLower))
                score++;

            if (password.Any(char.IsDigit))
                score++;

            if (password.Any(ch => !char.IsLetterOrDigit(ch)))
                score++;

            if (score <= 2)
            {
                LblPasswordStrength.Text = "Password strength: Weak";
                LblPasswordStrength.ForeColor = Color.FromArgb(220, 38, 38);
            }
            else if (score <= 4)
            {
                LblPasswordStrength.Text = "Password strength: Medium";
                LblPasswordStrength.ForeColor = Color.FromArgb(234, 179, 8);
            }
            else
            {
                LblPasswordStrength.Text = "Password strength: Strong";
                LblPasswordStrength.ForeColor = Color.FromArgb(22, 163, 74);
            }
        }

        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = !ChkShowPassword.Checked;
        }

        private void ChkShowPasswordConfirmation_CheckedChanged(object sender, EventArgs e)
        {
            TxtPasswordComfirmation.UseSystemPasswordChar = !ChkShowPasswordConfirmation.Checked;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (user == null)
                    return;

                if (TxtPassword.Text != TxtPasswordComfirmation.Text)
                {
                    MessageBox.Show(
                        "Passwords do not match.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    TxtPasswordComfirmation.Focus();
                    return;
                }

                var userToUpdate = new User
                {
                    UserId = user.UserId,

                    Username = user.Username,

                    PasswordHash =
                        string.IsNullOrWhiteSpace(TxtPassword.Text)
                            ? user.PasswordHash
                            : PasswordHelper.PasswordHash(
                                TxtPassword.Text),

                    IsActive = CBIsActive.Checked,

                    UserRoleId = user.UserRoleId
                };

                if (!blUser.UserUpdate(userToUpdate))
                {
                    MessageBox.Show(
                        "User could not be updated.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                MessageBox.Show(
                    "User updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "User işleminde beklenmeyen bir hata oluştu.\n\n"
                    + ex.Message,
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
