namespace CompanyProjectWindowsFormApp
{
    partial class FrmProductOrServiceAddEditForm
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
            this.BtnChooseImage = new System.Windows.Forms.Button();
            this.PBProductOrServiceImage = new System.Windows.Forms.PictureBox();
            this.CmbProductOrServiceType = new System.Windows.Forms.ComboBox();
            this.RBIsService = new System.Windows.Forms.RadioButton();
            this.RBIsProduct = new System.Windows.Forms.RadioButton();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.LblImage = new System.Windows.Forms.Label();
            this.LblType = new System.Windows.Forms.Label();
            this.LblProductOrService = new System.Windows.Forms.Label();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.LblName = new System.Windows.Forms.Label();
            this.PnlHeader = new System.Windows.Forms.Panel();
            this.LblDescription = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.PnlMain.SuspendLayout();
            this.PnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBProductOrServiceImage)).BeginInit();
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
            this.PnlMain.Size = new System.Drawing.Size(682, 553);
            this.PnlMain.TabIndex = 2;
            // 
            // PnlContent
            // 
            this.PnlContent.AutoScroll = true;
            this.PnlContent.Controls.Add(this.BtnChooseImage);
            this.PnlContent.Controls.Add(this.PBProductOrServiceImage);
            this.PnlContent.Controls.Add(this.CmbProductOrServiceType);
            this.PnlContent.Controls.Add(this.RBIsService);
            this.PnlContent.Controls.Add(this.RBIsProduct);
            this.PnlContent.Controls.Add(this.BtnCancel);
            this.PnlContent.Controls.Add(this.BtnSave);
            this.PnlContent.Controls.Add(this.LblImage);
            this.PnlContent.Controls.Add(this.LblType);
            this.PnlContent.Controls.Add(this.LblProductOrService);
            this.PnlContent.Controls.Add(this.TxtName);
            this.PnlContent.Controls.Add(this.LblName);
            this.PnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContent.Location = new System.Drawing.Point(0, 80);
            this.PnlContent.Name = "PnlContent";
            this.PnlContent.Padding = new System.Windows.Forms.Padding(30, 25, 30, 20);
            this.PnlContent.Size = new System.Drawing.Size(682, 473);
            this.PnlContent.TabIndex = 1;
            // 
            // BtnChooseImage
            // 
            this.BtnChooseImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.BtnChooseImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnChooseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnChooseImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnChooseImage.ForeColor = System.Drawing.Color.White;
            this.BtnChooseImage.Location = new System.Drawing.Point(165, 317);
            this.BtnChooseImage.Name = "BtnChooseImage";
            this.BtnChooseImage.Size = new System.Drawing.Size(119, 35);
            this.BtnChooseImage.TabIndex = 16;
            this.BtnChooseImage.Text = "Chosse Image";
            this.BtnChooseImage.UseVisualStyleBackColor = false;
            this.BtnChooseImage.Click += new System.EventHandler(this.BtnChooseImage_Click);
            // 
            // PBProductOrServiceImage
            // 
            this.PBProductOrServiceImage.BackColor = System.Drawing.Color.Transparent;
            this.PBProductOrServiceImage.Location = new System.Drawing.Point(30, 275);
            this.PBProductOrServiceImage.Name = "PBProductOrServiceImage";
            this.PBProductOrServiceImage.Size = new System.Drawing.Size(125, 125);
            this.PBProductOrServiceImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PBProductOrServiceImage.TabIndex = 15;
            this.PBProductOrServiceImage.TabStop = false;
            // 
            // CmbProductOrServiceType
            // 
            this.CmbProductOrServiceType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.CmbProductOrServiceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProductOrServiceType.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbProductOrServiceType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.CmbProductOrServiceType.FormattingEnabled = true;
            this.CmbProductOrServiceType.Location = new System.Drawing.Point(30, 200);
            this.CmbProductOrServiceType.Name = "CmbProductOrServiceType";
            this.CmbProductOrServiceType.Size = new System.Drawing.Size(275, 31);
            this.CmbProductOrServiceType.TabIndex = 14;
            // 
            // RBIsService
            // 
            this.RBIsService.AutoSize = true;
            this.RBIsService.BackColor = System.Drawing.Color.Transparent;
            this.RBIsService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RBIsService.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RBIsService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.RBIsService.Location = new System.Drawing.Point(139, 133);
            this.RBIsService.Name = "RBIsService";
            this.RBIsService.Size = new System.Drawing.Size(84, 27);
            this.RBIsService.TabIndex = 13;
            this.RBIsService.Text = "Service";
            this.RBIsService.UseVisualStyleBackColor = false;
            // 
            // RBIsProduct
            // 
            this.RBIsProduct.AutoSize = true;
            this.RBIsProduct.BackColor = System.Drawing.Color.Transparent;
            this.RBIsProduct.Checked = true;
            this.RBIsProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RBIsProduct.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RBIsProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.RBIsProduct.Location = new System.Drawing.Point(42, 133);
            this.RBIsProduct.Name = "RBIsProduct";
            this.RBIsProduct.Size = new System.Drawing.Size(91, 27);
            this.RBIsProduct.TabIndex = 12;
            this.RBIsProduct.TabStop = true;
            this.RBIsProduct.Text = "Product";
            this.RBIsProduct.UseVisualStyleBackColor = false;
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(525, 400);
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
            this.BtnSave.Location = new System.Drawing.Point(400, 400);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(110, 35);
            this.BtnSave.TabIndex = 10;
            this.BtnSave.Text = "Save";
            this.BtnSave.UseVisualStyleBackColor = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // LblImage
            // 
            this.LblImage.AutoSize = true;
            this.LblImage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblImage.Location = new System.Drawing.Point(31, 245);
            this.LblImage.Name = "LblImage";
            this.LblImage.Size = new System.Drawing.Size(51, 20);
            this.LblImage.TabIndex = 6;
            this.LblImage.Text = "Image";
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblType.Location = new System.Drawing.Point(30, 175);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(40, 20);
            this.LblType.TabIndex = 4;
            this.LblType.Text = "Type";
            // 
            // LblProductOrService
            // 
            this.LblProductOrService.AutoSize = true;
            this.LblProductOrService.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblProductOrService.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblProductOrService.Location = new System.Drawing.Point(30, 100);
            this.LblProductOrService.Name = "LblProductOrService";
            this.LblProductOrService.Size = new System.Drawing.Size(131, 20);
            this.LblProductOrService.TabIndex = 2;
            this.LblProductOrService.Text = "Product Or Service";
            // 
            // TxtName
            // 
            this.TxtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.TxtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtName.Location = new System.Drawing.Point(30, 50);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(570, 30);
            this.TxtName.TabIndex = 1;
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.BackColor = System.Drawing.Color.Transparent;
            this.LblName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblName.Location = new System.Drawing.Point(30, 25);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(49, 20);
            this.LblName.TabIndex = 0;
            this.LblName.Text = "Name";
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
            this.LblDescription.Size = new System.Drawing.Size(248, 20);
            this.LblDescription.TabIndex = 1;
            this.LblDescription.Text = "Enter product or service information";
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(25, 5);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(332, 41);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "New Product Or Service";
            // 
            // FrmProductOrServiceAddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(682, 553);
            this.Controls.Add(this.PnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProductOrServiceAddEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Products Or Services";
            this.PnlMain.ResumeLayout(false);
            this.PnlContent.ResumeLayout(false);
            this.PnlContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBProductOrServiceImage)).EndInit();
            this.PnlHeader.ResumeLayout(false);
            this.PnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Panel PnlContent;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Label LblImage;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.Label LblProductOrService;
        private System.Windows.Forms.TextBox TxtName;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Panel PnlHeader;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.RadioButton RBIsProduct;
        private System.Windows.Forms.RadioButton RBIsService;
        private System.Windows.Forms.ComboBox CmbProductOrServiceType;
        private System.Windows.Forms.PictureBox PBProductOrServiceImage;
        private System.Windows.Forms.Button BtnChooseImage;
    }
}