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
using System.Xml.Linq;

namespace CompanyProjectWindowsFormApp
{
    public partial class FrmFirstAdminForm : Form
    {
        public FrmFirstAdminForm()
        {
            InitializeComponent();
            SetTextBoxFocusEffect();
            setIcon();
            SetRegisterButtonBorder();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            try
            {

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

                var adminRole = new BLUserRole()
                    .UserRoleList()
                    .FirstOrDefault(x => x.UserRoleName == "Admin");

                if (adminRole == null)
                {
                    MessageBox.Show(
                        "Admin rolü bulunamadı.",
                        "Hata",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                var user = new User
                {
                    Username = TxtUserName.Text,
                    PasswordHash = PasswordHelper.PasswordHash(
                        TxtPassword.Text),
                    IsActive = true,
                    UserRoleId = adminRole.UserRoleId
                };

                var admin = new Admin
                {
                    AdminName = TxtName.Text,
                    AdminSurname = TxtSurname.Text,
                    AdminTelephoneNumber = MTBPhoneNumber.Text,
                    AdminEmail = string.IsNullOrWhiteSpace(TxtEmail.Text)
                        ? null
                        : TxtEmail.Text
                };

                BLAdmin blAdmin = new BLAdmin();

                if (!blAdmin.FirstAdminAdd(admin, user))
                {
                    MessageBox.Show(
                        "İlk Admin hesabı oluşturulamadı.",
                        "Hata",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                MessageBox.Show(
                    "İlk Admin hesabı başarıyla oluşturuldu.",
                    "Başarılı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "İlk Admin oluşturulurken beklenmeyen bir hata oluştu.\n\n" +
                    ex.Message,
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void ChkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            TxtPassword.UseSystemPasswordChar =!ChkShowPassword.Checked;
        }

        private void ChkShowPasswordConfirmation_CheckedChanged(object sender, EventArgs e)
        {
            TxtPasswordComfirmation.UseSystemPasswordChar =!ChkShowPasswordConfirmation.Checked;
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox == null)
                return;

            textBox.BackColor = Color.FromArgb(240, 249, 255);
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox == null)
                return;

            textBox.BackColor = Color.White;
        }

        private void SetTextBoxFocusEffect()
        {
            TxtName.Enter += TextBox_Enter;
            TxtName.Leave += TextBox_Leave;

            TxtSurname.Enter += TextBox_Enter;
            TxtSurname.Leave += TextBox_Leave;

            MTBPhoneNumber.Enter += TextBox_Enter;
            MTBPhoneNumber.Leave += TextBox_Leave;

            TxtEmail.Enter += TextBox_Enter;
            TxtEmail.Leave += TextBox_Leave;

            TxtUserName.Enter += TextBox_Enter;
            TxtUserName.Leave += TextBox_Leave;

            TxtPassword.Enter += TextBox_Enter;
            TxtPassword.Leave += TextBox_Leave;

            TxtPasswordComfirmation.Enter += TextBox_Enter;
            TxtPasswordComfirmation.Leave += TextBox_Leave;

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

        private void setIcon() 
        {
            this.Icon=Properties.Resources.icon_company;
            PBLogo.Image = Properties.Resources.iconCompany;
        }

        private void SetRegisterButtonBorder()
        {
            BtnRegister.FlatAppearance.BorderSize = 0;
        }


    }
}
