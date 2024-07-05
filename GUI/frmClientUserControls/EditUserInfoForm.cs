using GUI.DAO;
using GUI.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.frmClientUserControls
{
    public partial class EditUserInfoForm : Form
    {
        User User;
        public EditUserInfoForm(User user)
        {
            InitializeComponent();
            User=user;
            LoadUserInfo();

        }
        private void LoadUserInfo()
        {
            txtName.Text = User.HoTen;
            DataTable customerData = DataProvider.ExecuteQuery("SELECT * FROM KHACHHANG WHERE id = '" + User.ID + "'");
            if (customerData.Rows.Count > 0)
            {
                DataRow row = customerData.Rows[0];

                // Kiểm tra và gán giá trị cho số điện thoại
                if (row["SDT"] != DBNull.Value)
                {
                    txtPhone.Text = row["SDT"].ToString();
                }
                else
                {
                    txtPhone.Text = ""; // Hoặc giá trị mặc định nào đó
                }

                // Kiểm tra và gán giá trị cho địa chỉ
                if (row["DiaChi"] != DBNull.Value)
                {
                    txtAddress.Text = row["DiaChi"].ToString();
                }
                else
                {
                    txtAddress.Text = ""; // Hoặc giá trị mặc định nào đó
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newName = txtName.Text;
            string newPhone = txtPhone.Text;
            string newAddress = txtAddress.Text;


            bool result1 = DataProvider.ExecuteNonQuery("UPDATE NguoiDung SET HoTen = @newName WHERE ID = @userId",
              new object[] { newName, User.ID }) > 0;

            bool result2 = DataProvider.ExecuteNonQuery("UPDATE KhachHang SET SDT = @newPhone , DiaChi = @newAddress WHERE ID = @userId",
                new object[] { newPhone, newAddress, User.ID }) > 0;

            if (result1 && result2)
            {
                MessageBox.Show("Cập nhật thông tin thành công.");
                User.HoTen = newName;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin thất bại.");
            }
        }
    }
}
