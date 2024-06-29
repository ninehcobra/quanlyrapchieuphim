using GUI.DAO;
using GUI.DTO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
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
    }
}
