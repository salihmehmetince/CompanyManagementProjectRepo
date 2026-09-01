namespace CompanyProjectWindowsFormApp
{
    partial class FrmLoginForm
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
            this.PnlLeft = new System.Windows.Forms.Panel();
            this.LblAccent = new System.Windows.Forms.Label();
            this.LblDescription = new System.Windows.Forms.Label();
            this.LblAppName = new System.Windows.Forms.Label();
            this.PBLogo = new System.Windows.Forms.PictureBox();
            this.PnlRight = new System.Windows.Forms.Panel();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.CBShowPassword = new System.Windows.Forms.CheckBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.LblPassword = new System.Windows.Forms.Label();
            this.TxtUserName = new System.Windows.Forms.TextBox();
            this.LblUserName = new System.Windows.Forms.Label();
            this.LblLoginDescription = new System.Windows.Forms.Label();
            this.LblWelcome = new System.Windows.Forms.Label();
            this.PnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBLogo)).BeginInit();
            this.PnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlLeft
            // 
            this.PnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(84)))));
            this.PnlLeft.Controls.Add(this.LblAccent);
            this.PnlLeft.Controls.Add(this.LblDescription);
            this.PnlLeft.Controls.Add(this.LblAppName);
            this.PnlLeft.Controls.Add(this.PBLogo);
            this.PnlLeft.Location = new System.Drawing.Point(0, 0);
            this.PnlLeft.Name = "PnlLeft";
            this.PnlLeft.Size = new System.Drawing.Size(320, 550);
            this.PnlLeft.TabIndex = 0;
            // 
            // LblAccent
            // 
            this.LblAccent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.LblAccent.Location = new System.Drawing.Point(33, 274);
            this.LblAccent.Name = "LblAccent";
            this.LblAccent.Size = new System.Drawing.Size(260, 1);
            this.LblAccent.TabIndex = 41;
            // 
            // LblDescription
            // 
            this.LblDescription.BackColor = System.Drawing.Color.Transparent;
            this.LblDescription.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.LblDescription.Location = new System.Drawing.Point(32, 360);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(250, 60);
            this.LblDescription.TabIndex = 40;
            this.LblDescription.Text = "Manage your business in one place.";
            this.LblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblAppName
            // 
            this.LblAppName.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblAppName.ForeColor = System.Drawing.Color.White;
            this.LblAppName.Location = new System.Drawing.Point(27, 180);
            this.LblAppName.Name = "LblAppName";
            this.LblAppName.Size = new System.Drawing.Size(260, 80);
            this.LblAppName.TabIndex = 39;
            this.LblAppName.Text = "Company Management";
            this.LblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PBLogo
            // 
            this.PBLogo.BackColor = System.Drawing.Color.Transparent;
            this.PBLogo.Location = new System.Drawing.Point(124, 60);
            this.PBLogo.Name = "PBLogo";
            this.PBLogo.Size = new System.Drawing.Size(72, 72);
            this.PBLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBLogo.TabIndex = 1;
            this.PBLogo.TabStop = false;
            // 
            // PnlRight
            // 
            this.PnlRight.Controls.Add(this.BtnLogin);
            this.PnlRight.Controls.Add(this.CBShowPassword);
            this.PnlRight.Controls.Add(this.TxtPassword);
            this.PnlRight.Controls.Add(this.LblPassword);
            this.PnlRight.Controls.Add(this.TxtUserName);
            this.PnlRight.Controls.Add(this.LblUserName);
            this.PnlRight.Controls.Add(this.LblLoginDescription);
            this.PnlRight.Controls.Add(this.LblWelcome);
            this.PnlRight.Location = new System.Drawing.Point(320, 0);
            this.PnlRight.Name = "PnlRight";
            this.PnlRight.Size = new System.Drawing.Size(580, 550);
            this.PnlRight.TabIndex = 1;
            // 
            // BtnLogin
            // 
            this.BtnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(182)))), ((int)(((byte)(212)))));
            this.BtnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogin.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnLogin.ForeColor = System.Drawing.Color.White;
            this.BtnLogin.Location = new System.Drawing.Point(60, 380);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(440, 45);
            this.BtnLogin.TabIndex = 7;
            this.BtnLogin.Text = "LOGIN";
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // CBShowPassword
            // 
            this.CBShowPassword.BackColor = System.Drawing.Color.Transparent;
            this.CBShowPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CBShowPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.CBShowPassword.Location = new System.Drawing.Point(60, 327);
            this.CBShowPassword.Name = "CBShowPassword";
            this.CBShowPassword.Size = new System.Drawing.Size(140, 25);
            this.CBShowPassword.TabIndex = 6;
            this.CBShowPassword.Text = "Show Password";
            this.CBShowPassword.UseVisualStyleBackColor = false;
            this.CBShowPassword.CheckedChanged += new System.EventHandler(this.CBShowPassword_CheckedChanged);
            // 
            // TxtPassword
            // 
            this.TxtPassword.BackColor = System.Drawing.Color.White;
            this.TxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPassword.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(84)))));
            this.TxtPassword.Location = new System.Drawing.Point(60, 282);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(440, 30);
            this.TxtPassword.TabIndex = 5;
            this.TxtPassword.UseSystemPasswordChar = true;
            // 
            // LblPassword
            // 
            this.LblPassword.BackColor = System.Drawing.Color.Transparent;
            this.LblPassword.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(84)))));
            this.LblPassword.Location = new System.Drawing.Point(60, 255);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(440, 25);
            this.LblPassword.TabIndex = 4;
            this.LblPassword.Text = "Password";
            this.LblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtUserName
            // 
            this.TxtUserName.BackColor = System.Drawing.Color.White;
            this.TxtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtUserName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(84)))));
            this.TxtUserName.Location = new System.Drawing.Point(60, 192);
            this.TxtUserName.Name = "TxtUserName";
            this.TxtUserName.Size = new System.Drawing.Size(440, 30);
            this.TxtUserName.TabIndex = 3;
            // 
            // LblUserName
            // 
            this.LblUserName.BackColor = System.Drawing.Color.Transparent;
            this.LblUserName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(84)))));
            this.LblUserName.Location = new System.Drawing.Point(60, 165);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.Size = new System.Drawing.Size(440, 25);
            this.LblUserName.TabIndex = 2;
            this.LblUserName.Text = "Username";
            this.LblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblLoginDescription
            // 
            this.LblLoginDescription.BackColor = System.Drawing.Color.Transparent;
            this.LblLoginDescription.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblLoginDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.LblLoginDescription.Location = new System.Drawing.Point(60, 105);
            this.LblLoginDescription.Name = "LblLoginDescription";
            this.LblLoginDescription.Size = new System.Drawing.Size(440, 30);
            this.LblLoginDescription.TabIndex = 1;
            this.LblLoginDescription.Text = "Sign in to continue to Company Management.";
            this.LblLoginDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblWelcome
            // 
            this.LblWelcome.BackColor = System.Drawing.Color.Transparent;
            this.LblWelcome.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(84)))));
            this.LblWelcome.Location = new System.Drawing.Point(60, 55);
            this.LblWelcome.Name = "LblWelcome";
            this.LblWelcome.Size = new System.Drawing.Size(440, 45);
            this.LblWelcome.TabIndex = 0;
            this.LblWelcome.Text = "Welcome Back";
            this.LblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmLoginForm
            // 
            this.AcceptButton = this.BtnLogin;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(878, 549);
            this.Controls.Add(this.PnlRight);
            this.Controls.Add(this.PnlLeft);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "FrmLoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Management";
            this.PnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PBLogo)).EndInit();
            this.PnlRight.ResumeLayout(false);
            this.PnlRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlLeft;
        private System.Windows.Forms.PictureBox PBLogo;
        private System.Windows.Forms.Label LblAccent;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.Label LblAppName;
        private System.Windows.Forms.Panel PnlRight;
        private System.Windows.Forms.Label LblLoginDescription;
        private System.Windows.Forms.Label LblWelcome;
        private System.Windows.Forms.TextBox TxtUserName;
        private System.Windows.Forms.Label LblUserName;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.CheckBox CBShowPassword;
        private System.Windows.Forms.Button BtnLogin;
    }
}

