using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DTO
{
    public class Chat
    {
        public Chat(int id, string senderID, string receiverID, string message, DateTime timestamp, bool isRead)
        {
            this.ID = id;
            this.SenderID = senderID;
            this.ReceiverID = receiverID;
            this.Message = message;
            this.Timestamp = timestamp;
            this.IsRead = isRead;
        }

        public Chat(DataRow row)
        {
            this.ID = (int)row["id"];
            this.SenderID = row["SenderID"].ToString();
            this.ReceiverID = row["ReceiverID"].ToString();
            this.Message = row["Message"].ToString();
            this.Timestamp = (DateTime)row["Timestamp"];
            this.IsRead = (bool)row["IsRead"];
        }

        public int ID { get; set; }
        public string SenderID { get; set; }
        public string ReceiverID { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
    }
}
