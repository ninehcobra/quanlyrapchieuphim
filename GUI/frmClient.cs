using GUI.DTO;
using GUI.frmClientUserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                MovieUC movieUC = new MovieUC(this);
                movieUC.Dock = DockStyle.Fill;
                pnlContent.Controls.Add(movieUC);
            }    
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
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Close();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            clientUC = "movie";
            RenderContent();
        }
    }
}
