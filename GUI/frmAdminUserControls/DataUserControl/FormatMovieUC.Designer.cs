﻿namespace GUI.frmAdminUserControls.DataUserControl
{
    partial class FormatMovieUC
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnShowFormat = new System.Windows.Forms.Button();
            this.btnUpdateFormat = new System.Windows.Forms.Button();
            this.btnDeleteFormat = new System.Windows.Forms.Button();
            this.btnInsertFormat = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtgvFormat = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cboFormat_ScreenID = new System.Windows.Forms.ComboBox();
            this.lblFormat_ScreenName = new System.Windows.Forms.Label();
            this.cboFormat_MovieID = new System.Windows.Forms.ComboBox();
            this.lblFormat_ScreenID = new System.Windows.Forms.Label();
            this.lblFormat_MovieName = new System.Windows.Forms.Label();
            this.lblFormat_MovieID = new System.Windows.Forms.Label();
            this.txtFormat_ScreenName = new System.Windows.Forms.TextBox();
            this.lblFormatID = new System.Windows.Forms.Label();
            this.txtFormat_MovieName = new System.Windows.Forms.TextBox();
            this.txtFormatID = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvFormat)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.panel1.Controls.Add(this.btnShowFormat);
            this.panel1.Controls.Add(this.btnUpdateFormat);
            this.panel1.Controls.Add(this.btnDeleteFormat);
            this.panel1.Controls.Add(this.btnInsertFormat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1161, 52);
            this.panel1.TabIndex = 0;
            // 
            // btnShowFormat
            // 
            this.btnShowFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.btnShowFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowFormat.ForeColor = System.Drawing.Color.White;
            this.btnShowFormat.Location = new System.Drawing.Point(246, 3);
            this.btnShowFormat.Name = "btnShowFormat";
            this.btnShowFormat.Size = new System.Drawing.Size(75, 46);
            this.btnShowFormat.TabIndex = 11;
            this.btnShowFormat.Text = "Xem";
            this.btnShowFormat.UseVisualStyleBackColor = false;
            this.btnShowFormat.Click += new System.EventHandler(this.btnShowFormat_Click);
            // 
            // btnUpdateFormat
            // 
            this.btnUpdateFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.btnUpdateFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateFormat.ForeColor = System.Drawing.Color.White;
            this.btnUpdateFormat.Location = new System.Drawing.Point(165, 3);
            this.btnUpdateFormat.Name = "btnUpdateFormat";
            this.btnUpdateFormat.Size = new System.Drawing.Size(75, 46);
            this.btnUpdateFormat.TabIndex = 10;
            this.btnUpdateFormat.Text = "Sửa";
            this.btnUpdateFormat.UseVisualStyleBackColor = false;
            this.btnUpdateFormat.Click += new System.EventHandler(this.btnUpdateFormat_Click);
            // 
            // btnDeleteFormat
            // 
            this.btnDeleteFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.btnDeleteFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteFormat.ForeColor = System.Drawing.Color.White;
            this.btnDeleteFormat.Location = new System.Drawing.Point(84, 3);
            this.btnDeleteFormat.Name = "btnDeleteFormat";
            this.btnDeleteFormat.Size = new System.Drawing.Size(75, 46);
            this.btnDeleteFormat.TabIndex = 9;
            this.btnDeleteFormat.Text = "Xóa";
            this.btnDeleteFormat.UseVisualStyleBackColor = false;
            this.btnDeleteFormat.Click += new System.EventHandler(this.btnDeleteFormat_Click);
            // 
            // btnInsertFormat
            // 
            this.btnInsertFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.btnInsertFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertFormat.ForeColor = System.Drawing.Color.White;
            this.btnInsertFormat.Location = new System.Drawing.Point(3, 3);
            this.btnInsertFormat.Name = "btnInsertFormat";
            this.btnInsertFormat.Size = new System.Drawing.Size(75, 46);
            this.btnInsertFormat.TabIndex = 8;
            this.btnInsertFormat.Text = "Thêm";
            this.btnInsertFormat.UseVisualStyleBackColor = false;
            this.btnInsertFormat.Click += new System.EventHandler(this.btnInsertFormat_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtgvFormat);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 52);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1161, 466);
            this.panel2.TabIndex = 1;
            // 
            // dtgvFormat
            // 
            this.dtgvFormat.AllowUserToAddRows = false;
            this.dtgvFormat.AllowUserToDeleteRows = false;
            this.dtgvFormat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvFormat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgvFormat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvFormat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvFormat.Location = new System.Drawing.Point(0, 0);
            this.dtgvFormat.Margin = new System.Windows.Forms.Padding(2);
            this.dtgvFormat.Name = "dtgvFormat";
            this.dtgvFormat.ReadOnly = true;
            this.dtgvFormat.Size = new System.Drawing.Size(823, 466);
            this.dtgvFormat.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.panel3.Controls.Add(this.cboFormat_ScreenID);
            this.panel3.Controls.Add(this.lblFormat_ScreenName);
            this.panel3.Controls.Add(this.cboFormat_MovieID);
            this.panel3.Controls.Add(this.lblFormat_ScreenID);
            this.panel3.Controls.Add(this.lblFormat_MovieName);
            this.panel3.Controls.Add(this.lblFormat_MovieID);
            this.panel3.Controls.Add(this.txtFormat_ScreenName);
            this.panel3.Controls.Add(this.lblFormatID);
            this.panel3.Controls.Add(this.txtFormat_MovieName);
            this.panel3.Controls.Add(this.txtFormatID);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(823, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(338, 466);
            this.panel3.TabIndex = 0;
            // 
            // cboFormat_ScreenID
            // 
            this.cboFormat_ScreenID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormat_ScreenID.FormattingEnabled = true;
            this.cboFormat_ScreenID.Location = new System.Drawing.Point(128, 140);
            this.cboFormat_ScreenID.Margin = new System.Windows.Forms.Padding(2);
            this.cboFormat_ScreenID.Name = "cboFormat_ScreenID";
            this.cboFormat_ScreenID.Size = new System.Drawing.Size(188, 21);
            this.cboFormat_ScreenID.TabIndex = 20;
            this.cboFormat_ScreenID.SelectedIndexChanged += new System.EventHandler(this.cboFormat_ScreenID_SelectedValueChanged);
            // 
            // lblFormat_ScreenName
            // 
            this.lblFormat_ScreenName.AutoSize = true;
            this.lblFormat_ScreenName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormat_ScreenName.ForeColor = System.Drawing.Color.White;
            this.lblFormat_ScreenName.Location = new System.Drawing.Point(9, 167);
            this.lblFormat_ScreenName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormat_ScreenName.Name = "lblFormat_ScreenName";
            this.lblFormat_ScreenName.Size = new System.Drawing.Size(104, 19);
            this.lblFormat_ScreenName.TabIndex = 15;
            this.lblFormat_ScreenName.Text = "Tên màn hình:";
            // 
            // cboFormat_MovieID
            // 
            this.cboFormat_MovieID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFormat_MovieID.FormattingEnabled = true;
            this.cboFormat_MovieID.Location = new System.Drawing.Point(128, 63);
            this.cboFormat_MovieID.Margin = new System.Windows.Forms.Padding(2);
            this.cboFormat_MovieID.Name = "cboFormat_MovieID";
            this.cboFormat_MovieID.Size = new System.Drawing.Size(188, 21);
            this.cboFormat_MovieID.TabIndex = 21;
            this.cboFormat_MovieID.SelectedIndexChanged += new System.EventHandler(this.cboFormat_MovieID_SelectedValueChanged);
            // 
            // lblFormat_ScreenID
            // 
            this.lblFormat_ScreenID.AutoSize = true;
            this.lblFormat_ScreenID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormat_ScreenID.ForeColor = System.Drawing.Color.White;
            this.lblFormat_ScreenID.Location = new System.Drawing.Point(9, 141);
            this.lblFormat_ScreenID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormat_ScreenID.Name = "lblFormat_ScreenID";
            this.lblFormat_ScreenID.Size = new System.Drawing.Size(102, 19);
            this.lblFormat_ScreenID.TabIndex = 16;
            this.lblFormat_ScreenID.Text = "Mã màn hình:";
            // 
            // lblFormat_MovieName
            // 
            this.lblFormat_MovieName.AutoSize = true;
            this.lblFormat_MovieName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormat_MovieName.ForeColor = System.Drawing.Color.White;
            this.lblFormat_MovieName.Location = new System.Drawing.Point(9, 91);
            this.lblFormat_MovieName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormat_MovieName.Name = "lblFormat_MovieName";
            this.lblFormat_MovieName.Size = new System.Drawing.Size(76, 19);
            this.lblFormat_MovieName.TabIndex = 17;
            this.lblFormat_MovieName.Text = "Tên phim:";
            // 
            // lblFormat_MovieID
            // 
            this.lblFormat_MovieID.AutoSize = true;
            this.lblFormat_MovieID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormat_MovieID.ForeColor = System.Drawing.Color.White;
            this.lblFormat_MovieID.Location = new System.Drawing.Point(9, 64);
            this.lblFormat_MovieID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormat_MovieID.Name = "lblFormat_MovieID";
            this.lblFormat_MovieID.Size = new System.Drawing.Size(74, 19);
            this.lblFormat_MovieID.TabIndex = 18;
            this.lblFormat_MovieID.Text = "Mã phim:";
            // 
            // txtFormat_ScreenName
            // 
            this.txtFormat_ScreenName.Location = new System.Drawing.Point(128, 170);
            this.txtFormat_ScreenName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFormat_ScreenName.Name = "txtFormat_ScreenName";
            this.txtFormat_ScreenName.ReadOnly = true;
            this.txtFormat_ScreenName.Size = new System.Drawing.Size(188, 20);
            this.txtFormat_ScreenName.TabIndex = 12;
            // 
            // lblFormatID
            // 
            this.lblFormatID.AutoSize = true;
            this.lblFormatID.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormatID.ForeColor = System.Drawing.Color.White;
            this.lblFormatID.Location = new System.Drawing.Point(9, 14);
            this.lblFormatID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormatID.Name = "lblFormatID";
            this.lblFormatID.Size = new System.Drawing.Size(106, 19);
            this.lblFormatID.TabIndex = 19;
            this.lblFormatID.Text = "Mã định dạng:";
            // 
            // txtFormat_MovieName
            // 
            this.txtFormat_MovieName.Location = new System.Drawing.Point(128, 90);
            this.txtFormat_MovieName.Margin = new System.Windows.Forms.Padding(2);
            this.txtFormat_MovieName.Name = "txtFormat_MovieName";
            this.txtFormat_MovieName.ReadOnly = true;
            this.txtFormat_MovieName.Size = new System.Drawing.Size(188, 20);
            this.txtFormat_MovieName.TabIndex = 13;
            // 
            // txtFormatID
            // 
            this.txtFormatID.Location = new System.Drawing.Point(128, 13);
            this.txtFormatID.Margin = new System.Windows.Forms.Padding(2);
            this.txtFormatID.Name = "txtFormatID";
            this.txtFormatID.Size = new System.Drawing.Size(188, 20);
            this.txtFormatID.TabIndex = 14;
            this.txtFormatID.TextChanged += new System.EventHandler(this.txtFormatID_TextChanged);
            // 
            // FormatMovieUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormatMovieUC";
            this.Size = new System.Drawing.Size(1161, 518);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvFormat)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnShowFormat;
        private System.Windows.Forms.Button btnUpdateFormat;
        private System.Windows.Forms.Button btnDeleteFormat;
        private System.Windows.Forms.Button btnInsertFormat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cboFormat_ScreenID;
        private System.Windows.Forms.Label lblFormat_ScreenName;
        private System.Windows.Forms.ComboBox cboFormat_MovieID;
        private System.Windows.Forms.Label lblFormat_ScreenID;
        private System.Windows.Forms.Label lblFormat_MovieName;
        private System.Windows.Forms.Label lblFormat_MovieID;
        private System.Windows.Forms.TextBox txtFormat_ScreenName;
        private System.Windows.Forms.Label lblFormatID;
        private System.Windows.Forms.TextBox txtFormat_MovieName;
        private System.Windows.Forms.TextBox txtFormatID;
        private System.Windows.Forms.DataGridView dtgvFormat;
    }
}
