namespace CompanyProjectWindowsFormApp
{
    partial class FrmCompanyOwnersForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PnlMain = new System.Windows.Forms.Panel();
            this.PnlFooter = new System.Windows.Forms.Panel();
            this.LblRecordCount = new System.Windows.Forms.Label();
            this.DgvCompanyOwners = new System.Windows.Forms.DataGridView();
            this.PnlToolbar = new System.Windows.Forms.Panel();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.PnlHeader = new System.Windows.Forms.Panel();
            this.LblDescription = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.PnlMain.SuspendLayout();
            this.PnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCompanyOwners)).BeginInit();
            this.PnlToolbar.SuspendLayout();
            this.PnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.PnlFooter);
            this.PnlMain.Controls.Add(this.DgvCompanyOwners);
            this.PnlMain.Controls.Add(this.PnlToolbar);
            this.PnlMain.Controls.Add(this.PnlHeader);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(1082, 603);
            this.PnlMain.TabIndex = 1;
            // 
            // PnlFooter
            // 
            this.PnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.PnlFooter.Controls.Add(this.LblRecordCount);
            this.PnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlFooter.Location = new System.Drawing.Point(0, 558);
            this.PnlFooter.Name = "PnlFooter";
            this.PnlFooter.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.PnlFooter.Size = new System.Drawing.Size(1082, 45);
            this.PnlFooter.TabIndex = 3;
            // 
            // LblRecordCount
            // 
            this.LblRecordCount.AutoSize = true;
            this.LblRecordCount.BackColor = System.Drawing.Color.Transparent;
            this.LblRecordCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblRecordCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.LblRecordCount.Location = new System.Drawing.Point(20, 14);
            this.LblRecordCount.Name = "LblRecordCount";
            this.LblRecordCount.Size = new System.Drawing.Size(93, 20);
            this.LblRecordCount.TabIndex = 0;
            this.LblRecordCount.Text = "0 companies";
            // 
            // DgvCompanyOwners
            // 
            this.DgvCompanyOwners.AllowUserToAddRows = false;
            this.DgvCompanyOwners.AllowUserToDeleteRows = false;
            this.DgvCompanyOwners.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.DgvCompanyOwners.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvCompanyOwners.BackgroundColor = System.Drawing.Color.White;
            this.DgvCompanyOwners.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvCompanyOwners.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvCompanyOwners.ColumnHeadersHeight = 40;
            this.DgvCompanyOwners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvCompanyOwners.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvCompanyOwners.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvCompanyOwners.EnableHeadersVisualStyles = false;
            this.DgvCompanyOwners.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.DgvCompanyOwners.Location = new System.Drawing.Point(0, 150);
            this.DgvCompanyOwners.MultiSelect = false;
            this.DgvCompanyOwners.Name = "DgvCompanyOwners";
            this.DgvCompanyOwners.ReadOnly = true;
            this.DgvCompanyOwners.RowHeadersVisible = false;
            this.DgvCompanyOwners.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.DgvCompanyOwners.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvCompanyOwners.RowTemplate.Height = 35;
            this.DgvCompanyOwners.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCompanyOwners.Size = new System.Drawing.Size(1082, 453);
            this.DgvCompanyOwners.TabIndex = 2;
            // 
            // PnlToolbar
            // 
            this.PnlToolbar.Controls.Add(this.BtnDelete);
            this.PnlToolbar.Controls.Add(this.BtnEdit);
            this.PnlToolbar.Controls.Add(this.BtnAdd);
            this.PnlToolbar.Controls.Add(this.TxtSearch);
            this.PnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlToolbar.Location = new System.Drawing.Point(0, 80);
            this.PnlToolbar.Name = "PnlToolbar";
            this.PnlToolbar.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);
            this.PnlToolbar.Size = new System.Drawing.Size(1082, 70);
            this.PnlToolbar.TabIndex = 1;
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.BtnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnDelete.ForeColor = System.Drawing.Color.White;
            this.BtnDelete.Location = new System.Drawing.Point(630, 17);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(90, 35);
            this.BtnDelete.TabIndex = 3;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.BtnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnEdit.ForeColor = System.Drawing.Color.White;
            this.BtnEdit.Location = new System.Drawing.Point(530, 17);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(90, 35);
            this.BtnEdit.TabIndex = 2;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(390, 17);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(130, 35);
            this.BtnAdd.TabIndex = 1;
            this.BtnAdd.Text = "New Owner";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // TxtSearch
            // 
            this.TxtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.TxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtSearch.Location = new System.Drawing.Point(20, 17);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(350, 30);
            this.TxtSearch.TabIndex = 0;
            this.TxtSearch.TextChanged += new System.EventHandler(this.TxtSearch_TextChanged);
            // 
            // PnlHeader
            // 
            this.PnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.PnlHeader.Controls.Add(this.LblDescription);
            this.PnlHeader.Controls.Add(this.LblTitle);
            this.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlHeader.Location = new System.Drawing.Point(0, 0);
            this.PnlHeader.Name = "PnlHeader";
            this.PnlHeader.Size = new System.Drawing.Size(1082, 80);
            this.PnlHeader.TabIndex = 0;
            // 
            // LblDescription
            // 
            this.LblDescription.AutoSize = true;
            this.LblDescription.BackColor = System.Drawing.Color.Transparent;
            this.LblDescription.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.LblDescription.Location = new System.Drawing.Point(27, 48);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(257, 20);
            this.LblDescription.TabIndex = 1;
            this.LblDescription.Text = "Manage company Owner information";
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(25, 15);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(255, 41);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "Company Owners";
            // 
            // FrmCompanyOwnersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1082, 603);
            this.Controls.Add(this.PnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCompanyOwnersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Company Owners";
            this.PnlMain.ResumeLayout(false);
            this.PnlFooter.ResumeLayout(false);
            this.PnlFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCompanyOwners)).EndInit();
            this.PnlToolbar.ResumeLayout(false);
            this.PnlToolbar.PerformLayout();
            this.PnlHeader.ResumeLayout(false);
            this.PnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Panel PnlFooter;
        private System.Windows.Forms.Label LblRecordCount;
        private System.Windows.Forms.DataGridView DgvCompanyOwners;
        private System.Windows.Forms.Panel PnlToolbar;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Panel PnlHeader;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.Label LblTitle;
    }
}