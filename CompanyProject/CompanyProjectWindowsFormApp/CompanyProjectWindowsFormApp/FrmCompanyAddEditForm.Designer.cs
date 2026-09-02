namespace CompanyProjectWindowsFormApp
{
    partial class FrmCompanyAddEditForm
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
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.CmbCompanyType = new System.Windows.Forms.ComboBox();
            this.LblCompanyType = new System.Windows.Forms.Label();
            this.TxtCompanyEmail = new System.Windows.Forms.TextBox();
            this.LblCompanyEmail = new System.Windows.Forms.Label();
            this.LblCompanyTelephoneNumber = new System.Windows.Forms.Label();
            this.TxtCompanyAddress = new System.Windows.Forms.TextBox();
            this.LblCompanyAddress = new System.Windows.Forms.Label();
            this.TxtCompanyName = new System.Windows.Forms.TextBox();
            this.LblCompanyName = new System.Windows.Forms.Label();
            this.PnlHeader = new System.Windows.Forms.Panel();
            this.LblDescription = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.MTBTelephoneNumber = new System.Windows.Forms.MaskedTextBox();
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
            this.PnlMain.Size = new System.Drawing.Size(650, 500);
            this.PnlMain.TabIndex = 0;
            // 
            // PnlContent
            // 
            this.PnlContent.Controls.Add(this.MTBTelephoneNumber);
            this.PnlContent.Controls.Add(this.BtnCancel);
            this.PnlContent.Controls.Add(this.BtnSave);
            this.PnlContent.Controls.Add(this.CmbCompanyType);
            this.PnlContent.Controls.Add(this.LblCompanyType);
            this.PnlContent.Controls.Add(this.TxtCompanyEmail);
            this.PnlContent.Controls.Add(this.LblCompanyEmail);
            this.PnlContent.Controls.Add(this.LblCompanyTelephoneNumber);
            this.PnlContent.Controls.Add(this.TxtCompanyAddress);
            this.PnlContent.Controls.Add(this.LblCompanyAddress);
            this.PnlContent.Controls.Add(this.TxtCompanyName);
            this.PnlContent.Controls.Add(this.LblCompanyName);
            this.PnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContent.Location = new System.Drawing.Point(0, 80);
            this.PnlContent.Name = "PnlContent";
            this.PnlContent.Padding = new System.Windows.Forms.Padding(30, 25, 30, 20);
            this.PnlContent.Size = new System.Drawing.Size(650, 420);
            this.PnlContent.TabIndex = 1;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(510, 340);
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
            this.BtnSave.Location = new System.Drawing.Point(390, 340);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(110, 35);
            this.BtnSave.TabIndex = 10;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // CmbCompanyType
            // 
            this.CmbCompanyType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.CmbCompanyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCompanyType.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbCompanyType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.CmbCompanyType.FormattingEnabled = true;
            this.CmbCompanyType.Location = new System.Drawing.Point(30, 350);
            this.CmbCompanyType.Name = "CmbCompanyType";
            this.CmbCompanyType.Size = new System.Drawing.Size(275, 31);
            this.CmbCompanyType.TabIndex = 9;
            // 
            // LblCompanyType
            // 
            this.LblCompanyType.AutoSize = true;
            this.LblCompanyType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblCompanyType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblCompanyType.Location = new System.Drawing.Point(30, 315);
            this.LblCompanyType.Name = "LblCompanyType";
            this.LblCompanyType.Size = new System.Drawing.Size(107, 20);
            this.LblCompanyType.TabIndex = 8;
            this.LblCompanyType.Text = "Company Type";
            // 
            // TxtCompanyEmail
            // 
            this.TxtCompanyEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.TxtCompanyEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCompanyEmail.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtCompanyEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtCompanyEmail.Location = new System.Drawing.Point(30, 275);
            this.TxtCompanyEmail.Name = "TxtCompanyEmail";
            this.TxtCompanyEmail.Size = new System.Drawing.Size(570, 30);
            this.TxtCompanyEmail.TabIndex = 7;
            // 
            // LblCompanyEmail
            // 
            this.LblCompanyEmail.AutoSize = true;
            this.LblCompanyEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblCompanyEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblCompanyEmail.Location = new System.Drawing.Point(31, 245);
            this.LblCompanyEmail.Name = "LblCompanyEmail";
            this.LblCompanyEmail.Size = new System.Drawing.Size(46, 20);
            this.LblCompanyEmail.TabIndex = 6;
            this.LblCompanyEmail.Text = "Email";
            // 
            // LblCompanyTelephoneNumber
            // 
            this.LblCompanyTelephoneNumber.AutoSize = true;
            this.LblCompanyTelephoneNumber.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblCompanyTelephoneNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblCompanyTelephoneNumber.Location = new System.Drawing.Point(30, 175);
            this.LblCompanyTelephoneNumber.Name = "LblCompanyTelephoneNumber";
            this.LblCompanyTelephoneNumber.Size = new System.Drawing.Size(78, 20);
            this.LblCompanyTelephoneNumber.TabIndex = 4;
            this.LblCompanyTelephoneNumber.Text = "Telephone";
            // 
            // TxtCompanyAddress
            // 
            this.TxtCompanyAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.TxtCompanyAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCompanyAddress.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtCompanyAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtCompanyAddress.Location = new System.Drawing.Point(30, 125);
            this.TxtCompanyAddress.Name = "TxtCompanyAddress";
            this.TxtCompanyAddress.Size = new System.Drawing.Size(570, 30);
            this.TxtCompanyAddress.TabIndex = 3;
            // 
            // LblCompanyAddress
            // 
            this.LblCompanyAddress.AutoSize = true;
            this.LblCompanyAddress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblCompanyAddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblCompanyAddress.Location = new System.Drawing.Point(30, 100);
            this.LblCompanyAddress.Name = "LblCompanyAddress";
            this.LblCompanyAddress.Size = new System.Drawing.Size(62, 20);
            this.LblCompanyAddress.TabIndex = 2;
            this.LblCompanyAddress.Text = "Address";
            // 
            // TxtCompanyName
            // 
            this.TxtCompanyName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.TxtCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtCompanyName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtCompanyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtCompanyName.Location = new System.Drawing.Point(30, 50);
            this.TxtCompanyName.Name = "TxtCompanyName";
            this.TxtCompanyName.Size = new System.Drawing.Size(570, 30);
            this.TxtCompanyName.TabIndex = 1;
            // 
            // LblCompanyName
            // 
            this.LblCompanyName.AutoSize = true;
            this.LblCompanyName.BackColor = System.Drawing.Color.Transparent;
            this.LblCompanyName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblCompanyName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblCompanyName.Location = new System.Drawing.Point(30, 25);
            this.LblCompanyName.Name = "LblCompanyName";
            this.LblCompanyName.Size = new System.Drawing.Size(116, 20);
            this.LblCompanyName.TabIndex = 0;
            this.LblCompanyName.Text = "Company Name";
            // 
            // PnlHeader
            // 
            this.PnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.PnlHeader.Controls.Add(this.LblDescription);
            this.PnlHeader.Controls.Add(this.LblTitle);
            this.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlHeader.Location = new System.Drawing.Point(0, 0);
            this.PnlHeader.Name = "PnlHeader";
            this.PnlHeader.Size = new System.Drawing.Size(650, 80);
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
            this.LblDescription.Size = new System.Drawing.Size(190, 20);
            this.LblDescription.TabIndex = 1;
            this.LblDescription.Text = "Enter company information";
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(25, 15);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(214, 41);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "New Company";
            // 
            // MTBTelephoneNumber
            // 
            this.MTBTelephoneNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.MTBTelephoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MTBTelephoneNumber.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.MTBTelephoneNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.MTBTelephoneNumber.Location = new System.Drawing.Point(30, 200);
            this.MTBTelephoneNumber.Mask = "(999) 000-0000";
            this.MTBTelephoneNumber.Name = "MTBTelephoneNumber";
            this.MTBTelephoneNumber.Size = new System.Drawing.Size(275, 30);
            this.MTBTelephoneNumber.TabIndex = 12;
            this.MTBTelephoneNumber.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // FrmCompanyAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(650, 500);
            this.Controls.Add(this.PnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCompanyAddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company";
            this.PnlMain.ResumeLayout(false);
            this.PnlContent.ResumeLayout(false);
            this.PnlContent.PerformLayout();
            this.PnlHeader.ResumeLayout(false);
            this.PnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Panel PnlHeader;
        private System.Windows.Forms.Panel PnlContent;
        private System.Windows.Forms.TextBox TxtCompanyName;
        private System.Windows.Forms.Label LblCompanyName;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.TextBox TxtCompanyEmail;
        private System.Windows.Forms.Label LblCompanyEmail;
        private System.Windows.Forms.Label LblCompanyTelephoneNumber;
        private System.Windows.Forms.TextBox TxtCompanyAddress;
        private System.Windows.Forms.Label LblCompanyAddress;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.ComboBox CmbCompanyType;
        private System.Windows.Forms.Label LblCompanyType;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.MaskedTextBox MTBTelephoneNumber;
    }
}