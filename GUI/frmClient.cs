﻿using GUI.DTO;
using GUI.frmClientUserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmClient : Form
    {
        public string clientUC = "home";

        public frmClient(User user)
        {
            InitializeComponent();
            this.LoginAccount=user;
            RenderContent();

        }

        public void RenderContent()
        {
            if(clientUC =="home")
            {
                pnlContent.Controls.Clear();
                HomeUC homeUC = new HomeUC();
                homeUC.Dock = DockStyle.Fill;
                pnlContent.Controls.Add(homeUC);
            }    
            else if(clientUC =="movie")
            {
                pnlContent.Controls.Clear();
                MovieUC movieUC = new MovieUC(this,this.loginAccount);
                movieUC.Dock = DockStyle.Fill;
                pnlContent.Controls.Add(movieUC);
            } 
            else if(clientUC =="booking")
            {
                pnlContent.Controls.Clear();
            }
            else if(clientUC =="info")
            {
                pnlContent.Controls.Clear();
                InfoUC infoUC = new InfoUC(this.loginAccount);
                infoUC.Dock = DockStyle.Fill;
                pnlContent.Controls.Add(infoUC);
            }    else if(clientUC== "ticket")
            {
                pnlContent.Controls.Clear();
                TicketUC ticketUC = new TicketUC(this.loginAccount);
                ticketUC.Dock = DockStyle.Fill;
                pnlContent.Controls.Add (ticketUC);
            }    
        }

        public void SetBooking(BookingUC bookingUC)
        {
            bookingUC.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(bookingUC);
        }

        private User loginAccount;

        public User LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(); }
        }

        void ChangeAccount()
        {
            lblUser.Text=LoginAccount.HoTen;
        }

      

     

        private void pictureBox3_Click(object sender, EventArgs e)
        {
          
            this.Close();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
           if(clientUC=="movie")
            { }
            else
            {
                clientUC = "movie";
                RenderContent();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
           if(clientUC =="home")
            { }
            else
            {
                clientUC = "home";
                RenderContent();
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if(clientUC=="info")
            { }
            else
            {
                clientUC= "info";
                RenderContent();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (clientUC == "ticket")
            { }
            else
            {
                clientUC = "ticket";
                RenderContent();
            }
        }

        private void frmClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn đăng xuất không?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            // Địa chỉ email hỗ trợ
            string supportEmail = "chinhtnc2903@gmail.com";

            // Tiêu đề email
            string emailSubject = Uri.EscapeDataString("Support Request");

            // Nội dung email
            string emailBody = Uri.EscapeDataString("Please describe your issue here...");

            // Đường dẫn mailto
            string mailtoUrl = $"mailto:{supportEmail}?subject={emailSubject}&body={emailBody}";

            // Mở ứng dụng email mặc định
            try
            {
                Process.Start(mailtoUrl);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open email client. Please contact support directly at " + supportEmail);
            }
        }
    }
}
