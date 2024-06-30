using GUI.DAO;
using GUI.DTO;
using System;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmLogin : Form
    {
        string frmType = "signin";

        public frmLogin()
        {
            InitializeComponent();
            renderFrm();
        }

        private void renderFrm()
        {
            if(frmType =="signin")
            {
                btnRegister.Visible = false;
               
                btnLogin.Visible = true;

                txtEmail.Visible = false;
                txtPassword.Location = new System.Drawing.Point(820, 348);

                label3.Location = new System.Drawing.Point(816, 320);
                label11.Visible = false;
                
                label12.Visible = false;
                txtFullName.Visible = false;

                checkBox1.Visible = true;

                label9.Visible = true;
                label10.Visible = true;
                

                label5.Text = "Don't have an account?";
                label6.Text= "Sign up";
            }
            else
            {
                btnRegister.Visible = true;
                btnRegister.Location = new System.Drawing.Point(820, 575);

                btnLogin.Visible = false;

                txtEmail.Visible = true;
                txtEmail.Location = new System.Drawing.Point(820, 348);
                txtPassword.Location = new System.Drawing.Point(820, 430);

                label3.Location = new System.Drawing.Point(816, 402);
                label11.Visible = true;
                label11.Location = new System.Drawing.Point(816, 320);

                label12.Visible = true;
                label12.Location= new System.Drawing.Point(816, 484);
                txtFullName.Visible = true;
                txtFullName.Location = new System.Drawing.Point(816, 512);

                checkBox1.Visible = false;

                label9.Visible= false;
                label10.Visible= false;

                label5.Text = "Already have an account?";
                label6.Text = "Sign in";
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
            string userName = txtUsername.Text;
            string passWord = txtPassword.Text;
            int result = Login(userName, passWord);
            if (result == 2 || result==3)
            {
                Account loginAccount = AccountDAO.GetAccountByUserName(userName);
                frmDashBoard frm = new frmDashBoard(loginAccount);
                this.Hide();
                frm.ShowDialog();
                this.Show();
            }
            else if(result==1)
            {
                User nguoiDung = UserDAO.GetUserByUserName(userName);
                frmClient frm=new frmClient(nguoiDung);
                this.Hide();
                frm.ShowDialog();
                this.Show();

              
            }    
            else if (result == 0)
            {
                MessageBox.Show("SAI TÊN TÀI KHOẢN HOẶC MẬT KHẨU!!!!", "THÔNG BÁO");
            }
            else
            {
                MessageBox.Show("KẾT NỐI THẤT BẠI", "THÔNG BÁO");
            }
            btnLogin.Enabled = true;
        }

        private int Login(string userName, string passWord)
        {
            (int loginStatus, string accountType) = AccountDAO.Login(userName, passWord);

            if (loginStatus == -1)
                return -1; // Đăng nhập thất bại

            if (accountType == "AdminOrStaff")
            {
                // Kiểm tra loại tài khoản cụ thể
                string specificAccountType = AccountDAO.GetAccountType(userName);
                if (specificAccountType == "Admin")
                    return 2; // Admin
                else if (specificAccountType == "Staff")
                    return 3; // Staff
            }
            else if (accountType == "User")
            {
                return 1; // Người dùng
            }

            return 0; // Trường hợp không xác định
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void mnuSetting_Click(object sender, EventArgs e)
        {
            frmConnectData frm = new frmConnectData();
            frm.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassword.PasswordChar = '\0';

            }
            else
            {
                txtPassword.PasswordChar = '•';

            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            if(frmType == "signup")
            {
                frmType = "signin";
            }
            else
            {
                frmType = "signup";
            }
            renderFrm();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            frmForgotPassword frm = new frmForgotPassword();   
            frm.ShowDialog();

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            btnRegister.Enabled = false;
            string userName = txtUsername.Text;
            string passWord = txtPassword.Text;
            string email= txtEmail.Text;
            string fullname=txtFullName.Text;

            bool register= UserDAO.InsertUser(email, userName, passWord, fullname, email);
            if (register)
            {
                MessageBox.Show("Đăng ký thành công", "THÔNG BÁO");
                frmType = "signin";
                renderFrm();
            }
            else
            {
                MessageBox.Show("Đăng ký thất bại", "THÔNG BÁO");
            }
            btnRegister.Enabled = true;

        }
    }
}
