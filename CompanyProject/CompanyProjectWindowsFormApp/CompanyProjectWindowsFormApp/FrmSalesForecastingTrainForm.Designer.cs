namespace CompanyProjectWindowsFormApp
{
    partial class FrmSalesForecastingTrainForm
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
            this.GBAlgorithm = new System.Windows.Forms.GroupBox();
            this.TxtModelName = new System.Windows.Forms.TextBox();
            this.LblModelName = new System.Windows.Forms.Label();
            this.PnlHeader = new System.Windows.Forms.Panel();
            this.LblDescription = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.RdoSDCA = new System.Windows.Forms.RadioButton();
            this.RdoFastTree = new System.Windows.Forms.RadioButton();
            this.RdoFastForest = new System.Windows.Forms.RadioButton();
            this.GBFeatures = new System.Windows.Forms.GroupBox();
            this.ChkCompany = new System.Windows.Forms.CheckBox();
            this.LblSelectModelInfo = new System.Windows.Forms.Label();
            this.ChkProduct = new System.Windows.Forms.CheckBox();
            this.ChkYear = new System.Windows.Forms.CheckBox();
            this.ChkMonth = new System.Windows.Forms.CheckBox();
            this.ChkPreviousMonthSales = new System.Windows.Forms.CheckBox();
            this.ChkThreeMonthAverage = new System.Windows.Forms.CheckBox();
            this.LblTrainTestRatio = new System.Windows.Forms.Label();
            this.CmbTrainTestRatio = new System.Windows.Forms.ComboBox();
            this.BtnTrainModel = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.PnlMain.SuspendLayout();
            this.PnlContent.SuspendLayout();
            this.GBAlgorithm.SuspendLayout();
            this.PnlHeader.SuspendLayout();
            this.GBFeatures.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.PnlContent);
            this.PnlMain.Controls.Add(this.PnlHeader);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(680, 850);
            this.PnlMain.TabIndex = 2;
            // 
            // PnlContent
            // 
            this.PnlContent.AutoScroll = true;
            this.PnlContent.Controls.Add(this.CmbTrainTestRatio);
            this.PnlContent.Controls.Add(this.LblTrainTestRatio);
            this.PnlContent.Controls.Add(this.GBFeatures);
            this.PnlContent.Controls.Add(this.GBAlgorithm);
            this.PnlContent.Controls.Add(this.BtnCancel);
            this.PnlContent.Controls.Add(this.BtnTrainModel);
            this.PnlContent.Controls.Add(this.TxtModelName);
            this.PnlContent.Controls.Add(this.LblModelName);
            this.PnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContent.Location = new System.Drawing.Point(0, 80);
            this.PnlContent.Name = "PnlContent";
            this.PnlContent.Padding = new System.Windows.Forms.Padding(30, 25, 30, 20);
            this.PnlContent.Size = new System.Drawing.Size(680, 770);
            this.PnlContent.TabIndex = 1;
            // 
            // GBAlgorithm
            // 
            this.GBAlgorithm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.GBAlgorithm.Controls.Add(this.RdoFastForest);
            this.GBAlgorithm.Controls.Add(this.RdoFastTree);
            this.GBAlgorithm.Controls.Add(this.RdoSDCA);
            this.GBAlgorithm.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.GBAlgorithm.Location = new System.Drawing.Point(30, 100);
            this.GBAlgorithm.Name = "GBAlgorithm";
            this.GBAlgorithm.Size = new System.Drawing.Size(563, 206);
            this.GBAlgorithm.TabIndex = 12;
            this.GBAlgorithm.TabStop = false;
            this.GBAlgorithm.Text = "1. ALGORITHM SELECTION";
            // 
            // TxtModelName
            // 
            this.TxtModelName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.TxtModelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtModelName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtModelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.TxtModelName.Location = new System.Drawing.Point(30, 50);
            this.TxtModelName.Name = "TxtModelName";
            this.TxtModelName.Size = new System.Drawing.Size(570, 30);
            this.TxtModelName.TabIndex = 1;
            // 
            // LblModelName
            // 
            this.LblModelName.AutoSize = true;
            this.LblModelName.BackColor = System.Drawing.Color.Transparent;
            this.LblModelName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblModelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblModelName.Location = new System.Drawing.Point(30, 25);
            this.LblModelName.Name = "LblModelName";
            this.LblModelName.Size = new System.Drawing.Size(96, 20);
            this.LblModelName.TabIndex = 0;
            this.LblModelName.Text = "Model Name";
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
            this.LblDescription.Size = new System.Drawing.Size(319, 20);
            this.LblDescription.TabIndex = 1;
            this.LblDescription.Text = "Enter your sales forecasting model information";
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(25, 5);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(568, 41);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "SALES FORECASTING - MODEL TRAINING";
            // 
            // RdoSDCA
            // 
            this.RdoSDCA.AutoSize = true;
            this.RdoSDCA.BackColor = System.Drawing.Color.Transparent;
            this.RdoSDCA.Checked = true;
            this.RdoSDCA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RdoSDCA.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RdoSDCA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.RdoSDCA.Location = new System.Drawing.Point(6, 29);
            this.RdoSDCA.Name = "RdoSDCA";
            this.RdoSDCA.Size = new System.Drawing.Size(161, 27);
            this.RdoSDCA.TabIndex = 13;
            this.RdoSDCA.Text = "SDCA Regression";
            this.RdoSDCA.UseVisualStyleBackColor = false;
            // 
            // RdoFastTree
            // 
            this.RdoFastTree.AutoSize = true;
            this.RdoFastTree.BackColor = System.Drawing.Color.Transparent;
            this.RdoFastTree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RdoFastTree.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RdoFastTree.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.RdoFastTree.Location = new System.Drawing.Point(6, 62);
            this.RdoFastTree.Name = "RdoFastTree";
            this.RdoFastTree.Size = new System.Drawing.Size(179, 27);
            this.RdoFastTree.TabIndex = 14;
            this.RdoFastTree.Text = "FastTree Regression";
            this.RdoFastTree.UseVisualStyleBackColor = false;
            // 
            // RdoFastForest
            // 
            this.RdoFastForest.AutoSize = true;
            this.RdoFastForest.BackColor = System.Drawing.Color.Transparent;
            this.RdoFastForest.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RdoFastForest.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.RdoFastForest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.RdoFastForest.Location = new System.Drawing.Point(6, 95);
            this.RdoFastForest.Name = "RdoFastForest";
            this.RdoFastForest.Size = new System.Drawing.Size(193, 27);
            this.RdoFastForest.TabIndex = 15;
            this.RdoFastForest.Text = "FastForest Regression";
            this.RdoFastForest.UseVisualStyleBackColor = false;
            // 
            // GBFeatures
            // 
            this.GBFeatures.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.GBFeatures.Controls.Add(this.ChkThreeMonthAverage);
            this.GBFeatures.Controls.Add(this.ChkPreviousMonthSales);
            this.GBFeatures.Controls.Add(this.ChkMonth);
            this.GBFeatures.Controls.Add(this.ChkYear);
            this.GBFeatures.Controls.Add(this.ChkProduct);
            this.GBFeatures.Controls.Add(this.LblSelectModelInfo);
            this.GBFeatures.Controls.Add(this.ChkCompany);
            this.GBFeatures.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.GBFeatures.Location = new System.Drawing.Point(30, 312);
            this.GBFeatures.Name = "GBFeatures";
            this.GBFeatures.Size = new System.Drawing.Size(563, 239);
            this.GBFeatures.TabIndex = 16;
            this.GBFeatures.TabStop = false;
            this.GBFeatures.Text = "2. FEATURES";
            // 
            // ChkCompany
            // 
            this.ChkCompany.AutoSize = true;
            this.ChkCompany.Checked = true;
            this.ChkCompany.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkCompany.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkCompany.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkCompany.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.ChkCompany.Location = new System.Drawing.Point(6, 72);
            this.ChkCompany.Name = "ChkCompany";
            this.ChkCompany.Size = new System.Drawing.Size(85, 21);
            this.ChkCompany.TabIndex = 36;
            this.ChkCompany.Text = "Company";
            this.ChkCompany.UseVisualStyleBackColor = true;
            // 
            // LblSelectModelInfo
            // 
            this.LblSelectModelInfo.AutoSize = true;
            this.LblSelectModelInfo.BackColor = System.Drawing.Color.Transparent;
            this.LblSelectModelInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblSelectModelInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblSelectModelInfo.Location = new System.Drawing.Point(6, 35);
            this.LblSelectModelInfo.Name = "LblSelectModelInfo";
            this.LblSelectModelInfo.Size = new System.Drawing.Size(240, 20);
            this.LblSelectModelInfo.TabIndex = 17;
            this.LblSelectModelInfo.Text = " Select the data the model will use:";
            // 
            // ChkProduct
            // 
            this.ChkProduct.AutoSize = true;
            this.ChkProduct.Checked = true;
            this.ChkProduct.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkProduct.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.ChkProduct.Location = new System.Drawing.Point(6, 99);
            this.ChkProduct.Name = "ChkProduct";
            this.ChkProduct.Size = new System.Drawing.Size(75, 21);
            this.ChkProduct.TabIndex = 37;
            this.ChkProduct.Text = "Product";
            this.ChkProduct.UseVisualStyleBackColor = true;
            // 
            // ChkYear
            // 
            this.ChkYear.AutoSize = true;
            this.ChkYear.Checked = true;
            this.ChkYear.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkYear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkYear.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.ChkYear.Location = new System.Drawing.Point(6, 126);
            this.ChkYear.Name = "ChkYear";
            this.ChkYear.Size = new System.Drawing.Size(55, 21);
            this.ChkYear.TabIndex = 38;
            this.ChkYear.Text = "Year";
            this.ChkYear.UseVisualStyleBackColor = true;
            // 
            // ChkMonth
            // 
            this.ChkMonth.AutoSize = true;
            this.ChkMonth.Checked = true;
            this.ChkMonth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkMonth.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.ChkMonth.Location = new System.Drawing.Point(6, 153);
            this.ChkMonth.Name = "ChkMonth";
            this.ChkMonth.Size = new System.Drawing.Size(68, 21);
            this.ChkMonth.TabIndex = 39;
            this.ChkMonth.Text = "Month";
            this.ChkMonth.UseVisualStyleBackColor = true;
            // 
            // ChkPreviousMonthSales
            // 
            this.ChkPreviousMonthSales.AutoSize = true;
            this.ChkPreviousMonthSales.Checked = true;
            this.ChkPreviousMonthSales.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkPreviousMonthSales.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkPreviousMonthSales.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkPreviousMonthSales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.ChkPreviousMonthSales.Location = new System.Drawing.Point(6, 180);
            this.ChkPreviousMonthSales.Name = "ChkPreviousMonthSales";
            this.ChkPreviousMonthSales.Size = new System.Drawing.Size(162, 21);
            this.ChkPreviousMonthSales.TabIndex = 40;
            this.ChkPreviousMonthSales.Text = "Previous month\'s sales";
            this.ChkPreviousMonthSales.UseVisualStyleBackColor = true;
            // 
            // ChkThreeMonthAverage
            // 
            this.ChkThreeMonthAverage.AutoSize = true;
            this.ChkThreeMonthAverage.Checked = true;
            this.ChkThreeMonthAverage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkThreeMonthAverage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChkThreeMonthAverage.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ChkThreeMonthAverage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.ChkThreeMonthAverage.Location = new System.Drawing.Point(6, 207);
            this.ChkThreeMonthAverage.Name = "ChkThreeMonthAverage";
            this.ChkThreeMonthAverage.Size = new System.Drawing.Size(201, 21);
            this.ChkThreeMonthAverage.TabIndex = 41;
            this.ChkThreeMonthAverage.Text = "Average sales (last 3 months)";
            this.ChkThreeMonthAverage.UseVisualStyleBackColor = true;
            // 
            // LblTrainTestRatio
            // 
            this.LblTrainTestRatio.AutoSize = true;
            this.LblTrainTestRatio.BackColor = System.Drawing.Color.Transparent;
            this.LblTrainTestRatio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTrainTestRatio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblTrainTestRatio.Location = new System.Drawing.Point(30, 568);
            this.LblTrainTestRatio.Name = "LblTrainTestRatio";
            this.LblTrainTestRatio.Size = new System.Drawing.Size(110, 20);
            this.LblTrainTestRatio.TabIndex = 17;
            this.LblTrainTestRatio.Text = "Train Test Ratio";
            // 
            // CmbTrainTestRatio
            // 
            this.CmbTrainTestRatio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.CmbTrainTestRatio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTrainTestRatio.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbTrainTestRatio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.CmbTrainTestRatio.FormattingEnabled = true;
            this.CmbTrainTestRatio.Location = new System.Drawing.Point(30, 591);
            this.CmbTrainTestRatio.Name = "CmbTrainTestRatio";
            this.CmbTrainTestRatio.Size = new System.Drawing.Size(275, 31);
            this.CmbTrainTestRatio.TabIndex = 18;
            // 
            // BtnTrainModel
            // 
            this.BtnTrainModel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.BtnTrainModel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnTrainModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnTrainModel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTrainModel.ForeColor = System.Drawing.Color.White;
            this.BtnTrainModel.Location = new System.Drawing.Point(390, 660);
            this.BtnTrainModel.Name = "BtnTrainModel";
            this.BtnTrainModel.Size = new System.Drawing.Size(110, 35);
            this.BtnTrainModel.TabIndex = 10;
            this.BtnTrainModel.Text = "Train Model";
            this.BtnTrainModel.UseVisualStyleBackColor = false;
            this.BtnTrainModel.Click += new System.EventHandler(this.BtnTrainModel_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(510, 660);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(110, 35);
            this.BtnCancel.TabIndex = 11;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmSalesForecastingTrainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(680, 850);
            this.Controls.Add(this.PnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSalesForecastingTrainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sales Forecasting Train";
            this.PnlMain.ResumeLayout(false);
            this.PnlContent.ResumeLayout(false);
            this.PnlContent.PerformLayout();
            this.GBAlgorithm.ResumeLayout(false);
            this.GBAlgorithm.PerformLayout();
            this.PnlHeader.ResumeLayout(false);
            this.PnlHeader.PerformLayout();
            this.GBFeatures.ResumeLayout(false);
            this.GBFeatures.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PnlMain;
        private System.Windows.Forms.Panel PnlContent;
        private System.Windows.Forms.GroupBox GBAlgorithm;
        private System.Windows.Forms.TextBox TxtModelName;
        private System.Windows.Forms.Label LblModelName;
        private System.Windows.Forms.Panel PnlHeader;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.RadioButton RdoFastForest;
        private System.Windows.Forms.RadioButton RdoFastTree;
        private System.Windows.Forms.RadioButton RdoSDCA;
        private System.Windows.Forms.GroupBox GBFeatures;
        private System.Windows.Forms.CheckBox ChkCompany;
        private System.Windows.Forms.Label LblSelectModelInfo;
        private System.Windows.Forms.CheckBox ChkThreeMonthAverage;
        private System.Windows.Forms.CheckBox ChkPreviousMonthSales;
        private System.Windows.Forms.CheckBox ChkMonth;
        private System.Windows.Forms.CheckBox ChkYear;
        private System.Windows.Forms.CheckBox ChkProduct;
        private System.Windows.Forms.Label LblTrainTestRatio;
        private System.Windows.Forms.ComboBox CmbTrainTestRatio;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnTrainModel;
    }
}