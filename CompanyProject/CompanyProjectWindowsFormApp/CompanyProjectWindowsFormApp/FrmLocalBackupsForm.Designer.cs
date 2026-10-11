namespace CompanyProjectWindowsFormApp
{
    partial class FrmLocalBackupsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PnlMain = new System.Windows.Forms.Panel();
            this.PnlFooter = new System.Windows.Forms.Panel();
            this.LblRecordCount = new System.Windows.Forms.Label();
            this.DgvLocalBackups = new System.Windows.Forms.DataGridView();
            this.PnlToolbar = new System.Windows.Forms.Panel();
            this.BtnRestore = new System.Windows.Forms.Button();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.PnlHeader = new System.Windows.Forms.Panel();
            this.LblDescription = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.PnlMain.SuspendLayout();
            this.PnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLocalBackups)).BeginInit();
            this.PnlToolbar.SuspendLayout();
            this.PnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.PnlFooter);
            this.PnlMain.Controls.Add(this.DgvLocalBackups);
            this.PnlMain.Controls.Add(this.PnlToolbar);
            this.PnlMain.Controls.Add(this.PnlHeader);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(1082, 603);
            this.PnlMain.TabIndex = 2;
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
            this.LblRecordCount.Size = new System.Drawing.Size(82, 20);
            this.LblRecordCount.TabIndex = 0;
            this.LblRecordCount.Text = "0 Meetings";
            // 
            // DgvLocalBackups
            // 
            this.DgvLocalBackups.AllowUserToAddRows = false;
            this.DgvLocalBackups.AllowUserToDeleteRows = false;
            this.DgvLocalBackups.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.DgvLocalBackups.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.DgvLocalBackups.BackgroundColor = System.Drawing.Color.White;
            this.DgvLocalBackups.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvLocalBackups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.DgvLocalBackups.ColumnHeadersHeight = 40;
            this.DgvLocalBackups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvLocalBackups.DefaultCellStyle = dataGridViewCellStyle11;
            this.DgvLocalBackups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvLocalBackups.EnableHeadersVisualStyles = false;
            this.DgvLocalBackups.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.DgvLocalBackups.Location = new System.Drawing.Point(0, 150);
            this.DgvLocalBackups.MultiSelect = false;
            this.DgvLocalBackups.Name = "DgvLocalBackups";
            this.DgvLocalBackups.ReadOnly = true;
            this.DgvLocalBackups.RowHeadersVisible = false;
            this.DgvLocalBackups.RowHeadersWidth = 51;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            this.DgvLocalBackups.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.DgvLocalBackups.RowTemplate.Height = 35;
            this.DgvLocalBackups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvLocalBackups.Size = new System.Drawing.Size(1082, 453);
            this.DgvLocalBackups.TabIndex = 2;
            // 
            // PnlToolbar
            // 
            this.PnlToolbar.Controls.Add(this.BtnRestore);
            this.PnlToolbar.Controls.Add(this.TxtSearch);
            this.PnlToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlToolbar.Location = new System.Drawing.Point(0, 80);
            this.PnlToolbar.Name = "PnlToolbar";
            this.PnlToolbar.Padding = new System.Windows.Forms.Padding(20, 15, 20, 10);
            this.PnlToolbar.Size = new System.Drawing.Size(1082, 70);
            this.PnlToolbar.TabIndex = 1;
            // 
            // BtnRestore
            // 
            this.BtnRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.BtnRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRestore.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnRestore.ForeColor = System.Drawing.Color.White;
            this.BtnRestore.Location = new System.Drawing.Point(376, 17);
            this.BtnRestore.Name = "BtnRestore";
            this.BtnRestore.Size = new System.Drawing.Size(129, 35);
            this.BtnRestore.TabIndex = 3;
            this.BtnRestore.Text = "Restore";
            this.BtnRestore.UseVisualStyleBackColor = false;
            this.BtnRestore.Click += new System.EventHandler(this.BtnRestore_Click);
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
            this.LblDescription.Size = new System.Drawing.Size(186, 20);
            this.LblDescription.TabIndex = 1;
            this.LblDescription.Text = "Restore your local backups";
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(25, 8);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(219, 41);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "Local Back-Ups";
            // 
            // FrmLocalBackupsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1082, 603);
            this.Controls.Add(this.PnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLocalBackupsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Back-Ups";
            this.PnlMain.ResumeLayout(false);
            this.PnlFooter.ResumeLayout(false);
            this.PnlFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvLocalBackups)).EndInit();
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
        private System.Windows.Forms.DataGridView DgvLocalBackups;
        private System.Windows.Forms.Panel PnlToolbar;
        private System.Windows.Forms.Button BtnRestore;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Panel PnlHeader;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.Label LblTitle;
    }
}