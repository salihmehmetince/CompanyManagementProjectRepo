namespace CompanyProjectWindowsFormApp
{
    partial class FrmMeetingAddEditForm
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
            this.CLBEmployees = new System.Windows.Forms.CheckedListBox();
            this.LblEmployees = new System.Windows.Forms.Label();
            this.CLBCompanyOwners = new System.Windows.Forms.CheckedListBox();
            this.RTBDetail = new System.Windows.Forms.RichTextBox();
            this.DTPDate = new System.Windows.Forms.DateTimePicker();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.LblCompanyOwners = new System.Windows.Forms.Label();
            this.LblDetail = new System.Windows.Forms.Label();
            this.LblDate = new System.Windows.Forms.Label();
            this.TxtPlace = new System.Windows.Forms.TextBox();
            this.LblPlace = new System.Windows.Forms.Label();
            this.TxtPlot = new System.Windows.Forms.TextBox();
            this.LblPlot = new System.Windows.Forms.Label();
            this.PnlHeader = new System.Windows.Forms.Panel();
            this.LblDescription = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
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
            this.PnlMain.Size = new System.Drawing.Size(682, 953);
            this.PnlMain.TabIndex = 1;
            // 
            // PnlContent
            // 
            this.PnlContent.AutoScroll = true;
            this.PnlContent.Controls.Add(this.CLBEmployees);
            this.PnlContent.Controls.Add(this.LblEmployees);
            this.PnlContent.Controls.Add(this.CLBCompanyOwners);
            this.PnlContent.Controls.Add(this.RTBDetail);
            this.PnlContent.Controls.Add(this.DTPDate);
            this.PnlContent.Controls.Add(this.BtnCancel);
            this.PnlContent.Controls.Add(this.BtnSave);
            this.PnlContent.Controls.Add(this.LblCompanyOwners);
            this.PnlContent.Controls.Add(this.LblDetail);
            this.PnlContent.Controls.Add(this.LblDate);
            this.PnlContent.Controls.Add(this.TxtPlace);
            this.PnlContent.Controls.Add(this.LblPlace);
            this.PnlContent.Controls.Add(this.TxtPlot);
            this.PnlContent.Controls.Add(this.LblPlot);
            this.PnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContent.Location = new System.Drawing.Point(0, 80);
            this.PnlContent.Name = "PnlContent";
            this.PnlContent.Padding = new System.Windows.Forms.Padding(30, 25, 30, 20);
            this.PnlContent.Size = new System.Drawing.Size(682, 873);
            this.PnlContent.TabIndex = 1;
            // 
            // CLBEmployees
            // 
            this.CLBEmployees.BackColor = System.Drawing.Color.White;
            this.CLBEmployees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CLBEmployees.CheckOnClick = true;
            this.CLBEmployees.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CLBEmployees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.CLBEmployees.FormattingEnabled = true;
            this.CLBEmployees.HorizontalScrollbar = true;
            this.CLBEmployees.IntegralHeight = false;
            this.CLBEmployees.Location = new System.Drawing.Point(375, 625);
            this.CLBEmployees.Name = "CLBEmployees";
            this.CLBEmployees.Size = new System.Drawing.Size(300, 150);
            this.CLBEmployees.TabIndex = 46;
            // 
            // LblEmployees
            // 
            this.LblEmployees.AutoSize = true;
            this.LblEmployees.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblEmployees.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblEmployees.Location = new System.Drawing.Point(375, 600);
            this.LblEmployees.Name = "LblEmployees";
            this.LblEmployees.Size = new System.Drawing.Size(125, 20);
            this.LblEmployees.TabIndex = 45;
            this.LblEmployees.Text = "Company Owners";
            // 
            // CLBCompanyOwners
            // 
            this.CLBCompanyOwners.BackColor = System.Drawing.Color.White;
            this.CLBCompanyOwners.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CLBCompanyOwners.CheckOnClick = true;
            this.CLBCompanyOwners.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CLBCompanyOwners.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.CLBCompanyOwners.FormattingEnabled = true;
            this.CLBCompanyOwners.HorizontalScrollbar = true;
            this.CLBCompanyOwners.IntegralHeight = false;
            this.CLBCompanyOwners.Location = new System.Drawing.Point(30, 625);
            this.CLBCompanyOwners.Name = "CLBCompanyOwners";
            this.CLBCompanyOwners.Size = new System.Drawing.Size(300, 150);
            this.CLBCompanyOwners.TabIndex = 44;
            // 
            // RTBDetail
            // 
            this.RTBDetail.BackColor = System.Drawing.Color.White;
            this.RTBDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RTBDetail.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RTBDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.RTBDetail.Location = new System.Drawing.Point(30, 268);
            this.RTBDetail.MaxLength = 250;
            this.RTBDetail.Name = "RTBDetail";
            this.RTBDetail.Size = new System.Drawing.Size(570, 300);
            this.RTBDetail.TabIndex = 43;
            this.RTBDetail.Text = "";
            // 
            // DTPDate
            // 
            this.DTPDate.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.DTPDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPDate.Location = new System.Drawing.Point(30, 200);
            this.DTPDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.DTPDate.Name = "DTPDate";
            this.DTPDate.Size = new System.Drawing.Size(200, 30);
            this.DTPDate.TabIndex = 14;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(510, 800);
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
            this.BtnSave.Location = new System.Drawing.Point(390, 800);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(110, 35);
            this.BtnSave.TabIndex = 10;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // LblCompanyOwners
            // 
            this.LblCompanyOwners.AutoSize = true;
            this.LblCompanyOwners.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblCompanyOwners.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblCompanyOwners.Location = new System.Drawing.Point(30, 600);
            this.LblCompanyOwners.Name = "LblCompanyOwners";
            this.LblCompanyOwners.Size = new System.Drawing.Size(125, 20);
            this.LblCompanyOwners.TabIndex = 8;
            this.LblCompanyOwners.Text = "Company Owners";
            // 
            // LblDetail
            // 
            this.LblDetail.AutoSize = true;
            this.LblDetail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblDetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblDetail.Location = new System.Drawing.Point(31, 245);
            this.LblDetail.Name = "LblDetail";
            this.LblDetail.Size = new System.Drawing.Size(49, 20);
            this.LblDetail.TabIndex = 6;
            this.LblDetail.Text = "Detail";
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblDate.Location = new System.Drawing.Point(30, 175);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(41, 20);
            this.LblDate.TabIndex = 4;
            this.LblDate.Text = "Date";
            // 
            // TxtPlace
            // 
            this.TxtPlace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.TxtPlace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPlace.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtPlace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtPlace.Location = new System.Drawing.Point(30, 125);
            this.TxtPlace.Name = "TxtPlace";
            this.TxtPlace.Size = new System.Drawing.Size(570, 30);
            this.TxtPlace.TabIndex = 3;
            // 
            // LblPlace
            // 
            this.LblPlace.AutoSize = true;
            this.LblPlace.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblPlace.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblPlace.Location = new System.Drawing.Point(30, 100);
            this.LblPlace.Name = "LblPlace";
            this.LblPlace.Size = new System.Drawing.Size(44, 20);
            this.LblPlace.TabIndex = 2;
            this.LblPlace.Text = "Place";
            // 
            // TxtPlot
            // 
            this.TxtPlot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.TxtPlot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtPlot.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtPlot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtPlot.Location = new System.Drawing.Point(30, 50);
            this.TxtPlot.Name = "TxtPlot";
            this.TxtPlot.Size = new System.Drawing.Size(570, 30);
            this.TxtPlot.TabIndex = 1;
            // 
            // LblPlot
            // 
            this.LblPlot.AutoSize = true;
            this.LblPlot.BackColor = System.Drawing.Color.Transparent;
            this.LblPlot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblPlot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblPlot.Location = new System.Drawing.Point(30, 25);
            this.LblPlot.Name = "LblPlot";
            this.LblPlot.Size = new System.Drawing.Size(35, 20);
            this.LblPlot.TabIndex = 0;
            this.LblPlot.Text = "Plot";
            // 
            // PnlHeader
            // 
            this.PnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.PnlHeader.Controls.Add(this.LblDescription);
            this.PnlHeader.Controls.Add(this.LblTitle);
            this.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlHeader.Location = new System.Drawing.Point(0, 0);
            this.PnlHeader.Name = "PnlHeader";
            this.PnlHeader.Size = new System.Drawing.Size(682, 80);
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
            this.LblDescription.Size = new System.Drawing.Size(184, 20);
            this.LblDescription.TabIndex = 1;
            this.LblDescription.Text = "Enter meeting information";
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(25, 5);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(197, 41);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "New Meeting";
            // 
            // FrmMeetingAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(682, 953);
            this.Controls.Add(this.PnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMeetingAddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Meetings";
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
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label LblCompanyOwners;
        private System.Windows.Forms.Label LblDetail;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.TextBox TxtPlace;
        private System.Windows.Forms.Label LblPlace;
        private System.Windows.Forms.TextBox TxtPlot;
        private System.Windows.Forms.Label LblPlot;
        private System.Windows.Forms.Panel PnlHeader;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.DateTimePicker DTPDate;
        private System.Windows.Forms.RichTextBox RTBDetail;
        private System.Windows.Forms.CheckedListBox CLBCompanyOwners;
        private System.Windows.Forms.CheckedListBox CLBEmployees;
        private System.Windows.Forms.Label LblEmployees;
    }
}