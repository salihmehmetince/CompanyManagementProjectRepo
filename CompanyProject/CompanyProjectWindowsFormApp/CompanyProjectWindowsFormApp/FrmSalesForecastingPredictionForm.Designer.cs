namespace CompanyProjectWindowsFormApp
{
    partial class FrmSalesForecastingPredictionForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PnlMain = new System.Windows.Forms.Panel();
            this.PnlContent = new System.Windows.Forms.Panel();
            this.BtnExportPdf = new System.Windows.Forms.Button();
            this.BtnExportExcel = new System.Windows.Forms.Button();
            this.GBResults = new System.Windows.Forms.GroupBox();
            this.DgvPredictionResults = new System.Windows.Forms.DataGridView();
            this.GBPredictionData = new System.Windows.Forms.GroupBox();
            this.BtnRunForecast = new System.Windows.Forms.Button();
            this.BtnRemoveRow = new System.Windows.Forms.Button();
            this.BtnAddRow = new System.Windows.Forms.Button();
            this.DgvPredictionData = new System.Windows.Forms.DataGridView();
            this.GBModel = new System.Windows.Forms.GroupBox();
            this.LblModelNameLabel = new System.Windows.Forms.Label();
            this.LblAlgorithm = new System.Windows.Forms.Label();
            this.LblModelName = new System.Windows.Forms.Label();
            this.LblAlgorithNameLabel = new System.Windows.Forms.Label();
            this.PnlHeader = new System.Windows.Forms.Panel();
            this.LblDescription = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.PnlMain.SuspendLayout();
            this.PnlContent.SuspendLayout();
            this.GBResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPredictionResults)).BeginInit();
            this.GBPredictionData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPredictionData)).BeginInit();
            this.GBModel.SuspendLayout();
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
            this.PnlMain.Size = new System.Drawing.Size(1200, 1102);
            this.PnlMain.TabIndex = 2;
            // 
            // PnlContent
            // 
            this.PnlContent.AutoScroll = true;
            this.PnlContent.Controls.Add(this.BtnCancel);
            this.PnlContent.Controls.Add(this.BtnExportPdf);
            this.PnlContent.Controls.Add(this.BtnExportExcel);
            this.PnlContent.Controls.Add(this.GBResults);
            this.PnlContent.Controls.Add(this.GBPredictionData);
            this.PnlContent.Controls.Add(this.GBModel);
            this.PnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContent.Location = new System.Drawing.Point(0, 80);
            this.PnlContent.Name = "PnlContent";
            this.PnlContent.Padding = new System.Windows.Forms.Padding(30, 25, 30, 20);
            this.PnlContent.Size = new System.Drawing.Size(1200, 1022);
            this.PnlContent.TabIndex = 1;
            // 
            // BtnExportPdf
            // 
            this.BtnExportPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.BtnExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExportPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExportPdf.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnExportPdf.ForeColor = System.Drawing.Color.White;
            this.BtnExportPdf.Location = new System.Drawing.Point(412, 935);
            this.BtnExportPdf.Name = "BtnExportPdf";
            this.BtnExportPdf.Size = new System.Drawing.Size(200, 35);
            this.BtnExportPdf.TabIndex = 17;
            this.BtnExportPdf.Text = "Export to PDF";
            this.BtnExportPdf.UseVisualStyleBackColor = false;
            this.BtnExportPdf.Click += new System.EventHandler(this.BtnExportPdf_Click);
            // 
            // BtnExportExcel
            // 
            this.BtnExportExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.BtnExportExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnExportExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnExportExcel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnExportExcel.ForeColor = System.Drawing.Color.White;
            this.BtnExportExcel.Location = new System.Drawing.Point(12, 935);
            this.BtnExportExcel.Name = "BtnExportExcel";
            this.BtnExportExcel.Size = new System.Drawing.Size(200, 35);
            this.BtnExportExcel.TabIndex = 16;
            this.BtnExportExcel.Text = "Export to Excel";
            this.BtnExportExcel.UseVisualStyleBackColor = false;
            this.BtnExportExcel.Click += new System.EventHandler(this.BtnExportExcel_Click);
            // 
            // GBResults
            // 
            this.GBResults.Controls.Add(this.DgvPredictionResults);
            this.GBResults.Location = new System.Drawing.Point(12, 510);
            this.GBResults.Name = "GBResults";
            this.GBResults.Size = new System.Drawing.Size(1176, 376);
            this.GBResults.TabIndex = 15;
            this.GBResults.TabStop = false;
            this.GBResults.Text = "Results";
            // 
            // DgvPredictionResults
            // 
            this.DgvPredictionResults.AllowUserToAddRows = false;
            this.DgvPredictionResults.AllowUserToDeleteRows = false;
            this.DgvPredictionResults.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.DgvPredictionResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvPredictionResults.BackgroundColor = System.Drawing.Color.White;
            this.DgvPredictionResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPredictionResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvPredictionResults.ColumnHeadersHeight = 40;
            this.DgvPredictionResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvPredictionResults.DefaultCellStyle = dataGridViewCellStyle3;
            this.DgvPredictionResults.EnableHeadersVisualStyles = false;
            this.DgvPredictionResults.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.DgvPredictionResults.Location = new System.Drawing.Point(21, 21);
            this.DgvPredictionResults.MultiSelect = false;
            this.DgvPredictionResults.Name = "DgvPredictionResults";
            this.DgvPredictionResults.ReadOnly = true;
            this.DgvPredictionResults.RowHeadersVisible = false;
            this.DgvPredictionResults.RowHeadersWidth = 51;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.DgvPredictionResults.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.DgvPredictionResults.RowTemplate.Height = 35;
            this.DgvPredictionResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPredictionResults.Size = new System.Drawing.Size(1134, 296);
            this.DgvPredictionResults.TabIndex = 3;
            // 
            // GBPredictionData
            // 
            this.GBPredictionData.Controls.Add(this.BtnRunForecast);
            this.GBPredictionData.Controls.Add(this.BtnRemoveRow);
            this.GBPredictionData.Controls.Add(this.BtnAddRow);
            this.GBPredictionData.Controls.Add(this.DgvPredictionData);
            this.GBPredictionData.Location = new System.Drawing.Point(12, 128);
            this.GBPredictionData.Name = "GBPredictionData";
            this.GBPredictionData.Size = new System.Drawing.Size(1176, 376);
            this.GBPredictionData.TabIndex = 6;
            this.GBPredictionData.TabStop = false;
            this.GBPredictionData.Text = "Prediction Data";
            // 
            // BtnRunForecast
            // 
            this.BtnRunForecast.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.BtnRunForecast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRunForecast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRunForecast.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnRunForecast.ForeColor = System.Drawing.Color.White;
            this.BtnRunForecast.Location = new System.Drawing.Point(1013, 323);
            this.BtnRunForecast.Name = "BtnRunForecast";
            this.BtnRunForecast.Size = new System.Drawing.Size(110, 35);
            this.BtnRunForecast.TabIndex = 14;
            this.BtnRunForecast.Text = "Run Forecast";
            this.BtnRunForecast.UseVisualStyleBackColor = false;
            this.BtnRunForecast.Click += new System.EventHandler(this.BtnRunForecast_Click);
            // 
            // BtnRemoveRow
            // 
            this.BtnRemoveRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.BtnRemoveRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnRemoveRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRemoveRow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnRemoveRow.ForeColor = System.Drawing.Color.White;
            this.BtnRemoveRow.Location = new System.Drawing.Point(813, 323);
            this.BtnRemoveRow.Name = "BtnRemoveRow";
            this.BtnRemoveRow.Size = new System.Drawing.Size(110, 35);
            this.BtnRemoveRow.TabIndex = 13;
            this.BtnRemoveRow.Text = "Remove Row";
            this.BtnRemoveRow.UseVisualStyleBackColor = false;
            this.BtnRemoveRow.Click += new System.EventHandler(this.BtnRemoveRow_Click);
            // 
            // BtnAddRow
            // 
            this.BtnAddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.BtnAddRow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAddRow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAddRow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnAddRow.ForeColor = System.Drawing.Color.White;
            this.BtnAddRow.Location = new System.Drawing.Point(697, 323);
            this.BtnAddRow.Name = "BtnAddRow";
            this.BtnAddRow.Size = new System.Drawing.Size(110, 35);
            this.BtnAddRow.TabIndex = 12;
            this.BtnAddRow.Text = "Add Row";
            this.BtnAddRow.UseVisualStyleBackColor = false;
            this.BtnAddRow.Click += new System.EventHandler(this.BtnAddRow_Click);
            // 
            // DgvPredictionData
            // 
            this.DgvPredictionData.AllowUserToAddRows = false;
            this.DgvPredictionData.AllowUserToDeleteRows = false;
            this.DgvPredictionData.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.DgvPredictionData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.DgvPredictionData.BackgroundColor = System.Drawing.Color.White;
            this.DgvPredictionData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvPredictionData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.DgvPredictionData.ColumnHeadersHeight = 40;
            this.DgvPredictionData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvPredictionData.DefaultCellStyle = dataGridViewCellStyle7;
            this.DgvPredictionData.EnableHeadersVisualStyles = false;
            this.DgvPredictionData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.DgvPredictionData.Location = new System.Drawing.Point(21, 21);
            this.DgvPredictionData.MultiSelect = false;
            this.DgvPredictionData.Name = "DgvPredictionData";
            this.DgvPredictionData.RowHeadersVisible = false;
            this.DgvPredictionData.RowHeadersWidth = 51;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            this.DgvPredictionData.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.DgvPredictionData.RowTemplate.Height = 35;
            this.DgvPredictionData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvPredictionData.Size = new System.Drawing.Size(1134, 296);
            this.DgvPredictionData.TabIndex = 3;
            // 
            // GBModel
            // 
            this.GBModel.Controls.Add(this.LblModelNameLabel);
            this.GBModel.Controls.Add(this.LblAlgorithm);
            this.GBModel.Controls.Add(this.LblModelName);
            this.GBModel.Controls.Add(this.LblAlgorithNameLabel);
            this.GBModel.Location = new System.Drawing.Point(12, 6);
            this.GBModel.Name = "GBModel";
            this.GBModel.Size = new System.Drawing.Size(1176, 116);
            this.GBModel.TabIndex = 5;
            this.GBModel.TabStop = false;
            this.GBModel.Text = "Selected Model";
            // 
            // LblModelNameLabel
            // 
            this.LblModelNameLabel.AutoSize = true;
            this.LblModelNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.LblModelNameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblModelNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblModelNameLabel.Location = new System.Drawing.Point(420, 18);
            this.LblModelNameLabel.Name = "LblModelNameLabel";
            this.LblModelNameLabel.Size = new System.Drawing.Size(99, 20);
            this.LblModelNameLabel.TabIndex = 1;
            this.LblModelNameLabel.Text = "Model Name:";
            // 
            // LblAlgorithm
            // 
            this.LblAlgorithm.AutoSize = true;
            this.LblAlgorithm.BackColor = System.Drawing.Color.Transparent;
            this.LblAlgorithm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblAlgorithm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblAlgorithm.Location = new System.Drawing.Point(525, 49);
            this.LblAlgorithm.Name = "LblAlgorithm";
            this.LblAlgorithm.Size = new System.Drawing.Size(45, 20);
            this.LblAlgorithm.TabIndex = 4;
            this.LblAlgorithm.Text = "None";
            // 
            // LblModelName
            // 
            this.LblModelName.AutoSize = true;
            this.LblModelName.BackColor = System.Drawing.Color.Transparent;
            this.LblModelName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblModelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblModelName.Location = new System.Drawing.Point(525, 18);
            this.LblModelName.Name = "LblModelName";
            this.LblModelName.Size = new System.Drawing.Size(45, 20);
            this.LblModelName.TabIndex = 2;
            this.LblModelName.Text = "None";
            // 
            // LblAlgorithNameLabel
            // 
            this.LblAlgorithNameLabel.AutoSize = true;
            this.LblAlgorithNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.LblAlgorithNameLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblAlgorithNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.LblAlgorithNameLabel.Location = new System.Drawing.Point(440, 49);
            this.LblAlgorithNameLabel.Name = "LblAlgorithNameLabel";
            this.LblAlgorithNameLabel.Size = new System.Drawing.Size(79, 20);
            this.LblAlgorithNameLabel.TabIndex = 3;
            this.LblAlgorithNameLabel.Text = "Algorithm:";
            // 
            // PnlHeader
            // 
            this.PnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.PnlHeader.Controls.Add(this.LblDescription);
            this.PnlHeader.Controls.Add(this.LblTitle);
            this.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlHeader.Location = new System.Drawing.Point(0, 0);
            this.PnlHeader.Name = "PnlHeader";
            this.PnlHeader.Size = new System.Drawing.Size(1200, 80);
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
            this.LblDescription.Size = new System.Drawing.Size(197, 20);
            this.LblDescription.TabIndex = 1;
            this.LblDescription.Text = "Enter prediction information";
            // 
            // LblTitle
            // 
            this.LblTitle.AutoSize = true;
            this.LblTitle.BackColor = System.Drawing.Color.Transparent;
            this.LblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(25, 5);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(388, 41);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "Sales Forecasting Prediction";
            // 
            // BtnCancel
            // 
            this.BtnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.BtnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(1025, 935);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(110, 35);
            this.BtnCancel.TabIndex = 18;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmSalesForecastingPredictionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 1102);
            this.Controls.Add(this.PnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSalesForecastingPredictionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Sales Forecasting Prediction";
            this.PnlMain.ResumeLayout(false);
            this.PnlContent.ResumeLayout(false);
            this.GBResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPredictionResults)).EndInit();
            this.GBPredictionData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPredictionData)).EndInit();
            this.GBModel.ResumeLayout(false);
            this.GBModel.PerformLayout();
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
        private System.Windows.Forms.Label LblAlgorithm;
        private System.Windows.Forms.Label LblAlgorithNameLabel;
        private System.Windows.Forms.Label LblModelName;
        private System.Windows.Forms.Label LblModelNameLabel;
        private System.Windows.Forms.GroupBox GBPredictionData;
        private System.Windows.Forms.GroupBox GBModel;
        private System.Windows.Forms.DataGridView DgvPredictionData;
        private System.Windows.Forms.GroupBox GBResults;
        private System.Windows.Forms.DataGridView DgvPredictionResults;
        private System.Windows.Forms.Button BtnRunForecast;
        private System.Windows.Forms.Button BtnRemoveRow;
        private System.Windows.Forms.Button BtnAddRow;
        private System.Windows.Forms.Button BtnExportPdf;
        private System.Windows.Forms.Button BtnExportExcel;
        private System.Windows.Forms.Button BtnCancel;
    }
}