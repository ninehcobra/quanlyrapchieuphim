﻿namespace GUI.frmAdminUserControls.DataUserControl
{
    partial class TicketsUC
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
            this.panel61 = new System.Windows.Forms.Panel();
            this.btnShowAllTicketsByShowTime = new System.Windows.Forms.Button();
            this.btnShowAllTicketsBoughtByShowTime = new System.Windows.Forms.Button();
            this.btnAddTicketsByShowTime = new System.Windows.Forms.Button();
            this.btnAllListShowTimes = new System.Windows.Forms.Button();
            this.btnShowShowTimeNotCreateTickets = new System.Windows.Forms.Button();
            this.btnDeleteTicketsByShowTime = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lsvAllListShowTimes = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dtgvTicket = new System.Windows.Forms.DataGridView();
            this.panel61.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTicket)).BeginInit();
            this.SuspendLayout();
            // 
            // panel61
            // 
            this.panel61.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(81)))));
            this.panel61.Controls.Add(this.btnShowAllTicketsByShowTime);
            this.panel61.Controls.Add(this.btnShowAllTicketsBoughtByShowTime);
            this.panel61.Controls.Add(this.btnAddTicketsByShowTime);
            this.panel61.Controls.Add(this.btnAllListShowTimes);
            this.panel61.Controls.Add(this.btnShowShowTimeNotCreateTickets);
            this.panel61.Controls.Add(this.btnDeleteTicketsByShowTime);
            this.panel61.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel61.Location = new System.Drawing.Point(0, 0);
            this.panel61.Name = "panel61";
            this.panel61.Size = new System.Drawing.Size(1161, 52);
            this.panel61.TabIndex = 10;
            // 
            // btnShowAllTicketsByShowTime
            // 
            this.btnShowAllTicketsByShowTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.btnShowAllTicketsByShowTime.ForeColor = System.Drawing.Color.White;
            this.btnShowAllTicketsByShowTime.Location = new System.Drawing.Point(368, 3);
            this.btnShowAllTicketsByShowTime.Name = "btnShowAllTicketsByShowTime";
            this.btnShowAllTicketsByShowTime.Size = new System.Drawing.Size(116, 46);
            this.btnShowAllTicketsByShowTime.TabIndex = 5;
            this.btnShowAllTicketsByShowTime.Text = "Xem Tất Cả Các Vé Theo Lịch Chiếu";
            this.btnShowAllTicketsByShowTime.UseVisualStyleBackColor = false;
            this.btnShowAllTicketsByShowTime.Click += new System.EventHandler(this.btnShowAllTicketsByShowTime_Click);
            // 
            // btnShowAllTicketsBoughtByShowTime
            // 
            this.btnShowAllTicketsBoughtByShowTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.btnShowAllTicketsBoughtByShowTime.ForeColor = System.Drawing.Color.White;
            this.btnShowAllTicketsBoughtByShowTime.Location = new System.Drawing.Point(246, 3);
            this.btnShowAllTicketsBoughtByShowTime.Name = "btnShowAllTicketsBoughtByShowTime";
            this.btnShowAllTicketsBoughtByShowTime.Size = new System.Drawing.Size(116, 46);
            this.btnShowAllTicketsBoughtByShowTime.TabIndex = 4;
            this.btnShowAllTicketsBoughtByShowTime.Text = "Xem Các Vé Được Bán Theo Lịch Chiếu";
            this.btnShowAllTicketsBoughtByShowTime.UseVisualStyleBackColor = false;
            this.btnShowAllTicketsBoughtByShowTime.Click += new System.EventHandler(this.btnShowAllTicketsBoughtByShowTime_Click);
            // 
            // btnAddTicketsByShowTime
            // 
            this.btnAddTicketsByShowTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.btnAddTicketsByShowTime.ForeColor = System.Drawing.Color.White;
            this.btnAddTicketsByShowTime.Location = new System.Drawing.Point(3, 3);
            this.btnAddTicketsByShowTime.Name = "btnAddTicketsByShowTime";
            this.btnAddTicketsByShowTime.Size = new System.Drawing.Size(116, 46);
            this.btnAddTicketsByShowTime.TabIndex = 0;
            this.btnAddTicketsByShowTime.Text = "Tự Động Thêm Vé Theo Lịch Chiếu\r\n";
            this.btnAddTicketsByShowTime.UseVisualStyleBackColor = false;
            this.btnAddTicketsByShowTime.Click += new System.EventHandler(this.btnAddTicketsByShowTime_Click);
            // 
            // btnAllListShowTimes
            // 
            this.btnAllListShowTimes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.btnAllListShowTimes.ForeColor = System.Drawing.Color.White;
            this.btnAllListShowTimes.Location = new System.Drawing.Point(610, 3);
            this.btnAllListShowTimes.Name = "btnAllListShowTimes";
            this.btnAllListShowTimes.Size = new System.Drawing.Size(116, 46);
            this.btnAllListShowTimes.TabIndex = 3;
            this.btnAllListShowTimes.Text = "Xem Tất Cả Lịch Chiếu\r\n";
            this.btnAllListShowTimes.UseVisualStyleBackColor = false;
            this.btnAllListShowTimes.Click += new System.EventHandler(this.btnAllListShowTimes_Click);
            // 
            // btnShowShowTimeNotCreateTickets
            // 
            this.btnShowShowTimeNotCreateTickets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.btnShowShowTimeNotCreateTickets.ForeColor = System.Drawing.Color.White;
            this.btnShowShowTimeNotCreateTickets.Location = new System.Drawing.Point(489, 3);
            this.btnShowShowTimeNotCreateTickets.Name = "btnShowShowTimeNotCreateTickets";
            this.btnShowShowTimeNotCreateTickets.Size = new System.Drawing.Size(116, 46);
            this.btnShowShowTimeNotCreateTickets.TabIndex = 3;
            this.btnShowShowTimeNotCreateTickets.Text = "Xem Lịch Chiếu Chưa Được Tạo Vé";
            this.btnShowShowTimeNotCreateTickets.UseVisualStyleBackColor = false;
            this.btnShowShowTimeNotCreateTickets.Click += new System.EventHandler(this.btnShowShowTimeNotCreateTickets_Click);
            // 
            // btnDeleteTicketsByShowTime
            // 
            this.btnDeleteTicketsByShowTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(42)))), ((int)(((byte)(52)))));
            this.btnDeleteTicketsByShowTime.ForeColor = System.Drawing.Color.White;
            this.btnDeleteTicketsByShowTime.Location = new System.Drawing.Point(124, 3);
            this.btnDeleteTicketsByShowTime.Name = "btnDeleteTicketsByShowTime";
            this.btnDeleteTicketsByShowTime.Size = new System.Drawing.Size(116, 46);
            this.btnDeleteTicketsByShowTime.TabIndex = 1;
            this.btnDeleteTicketsByShowTime.Text = "Xóa Vé Theo Lịch Chiếu";
            this.btnDeleteTicketsByShowTime.UseVisualStyleBackColor = false;
            this.btnDeleteTicketsByShowTime.Click += new System.EventHandler(this.btnDeleteTicketsByShowTime_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lsvAllListShowTimes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(644, 52);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(517, 466);
            this.panel1.TabIndex = 11;
            // 
            // lsvAllListShowTimes
            // 
            this.lsvAllListShowTimes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvAllListShowTimes.FullRowSelect = true;
            this.lsvAllListShowTimes.GridLines = true;
            this.lsvAllListShowTimes.HideSelection = false;
            this.lsvAllListShowTimes.Location = new System.Drawing.Point(5, 6);
            this.lsvAllListShowTimes.Margin = new System.Windows.Forms.Padding(2);
            this.lsvAllListShowTimes.Name = "lsvAllListShowTimes";
            this.lsvAllListShowTimes.Size = new System.Drawing.Size(498, 459);
            this.lsvAllListShowTimes.TabIndex = 9;
            this.lsvAllListShowTimes.UseCompatibleStateImageBehavior = false;
            this.lsvAllListShowTimes.View = System.Windows.Forms.View.Details;
            this.lsvAllListShowTimes.Click += new System.EventHandler(this.lsvAllListShowTimes_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên Phòng Chiếu";
            this.columnHeader1.Width = 120;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên Phim";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Thời Gian";
            this.columnHeader3.Width = 150;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Trạng Thái";
            this.columnHeader4.Width = 100;
            // 
            // dtgvTicket
            // 
            this.dtgvTicket.AllowUserToAddRows = false;
            this.dtgvTicket.AllowUserToDeleteRows = false;
            this.dtgvTicket.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvTicket.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgvTicket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTicket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvTicket.Location = new System.Drawing.Point(0, 52);
            this.dtgvTicket.Name = "dtgvTicket";
            this.dtgvTicket.Size = new System.Drawing.Size(644, 466);
            this.dtgvTicket.TabIndex = 12;
            // 
            // TicketsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtgvTicket);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel61);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TicketsUC";
            this.Size = new System.Drawing.Size(1161, 518);
            this.panel61.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTicket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel61;
        private System.Windows.Forms.Button btnShowAllTicketsByShowTime;
        private System.Windows.Forms.Button btnShowAllTicketsBoughtByShowTime;
        private System.Windows.Forms.Button btnAddTicketsByShowTime;
        private System.Windows.Forms.Button btnAllListShowTimes;
        private System.Windows.Forms.Button btnShowShowTimeNotCreateTickets;
        private System.Windows.Forms.Button btnDeleteTicketsByShowTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView lsvAllListShowTimes;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.DataGridView dtgvTicket;
    }
}
