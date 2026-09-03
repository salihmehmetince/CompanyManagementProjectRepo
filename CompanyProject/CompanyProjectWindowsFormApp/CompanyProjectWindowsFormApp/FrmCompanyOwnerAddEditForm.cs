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
    public partial class FrmCompanyOwnerAddEditForm : Form
    {
        private BLCompanyOwner blCompanyOwner = new BLCompanyOwner();

        private CompanyOwner companyOwner;

        public FrmCompanyOwnerAddEditForm(CompanyOwner companyOwner = null)
        {
            InitializeComponent();
            this.companyOwner = companyOwner;

            if (companyOwner != null)
            {
                LoadCompanyOwner();
            }
        }

        private void LoadCompanyOwner()
        {
            LblTitle.Text = "Edit Company Owner";
            LblDescription.Text = "Update company owner information";

            TxtIdentityNumber.Text =
                companyOwner.CompanyOwnerIdentityNumber;

            TxtCompanyOwnerName.Text =
                companyOwner.CompanyOwnerName;

            TxtSurname.Text =
                companyOwner.CompanyOwnerSurname;

            DTPBirthday.Value =
                companyOwner.CompanyOwnerBirthday;

            MTBTelephoneNumber.Text =
                companyOwner.CompanyOwnerTelephoneNumber;

            TxtEmail.Text =
                companyOwner.CompanyOwnerEmail;

            TxtUsername.Text =
                companyOwner.User != null
                    ? companyOwner.User.Username
                    : "";
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (companyOwner == null)
                {
                    // ADD

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

                    var companyOwnerRole = new BLUserRole()
                        .UserRoleList()
                        .FirstOrDefault(x =>
                            x.UserRoleName == "CompanyOwner");

                    if (companyOwnerRole == null)
                    {
                        MessageBox.Show(
                            "CompanyOwner rolü bulunamadı.",
                            "Hata",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return;
                    }

                    var user = new User
                    {
                        Username = TxtUsername.Text.Trim(),

                        PasswordHash =
                            PasswordHelper.PasswordHash(
                                TxtPassword.Text),

                        IsActive = true,

                        UserRoleId =
                            companyOwnerRole.UserRoleId
                    };

                    var companyOwnerToSave = new CompanyOwner
                    {
                        CompanyOwnerIdentityNumber =
                            TxtIdentityNumber.Text.Trim(),

                        CompanyOwnerName =
                            TxtCompanyOwnerName.Text.Trim(),

                        CompanyOwnerSurname =
                            TxtSurname.Text.Trim(),

                        CompanyOwnerBirthday =
                            DTPBirthday.Value,

                        CompanyOwnerTelephoneNumber =
                            MTBTelephoneNumber.Text.Trim(),

                        CompanyOwnerEmail =
                            string.IsNullOrWhiteSpace(TxtEmail.Text)
                                ? null
                                : TxtEmail.Text.Trim()
                    };

                    if (!blCompanyOwner.CompanyOwnerAdd(
                        companyOwnerToSave, user))
                    {
                        MessageBox.Show(
                            "Company owner could not be added.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        return;
                    }

                    MessageBox.Show(
                        "Company owner added successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();

                    return;
                }

                // UPDATE

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
                    UserId = companyOwner.UserId,

                    Username = TxtUsername.Text.Trim(),

                    PasswordHash =
                        string.IsNullOrWhiteSpace(TxtPassword.Text)
                            ? null
                            : PasswordHelper.PasswordHash(
                                TxtPassword.Text),

                    IsActive = true,

                                    UserRoleId = companyOwner.User != null
                    ? companyOwner.User.UserRoleId
                    : 2
                };

                companyOwner.CompanyOwnerIdentityNumber =
                    TxtIdentityNumber.Text.Trim();

                companyOwner.CompanyOwnerName =
                    TxtCompanyOwnerName.Text.Trim();

                companyOwner.CompanyOwnerSurname =
                    TxtSurname.Text.Trim();

                companyOwner.CompanyOwnerBirthday =
                    DTPBirthday.Value;

                companyOwner.CompanyOwnerTelephoneNumber =
                    MTBTelephoneNumber.Text.Trim();

                companyOwner.CompanyOwnerEmail =
                    string.IsNullOrWhiteSpace(TxtEmail.Text)
                        ? null
                        : TxtEmail.Text.Trim();

                if (!blCompanyOwner.CompanyOwnerUpdate(
                    companyOwner, userToUpdate))
                {
                    MessageBox.Show(
                        "Company owner could not be updated.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                MessageBox.Show(
                    "Company owner updated successfully.",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Company owner işleminde beklenmeyen bir hata oluştu.\n\n"
                    + ex.Message,
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}