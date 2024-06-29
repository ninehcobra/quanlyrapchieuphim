using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI.DAO
{
    public class ChatDAO
    {
        private ChatDAO() { }

        public static bool InsertChat(string senderID, string receiverID, string message)
        {
            int result = DataProvider.ExecuteNonQuery("EXEC USP_InsertChat @senderID, @receiverID, @message",
                new object[] { senderID, receiverID, message });
            return result > 0;
        }

        public static DataTable GetChatByUser(string userID)
        {
            return DataProvider.ExecuteQuery("SELECT * FROM Chat WHERE SenderID = N'" + userID + "' OR ReceiverID = N'" + userID + "'");
        }

        public static DataTable GetChatBetweenUsers(string user1ID, string user2ID)
        {
            return DataProvider.ExecuteQuery("SELECT * FROM Chat WHERE (SenderID = N'" + user1ID + "' AND ReceiverID = N'" + user2ID + "') OR (SenderID = N'" + user2ID + "' AND ReceiverID = N'" + user1ID + "') ORDER BY Timestamp");
        }

        public static bool MarkChatAsRead(int chatID)
        {
            int result = DataProvider.ExecuteNonQuery("UPDATE Chat SET IsRead = 1 WHERE id = @chatID", new object[] { chatID });
            return result > 0;
        }
    }
}
