namespace CompanyManagement.BusinessLogic
{
    partial class FrmEmployeeBonusAddEditForm
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
            this.TxtAmount = new System.Windows.Forms.TextBox();
            this.LblAmount = new System.Windows.Forms.Label();
            this.CBAffectSalary = new System.Windows.Forms.CheckBox();
            this.RBRate = new System.Windows.Forms.RadioButton();
            this.RBAmount = new System.Windows.Forms.RadioButton();
            this.CmbEmployee = new System.Windows.Forms.ComboBox();
            this.LblEmployee = new System.Windows.Forms.Label();
            this.CmbCompany = new System.Windows.Forms.ComboBox();
            this.LblCompany = new System.Windows.Forms.Label();
            this.PnlHeader = new System.Windows.Forms.Panel();
            this.LblDescription = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.LblCurrentSalary = new System.Windows.Forms.Label();
            this.LblCurrentSalaryAmount = new System.Windows.Forms.Label();
            this.DTPDate = new System.Windows.Forms.DateTimePicker();
            this.LblDate = new System.Windows.Forms.Label();
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
            this.PnlMain.Size = new System.Drawing.Size(680, 550);
            this.PnlMain.TabIndex = 2;
            // 
            // PnlContent
            // 
            this.PnlContent.AutoScroll = true;
            this.PnlContent.Controls.Add(this.DTPDate);
            this.PnlContent.Controls.Add(this.LblDate);
            this.PnlContent.Controls.Add(this.LblCurrentSalaryAmount);
            this.PnlContent.Controls.Add(this.LblCurrentSalary);
            this.PnlContent.Controls.Add(this.BtnCancel);
            this.PnlContent.Controls.Add(this.BtnSave);
            this.PnlContent.Controls.Add(this.TxtAmount);
            this.PnlContent.Controls.Add(this.LblAmount);
            this.PnlContent.Controls.Add(this.CBAffectSalary);
            this.PnlContent.Controls.Add(this.RBRate);
            this.PnlContent.Controls.Add(this.RBAmount);
            this.PnlContent.Controls.Add(this.CmbEmployee);
            this.PnlContent.Controls.Add(this.LblEmployee);
            this.PnlContent.Controls.Add(this.CmbCompany);
            this.PnlContent.Controls.Add(this.LblCompany);
            this.PnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContent.Location = new System.Drawing.Point(0, 80);
            this.PnlContent.Name = "PnlContent";
            this.PnlContent.Padding = new System.Windows.Forms.Padding(30, 25, 30, 20);
            this.PnlContent.Size = new System.Drawing.Size(680, 470);
            this.PnlContent.TabIndex = 1;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(500, 370);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(110, 35);
            this.BtnCancel.TabIndex = 61;
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
            this.BtnSave.Location = new System.Drawing.Point(375, 370);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(110, 35);
            this.BtnSave.TabIndex = 60;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TxtAmount
            // 
            this.TxtAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.TxtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtAmount.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtAmount.Location = new System.Drawing.Point(30, 250);
            this.TxtAmount.Name = "TxtAmount";
            this.TxtAmount.Size = new System.Drawing.Size(570, 30);
            this.TxtAmount.TabIndex = 59;
            // 
            // LblAmount
            // 
            this.LblAmount.AutoSize = true;
            this.LblAmount.BackColor = System.Drawing.Color.Transparent;
            this.LblAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblAmount.Location = new System.Drawing.Point(30, 225);
            this.LblAmount.Name = "LblAmount";
            this.LblAmount.Size = new System.Drawing.Size(120, 20);
            this.LblAmount.TabIndex = 58;
            this.LblAmount.Text = "Amount/Rate(%)";
            // 
            // CBAffectSalary
            // 
            this.CBAffectSalary.AutoSize = true;
            this.CBAffectSalary.Location = new System.Drawing.Point(351, 175);
            this.CBAffectSalary.Name = "CBAffectSalary";
            this.CBAffectSalary.Size = new System.Drawing.Size(118, 20);
            this.CBAffectSalary.TabIndex = 57;
            this.CBAffectSalary.Text = "Change Salary";
            this.CBAffectSalary.UseVisualStyleBackColor = true;
            // 
            // RBRate
            // 
            this.RBRate.AutoSize = true;
            this.RBRate.Location = new System.Drawing.Point(200, 175);
            this.RBRate.Name = "RBRate";
            this.RBRate.Size = new System.Drawing.Size(57, 20);
            this.RBRate.TabIndex = 56;
            this.RBRate.Text = "Rate";
            this.RBRate.UseVisualStyleBackColor = true;
            // 
            // RBAmount
            // 
            this.RBAmount.AutoSize = true;
            this.RBAmount.Checked = true;
            this.RBAmount.Location = new System.Drawing.Point(30, 175);
            this.RBAmount.Name = "RBAmount";
            this.RBAmount.Size = new System.Drawing.Size(73, 20);
            this.RBAmount.TabIndex = 55;
            this.RBAmount.TabStop = true;
            this.RBAmount.Text = "Amount";
            this.RBAmount.UseVisualStyleBackColor = true;
            // 
            // CmbEmployee
            // 
            this.CmbEmployee.BackColor = System.Drawing.Color.White;
            this.CmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEmployee.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.CmbEmployee.FormattingEnabled = true;
            this.CmbEmployee.Location = new System.Drawing.Point(30, 125);
            this.CmbEmployee.Name = "CmbEmployee";
            this.CmbEmployee.Size = new System.Drawing.Size(570, 31);
            this.CmbEmployee.TabIndex = 54;
            this.CmbEmployee.SelectedIndexChanged += new System.EventHandler(this.CmbEmployee_SelectedIndexChanged);
            // 
            // LblEmployee
            // 
            this.LblEmployee.AutoSize = true;
            this.LblEmployee.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblEmployee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblEmployee.Location = new System.Drawing.Point(30, 100);
            this.LblEmployee.Name = "LblEmployee";
            this.LblEmployee.Size = new System.Drawing.Size(75, 20);
            this.LblEmployee.TabIndex = 53;
            this.LblEmployee.Text = "Employee";
            // 
            // CmbCompany
            // 
            this.CmbCompany.BackColor = System.Drawing.Color.White;
            this.CmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCompany.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.CmbCompany.FormattingEnabled = true;
            this.CmbCompany.Location = new System.Drawing.Point(30, 50);
            this.CmbCompany.Name = "CmbCompany";
            this.CmbCompany.Size = new System.Drawing.Size(570, 31);
            this.CmbCompany.TabIndex = 52;
            this.CmbCompany.SelectedIndexChanged += new System.EventHandler(this.CmbCompany_SelectedIndexChanged);
            // 
            // LblCompany
            // 
            this.LblCompany.AutoSize = true;
            this.LblCompany.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblCompany.Location = new System.Drawing.Point(30, 25);
            this.LblCompany.Name = "LblCompany";
            this.LblCompany.Size = new System.Drawing.Size(72, 20);
            this.LblCompany.TabIndex = 51;
            this.LblCompany.Text = "Company";
            // 
            // PnlHeader
            // 
            this.PnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.PnlHeader.Controls.Add(this.LblDescription);
            this.PnlHeader.Controls.Add(this.LblTitle);
            this.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlHeader.Location = new System.Drawing.Point(0, 0);
            this.PnlHeader.Name = "PnlHeader";
            this.PnlHeader.Size = new System.Drawing.Size(680, 80);
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
            this.LblDescription.Size = new System.Drawing.Size(239, 20);
            this.LblDescription.TabIndex = 1;
            this.LblDescription.Text = "Enter employee bonus information";
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(25, 5);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(336, 41);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "New Employee Bonuses";
            // 
            // LblCurrentSalary
            // 
            this.LblCurrentSalary.AutoSize = true;
            this.LblCurrentSalary.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblCurrentSalary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblCurrentSalary.Location = new System.Drawing.Point(496, 175);
            this.LblCurrentSalary.Name = "LblCurrentSalary";
            this.LblCurrentSalary.Size = new System.Drawing.Size(104, 20);
            this.LblCurrentSalary.TabIndex = 62;
            this.LblCurrentSalary.Text = "Current Salary:";
            // 
            // LblCurrentSalaryAmount
            // 
            this.LblCurrentSalaryAmount.AutoSize = true;
            this.LblCurrentSalaryAmount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblCurrentSalaryAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblCurrentSalaryAmount.Location = new System.Drawing.Point(606, 175);
            this.LblCurrentSalaryAmount.Name = "LblCurrentSalaryAmount";
            this.LblCurrentSalaryAmount.Size = new System.Drawing.Size(17, 20);
            this.LblCurrentSalaryAmount.TabIndex = 63;
            this.LblCurrentSalaryAmount.Text = "0";
            // 
            // DTPDate
            // 
            this.DTPDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DTPDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDate.Location = new System.Drawing.Point(30, 325);
            this.DTPDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.DTPDate.Name = "DTPDate";
            this.DTPDate.Size = new System.Drawing.Size(200, 30);
            this.DTPDate.TabIndex = 65;
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblDate.Location = new System.Drawing.Point(30, 300);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(41, 20);
            this.LblDate.TabIndex = 64;
            this.LblDate.Text = "Date";
            // 
            // FrmEmployeeBonusAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(680, 550);
            this.Controls.Add(this.PnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEmployeeBonusAddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Employee Bonuses";
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
        private System.Windows.Forms.Panel PnlHeader;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.ComboBox CmbEmployee;
        private System.Windows.Forms.Label LblEmployee;
        private System.Windows.Forms.ComboBox CmbCompany;
        private System.Windows.Forms.Label LblCompany;
        private System.Windows.Forms.RadioButton RBAmount;
        private System.Windows.Forms.RadioButton RBRate;
        private System.Windows.Forms.CheckBox CBAffectSalary;
        private System.Windows.Forms.TextBox TxtAmount;
        private System.Windows.Forms.Label LblAmount;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label LblCurrentSalaryAmount;
        private System.Windows.Forms.Label LblCurrentSalary;
        private System.Windows.Forms.DateTimePicker DTPDate;
        private System.Windows.Forms.Label LblDate;
    }
}