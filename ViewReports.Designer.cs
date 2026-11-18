namespace SAMS_Project
{
    partial class ViewReports
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
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.dtpFilterDate = new System.Windows.Forms.DateTimePicker();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblTotalStudents = new System.Windows.Forms.Label();
            this.lblPresentCount = new System.Windows.Forms.Label();
            this.lblAbsentCount = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFilters
            // 
            this.pnlFilters.Controls.Add(this.btnSearch);
            this.pnlFilters.Controls.Add(this.cmbClass);
            this.pnlFilters.Controls.Add(this.dtpFilterDate);
            this.pnlFilters.Controls.Add(this.lblTitle);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 0);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(932, 150);
            this.pnlFilters.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(746, 95);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(155, 38);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Generate Report";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbClass
            // 
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Items.AddRange(new object[] {
            "Admin",
            "Student",
            "Parent"});
            this.cmbClass.Location = new System.Drawing.Point(720, 54);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(200, 24);
            this.cmbClass.TabIndex = 2;
            // 
            // dtpFilterDate
            // 
            this.dtpFilterDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFilterDate.Location = new System.Drawing.Point(720, 12);
            this.dtpFilterDate.Name = "dtpFilterDate";
            this.dtpFilterDate.Size = new System.Drawing.Size(200, 22);
            this.dtpFilterDate.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(289, 29);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(297, 36);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Attendance Reports";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // dgvReports
            // 
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReports.Location = new System.Drawing.Point(0, 156);
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.RowHeadersWidth = 51;
            this.dgvReports.RowTemplate.Height = 24;
            this.dgvReports.Size = new System.Drawing.Size(932, 364);
            this.dgvReports.TabIndex = 1;
            this.dgvReports.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReports_CellContentClick);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(12, 555);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(388, 71);
            this.btnExport.TabIndex = 2;
            this.btnExport.Text = "Export to PDF/Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblTotalStudents
            // 
            this.lblTotalStudents.AutoSize = true;
            this.lblTotalStudents.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalStudents.Location = new System.Drawing.Point(457, 546);
            this.lblTotalStudents.Name = "lblTotalStudents";
            this.lblTotalStudents.Size = new System.Drawing.Size(164, 22);
            this.lblTotalStudents.TabIndex = 3;
            this.lblTotalStudents.Text = "Total Students: 0";
            // 
            // lblPresentCount
            // 
            this.lblPresentCount.AutoSize = true;
            this.lblPresentCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresentCount.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblPresentCount.Location = new System.Drawing.Point(585, 583);
            this.lblPresentCount.Name = "lblPresentCount";
            this.lblPresentCount.Size = new System.Drawing.Size(102, 22);
            this.lblPresentCount.TabIndex = 4;
            this.lblPresentCount.Text = "Present: 0";
            // 
            // lblAbsentCount
            // 
            this.lblAbsentCount.AutoSize = true;
            this.lblAbsentCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbsentCount.ForeColor = System.Drawing.Color.Red;
            this.lblAbsentCount.Location = new System.Drawing.Point(585, 623);
            this.lblAbsentCount.Name = "lblAbsentCount";
            this.lblAbsentCount.Size = new System.Drawing.Size(95, 22);
            this.lblAbsentCount.TabIndex = 5;
            this.lblAbsentCount.Text = "Absent: 0";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(815, 616);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 35);
            this.button1.TabIndex = 9;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ViewReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(254)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(932, 664);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblAbsentCount);
            this.Controls.Add(this.lblPresentCount);
            this.Controls.Add(this.lblTotalStudents);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvReports);
            this.Controls.Add(this.pnlFilters);
            this.Name = "ViewReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewReports";
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.DateTimePicker dtpFilterDate;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbClass;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.Label lblPresentCount;
        private System.Windows.Forms.Label lblAbsentCount;
        private System.Windows.Forms.Button button1;
    }
}