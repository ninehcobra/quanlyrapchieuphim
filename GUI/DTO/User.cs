using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DTO
{
    public class User
    {
        public User(string id, string userName, string password, string hoTen, string email, string sdt = null, string diaChi = null)
        {
            this.ID = id;
            this.UserName = userName;
            this.Password = password;
            this.HoTen = hoTen;
            this.Email = email;
           
        }

        public User(DataRow row)
        {
            this.ID = row["id"].ToString();
            this.UserName = row["UserName"].ToString();
            this.Password = row["Pass"].ToString();
            this.HoTen = row["HoTen"].ToString();
            this.Email = row["Email"].ToString();
           
        }

        public string ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
       
    }
}
