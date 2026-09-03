namespace CompanyProjectWindowsFormApp
{
    partial class FrmCompanyOwnerAddEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PnlMain = new System.Windows.Forms.Panel();
            this.PnlContent = new System.Windows.Forms.Panel();
            this.TxtUsername = new System.Windows.Forms.TextBox();
            this.LblUsername = new System.Windows.Forms.Label();
            this.TxtPasswordComfirmation = new System.Windows.Forms.TextBox();
            this.LblPasswordComfirmation = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.LblPassword = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.LblEmail = new System.Windows.Forms.Label();
            this.MTBTelephoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.DTPBirthday = new System.Windows.Forms.DateTimePicker();
            this.TxtSurname = new System.Windows.Forms.TextBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.LblTelephoneNumber = new System.Windows.Forms.Label();
            this.LblCompanyOwnerBirthday = new System.Windows.Forms.Label();
            this.LblCompanyOwnerSurname = new System.Windows.Forms.Label();
            this.TxtCompanyOwnerName = new System.Windows.Forms.TextBox();
            this.LblCompanyOwnerName = new System.Windows.Forms.Label();
            this.TxtIdentityNumber = new System.Windows.Forms.TextBox();
            this.LblCompanyOwnerIdentityNumber = new System.Windows.Forms.Label();
            this.PnlHeader = new System.Windows.Forms.Panel();
            this.LblDescription = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.LblPasswordStrength = new System.Windows.Forms.Label();
            this.ChkShowPassword = new System.Windows.Forms.CheckBox();
            this.ChkShowPasswordConfirmation = new System.Windows.Forms.CheckBox();
            this.PnlMain.SuspendLayout();
            this.PnlContent.SuspendLayout();
            this.PnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.PnlContent);
            this.PnlMain.Controls.Add(this.PnlHeader);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(630, 1000);
            this.PnlMain.TabIndex = 1;
            // 
            // PnlContent
            // 
            this.PnlContent.AutoScroll = true;
            this.PnlContent.Controls.Add(this.ChkShowPasswordConfirmation);
            this.PnlContent.Controls.Add(this.LblPasswordStrength);
            this.PnlContent.Controls.Add(this.ChkShowPassword);
            this.PnlContent.Controls.Add(this.TxtUsername);
            this.PnlContent.Controls.Add(this.LblUsername);
            this.PnlContent.Controls.Add(this.TxtPasswordComfirmation);
            this.PnlContent.Controls.Add(this.LblPasswordComfirmation);
            this.PnlContent.Controls.Add(this.TxtPassword);
            this.PnlContent.Controls.Add(this.LblPassword);
            this.PnlContent.Controls.Add(this.TxtEmail);
            this.PnlContent.Controls.Add(this.LblEmail);
            this.PnlContent.Controls.Add(this.MTBTelephoneNumber);
            this.PnlContent.Controls.Add(this.DTPBirthday);
            this.PnlContent.Controls.Add(this.TxtSurname);
            this.PnlContent.Controls.Add(this.BtnCancel);
            this.PnlContent.Controls.Add(this.BtnSave);
            this.PnlContent.Controls.Add(this.LblTelephoneNumber);
            this.PnlContent.Controls.Add(this.LblCompanyOwnerBirthday);
            this.PnlContent.Controls.Add(this.LblCompanyOwnerSurname);
            this.PnlContent.Controls.Add(this.TxtCompanyOwnerName);
            this.PnlContent.Controls.Add(this.LblCompanyOwnerName);
            this.PnlContent.Controls.Add(this.TxtIdentityNumber);
            this.PnlContent.Controls.Add(this.LblCompanyOwnerIdentityNumber);
            this.PnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContent.Location = new System.Drawing.Point(0, 80);
            this.PnlContent.Name = "PnlContent";
            this.PnlContent.Padding = new System.Windows.Forms.Padding(30, 25, 30, 20);
            this.PnlContent.Size = new System.Drawing.Size(630, 920);
            this.PnlContent.TabIndex = 1;
            // 
            // TxtUsername
            // 
            this.TxtUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.TxtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUsername.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtUsername.Location = new System.Drawing.Point(30, 500);
            this.TxtUsername.Name = "TxtUsername";
            this.TxtUsername.Size = new System.Drawing.Size(570, 30);
            this.TxtUsername.TabIndex = 18;
            // 
            // LblUsername
            // 
            this.LblUsername.AutoSize = true;
            this.LblUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblUsername.Location = new System.Drawing.Point(30, 475);
            this.LblUsername.Name = "LblUsername";
            this.LblUsername.Size = new System.Drawing.Size(75, 20);
            this.LblUsername.TabIndex = 17;
            this.LblUsername.Text = "Username";
            // 
            // TxtPasswordComfirmation
            // 
            this.TxtPasswordComfirmation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.TxtPasswordComfirmation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPasswordComfirmation.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtPasswordComfirmation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtPasswordComfirmation.Location = new System.Drawing.Point(30, 725);
            this.TxtPasswordComfirmation.Name = "TxtPasswordComfirmation";
            this.TxtPasswordComfirmation.Size = new System.Drawing.Size(570, 30);
            this.TxtPasswordComfirmation.TabIndex = 22;
            this.TxtPasswordComfirmation.UseSystemPasswordChar = true;
            // 
            // LblPasswordComfirmation
            // 
            this.LblPasswordComfirmation.AutoSize = true;
            this.LblPasswordComfirmation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblPasswordComfirmation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblPasswordComfirmation.Location = new System.Drawing.Point(30, 700);
            this.LblPasswordComfirmation.Name = "LblPasswordComfirmation";
            this.LblPasswordComfirmation.Size = new System.Drawing.Size(166, 20);
            this.LblPasswordComfirmation.TabIndex = 21;
            this.LblPasswordComfirmation.Text = "Password Comfirmation";
            // 
            // TxtPassword
            // 
            this.TxtPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.TxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPassword.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtPassword.Location = new System.Drawing.Point(29, 575);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(570, 30);
            this.TxtPassword.TabIndex = 20;
            this.TxtPassword.UseSystemPasswordChar = true;
            this.TxtPassword.TextChanged += new System.EventHandler(this.TxtPassword_TextChanged);
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblPassword.Location = new System.Drawing.Point(29, 550);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(70, 20);
            this.LblPassword.TabIndex = 19;
            this.LblPassword.Text = "Password";
            // 
            // TxtEmail
            // 
            this.TxtEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.TxtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtEmail.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtEmail.Location = new System.Drawing.Point(30, 425);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(570, 30);
            this.TxtEmail.TabIndex = 16;
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblEmail.Location = new System.Drawing.Point(30, 400);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(46, 20);
            this.LblEmail.TabIndex = 15;
            this.LblEmail.Text = "Email";
            // 
            // MTBTelephoneNumber
            // 
            this.MTBTelephoneNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MTBTelephoneNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.MTBTelephoneNumber.Location = new System.Drawing.Point(30, 350);
            this.MTBTelephoneNumber.Mask = "(999) 000-0000";
            this.MTBTelephoneNumber.Name = "MTBTelephoneNumber";
            this.MTBTelephoneNumber.Size = new System.Drawing.Size(200, 30);
            this.MTBTelephoneNumber.TabIndex = 14;
            this.MTBTelephoneNumber.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // DTPBirthday
            // 
            this.DTPBirthday.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DTPBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPBirthday.Location = new System.Drawing.Point(30, 275);
            this.DTPBirthday.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.DTPBirthday.Name = "DTPBirthday";
            this.DTPBirthday.Size = new System.Drawing.Size(200, 30);
            this.DTPBirthday.TabIndex = 13;
            // 
            // TxtSurname
            // 
            this.TxtSurname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.TxtSurname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSurname.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtSurname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtSurname.Location = new System.Drawing.Point(30, 200);
            this.TxtSurname.Name = "TxtSurname";
            this.TxtSurname.Size = new System.Drawing.Size(570, 30);
            this.TxtSurname.TabIndex = 12;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(510, 825);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(110, 35);
            this.BtnCancel.TabIndex = 11;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.BtnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSave.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnSave.ForeColor = System.Drawing.Color.White;
            this.BtnSave.Location = new System.Drawing.Point(390, 825);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(110, 35);
            this.BtnSave.TabIndex = 10;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // LblTelephoneNumber
            // 
            this.LblTelephoneNumber.AutoSize = true;
            this.LblTelephoneNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTelephoneNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblTelephoneNumber.Location = new System.Drawing.Point(30, 325);
            this.LblTelephoneNumber.Name = "LblTelephoneNumber";
            this.LblTelephoneNumber.Size = new System.Drawing.Size(136, 20);
            this.LblTelephoneNumber.TabIndex = 8;
            this.LblTelephoneNumber.Text = "Telephone Number";
            // 
            // LblCompanyOwnerBirthday
            // 
            this.LblCompanyOwnerBirthday.AutoSize = true;
            this.LblCompanyOwnerBirthday.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblCompanyOwnerBirthday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblCompanyOwnerBirthday.Location = new System.Drawing.Point(30, 250);
            this.LblCompanyOwnerBirthday.Name = "LblCompanyOwnerBirthday";
            this.LblCompanyOwnerBirthday.Size = new System.Drawing.Size(64, 20);
            this.LblCompanyOwnerBirthday.TabIndex = 6;
            this.LblCompanyOwnerBirthday.Text = "Birthday";
            // 
            // LblCompanyOwnerSurname
            // 
            this.LblCompanyOwnerSurname.AutoSize = true;
            this.LblCompanyOwnerSurname.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblCompanyOwnerSurname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblCompanyOwnerSurname.Location = new System.Drawing.Point(30, 175);
            this.LblCompanyOwnerSurname.Name = "LblCompanyOwnerSurname";
            this.LblCompanyOwnerSurname.Size = new System.Drawing.Size(67, 20);
            this.LblCompanyOwnerSurname.TabIndex = 4;
            this.LblCompanyOwnerSurname.Text = "Surname";
            // 
            // TxtCompanyOwnerName
            // 
            this.TxtCompanyOwnerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.TxtCompanyOwnerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCompanyOwnerName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtCompanyOwnerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtCompanyOwnerName.Location = new System.Drawing.Point(30, 125);
            this.TxtCompanyOwnerName.Name = "TxtCompanyOwnerName";
            this.TxtCompanyOwnerName.Size = new System.Drawing.Size(570, 30);
            this.TxtCompanyOwnerName.TabIndex = 3;
            // 
            // LblCompanyOwnerName
            // 
            this.LblCompanyOwnerName.AutoSize = true;
            this.LblCompanyOwnerName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblCompanyOwnerName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblCompanyOwnerName.Location = new System.Drawing.Point(30, 100);
            this.LblCompanyOwnerName.Name = "LblCompanyOwnerName";
            this.LblCompanyOwnerName.Size = new System.Drawing.Size(49, 20);
            this.LblCompanyOwnerName.TabIndex = 2;
            this.LblCompanyOwnerName.Text = "Name";
            // 
            // TxtIdentityNumber
            // 
            this.TxtIdentityNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.TxtIdentityNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtIdentityNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtIdentityNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtIdentityNumber.Location = new System.Drawing.Point(30, 50);
            this.TxtIdentityNumber.Name = "TxtIdentityNumber";
            this.TxtIdentityNumber.Size = new System.Drawing.Size(570, 30);
            this.TxtIdentityNumber.TabIndex = 1;
            // 
            // LblCompanyOwnerIdentityNumber
            // 
            this.LblCompanyOwnerIdentityNumber.AutoSize = true;
            this.LblCompanyOwnerIdentityNumber.BackColor = System.Drawing.Color.Transparent;
            this.LblCompanyOwnerIdentityNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblCompanyOwnerIdentityNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblCompanyOwnerIdentityNumber.Location = new System.Drawing.Point(30, 25);
            this.LblCompanyOwnerIdentityNumber.Name = "LblCompanyOwnerIdentityNumber";
            this.LblCompanyOwnerIdentityNumber.Size = new System.Drawing.Size(231, 20);
            this.LblCompanyOwnerIdentityNumber.TabIndex = 0;
            this.LblCompanyOwnerIdentityNumber.Text = "Company Owner Identity Number";
            // 
            // PnlHeader
            // 
            this.PnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.PnlHeader.Controls.Add(this.LblDescription);
            this.PnlHeader.Controls.Add(this.LblTitle);
            this.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlHeader.Location = new System.Drawing.Point(0, 0);
            this.PnlHeader.Name = "PnlHeader";
            this.PnlHeader.Size = new System.Drawing.Size(630, 80);
            this.PnlHeader.TabIndex = 0;
            // 
            // LblDescription
            // 
            this.LblDescription.AutoSize = true;
            this.LblDescription.BackColor = System.Drawing.Color.Transparent;
            this.LblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.LblDescription.Location = new System.Drawing.Point(27, 48);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(235, 20);
            this.LblDescription.TabIndex = 1;
            this.LblDescription.Text = "Enter company owner information";
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(25, 15);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(310, 41);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "New Company Owner";
            // 
            // LblPasswordStrength
            // 
            this.LblPasswordStrength.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblPasswordStrength.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.LblPasswordStrength.Location = new System.Drawing.Point(30, 650);
            this.LblPasswordStrength.Name = "LblPasswordStrength";
            this.LblPasswordStrength.Size = new System.Drawing.Size(220, 22);
            this.LblPasswordStrength.TabIndex = 39;
            this.LblPasswordStrength.Text = "Password strength: -";
            this.LblPasswordStrength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChkShowPassword
            // 
            this.ChkShowPassword.AutoSize = true;
            this.ChkShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkShowPassword.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkShowPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.ChkShowPassword.Location = new System.Drawing.Point(30, 625);
            this.ChkShowPassword.Name = "ChkShowPassword";
            this.ChkShowPassword.Size = new System.Drawing.Size(121, 21);
            this.ChkShowPassword.TabIndex = 38;
            this.ChkShowPassword.Text = "Show Password";
            this.ChkShowPassword.UseVisualStyleBackColor = true;
            this.ChkShowPassword.CheckedChanged += new System.EventHandler(this.ChkShowPassword_CheckedChanged);
            // 
            // ChkShowPasswordConfirmation
            // 
            this.ChkShowPasswordConfirmation.AutoSize = true;
            this.ChkShowPasswordConfirmation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkShowPasswordConfirmation.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkShowPasswordConfirmation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.ChkShowPasswordConfirmation.Location = new System.Drawing.Point(30, 775);
            this.ChkShowPasswordConfirmation.Name = "ChkShowPasswordConfirmation";
            this.ChkShowPasswordConfirmation.Size = new System.Drawing.Size(121, 21);
            this.ChkShowPasswordConfirmation.TabIndex = 40;
            this.ChkShowPasswordConfirmation.Text = "Show Password";
            this.ChkShowPasswordConfirmation.UseVisualStyleBackColor = true;
            this.ChkShowPasswordConfirmation.CheckedChanged += new System.EventHandler(this.ChkShowPasswordConfirmation_CheckedChanged);
            // 
            // FrmCompanyOwnerAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(630, 1000);
            this.Controls.Add(this.PnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCompanyOwnerAddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Company Owner";
            this.PnlMain.ResumeLayout(false);
            this.PnlContent.ResumeLayout(false);
            this.PnlContent.PerformLayout();
            this.PnlHeader.ResumeLayout(false);
            this.PnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Panel PnlContent;
        private System.Windows.Forms.TextBox TxtSurname;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label LblTelephoneNumber;
        private System.Windows.Forms.Label LblCompanyOwnerBirthday;
        private System.Windows.Forms.Label LblCompanyOwnerSurname;
        private System.Windows.Forms.TextBox TxtCompanyOwnerName;
        private System.Windows.Forms.Label LblCompanyOwnerName;
        private System.Windows.Forms.TextBox TxtIdentityNumber;
        private System.Windows.Forms.Label LblCompanyOwnerIdentityNumber;
        private System.Windows.Forms.Panel PnlHeader;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.DateTimePicker DTPBirthday;
        private System.Windows.Forms.MaskedTextBox MTBTelephoneNumber;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.TextBox TxtPasswordComfirmation;
        private System.Windows.Forms.Label LblPasswordComfirmation;
        private System.Windows.Forms.TextBox TxtUsername;
        private System.Windows.Forms.Label LblUsername;
        private System.Windows.Forms.Label LblPasswordStrength;
        private System.Windows.Forms.CheckBox ChkShowPassword;
        private System.Windows.Forms.CheckBox ChkShowPasswordConfirmation;
    }
}