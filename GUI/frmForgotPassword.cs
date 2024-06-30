using GUI.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmForgotPassword : Form
    {
        public frmForgotPassword()
        {
            InitializeComponent();
        }

        private void frmForgotPassword_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username=txtUsername.Text;
            string email=txtEmail.Text;
            Boolean resetPassword = AccountDAO.ResetPasswordUser(username, email);
            if (resetPassword) {
                this.Close();
            }
            else {
                MessageBox.Show("KẾT NỐI THẤT BẠI", "THÔNG BÁO");
            }
        }
    }
}
