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
    public partial class FrmLoginForm : Form
    {
        public FrmLoginForm()
        {
            InitializeComponent();
            setIcon();
            SetTextBoxFocusEffect();
            SetRegisterButtonBorder();
        }

        private void setIcon()
        {
            this.Icon = Properties.Resources.icon_company;
            PBLogo.Image = Properties.Resources.iconCompany;
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
            TxtUserName.Enter += TextBox_Enter;
            TxtUserName.Leave += TextBox_Leave;

        }

        private void SetRegisterButtonBorder()
        {
            BtnLogin.FlatAppearance.BorderSize = 0;
        }

        private void CBShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            TxtPassword.UseSystemPasswordChar = !CBShowPassword.Checked;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                BLUser blUser = new BLUser();

                User user = blUser.UserGetByUsername(
                    TxtUserName.Text);

                if (user == null)
                {
                    MessageBox.Show(
                        "Invalid username or password.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (!user.IsActive)
                {
                    MessageBox.Show(
                        "The user account is not active.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (!PasswordHelper.PasswordVerify(
                    TxtPassword.Text,
                    user.PasswordHash))
                {
                    MessageBox.Show(
                        "Invalid username or password.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                MessageBox.Show(
                    "Login successful.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                FrmMainForm frmMainForm = new FrmMainForm(user);

                Hide();

                frmMainForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An unexpected error occurred while logging in.\n\n" +
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
