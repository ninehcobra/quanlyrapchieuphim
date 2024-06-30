using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
    public class UserDAO
    {
        private UserDAO() { }

        public static User GetUserByUserName(string userName)
        {
            DataTable data = DataProvider.ExecuteQuery("SELECT * FROM NguoiDung WHERE UserName = '" + userName + "'");

            foreach (DataRow row in data.Rows)
            {
                return new User(row);
            }

            return null;
        }

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

        public static bool InsertUser(string id, string userName, string password, string hoTen, string email)
        {
            int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertNguoiDung @id , @userName , @password , @hoTen , @email",
                new object[] { id, userName, PasswordEncryption(password), hoTen, email});

            if(result>0)
            {
                AccountDAO.SendEmail(email, "Created Success", "<!doctype html>\r\n<html lang=\"en\">\r\n  <head>\r\n    <meta charset=\"UTF-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <title>OTP</title>\r\n    <style>\r\n      /* Styles for small screens */\r\n      @media (max-width: 767px) {\r\n        .container {\r\n          width: 90%;\r\n          padding: 12px;\r\n        }\r\n        .logo img {\r\n          height: 30px;\r\n        }\r\n        .heading {\r\n          font-size: 24px;\r\n        }\r\n        .otp-banner img {\r\n          max-width: 100%;\r\n          height: auto;\r\n        }\r\n        .content {\r\n          padding: 20px;\r\n        }\r\n        .footer {\r\n          font-size: 12px;\r\n        }\r\n      }\r\n\r\n      /* Styles for medium screens */\r\n      @media (min-width: 768px) and (max-width: 1023px) {\r\n        .container {\r\n          width: 80%;\r\n        }\r\n        .logo img {\r\n          height: 40px;\r\n        }\r\n        .heading {\r\n          font-size: 32px;\r\n        }\r\n        .otp-banner img {\r\n          max-width: 100%;\r\n          height: auto;\r\n        }\r\n        .content {\r\n          padding: 30px;\r\n        }\r\n        .footer {\r\n          font-size: 14px;\r\n        }\r\n      }\r\n\r\n      /* Styles for large screens */\r\n      @media (min-width: 1024px) {\r\n        .container {\r\n          width: 60%;\r\n          max-width: 800px; /* Giới hạn chiều rộng tối đa */\r\n        }\r\n        .logo img {\r\n          height: 45px;\r\n        }\r\n        .heading {\r\n          font-size: 38px;\r\n        }\r\n        .otp-banner img {\r\n          max-width: 100%;\r\n          height: auto;\r\n        }\r\n        .content {\r\n          padding: 40px 48px;\r\n        }\r\n        .footer {\r\n          font-size: 16px;\r\n        }\r\n      }\r\n\r\n      /* Căn giữa nội dung */\r\n      .container {\r\n        margin: 0 auto;\r\n      }\r\n    </style>\r\n  </head>\r\n  <body style=\"font-family: 'Poppins', sans-serif; background-color: #101010; color: #ffffff; border-radius: 16px\">\r\n    <div style=\"display: table; width: 100%\">\r\n      <div style=\"display: table-cell; vertical-align: middle\">\r\n        <div class=\"container\" style=\"padding: 24px\">\r\n          <div class=\"logo\" style=\"width: 100%\">\r\n            <img\r\n              src=\"https://raw.githubusercontent.com/ninehcobra/free-host-image/main/cinema-logo.png\"\r\n              alt=\"logo\"\r\n              style=\"height: 45px\"\r\n            />\r\n          </div>\r\n          <div style=\"margin-top: 32px; text-align: center\">\r\n            <div class=\"heading\" style=\"font-size: 38px; font-weight: 700\">Account successfully created</div>\r\n            <div style=\"margin-top: 12px\">\r\n              <img\r\n                class=\"otp-banner\"\r\n                src=\"https://raw.githubusercontent.com/ninehcobra/free-host-image/main/congrat.png\"\r\n                alt=\"otp-banner\"\r\n                style=\"height: 200px\"\r\n              />\r\n              <div class=\"content\" style=\"padding: 40px 48px; background-color: #18181a\">\r\n                <div style=\"font-weight: 200; font-size: 14px; text-align: justify; line-height: 1.6\">\r\n                  You're all set! Thanks for confirming your email. Dream Cinema is great for booking and watching your\r\n                  favorite movie.\r\n                </div>\r\n              </div>\r\n            </div>\r\n          </div>\r\n          <div class=\"footer\" style=\"margin-top: 32px; text-align: center; font-size: 14px\">\r\n            Glad you're here, PC Team\r\n          </div>\r\n          <div style=\"margin-top: 24px; text-align: center\">\r\n            <ul style=\"list-style: none; padding: 0\">\r\n              <li style=\"display: inline-block; margin-right: 4px\">\r\n                <a href=\"/\" style=\"color: #103fcc; font-weight: 600; text-decoration: none\">QS</a>\r\n              </li>\r\n              <li style=\"display: inline-block; margin-right: 4px; color: #ffffff\">|</li>\r\n              <li style=\"display: inline-block; margin-right: 4px\">\r\n                <a href=\"/\" style=\"color: #103fcc; font-weight: 600; text-decoration: none\">Privacy Policy</a>\r\n              </li>\r\n              <li style=\"display: inline-block; margin-right: 4px; color: #ffffff\">|</li>\r\n              <li style=\"display: inline-block\">\r\n                <a href=\"/\" style=\"color: #103fcc; font-weight: 600; text-decoration: none\">Support</a>\r\n              </li>\r\n            </ul>\r\n          </div>\r\n        </div>\r\n      </div>\r\n    </div>\r\n  </body>\r\n</html>\r\n");
            }    
            return result > 0;
        }

        public static bool UpdateUser(string id, string userName, string password, string hoTen, string email)
        {
            int result = DataProvider.ExecuteNonQuery("EXEC USP_UpdateNguoiDung @id , @userName , @password , @hoTen , @email",
                new object[] {id, userName, password, hoTen, email });
            return result > 0;
        }

        public static bool DeleteUser(string userName)
        {
            int result = DataProvider.ExecuteNonQuery("DELETE FROM NguoiDung WHERE UserName = N'" + userName + "'");
            return result > 0;
        }

        public static DataTable GetUserList()
        {
            return DataProvider.ExecuteQuery("SELECT * FROM NguoiDung");
        }
    }
}
