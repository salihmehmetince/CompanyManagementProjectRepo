namespace CompanyProjectWindowsFormApp
{
    partial class FrmMainForm
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
            this.PnlContent = new System.Windows.Forms.Panel();
            this.PnlLogo = new System.Windows.Forms.Panel();
            this.LblAppName = new System.Windows.Forms.Label();
            this.PnlMenu = new System.Windows.Forms.Panel();
            this.PnlUserInfo = new System.Windows.Forms.Panel();
            this.LblUserRole = new System.Windows.Forms.Label();
            this.LblUserName = new System.Windows.Forms.Label();
            this.PnlMenuButtons = new System.Windows.Forms.Panel();
            this.PnlLogo.SuspendLayout();
            this.PnlMenu.SuspendLayout();
            this.PnlUserInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlContent
            // 
            this.PnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContent.Location = new System.Drawing.Point(230, 0);
            this.PnlContent.Name = "PnlContent";
            this.PnlContent.Size = new System.Drawing.Size(952, 653);
            this.PnlContent.TabIndex = 1;
            // 
            // PnlLogo
            // 
            this.PnlLogo.Controls.Add(this.LblAppName);
            this.PnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlLogo.Location = new System.Drawing.Point(0, 0);
            this.PnlLogo.Name = "PnlLogo";
            this.PnlLogo.Size = new System.Drawing.Size(230, 90);
            this.PnlLogo.TabIndex = 0;
            // 
            // LblAppName
            // 
            this.LblAppName.BackColor = System.Drawing.Color.Transparent;
            this.LblAppName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblAppName.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblAppName.ForeColor = System.Drawing.Color.White;
            this.LblAppName.Location = new System.Drawing.Point(0, 0);
            this.LblAppName.Name = "LblAppName";
            this.LblAppName.Size = new System.Drawing.Size(230, 90);
            this.LblAppName.TabIndex = 0;
            this.LblAppName.Text = "Company Management";
            this.LblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlMenu
            // 
            this.PnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.PnlMenu.Controls.Add(this.PnlMenuButtons);
            this.PnlMenu.Controls.Add(this.PnlUserInfo);
            this.PnlMenu.Controls.Add(this.PnlLogo);
            this.PnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlMenu.Location = new System.Drawing.Point(0, 0);
            this.PnlMenu.Name = "PnlMenu";
            this.PnlMenu.Size = new System.Drawing.Size(230, 653);
            this.PnlMenu.TabIndex = 0;
            // 
            // PnlUserInfo
            // 
            this.PnlUserInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.PnlUserInfo.Controls.Add(this.LblUserRole);
            this.PnlUserInfo.Controls.Add(this.LblUserName);
            this.PnlUserInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlUserInfo.Location = new System.Drawing.Point(0, 90);
            this.PnlUserInfo.Name = "PnlUserInfo";
            this.PnlUserInfo.Size = new System.Drawing.Size(230, 80);
            this.PnlUserInfo.TabIndex = 0;
            // 
            // LblUserRole
            // 
            this.LblUserRole.BackColor = System.Drawing.Color.Transparent;
            this.LblUserRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblUserRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblUserRole.ForeColor = System.Drawing.Color.Gainsboro;
            this.LblUserRole.Location = new System.Drawing.Point(0, 38);
            this.LblUserRole.Name = "LblUserRole";
            this.LblUserRole.Size = new System.Drawing.Size(230, 42);
            this.LblUserRole.TabIndex = 0;
            this.LblUserRole.Text = "UserRole";
            this.LblUserRole.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LblUserName
            // 
            this.LblUserName.BackColor = System.Drawing.Color.Transparent;
            this.LblUserName.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblUserName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblUserName.ForeColor = System.Drawing.Color.White;
            this.LblUserName.Location = new System.Drawing.Point(0, 0);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.Size = new System.Drawing.Size(230, 38);
            this.LblUserName.TabIndex = 0;
            this.LblUserName.Text = "Kullanıcı Adı";
            this.LblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlMenuButtons
            // 
            this.PnlMenuButtons.AutoScroll = true;
            this.PnlMenuButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMenuButtons.Location = new System.Drawing.Point(0, 170);
            this.PnlMenuButtons.Name = "PnlMenuButtons";
            this.PnlMenuButtons.Size = new System.Drawing.Size(230, 483);
            this.PnlMenuButtons.TabIndex = 0;
            // 
            // FrmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.PnlContent);
            this.Controls.Add(this.PnlMenu);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "FrmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company Management";
            this.PnlLogo.ResumeLayout(false);
            this.PnlMenu.ResumeLayout(false);
            this.PnlUserInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlContent;
        private System.Windows.Forms.Panel PnlLogo;
        private System.Windows.Forms.Label LblAppName;
        private System.Windows.Forms.Panel PnlMenu;
        private System.Windows.Forms.Panel PnlUserInfo;
        private System.Windows.Forms.Label LblUserRole;
        private System.Windows.Forms.Label LblUserName;
        private System.Windows.Forms.Panel PnlMenuButtons;
    }
}