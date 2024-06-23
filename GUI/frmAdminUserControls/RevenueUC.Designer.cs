namespace GUI.frmAdminUserControls
{
    partial class RevenueUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSelectMovie = new System.Windows.Forms.Label();
            this.lblTongDoanhThu = new System.Windows.Forms.Label();
            this.txtDoanhThu = new System.Windows.Forms.TextBox();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgvRevenue = new System.Windows.Forms.DataGridView();
            this.btnReportRevenue = new System.Windows.Forms.Button();
            this.btnShowRevenue = new System.Windows.Forms.Button();
            this.cboSelectMovie = new System.Windows.Forms.ComboBox();
            this.dtmToDate = new System.Windows.Forms.DateTimePicker();
            this.dtmFromDate = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvRevenue)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSelectMovie
            // 
            this.lblSelectMovie.AutoSize = true;
            this.lblSelectMovie.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectMovie.ForeColor = System.Drawing.Color.White;
            this.lblSelectMovie.Location = new System.Drawing.Point(150, 19);
            this.lblSelectMovie.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectMovie.Name = "lblSelectMovie";
            this.lblSelectMovie.Size = new System.Drawing.Size(85, 19);
            this.lblSelectMovie.TabIndex = 39;
            this.lblSelectMovie.Text = "Chọn phim:";
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.AutoSize = true;
            this.lblTongDoanhThu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongDoanhThu.ForeColor = System.Drawing.Color.White;
            this.lblTongDoanhThu.Location = new System.Drawing.Point(634, 449);
            this.lblTongDoanhThu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(117, 19);
            this.lblTongDoanhThu.TabIndex = 38;
            this.lblTongDoanhThu.Text = "Tổng doanh thu:";
            // 
            // txtDoanhThu
            // 
            this.txtDoanhThu.Enabled = false;
            this.txtDoanhThu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDoanhThu.Location = new System.Drawing.Point(748, 444);
            this.txtDoanhThu.Margin = new System.Windows.Forms.Padding(2);
            this.txtDoanhThu.Name = "txtDoanhThu";
            this.txtDoanhThu.Size = new System.Drawing.Size(177, 29);
            this.txtDoanhThu.TabIndex = 37;
            this.txtDoanhThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.ForeColor = System.Drawing.Color.White;
            this.lblDenNgay.Location = new System.Drawing.Point(338, 57);
            this.lblDenNgay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(56, 13);
            this.lblDenNgay.TabIndex = 36;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(147, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Từ ngày:";
            // 
            // dtgvRevenue
            // 
            this.dtgvRevenue.AllowUserToAddRows = false;
            this.dtgvRevenue.AllowUserToDeleteRows = false;
            this.dtgvRevenue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvRevenue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvRevenue.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dtgvRevenue.Location = new System.Drawing.Point(150, 99);
            this.dtgvRevenue.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvRevenue.Name = "dtgvRevenue";
            this.dtgvRevenue.ReadOnly = true;
            this.dtgvRevenue.Size = new System.Drawing.Size(775, 342);
            this.dtgvRevenue.TabIndex = 34;
            // 
            // btnReportRevenue
            // 
            this.btnReportRevenue.AutoSize = true;
            this.btnReportRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.btnReportRevenue.ForeColor = System.Drawing.Color.White;
            this.btnReportRevenue.Location = new System.Drawing.Point(595, 53);
            this.btnReportRevenue.Margin = new System.Windows.Forms.Padding(2);
            this.btnReportRevenue.Name = "btnReportRevenue";
            this.btnReportRevenue.Size = new System.Drawing.Size(69, 26);
            this.btnReportRevenue.TabIndex = 32;
            this.btnReportRevenue.Text = "Báo Cáo";
            this.btnReportRevenue.UseVisualStyleBackColor = false;
            this.btnReportRevenue.Click += new System.EventHandler(this.btnReportRevenue_Click);
            // 
            // btnShowRevenue
            // 
            this.btnShowRevenue.AutoSize = true;
            this.btnShowRevenue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.btnShowRevenue.ForeColor = System.Drawing.Color.White;
            this.btnShowRevenue.Location = new System.Drawing.Point(509, 53);
            this.btnShowRevenue.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowRevenue.Name = "btnShowRevenue";
            this.btnShowRevenue.Size = new System.Drawing.Size(73, 26);
            this.btnShowRevenue.TabIndex = 33;
            this.btnShowRevenue.Text = "Thống kê";
            this.btnShowRevenue.UseVisualStyleBackColor = false;
            this.btnShowRevenue.Click += new System.EventHandler(this.btnShowRevenue_Click);
            // 
            // cboSelectMovie
            // 
            this.cboSelectMovie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectMovie.FormattingEnabled = true;
            this.cboSelectMovie.Location = new System.Drawing.Point(244, 20);
            this.cboSelectMovie.Margin = new System.Windows.Forms.Padding(2);
            this.cboSelectMovie.Name = "cboSelectMovie";
            this.cboSelectMovie.Size = new System.Drawing.Size(263, 21);
            this.cboSelectMovie.TabIndex = 31;
            // 
            // dtmToDate
            // 
            this.dtmToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmToDate.Location = new System.Drawing.Point(397, 54);
            this.dtmToDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtmToDate.Name = "dtmToDate";
            this.dtmToDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtmToDate.Size = new System.Drawing.Size(102, 20);
            this.dtmToDate.TabIndex = 29;
            // 
            // dtmFromDate
            // 
            this.dtmFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtmFromDate.Location = new System.Drawing.Point(201, 54);
            this.dtmFromDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtmFromDate.Name = "dtmFromDate";
            this.dtmFromDate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtmFromDate.Size = new System.Drawing.Size(102, 20);
            this.dtmFromDate.TabIndex = 30;
            // 
            // RevenueUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.Controls.Add(this.lblSelectMovie);
            this.Controls.Add(this.lblTongDoanhThu);
            this.Controls.Add(this.txtDoanhThu);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtgvRevenue);
            this.Controls.Add(this.btnReportRevenue);
            this.Controls.Add(this.btnShowRevenue);
            this.Controls.Add(this.cboSelectMovie);
            this.Controls.Add(this.dtmToDate);
            this.Controls.Add(this.dtmFromDate);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RevenueUC";
            this.Size = new System.Drawing.Size(1050, 528);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvRevenue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelectMovie;
        private System.Windows.Forms.Label lblTongDoanhThu;
        private System.Windows.Forms.TextBox txtDoanhThu;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgvRevenue;
        private System.Windows.Forms.Button btnReportRevenue;
        private System.Windows.Forms.Button btnShowRevenue;
        private System.Windows.Forms.ComboBox cboSelectMovie;
        private System.Windows.Forms.DateTimePicker dtmToDate;
        private System.Windows.Forms.DateTimePicker dtmFromDate;
    }
}
