using GUI.DTO;
using System;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;//thư viện để mã hóa mật khẩu
using System.Text;
using System.Windows.Forms;

namespace GUI.DAO
{
    public class AccountDAO
    {
        private AccountDAO() { }

        private static string PasswordEncryption(string password)
        {
            //tính năng bảo mật cho việc đăng nhập
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(password);//chuyển qua mảng kiểu byte từ một chuỗi
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            //tạo ra bảng has(bảng băm) chứa các mảng byte
            //từ mật khẩu được mã hóa thành mảng băm

            string hasPass = "";

            foreach (byte item in hasData)
            {
                hasPass += item;
            }

            //tính năng mã hóa nâng cao bằng việc đảo ngược mật khẩu
            char[] arr = hasPass.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public static (int, string) Login(string userName, string passWord)
        {
            string pass = PasswordEncryption(passWord);

            string query = "USP_Login @userName , @passWord";
            DataTable result = DataProvider.ExecuteQuery(query, new object[] { userName, pass });

            if (result == null || result.Rows.Count == 0)
                return (-1, null);

            string source = result.Rows[0]["Source"].ToString();
            if (source == "TaiKhoan")
            {
                return (1, "AdminOrStaff");
            }
            else if (source == "NguoiDung")
            {
                return (1, "User");
            }
            return (0, null);
        }

        public static bool UpdatePasswordForAccount(string userName, string passWord, string newPassWord)
        {

            string oldPass = PasswordEncryption(passWord);
            string newPass = PasswordEncryption(newPassWord);

            int result = DataProvider.ExecuteNonQuery("EXEC USP_UpdatePasswordForAccount @username , @pass , @newPass", new object[] { userName, oldPass, newPass });

            return result > 0;
        }

        public static Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.ExecuteQuery("Select * from TaiKhoan where userName = '" + userName + "'");

            foreach (DataRow row in data.Rows)
            {
                return new Account(row);
            }

            return null;
        }

        public static void DeleteAccountByIdStaff(string idStaff)
        {
            DataProvider.ExecuteQuery("DELETE dbo.TaiKhoan WHERE idNV = '" + idStaff + "'");
        }

		public static DataTable GetAccountList()
		{
			return DataProvider.ExecuteQuery("USP_GetAccountList");
		}

		public static bool InsertAccount(string username, int accountType, string staffID)
		{
			int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertAccount @username , @loaiTK , @idnv ", new object[] { username, accountType, staffID });
			return result > 0;
		}

		public static bool UpdateAccount(string username, int accountType)
		{
			string command = string.Format("USP_UpdateAccount  @username , @loaiTK", new object[] { username, accountType});
			int result = DataProvider.ExecuteNonQuery(command);
			return result > 0;
		}

		public static bool DeleteAccount(string username)
		{
			int result = DataProvider.ExecuteNonQuery("DELETE dbo.TaiKhoan WHERE UserName = N'" + username + "'");
			return result > 0;
		}

		public static DataTable SearchAccountByStaffName(string name)
		{
			return DataProvider.ExecuteQuery("EXEC USP_SearchAccount @hoten ", new object[] { name });
		}

		public static bool ResetPassword(string username)
		{
			int result = DataProvider.ExecuteNonQuery("USP_ResetPasswordtAccount @username", new object[] { username});
			return result > 0;
		}

        public static bool ResetPasswordUser(string username,string email)
        {
            string randomPass = GenerateRandomString(6);
            string newPass = PasswordEncryption(randomPass);

            int result = DataProvider.ExecuteNonQuery("EXEC USP_ResetPasswordUser @username , @newPass , @email", new object[] { username,newPass,email});

            if(result > 0)
            {
                string body = string.Format(@"<!doctype html>
<html lang=""en"">
  <head>
    <meta charset=""UTF-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
    <title>OTP</title>
    <style>
      /* Styles for small screens */
      @media (max-width: 767px) {{
        .container {{
          width: 90%;
          padding: 12px;
        }}
        .logo img {{
          height: 30px;
        }}
        .heading {{
          font-size: 24px;
        }}
        .otp-banner img {{
          max-width: 100%;
          height: auto;
        }}
        .content {{
          padding: 20px;
        }}
        .footer {{
          font-size: 12px;
        }}
      }}

      /* Styles for medium screens */
      @media (min-width: 768px) and (max-width: 1023px) {{
        .container {{
          width: 80%;
        }}
        .logo img {{
          height: 40px;
        }}
        .heading {{
          font-size: 32px;
        }}
        .otp-banner img {{
          max-width: 100%;
          height: auto;
        }}
        .content {{
          padding: 30px;
        }}
        .footer {{
          font-size: 14px;
        }}
      }}

      /* Styles for large screens */
      @media (min-width: 1024px) {{
        .container {{
          width: 60%;
          max-width: 800px; /* Giới hạn chiều rộng tối đa */
        }}
        .logo img {{
          height: 45px;
        }}
        .heading {{
          font-size: 38px;
        }}
        .otp-banner img {{
          max-width: 100%;
          height: auto;
        }}
        .content {{
          padding: 40px 48px;
        }}
        .footer {{
          font-size: 16px;
        }}
      }}

      /* Căn giữa nội dung */
      .container {{
        margin: 0 auto;
      }}
    </style>
  </head>
  <body style=""font-family: 'Poppins', sans-serif; background-color: #101010; color: #ffffff; border-radius: 16px"">
    <div style=""display: table; width: 100%"">
      <div style=""display: table-cell; vertical-align: middle"">
        <div class=""container"" style=""padding: 24px"">
          <div style=""width: 100%"">
            <img
              src=""https://raw.githubusercontent.com/ninehcobra/free-host-image/main/cinema-logo.png""
              alt=""logo""
              style=""height: 45px""
            />
          </div>
          <div style=""margin-top: 32px; text-align: center"">
            <div style=""font-size: 38px; font-weight: 700"">Reset Your Password</div>
            <div style=""margin-top: 12px"">
              <img
                src=""https://raw.githubusercontent.com/ninehcobra/free-host-image/main/otp.png""
                alt=""otp-banner""
                style=""height: 100%""
              />
              <div style=""padding: 40px 48px; background-color: #18181a"">
                <div style=""font-weight: 200; font-size: 14px; text-align: left"">
                  Base on your reset password request. Here is your new password you can use it to login to Dream Cinema
                  now:
                </div>
                <div
                  style=""margin-top: 24px;
                    width: 100%;
                    text-align: center;
                    letter-spacing: 8px;
                    font-weight: 700;
                    font-size: 24px;
                    color: #ec0052;""
                >
                  <!-- OTP để ở đây -->
                  {0}
                </div>
              </div>
            </div>
          </div>
          <div style=""margin-top: 32px; text-align: center; font-size: 14px"">
            Didn't create or update your DS account? No worries — you can safely ignore this email.
          </div>
          <div style=""margin-top: 24px; text-align: center"">
            <ul style=""list-style: none; padding: 0"">
              <li style=""display: inline-block; margin-right: 4px"">
                <a href=""/"" style=""color: #103fcc; font-weight: 600; text-decoration: none"">QS</a>
              </li>
              <li style=""display: inline-block; margin-right: 4px; color: #ffffff"">|</li>
              <li style=""display: inline-block; margin-right: 4px"">
                <a href=""/"" style=""color: #103fcc; font-weight: 600; text-decoration: none"">Privacy Policy</a>
              </li>
              <li style=""display: inline-block"">
                <a href=""/"" style=""color: #103fcc; font-weight: 600; text-decoration: none"">Support</a>
              </li>
            </ul>
          </div>
        </div>
      </div>
    </div>
  </body>
</html>", randomPass);

                SendEmail(email, "Reset Password", body);
            }
            return result > 0;
        }

        public static void SendEmail(string to, string subject, string body)
        {
            try
            {
                // Tạo đối tượng MailMessage
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("chinhtnc2903@gmail.com"); // Địa chỉ email gửi đi
                mail.To.Add(to); // Địa chỉ email nhận
                mail.Subject = subject; // Tiêu đề email
                mail.IsBodyHtml = true;
                mail.Body = body; // Nội dung email

                // Tạo đối tượng SmtpClient
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com"); // Địa chỉ SMTP server
                smtpServer.Port = 587; // Cổng SMTP (có thể thay đổi tùy theo cấu hình của SMTP server)
                smtpServer.Credentials = new System.Net.NetworkCredential("chinhtnc2903@gmail.com", "nxys xhgi gkip zhnz"); // Thông tin đăng nhập email
                smtpServer.EnableSsl = true; // Sử dụng SSL (có thể thay đổi tùy theo cấu hình của SMTP server)

                // Gửi email
                smtpServer.Send(mail);

                MessageBox.Show("Email đã được gửi thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi email: " + ex.Message);
            }
        }

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                int index = random.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }

        public static string GetAccountType(string userName)
        {
            DataTable data = DataProvider.ExecuteQuery("SELECT LoaiTK FROM TaiKhoan WHERE UserName = '" + userName + "'");

            if (data != null && data.Rows.Count > 0)
            {
                int type = (int)data.Rows[0]["LoaiTK"];
                if (type == 1)
                    return "Admin";
                else if (type == 2)
                    return "Staff";
                else
                    return "User";
            }

            return null;
        }
    }
}
