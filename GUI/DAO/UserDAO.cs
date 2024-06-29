using GUI.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public static bool InsertUser(string id, string userName, string password, string hoTen, string email)
        {
            int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertNguoiDung @id, @userName, @password, @hoTen, @email",
                new object[] { id, userName, password, hoTen, email});
            return result > 0;
        }

        public static bool UpdateUser(string id, string userName, string password, string hoTen, string email)
        {
            int result = DataProvider.ExecuteNonQuery("EXEC USP_UpdateNguoiDung @id, @userName, @password, @hoTen, @email",
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
