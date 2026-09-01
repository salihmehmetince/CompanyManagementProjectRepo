namespace CompanyProjectWindowsFormApp
{
    partial class FrmFirstAdminForm
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
            this.LblName = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.TxtSurname = new System.Windows.Forms.TextBox();
            this.MTBPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.TxtPasswordComfirmation = new System.Windows.Forms.TextBox();
            this.BtnRegister = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblPasswordStrength = new System.Windows.Forms.Label();
            this.ChkShowPasswordConfirmation = new System.Windows.Forms.CheckBox();
            this.ChkShowPassword = new System.Windows.Forms.CheckBox();
            this.LblPasswordConfirmation = new System.Windows.Forms.Label();
            this.LblPassword = new System.Windows.Forms.Label();
            this.LblUsername = new System.Windows.Forms.Label();
            this.LblAccountInfoDescription = new System.Windows.Forms.Label();
            this.LblAccountInfo = new System.Windows.Forms.Label();
            this.LblEmail = new System.Windows.Forms.Label();
            this.LblPhoneNumber = new System.Windows.Forms.Label();
            this.LblSurname = new System.Windows.Forms.Label();
            this.LblPersonalInfoDescription = new System.Windows.Forms.Label();
            this.LblPersonelInfo = new System.Windows.Forms.Label();
            this.LblSubtitle = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.PBLogo = new System.Windows.Forms.PictureBox();
            this.LblAccent = new System.Windows.Forms.Label();
            this.LblDescription = new System.Windows.Forms.Label();
            this.LblWelcome = new System.Windows.Forms.Label();
            this.LblAppName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // LblName
            // 
            this.LblName.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblName.Location = new System.Drawing.Point(354, 212);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(220, 30);
            this.LblName.TabIndex = 0;
            this.LblName.Text = "Name (*)";
            this.LblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtName
            // 
            this.TxtName.BackColor = System.Drawing.Color.White;
            this.TxtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtName.Location = new System.Drawing.Point(357, 245);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(186, 30);
            this.TxtName.TabIndex = 12;
            // 
            // TxtSurname
            // 
            this.TxtSurname.BackColor = System.Drawing.Color.White;
            this.TxtSurname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSurname.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtSurname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtSurname.Location = new System.Drawing.Point(610, 245);
            this.TxtSurname.Name = "TxtSurname";
            this.TxtSurname.Size = new System.Drawing.Size(186, 30);
            this.TxtSurname.TabIndex = 13;
            // 
            // MTBPhoneNumber
            // 
            this.MTBPhoneNumber.BackColor = System.Drawing.Color.White;
            this.MTBPhoneNumber.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.MTBPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MTBPhoneNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.MTBPhoneNumber.Location = new System.Drawing.Point(357, 311);
            this.MTBPhoneNumber.Mask = "(999) 000-0000";
            this.MTBPhoneNumber.Name = "MTBPhoneNumber";
            this.MTBPhoneNumber.Size = new System.Drawing.Size(186, 30);
            this.MTBPhoneNumber.TabIndex = 15;
            this.MTBPhoneNumber.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // TxtEmail
            // 
            this.TxtEmail.BackColor = System.Drawing.Color.White;
            this.TxtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtEmail.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtEmail.Location = new System.Drawing.Point(610, 311);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(186, 30);
            this.TxtEmail.TabIndex = 17;
            // 
            // TxtUserName
            // 
            this.TxtUserName.BackColor = System.Drawing.Color.White;
            this.TxtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUserName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtUserName.Location = new System.Drawing.Point(358, 469);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(186, 30);
            this.TxtUserName.TabIndex = 19;
            // 
            // TxtPassword
            // 
            this.TxtPassword.BackColor = System.Drawing.Color.White;
            this.TxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPassword.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtPassword.Location = new System.Drawing.Point(357, 535);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(186, 30);
            this.TxtPassword.TabIndex = 20;
            this.TxtPassword.UseSystemPasswordChar = true;
            this.TxtPassword.TextChanged += new System.EventHandler(this.TxtPassword_TextChanged);
            // 
            // TxtPasswordComfirmation
            // 
            this.TxtPasswordComfirmation.BackColor = System.Drawing.Color.White;
            this.TxtPasswordComfirmation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPasswordComfirmation.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtPasswordComfirmation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtPasswordComfirmation.Location = new System.Drawing.Point(357, 650);
            this.TxtPasswordComfirmation.Name = "TxtPasswordComfirmation";
            this.TxtPasswordComfirmation.Size = new System.Drawing.Size(186, 30);
            this.TxtPasswordComfirmation.TabIndex = 21;
            this.TxtPasswordComfirmation.UseSystemPasswordChar = true;
            // 
            // BtnRegister
            // 
            this.BtnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.BtnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRegister.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnRegister.ForeColor = System.Drawing.Color.White;
            this.BtnRegister.Location = new System.Drawing.Point(357, 717);
            this.BtnRegister.Name = "BtnRegister";
            this.BtnRegister.Size = new System.Drawing.Size(200, 42);
            this.BtnRegister.TabIndex = 22;
            this.BtnRegister.Text = "CREATE ACCOUNT";
            this.BtnRegister.UseVisualStyleBackColor = false;
            this.BtnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LblPasswordStrength);
            this.panel1.Controls.Add(this.ChkShowPasswordConfirmation);
            this.panel1.Controls.Add(this.ChkShowPassword);
            this.panel1.Controls.Add(this.LblPasswordConfirmation);
            this.panel1.Controls.Add(this.LblPassword);
            this.panel1.Controls.Add(this.LblUsername);
            this.panel1.Controls.Add(this.LblAccountInfoDescription);
            this.panel1.Controls.Add(this.LblAccountInfo);
            this.panel1.Controls.Add(this.LblEmail);
            this.panel1.Controls.Add(this.LblPhoneNumber);
            this.panel1.Controls.Add(this.LblSurname);
            this.panel1.Controls.Add(this.LblPersonalInfoDescription);
            this.panel1.Controls.Add(this.LblPersonelInfo);
            this.panel1.Controls.Add(this.LblSubtitle);
            this.panel1.Controls.Add(this.LblTitle);
            this.panel1.Controls.Add(this.TxtEmail);
            this.panel1.Controls.Add(this.TxtName);
            this.panel1.Controls.Add(this.MTBPhoneNumber);
            this.panel1.Controls.Add(this.BtnRegister);
            this.panel1.Controls.Add(this.TxtPassword);
            this.panel1.Controls.Add(this.TxtSurname);
            this.panel1.Controls.Add(this.TxtPasswordComfirmation);
            this.panel1.Controls.Add(this.TxtUserName);
            this.panel1.Controls.Add(this.LblName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(882, 853);
            this.panel1.TabIndex = 23;
            // 
            // LblPasswordStrength
            // 
            this.LblPasswordStrength.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblPasswordStrength.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.LblPasswordStrength.Location = new System.Drawing.Point(355, 595);
            this.LblPasswordStrength.Name = "LblPasswordStrength";
            this.LblPasswordStrength.Size = new System.Drawing.Size(220, 22);
            this.LblPasswordStrength.TabIndex = 37;
            this.LblPasswordStrength.Text = "Password strength: -";
            this.LblPasswordStrength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChkShowPasswordConfirmation
            // 
            this.ChkShowPasswordConfirmation.AutoSize = true;
            this.ChkShowPasswordConfirmation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkShowPasswordConfirmation.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkShowPasswordConfirmation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.ChkShowPasswordConfirmation.Location = new System.Drawing.Point(357, 690);
            this.ChkShowPasswordConfirmation.Name = "ChkShowPasswordConfirmation";
            this.ChkShowPasswordConfirmation.Size = new System.Drawing.Size(121, 21);
            this.ChkShowPasswordConfirmation.TabIndex = 36;
            this.ChkShowPasswordConfirmation.Text = "Show Password";
            this.ChkShowPasswordConfirmation.UseVisualStyleBackColor = true;
            this.ChkShowPasswordConfirmation.CheckedChanged += new System.EventHandler(this.ChkShowPasswordConfirmation_CheckedChanged);
            // 
            // ChkShowPassword
            // 
            this.ChkShowPassword.AutoSize = true;
            this.ChkShowPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkShowPassword.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkShowPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.ChkShowPassword.Location = new System.Drawing.Point(358, 571);
            this.ChkShowPassword.Name = "ChkShowPassword";
            this.ChkShowPassword.Size = new System.Drawing.Size(121, 21);
            this.ChkShowPassword.TabIndex = 35;
            this.ChkShowPassword.Text = "Show Password";
            this.ChkShowPassword.UseVisualStyleBackColor = true;
            this.ChkShowPassword.CheckedChanged += new System.EventHandler(this.ChkShowPassword_CheckedChanged);
            // 
            // LblPasswordConfirmation
            // 
            this.LblPasswordConfirmation.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblPasswordConfirmation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblPasswordConfirmation.Location = new System.Drawing.Point(354, 617);
            this.LblPasswordConfirmation.Name = "LblPasswordConfirmation";
            this.LblPasswordConfirmation.Size = new System.Drawing.Size(220, 30);
            this.LblPasswordConfirmation.TabIndex = 34;
            this.LblPasswordConfirmation.Text = "Comfirm Password (*)";
            this.LblPasswordConfirmation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPassword
            // 
            this.LblPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblPassword.Location = new System.Drawing.Point(353, 502);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(220, 30);
            this.LblPassword.TabIndex = 33;
            this.LblPassword.Text = "Password (*)";
            this.LblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblUsername
            // 
            this.LblUsername.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblUsername.Location = new System.Drawing.Point(353, 436);
            this.LblUsername.Name = "LblUsername";
            this.LblUsername.Size = new System.Drawing.Size(220, 30);
            this.LblUsername.TabIndex = 32;
            this.LblUsername.Text = "Username (*)";
            this.LblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAccountInfoDescription
            // 
            this.LblAccountInfoDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblAccountInfoDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.LblAccountInfoDescription.Location = new System.Drawing.Point(357, 408);
            this.LblAccountInfoDescription.Name = "LblAccountInfoDescription";
            this.LblAccountInfoDescription.Size = new System.Drawing.Size(500, 25);
            this.LblAccountInfoDescription.TabIndex = 31;
            this.LblAccountInfoDescription.Text = "Create the login credentials for the administrator.";
            this.LblAccountInfoDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblAccountInfo
            // 
            this.LblAccountInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblAccountInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(84)))));
            this.LblAccountInfo.Location = new System.Drawing.Point(355, 366);
            this.LblAccountInfo.Name = "LblAccountInfo";
            this.LblAccountInfo.Size = new System.Drawing.Size(500, 30);
            this.LblAccountInfo.TabIndex = 30;
            this.LblAccountInfo.Text = "Account Information";
            this.LblAccountInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblEmail
            // 
            this.LblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblEmail.Location = new System.Drawing.Point(606, 278);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(220, 30);
            this.LblEmail.TabIndex = 29;
            this.LblEmail.Text = "Email (*)";
            this.LblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPhoneNumber
            // 
            this.LblPhoneNumber.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblPhoneNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblPhoneNumber.Location = new System.Drawing.Point(354, 278);
            this.LblPhoneNumber.Name = "LblPhoneNumber";
            this.LblPhoneNumber.Size = new System.Drawing.Size(220, 30);
            this.LblPhoneNumber.TabIndex = 28;
            this.LblPhoneNumber.Text = "Phone Number (*)";
            this.LblPhoneNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblSurname
            // 
            this.LblSurname.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblSurname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblSurname.Location = new System.Drawing.Point(606, 212);
            this.LblSurname.Name = "LblSurname";
            this.LblSurname.Size = new System.Drawing.Size(220, 30);
            this.LblSurname.TabIndex = 27;
            this.LblSurname.Text = "Surname (*)";
            this.LblSurname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPersonalInfoDescription
            // 
            this.LblPersonalInfoDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblPersonalInfoDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.LblPersonalInfoDescription.Location = new System.Drawing.Point(354, 180);
            this.LblPersonalInfoDescription.Name = "LblPersonalInfoDescription";
            this.LblPersonalInfoDescription.Size = new System.Drawing.Size(500, 25);
            this.LblPersonalInfoDescription.TabIndex = 26;
            this.LblPersonalInfoDescription.Text = "Enter the administrator\'s personal information.";
            this.LblPersonalInfoDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblPersonelInfo
            // 
            this.LblPersonelInfo.BackColor = System.Drawing.Color.White;
            this.LblPersonelInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblPersonelInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(84)))));
            this.LblPersonelInfo.Location = new System.Drawing.Point(352, 137);
            this.LblPersonelInfo.Name = "LblPersonelInfo";
            this.LblPersonelInfo.Size = new System.Drawing.Size(500, 30);
            this.LblPersonelInfo.TabIndex = 25;
            this.LblPersonelInfo.Text = "Personel Information";
            this.LblPersonelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblSubtitle
            // 
            this.LblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.LblSubtitle.Location = new System.Drawing.Point(353, 66);
            this.LblSubtitle.Name = "LblSubtitle";
            this.LblSubtitle.Size = new System.Drawing.Size(500, 35);
            this.LblSubtitle.TabIndex = 24;
            this.LblSubtitle.Text = "Set up the first administrator account to get started.";
            this.LblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitle
            // 
            this.LblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblTitle.Location = new System.Drawing.Point(350, 14);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(520, 40);
            this.LblTitle.TabIndex = 23;
            this.LblTitle.Text = "Create Your Administrator Account";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(84)))));
            this.panel2.Controls.Add(this.PBLogo);
            this.panel2.Controls.Add(this.LblAccent);
            this.panel2.Controls.Add(this.LblDescription);
            this.panel2.Controls.Add(this.LblWelcome);
            this.panel2.Controls.Add(this.LblAppName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 853);
            this.panel2.TabIndex = 24;
            // 
            // PBLogo
            // 
            this.PBLogo.BackColor = System.Drawing.Color.Transparent;
            this.PBLogo.Location = new System.Drawing.Point(106, 66);
            this.PBLogo.Name = "PBLogo";
            this.PBLogo.Size = new System.Drawing.Size(72, 72);
            this.PBLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBLogo.TabIndex = 38;
            this.PBLogo.TabStop = false;
            // 
            // LblAccent
            // 
            this.LblAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.LblAccent.Location = new System.Drawing.Point(18, 231);
            this.LblAccent.Name = "LblAccent";
            this.LblAccent.Size = new System.Drawing.Size(260, 1);
            this.LblAccent.TabIndex = 38;
            // 
            // LblDescription
            // 
            this.LblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.LblDescription.Location = new System.Drawing.Point(17, 317);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(250, 60);
            this.LblDescription.TabIndex = 25;
            this.LblDescription.Text = "Manage your business in one place.";
            this.LblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblWelcome
            // 
            this.LblWelcome.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            this.LblWelcome.Location = new System.Drawing.Point(12, 244);
            this.LblWelcome.Name = "LblWelcome";
            this.LblWelcome.Size = new System.Drawing.Size(260, 60);
            this.LblWelcome.TabIndex = 24;
            this.LblWelcome.Text = "Welcome to your company management application";
            this.LblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblAppName
            // 
            this.LblAppName.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblAppName.ForeColor = System.Drawing.Color.White;
            this.LblAppName.Location = new System.Drawing.Point(12, 137);
            this.LblAppName.Name = "LblAppName";
            this.LblAppName.Size = new System.Drawing.Size(260, 80);
            this.LblAppName.TabIndex = 23;
            this.LblAppName.Text = "Company Management";
            this.LblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmFirstAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(882, 853);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFirstAdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmFirstAdmin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.TextBox TxtSurname;
        private System.Windows.Forms.MaskedTextBox MTBPhoneNumber;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.TextBox TxtPasswordComfirmation;
        private System.Windows.Forms.Button BtnRegister;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.Label LblWelcome;
        private System.Windows.Forms.Label LblAppName;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Label LblSubtitle;
        private System.Windows.Forms.Label LblPersonelInfo;
        private System.Windows.Forms.Label LblPersonalInfoDescription;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.Label LblPhoneNumber;
        private System.Windows.Forms.Label LblSurname;
        private System.Windows.Forms.Label LblAccountInfoDescription;
        private System.Windows.Forms.Label LblAccountInfo;
        private System.Windows.Forms.Label LblPasswordConfirmation;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.Label LblUsername;
        private System.Windows.Forms.CheckBox ChkShowPassword;
        private System.Windows.Forms.CheckBox ChkShowPasswordConfirmation;
        private System.Windows.Forms.Label LblPasswordStrength;
        private System.Windows.Forms.Label LblAccent;
        private System.Windows.Forms.PictureBox PBLogo;
    }
}